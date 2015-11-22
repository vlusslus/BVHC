namespace Kinect2BVH
{
    partial class MainWindow
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.textBoxSensorStatus = new System.Windows.Forms.TextBox();
            this.dropDownFps = new System.Windows.Forms.ComboBox();
            this.txtLabel_fps = new System.Windows.Forms.Label();
            this.pictureBoxSkeleton = new System.Windows.Forms.PictureBox();
            this.buttonRecord = new System.Windows.Forms.Button();
            this.buttonRecordStop = new System.Windows.Forms.Button();
            this.checkBoxСolor = new System.Windows.Forms.CheckBox();
            this.groupBoxSmooth = new System.Windows.Forms.GroupBox();
            this.radioButtonSmoothIntense = new System.Windows.Forms.RadioButton();
            this.radioButtonSmoothModerate = new System.Windows.Forms.RadioButton();
            this.radioButtonSmoothDefault = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxInitial = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textField = new Kinect2BVH.TextField();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSkeleton)).BeginInit();
            this.groupBoxSmooth.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(667, 242);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(111, 23);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "Запуск потока";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(667, 271);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(111, 23);
            this.buttonStop.TabIndex = 3;
            this.buttonStop.Text = "Остановка потока";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // textBoxSensorStatus
            // 
            this.textBoxSensorStatus.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxSensorStatus.Location = new System.Drawing.Point(661, 472);
            this.textBoxSensorStatus.Name = "textBoxSensorStatus";
            this.textBoxSensorStatus.Size = new System.Drawing.Size(136, 20);
            this.textBoxSensorStatus.TabIndex = 4;
            this.textBoxSensorStatus.Text = "Состояние";
            this.textBoxSensorStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dropDownFps
            // 
            this.dropDownFps.Cursor = System.Windows.Forms.Cursors.Default;
            this.dropDownFps.FormattingEnabled = true;
            this.dropDownFps.Items.AddRange(new object[] {
            "30",
            "15",
            "10",
            "5",
            "1"});
            this.dropDownFps.Location = new System.Drawing.Point(747, 12);
            this.dropDownFps.Name = "dropDownFps";
            this.dropDownFps.Size = new System.Drawing.Size(49, 21);
            this.dropDownFps.TabIndex = 7;
            this.dropDownFps.Text = "30";
            // 
            // txtLabel_fps
            // 
            this.txtLabel_fps.AutoSize = true;
            this.txtLabel_fps.Location = new System.Drawing.Point(658, 15);
            this.txtLabel_fps.Name = "txtLabel_fps";
            this.txtLabel_fps.Size = new System.Drawing.Size(30, 13);
            this.txtLabel_fps.TabIndex = 9;
            this.txtLabel_fps.Text = "FPS:";
            // 
            // pictureBoxSkeleton
            // 
            this.pictureBoxSkeleton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBoxSkeleton.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxSkeleton.Name = "pictureBoxSkeleton";
            this.pictureBoxSkeleton.Size = new System.Drawing.Size(640, 480);
            this.pictureBoxSkeleton.TabIndex = 10;
            this.pictureBoxSkeleton.TabStop = false;
            // 
            // buttonRecord
            // 
            this.buttonRecord.Location = new System.Drawing.Point(661, 329);
            this.buttonRecord.Name = "buttonRecord";
            this.buttonRecord.Size = new System.Drawing.Size(130, 23);
            this.buttonRecord.TabIndex = 12;
            this.buttonRecord.Text = "Начать запись";
            this.buttonRecord.UseVisualStyleBackColor = true;
            this.buttonRecord.Click += new System.EventHandler(this.buttonRecord_Click);
            // 
            // buttonRecordStop
            // 
            this.buttonRecordStop.Location = new System.Drawing.Point(661, 358);
            this.buttonRecordStop.Name = "buttonRecordStop";
            this.buttonRecordStop.Size = new System.Drawing.Size(130, 23);
            this.buttonRecordStop.TabIndex = 13;
            this.buttonRecordStop.Text = "Остановить запись";
            this.buttonRecordStop.UseVisualStyleBackColor = true;
            this.buttonRecordStop.Click += new System.EventHandler(this.buttonRecordStop_Click);
            // 
            // checkBoxСolor
            // 
            this.checkBoxСolor.AutoSize = true;
            this.checkBoxСolor.Location = new System.Drawing.Point(661, 84);
            this.checkBoxСolor.Name = "checkBoxСolor";
            this.checkBoxСolor.Size = new System.Drawing.Size(89, 17);
            this.checkBoxСolor.TabIndex = 27;
            this.checkBoxСolor.Text = "Видео поток";
            this.checkBoxСolor.UseVisualStyleBackColor = true;
            // 
            // groupBoxSmooth
            // 
            this.groupBoxSmooth.Controls.Add(this.radioButtonSmoothIntense);
            this.groupBoxSmooth.Controls.Add(this.radioButtonSmoothModerate);
            this.groupBoxSmooth.Controls.Add(this.radioButtonSmoothDefault);
            this.groupBoxSmooth.Location = new System.Drawing.Point(661, 126);
            this.groupBoxSmooth.Name = "groupBoxSmooth";
            this.groupBoxSmooth.Size = new System.Drawing.Size(111, 87);
            this.groupBoxSmooth.TabIndex = 29;
            this.groupBoxSmooth.TabStop = false;
            this.groupBoxSmooth.Text = "Сглаживание";
            // 
            // radioButtonSmoothIntense
            // 
            this.radioButtonSmoothIntense.AutoSize = true;
            this.radioButtonSmoothIntense.Location = new System.Drawing.Point(6, 65);
            this.radioButtonSmoothIntense.Name = "radioButtonSmoothIntense";
            this.radioButtonSmoothIntense.Size = new System.Drawing.Size(91, 17);
            this.radioButtonSmoothIntense.TabIndex = 2;
            this.radioButtonSmoothIntense.Text = "Агрессивное";
            this.radioButtonSmoothIntense.UseVisualStyleBackColor = true;
            // 
            // radioButtonSmoothModerate
            // 
            this.radioButtonSmoothModerate.AutoSize = true;
            this.radioButtonSmoothModerate.Location = new System.Drawing.Point(6, 42);
            this.radioButtonSmoothModerate.Name = "radioButtonSmoothModerate";
            this.radioButtonSmoothModerate.Size = new System.Drawing.Size(83, 17);
            this.radioButtonSmoothModerate.TabIndex = 1;
            this.radioButtonSmoothModerate.Text = "Умеренное";
            this.radioButtonSmoothModerate.UseVisualStyleBackColor = true;
            // 
            // radioButtonSmoothDefault
            // 
            this.radioButtonSmoothDefault.AutoSize = true;
            this.radioButtonSmoothDefault.Checked = true;
            this.radioButtonSmoothDefault.Location = new System.Drawing.Point(6, 19);
            this.radioButtonSmoothDefault.Name = "radioButtonSmoothDefault";
            this.radioButtonSmoothDefault.Size = new System.Drawing.Size(98, 17);
            this.radioButtonSmoothDefault.TabIndex = 0;
            this.radioButtonSmoothDefault.TabStop = true;
            this.radioButtonSmoothDefault.Text = "По умолчанию";
            this.radioButtonSmoothDefault.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(658, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Инициализация:";
            // 
            // textBoxInitial
            // 
            this.textBoxInitial.Location = new System.Drawing.Point(747, 39);
            this.textBoxInitial.Name = "textBoxInitial";
            this.textBoxInitial.Size = new System.Drawing.Size(50, 20);
            this.textBoxInitial.TabIndex = 31;
            this.textBoxInitial.Text = "100";
            this.textBoxInitial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(661, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 32;
            // 
            // textField
            // 
            this.textField.Location = new System.Drawing.Point(12, 495);
            this.textField.Margin = new System.Windows.Forms.Padding(0, 0, 3, 3);
            this.textField.Name = "textField";
            this.textField.setTextBoxAngles = "";
            this.textField.setTextBoxCapturedFrames = "";
            this.textField.setTextBoxElapsedTime = "";
            this.textField.setTextBoxFrameRate = "";
            this.textField.setTextBoxLength = "";
            this.textField.setTextPosition = "";
            this.textField.Size = new System.Drawing.Size(689, 247);
            this.textField.TabIndex = 28;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 711);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxInitial);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBoxSmooth);
            this.Controls.Add(this.pictureBoxSkeleton);
            this.Controls.Add(this.textField);
            this.Controls.Add(this.checkBoxСolor);
            this.Controls.Add(this.buttonRecordStop);
            this.Controls.Add(this.buttonRecord);
            this.Controls.Add(this.txtLabel_fps);
            this.Controls.Add(this.dropDownFps);
            this.Controls.Add(this.textBoxSensorStatus);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonStart);
            this.Name = "MainWindow";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "BVH";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainWindow_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSkeleton)).EndInit();
            this.groupBoxSmooth.ResumeLayout(false);
            this.groupBoxSmooth.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.TextBox textBoxSensorStatus;
        private System.Windows.Forms.ComboBox dropDownFps;
        private System.Windows.Forms.Label txtLabel_fps;
        private System.Windows.Forms.PictureBox pictureBoxSkeleton;
        private System.Windows.Forms.Button buttonRecord;
        private System.Windows.Forms.Button buttonRecordStop;
        private System.Windows.Forms.CheckBox checkBoxСolor;
        private TextField textField;
        private System.Windows.Forms.GroupBox groupBoxSmooth;
        private System.Windows.Forms.RadioButton radioButtonSmoothIntense;
        private System.Windows.Forms.RadioButton radioButtonSmoothModerate;
        private System.Windows.Forms.RadioButton radioButtonSmoothDefault;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxInitial;
        private System.Windows.Forms.Label label2;
    }
}

