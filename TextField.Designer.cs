namespace Kinect2BVH
{
    partial class TextField
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

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.dropDown_joint = new System.Windows.Forms.ComboBox();
            this.textBox_angles = new System.Windows.Forms.TextBox();
            this.textBox_elapsedTime = new System.Windows.Forms.TextBox();
            this.textBox_capturedFrames = new System.Windows.Forms.TextBox();
            this.textBox_frameRate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_position = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_length = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dropDown_joint
            // 
            this.dropDown_joint.FormattingEnabled = true;
            this.dropDown_joint.Items.AddRange(new object[] {
            "HipCenter",
            "HipCenter2",
            "Spine",
            "ShoulderCenter",
            "CollarRight",
            "ShoulderRight",
            "ElbowRight",
            "WristRight",
            "HandRight",
            "CollarLeft",
            "ShoulderLeft",
            "ElbowLeft",
            "WristLeft",
            "HandLeft",
            "Neck",
            "Head",
            "HipRight",
            "KneeRight",
            "AnkleRight",
            "HipLeft",
            "KneeLeft",
            "AnkleLeft"});
            this.dropDown_joint.Location = new System.Drawing.Point(50, 23);
            this.dropDown_joint.Name = "dropDown_joint";
            this.dropDown_joint.Size = new System.Drawing.Size(100, 21);
            this.dropDown_joint.TabIndex = 29;
            this.dropDown_joint.Text = "HipCenter";
            // 
            // textBox_angles
            // 
            this.textBox_angles.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_angles.Location = new System.Drawing.Point(340, 86);
            this.textBox_angles.Name = "textBox_angles";
            this.textBox_angles.Size = new System.Drawing.Size(300, 44);
            this.textBox_angles.TabIndex = 30;
            this.textBox_angles.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_elapsedTime
            // 
            this.textBox_elapsedTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_elapsedTime.Location = new System.Drawing.Point(63, 21);
            this.textBox_elapsedTime.Name = "textBox_elapsedTime";
            this.textBox_elapsedTime.Size = new System.Drawing.Size(111, 44);
            this.textBox_elapsedTime.TabIndex = 31;
            this.textBox_elapsedTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_capturedFrames
            // 
            this.textBox_capturedFrames.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_capturedFrames.Location = new System.Drawing.Point(241, 21);
            this.textBox_capturedFrames.Name = "textBox_capturedFrames";
            this.textBox_capturedFrames.Size = new System.Drawing.Size(111, 44);
            this.textBox_capturedFrames.TabIndex = 32;
            this.textBox_capturedFrames.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_frameRate
            // 
            this.textBox_frameRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_frameRate.Location = new System.Drawing.Point(410, 21);
            this.textBox_frameRate.Name = "textBox_frameRate";
            this.textBox_frameRate.Size = new System.Drawing.Size(111, 44);
            this.textBox_frameRate.TabIndex = 33;
            this.textBox_frameRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Затраченное время:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(238, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "Записано кадров:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(410, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "Средний FPS:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(337, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(202, 13);
            this.label4.TabIndex = 37;
            this.label4.Text = "X Y Z Вращение, градусы (Hierarchical)";
            // 
            // textBox_position
            // 
            this.textBox_position.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_position.Location = new System.Drawing.Point(17, 87);
            this.textBox_position.Name = "textBox_position";
            this.textBox_position.Size = new System.Drawing.Size(300, 44);
            this.textBox_position.TabIndex = 38;
            this.textBox_position.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(163, 13);
            this.label5.TabIndex = 39;
            this.label5.Text = "X Y Z Координаты, см (Absolut)";
            // 
            // textBox_length
            // 
            this.textBox_length.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_length.Location = new System.Drawing.Point(302, 8);
            this.textBox_length.Name = "textBox_length";
            this.textBox_length.Size = new System.Drawing.Size(150, 44);
            this.textBox_length.TabIndex = 40;
            this.textBox_length.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(181, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 13);
            this.label6.TabIndex = 41;
            this.label6.Text = "Длина элемента, см:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.dropDown_joint);
            this.panel1.Controls.Add(this.textBox_length);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.textBox_angles);
            this.panel1.Controls.Add(this.textBox_position);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(13, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(659, 139);
            this.panel1.TabIndex = 42;
            // 
            // TextField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_frameRate);
            this.Controls.Add(this.textBox_capturedFrames);
            this.Controls.Add(this.textBox_elapsedTime);
            this.Controls.Add(this.panel1);
            this.Name = "TextField";
            this.Size = new System.Drawing.Size(684, 214);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox dropDown_joint;
        private System.Windows.Forms.TextBox textBox_elapsedTime;
        private System.Windows.Forms.TextBox textBox_angles;
        private System.Windows.Forms.TextBox textBox_capturedFrames;
        private System.Windows.Forms.TextBox textBox_frameRate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_position;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_length;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;



    }
}
