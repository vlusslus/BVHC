using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinect2BVH
{
    public enum BVHChannel //Канал
    {
        Xposition, // Координата х элемента
        Yposition, // Координата y элемента
        Zposition, // Координата z элемента
        Xrotation, // Вращение элемента по оси x
        Yrotation, // Вращение элемента по оси y
        Zrotation //  Вращение элемента по оси z
    }

    public enum TransAxis //Ось
    {
        None, //
        X, // Координата
        Y, // Координата
        Z, // Координата
        nX, // Обратная 
        nY, // Обратная
        nZ // Обратная
    }

    /// <summary>
    /// Класс скелета
    /// </summary>
    public class BVHSkeleton
    {
        private List<BVHBone> bones; // Список элементов скелета
        private int maxDepth = 0; // Максимальная глубина костей в иерархии
        private int nrBones; // НЕ ИСПОЛЬЗУЕТСЯ
        private int channels; // Суммарное количество степеней свободы скелета

        /// <summary>
        /// Конструктор
        /// </summary>
        public BVHSkeleton()
        {
            bones = new List<BVHBone>();
        }

        /// <summary>
        /// Получение элементов скелета
        /// </summary>
        public List<BVHBone> Bones
        {
            get { return bones; }
        }

        /// <summary>
        /// Получение каналов
        /// </summary>
        public int Channels
        {
            get { return channels; }
        }

        /// <summary>
        /// Добавление нового элемента скелета
        /// </summary>
        /// <param name="Bone">Элемент скелета</param>
        public void AddBone(BVHBone Bone)
        {
            if (!Bones.Contains(Bone))
            {
                bones.Add(Bone);
            }
        }

        /// <summary>
        /// Метод завершает построение экземпляра скелета
        /// </summary>
        public void FinalizeBVHSkeleton()
        {
            for (int k = 0; k < Bones.Count(); k++)
            {
                
                if (Bones[k].Depth > this.maxDepth) this.maxDepth = Bones[k].Depth;
   
                int motionCount = 0;
                for (int n = 0; n < k; n++)
                {
                    motionCount += Bones[n].ChannelCount; 
                }
                Bones[k].MotionSpace = motionCount;
                this.channels += Bones[k].ChannelCount;

                //Получить все дочерние кости у текущей кости
                List<BVHBone> childBoneList = Bones.FindAll(i => i.Parent == Bones[k]);
                if (childBoneList.Count == 0)
                {
                    Bones[k].End = true; //Если дочерних нет, то текущая кость признается конечной
                }
                else
                {
                    Bones[k].Children = childBoneList; //Если есть, то создается список дочерних костей
                }
            }
        }

        public void copyParameters(BVHSkeleton input)
        {
            channels = input.Channels;
            maxDepth = input.maxDepth;
            nrBones = input.nrBones;
        }

        /*public int getMaxDepth()
        {
            return maxDepth;
        }*/
    }

    /// <summary>
    /// Класс элемента скелета
    /// </summary>
    public class BVHBone
    {
        private BVHBone parent; //Родительский элемент
        private List<BVHBone> children; //Список дочерних элементов
        private string name; // Имя элемента
        private int depth; // Глубина элемента в иерархии

        static int index = 1;
        
        private BVHChannel[] channels;

        public double[] rotOffset = new double[] { 0, 0, 0 };
        public double[] translOffset = new double[] {0, 0, 0};

        private bool end; //Признак конечной кости
        private bool root; //Признак корневой кости
        int motionSpace; // Первый элемент в столбце движений (в файле)
        TransAxis axis;

        bool isKinectJoint; //Флаг является ли элемент частью скелетного потока

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="Parent">Родительский элемент того же типа</param>
        /// <param name="Name">Имя элемента</param>
        /// <param name="nrChannels">Номер каналов (Либо транляция, либо ротация)</param>
        /// <param name="Axis">Предположительно направление элемента в осях Kinect</param>
        /// <param name="IsKinectJoint">Флаг, является ли элементом потока Kinect</param>
        public BVHBone(BVHBone Parent, string Name, int nrChannels, TransAxis Axis, bool IsKinectJoint)
        {
            this.parent = Parent;   //Устанавливаем ссылку на родительскую кость
            BVHBone.index += BVHBone.index;     //Увеличиваем счетчик костей в скелете
            this.name = Name;   //Имя кости
            this.isKinectJoint = IsKinectJoint;

            this.axis = Axis;

            if (parent != null) // Если есть родитеьская кость
            {
                this.depth = this.parent.Depth + 1; //Увеличиваем глубины текущей кости
            }
            else
            {
                depth = 0; 
                root = true; //Эта кость является корневой
            }

            this.channels = new BVHChannel[nrChannels]; //Выделяется количество степеней свободы кости
            int ind = 5;
            for (int k = nrChannels - 1; k >= 0; k--)
            {
                this.channels[k] = (BVHChannel)ind;
                ind--;
            }
        }


        public List<BVHBone> Children
        {
            get { return children; }
            set { children = value; }
        }

        public bool IsKinectJoint
        {
            get { return isKinectJoint; }
            set { isKinectJoint = value; }
        }

        public bool Root
        {
            get { return root; }
            set { root = value; }
        }

        public bool End
        {
            get { return end; }
            set { end = value; }
        }

        public TransAxis Axis
        {
            get { return axis; }
            set { axis = value; }
        }

        public int MotionSpace
        {
            get { return motionSpace; }
            set { motionSpace = value; }
        }

        public int Depth
        {
            get { return depth; }
        }

        public int ChannelCount
        {
            get { return channels.Length; }
        }

        public string Name
        {
            get { return name; }
        }

        public BVHBone Parent
        {
            get { return parent; }
        }

        public BVHChannel[] Channels
        {
            get { return channels; }
        }

        public void setTransOffset(double xOff,double yOff,double zOff)
        {
            translOffset = new double[]{xOff, yOff, zOff};
        }

        public void setRotOffset(double xOff, double yOff, double zOff)
        {
            rotOffset = new double[] { xOff, yOff, zOff };
        }
    }
}
