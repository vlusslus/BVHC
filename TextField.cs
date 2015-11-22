using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kinect2BVH
{
    public partial class TextField : UserControl, IMyInterface
    {
        public TextField()
        {
            InitializeComponent();
        }

        public string setTextBoxElapsedTime { get { return textBox_elapsedTime.Text; } set { textBox_elapsedTime.Text = value; } }
        public string setTextBoxCapturedFrames { get { return textBox_capturedFrames.Text; } set { textBox_capturedFrames.Text = value; } }
        public string setTextBoxFrameRate { get { return textBox_frameRate.Text; } set { textBox_frameRate.Text = value; } }
        public string setTextBoxAngles { get { return textBox_angles.Text; } set { textBox_angles.Text = value; } }
        public string setTextBoxLength { get { return textBox_length.Text; } set { textBox_length.Text = value; } }
        public string setTextPosition { get { return textBox_position.Text; } set { textBox_position.Text = value; } }
        public string getDropDownJoint { get { return dropDown_joint.Text; } }

 }

 public interface IMyInterface
 {
     string setTextBoxElapsedTime { get; set; }
     string setTextBoxFrameRate { get; set; }
     string setTextBoxCapturedFrames { get; set; }
     string setTextBoxAngles { get; set; }
     string setTextBoxLength { get; set; }
     string setTextPosition { get; set; }
     string getDropDownJoint { get; }
 }


}
