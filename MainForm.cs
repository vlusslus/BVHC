using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Ссылки на сборки, добавленные вручную
using Microsoft.Kinect;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Media.Media3D;




namespace Kinect2BVH
{

    public partial class MainWindow : Form
    {

        private KinectSensor sensor; // Объект сенсора
        private WriteBVH BVHFile; // Объект для записи файла        
        Bitmap tempColorFrame; // Временное хранение RGB кадра

        bool windowClosing = false;
        private short fpsEnd = 1;
        int initFrames = 1;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (sensor == null)
            {
                // Просмостр списка всех подключенных устройств и подключение первого доступного
                foreach (var potentialSensor in KinectSensor.KinectSensors)
                {
                    this.textBoxSensorStatus.Text = "Поиск устройства...";
                    if (potentialSensor.Status == KinectStatus.Connected)
                    {
                        this.sensor = potentialSensor;
                        break;
                    }
                }

                if (null != this.sensor)
                {
                    TransformSmoothParameters smoothingParam = new TransformSmoothParameters();

                    if (radioButtonSmoothDefault.Checked)
                    {
                        // Коррекция небольших колебаний (Подходит для распознавания жестов)
                        smoothingParam = new TransformSmoothParameters();
                        {
                            smoothingParam.Smoothing = 0.5f;
                            smoothingParam.Correction = 0.5f;
                            smoothingParam.Prediction = 0.5f;
                            smoothingParam.JitterRadius = 0.05f;
                            smoothingParam.MaxDeviationRadius = 0.04f;
                        };
                    }
                    else if (radioButtonSmoothModerate.Checked)
                    {
                        // Средняя коррекция (Задержка возрастает)
                        smoothingParam = new TransformSmoothParameters();
                        {
                            smoothingParam.Smoothing = 0.5f;
                            smoothingParam.Correction = 0.1f;
                            smoothingParam.Prediction = 0.5f;
                            smoothingParam.JitterRadius = 0.1f;
                            smoothingParam.MaxDeviationRadius = 0.1f;
                        };
                    }
                    else if (radioButtonSmoothIntense.Checked)
                    {
                        // Анрессивная коррекция (Для случаев, когда величина задержки не важна)
                        smoothingParam = new TransformSmoothParameters();
                        {
                            smoothingParam.Smoothing = 0.7f;
                            smoothingParam.Correction = 0.3f;
                            smoothingParam.Prediction = 1.0f;
                            smoothingParam.JitterRadius = 1.0f;
                            smoothingParam.MaxDeviationRadius = 1.0f;
                        };
                    }
                    groupBoxSmooth.Enabled = false;

                    // Активация потока для получения цветного изображения камеры
                    this.sensor.ColorStream.Enable(ColorImageFormat.RgbResolution640x480Fps30);
                    // Активация скелетного потока с параметрами сглаживания
                    this.sensor.SkeletonStream.Enable(smoothingParam);

                    // Событие которое будет вызвано при получении нового кадра потока
                    this.sensor.AllFramesReady += sensor_AllFramesReady;

                    // Запуск устройства
                    try
                    {
                        this.sensor.Start();
                        this.textBoxSensorStatus.Text = "Поток запущен.";
                    }
                    catch (Exception)
                    {
                        this.sensor = null;
                        this.textBoxSensorStatus.Text = "Поток не удалось запустить!";
                    }
                }
                else
                {
                    this.textBoxSensorStatus.Text = "Доступные устройства не найдены!";
                }
            }

        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (BVHFile != null)
            {
                this.textBoxSensorStatus.Text = "Остановлена только запись в файл!";
            }
            else
            {
                if (sensor != null)
                {
                    StopKinect(sensor);
                    this.textBoxSensorStatus.Text = "Поток остановлен.";
                    this.pictureBoxSkeleton.Image = null;
                    groupBoxSmooth.Enabled = true;
                }
            }
        }

        void sensor_AllFramesReady(object sender, AllFramesReadyEventArgs e)
        {
            if (windowClosing)
            {
                return;
            }

            int value;
            if (int.TryParse(this.textBoxInitial.Text, out value))
            {
                initFrames = value;
            }

            if (fpsEnd == 1)
            {
                // FPS - Количество кадров в секунду (При <30 лишние кадры отбрасываются)
                Int16 fps = Convert.ToInt16(this.dropDownFps.Text);
                switch (fps)
                {
                    case 30:
                        fpsEnd = 1;
                        break;
                    case 15:
                        fpsEnd = 2;
                        break;
                    case 10:
                        fpsEnd = 3;
                        break;
                    case 5:
                        fpsEnd = 6;
                        break;
                    case 1:
                        fpsEnd = 30;
                        break;
                }

                // Сохранение текущего полученного кадра изображения во временное хранилище
                using (ColorImageFrame colorFrame = e.OpenColorImageFrame())
                {
                    if (colorFrame != null)
                    {
                        tempColorFrame = ColorImageFrameToBitmap(colorFrame);
                    }
                }

                // Получение кадра потока глубины
                using (SkeletonFrame skelFrame = e.OpenSkeletonFrame())
                {
                    if (skelFrame != null)
                    {
                        Image tempSkeletonFrame = new Bitmap(this.pictureBoxSkeleton.Width, this.pictureBoxSkeleton.Height);
                        // Отображение кадра скелетного потока и кадра видеопотока
                        this.pictureBoxSkeleton.BackColor = Color.Black;
                        if (checkBoxСolor.Checked)
                        {
                            tempSkeletonFrame = tempColorFrame;
                        }

                        Skeleton[] skeletons = new Skeleton[skelFrame.SkeletonArrayLength];
                        skelFrame.CopySkeletonDataTo(skeletons);
                        if (skeletons.Length != 0)
                        {
                            foreach (Skeleton skel in skeletons)
                            {
                                if (skel.TrackingState == SkeletonTrackingState.Tracked)
                                {
                                    // Нарисовать элемент скелета, если он находится в поле зрения камеры
                                    DrawSkeletons(tempSkeletonFrame, skel);
                                    if (BVHFile != null)
                                    {
                                        if (BVHFile.isRecording == true && BVHFile.isInitializing == true)
                                        {
                                            BVHFile.Entry(skel);
                                            if (BVHFile.intializingCounter > initFrames)
                                            {
                                                BVHFile.startWritingEntry();
                                            }
                                        }
                                        if (BVHFile.isRecording == true && BVHFile.isInitializing == false)
                                        {
                                            BVHFile.Motion(skel);
                                            this.textBoxSensorStatus.Text = "Recording.";
                                            this.textBoxSensorStatus.BackColor = Color.Green;
                                        }
                                    }
                                }
                            }
                        }
                        this.pictureBoxSkeleton.Image = tempSkeletonFrame;
                    }
                }
            }
            else
            {
                fpsEnd -= 1;
            }
        }

        /// <summary>
        /// Преобразование кадра видеопотока в объект BitMap для отображения на форме
        /// </summary>
        /// <param name="colorFrame">Кадра видеопотока</param>
        /// <returns>Объект битовой карты</returns>
        private Bitmap ColorImageFrameToBitmap(ColorImageFrame colorFrame)
        {
            byte[] pixelBuffer = new byte[colorFrame.PixelDataLength];
            colorFrame.CopyPixelDataTo(pixelBuffer);
            Bitmap bitmapFrame = ArrayToBitmap(pixelBuffer, colorFrame.Width, colorFrame.Height, PixelFormat.Format32bppRgb);
            return bitmapFrame;
        }

        /// <summary>
        /// Отрисовка на форме каждого элемента скелета, полученного на текущем кадре скелетного потока
        /// </summary>
        /// <param name="backgroundImage"></param>
        /// <param name="skel"></param>
        private void DrawSkeletons(Image backgroundImage, Skeleton skel)
        {
            Graphics graphicBox = Graphics.FromImage(backgroundImage);
            float width = (float)(backgroundImage.Width / 640F);
            float height = (float)(backgroundImage.Height / 480F);
            graphicBox.ScaleTransform(width, height);
            this.DrawBonesAndJoints(skel, graphicBox);
        }

        private void buttonRecord_Click(object sender, EventArgs e)
        {
            if (BVHFile == null && sensor != null)
            {
                this.textBoxSensorStatus.Text = "Инициализация...";
                this.textBoxSensorStatus.BackColor = Color.Yellow;
                DateTime thisDay = DateTime.UtcNow;
                string txtFileName = thisDay.ToString("dd.MM.yyyy_HH.mm");
                BVHFile = new WriteBVH(txtFileName);
                BVHFile.setTextField(textField);
            }
        }

        private void buttonRecordStop_Click(object sender, EventArgs e)
        {
            if (BVHFile != null)
            {
                BVHFile.closeBVHFile();
                this.textBoxSensorStatus.Text = "Запись сохраняется...";
                this.textBoxSensorStatus.BackColor = Color.White;
                BVHFile = null;
            }
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            windowClosing = true;
            StopKinect(sensor);
        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            StopKinect(sensor);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="skeleton"></param>
        /// <param name="graphicBox"></param>
        private void DrawBonesAndJoints(Skeleton skeleton, Graphics graphicBox)
        {
            Brush centerPointBrush = Brushes.Blue; // Кисть для отрисовки центральной точки элемента скелета
            Pen trackedJointPen = new Pen(Color.GreenYellow); //Кисть для отрисовки элементов скелета, которые отслеживаются     
            Pen inferredJointPen = new Pen(Color.Yellow); //Кисть для отрисовки неотслеживаемых элементов

            foreach (Joint joint in skeleton.Joints)
            {
                Pen drawPen = null;
                if (joint.TrackingState == JointTrackingState.Tracked)
                {
                    drawPen = trackedJointPen;
                }
                else if (joint.TrackingState == JointTrackingState.Inferred)
                {
                    drawPen = inferredJointPen;
                }
                if (drawPen != null)
                {
                    graphicBox.DrawEllipse(drawPen, new Rectangle(this.SkeletonPointToScreen(joint.Position), new Size(10, 10)));
                }
            }

            // Отрисовка торса
            this.DrawBone(skeleton, graphicBox, JointType.Head, JointType.ShoulderCenter);
            this.DrawBone(skeleton, graphicBox, JointType.ShoulderCenter, JointType.ShoulderLeft);
            this.DrawBone(skeleton, graphicBox, JointType.ShoulderCenter, JointType.ShoulderRight);
            this.DrawBone(skeleton, graphicBox, JointType.ShoulderCenter, JointType.Spine);
            this.DrawBone(skeleton, graphicBox, JointType.Spine, JointType.HipCenter);
            this.DrawBone(skeleton, graphicBox, JointType.HipCenter, JointType.HipLeft);
            this.DrawBone(skeleton, graphicBox, JointType.HipCenter, JointType.HipRight);

            // Отрисовка левой руки
            this.DrawBone(skeleton, graphicBox, JointType.ShoulderLeft, JointType.ElbowLeft);
            this.DrawBone(skeleton, graphicBox, JointType.ElbowLeft, JointType.WristLeft);
            this.DrawBone(skeleton, graphicBox, JointType.WristLeft, JointType.HandLeft);

            // Правая кура
            this.DrawBone(skeleton, graphicBox, JointType.ShoulderRight, JointType.ElbowRight);
            this.DrawBone(skeleton, graphicBox, JointType.ElbowRight, JointType.WristRight);
            this.DrawBone(skeleton, graphicBox, JointType.WristRight, JointType.HandRight);

            // Левая нога
            this.DrawBone(skeleton, graphicBox, JointType.HipLeft, JointType.KneeLeft);
            this.DrawBone(skeleton, graphicBox, JointType.KneeLeft, JointType.AnkleLeft);
            this.DrawBone(skeleton, graphicBox, JointType.AnkleLeft, JointType.FootLeft);

            // Правая нога
            this.DrawBone(skeleton, graphicBox, JointType.HipRight, JointType.KneeRight);
            this.DrawBone(skeleton, graphicBox, JointType.KneeRight, JointType.AnkleRight);
            this.DrawBone(skeleton, graphicBox, JointType.AnkleRight, JointType.FootRight);

            // Голова
            if (skeleton.Joints[JointType.Head].TrackingState == JointTrackingState.Tracked)
            {
                graphicBox.DrawEllipse
                    (
                        new Pen(Color.GreenYellow), 
                        this.SkeletonPointToScreen(skeleton.Joints[JointType.Head].Position).X - 50,
                        this.SkeletonPointToScreen(skeleton.Joints[JointType.Head].Position).Y - 50, 100, 100
                    );
            }
            return;
        }

        /// <summary>
        /// 
        /// 
        /// </summary>
        /// <param name="skeleton"></param>
        /// <param name="graphicBox"></param>
        /// <param name="jointTypeFrom"></param>
        /// <param name="jointTypeTo"></param>
        private void DrawBone(Skeleton skeleton, Graphics graphicBox, JointType jointTypeFrom, JointType jointTypeTo)
        {
            Pen trackedBonePen = new Pen(Brushes.Green, 6);    
            Pen inferredBonePen = new Pen(Brushes.Gray, 1);

            Joint jointFrom = skeleton.Joints[jointTypeFrom];
            Joint jointTo = skeleton.Joints[jointTypeTo];

            // Если не отслеживается ни одна из концевых точек элемента, то выходим из функции
            if (jointFrom.TrackingState == JointTrackingState.NotTracked || jointTo.TrackingState == JointTrackingState.NotTracked) return;
            // Если две концевые точки имеют состояние infareed также выход из функции
            if (jointFrom.TrackingState == JointTrackingState.Inferred && jointTo.TrackingState == JointTrackingState.Inferred) return;

            Pen drawPen = inferredBonePen;
            if (jointFrom.TrackingState == JointTrackingState.Tracked && jointTo.TrackingState == JointTrackingState.Tracked)
            {
                drawPen = trackedBonePen;
            }

            Point startPixel = SkeletonPointToScreen(jointFrom.Position);
            Point endPixel = SkeletonPointToScreen(jointTo.Position);
            //double distanceBetweenJoints = Math.Round(calcDistanceBetweenPoints(jointFrom.Position, jointTo.Position) * 100) / 100;
            graphicBox.DrawLine(drawPen, startPixel, endPixel);
            int textPosPixelX = Convert.ToInt32(Math.Abs(Math.Round(0.5 * (startPixel.X + endPixel.X))));
            int textPosPixelY = Convert.ToInt32(Math.Abs(Math.Round(0.5 * (startPixel.Y + endPixel.Y))));
            PointF textPos = new PointF(textPosPixelX, textPosPixelY);
            return;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="skelpoint"></param>
        /// <returns></returns>
        private Point SkeletonPointToScreen(SkeletonPoint skelpoint)
        {
            DepthImagePoint depthPoint = this.sensor.CoordinateMapper.MapSkeletonPointToDepthPoint(skelpoint, DepthImageFormat.Resolution640x480Fps30);
            return new Point(depthPoint.X, depthPoint.Y);
        }

        /*private double calcDistanceBetweenPoints(SkeletonPoint Joint1, SkeletonPoint Joint2)
        {
            double distanceBtwJoints = Math.Sqrt(Math.Pow(Joint1.X - Joint2.X, 2) + Math.Pow(Joint1.Y - Joint2.Y, 2) + Math.Pow(Joint1.Z - Joint2.Z, 2));
            return distanceBtwJoints;
        }*/

        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="pixelFormat"></param>
        /// <returns></returns>
        private Bitmap ArrayToBitmap(byte[] array, int width, int height, PixelFormat pixelFormat)
        {
            Bitmap bitmapFrame = new Bitmap(width, height, pixelFormat);
            BitmapData bitmapData = bitmapFrame.LockBits
                (
                new Rectangle(0, 0, width, height), 
                ImageLockMode.WriteOnly, 
                bitmapFrame.PixelFormat
                );
            IntPtr intPointer = bitmapData.Scan0;
            Marshal.Copy(array, 0, intPointer, array.Length);
            bitmapFrame.UnlockBits(bitmapData);
            return bitmapFrame;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sensor"></param>
        private void StopKinect(KinectSensor sensor)
        {
            if (sensor != null)
            {
                if (sensor.IsRunning)
                {
                    sensor.Stop();
                }
            }
        }

    }
}
