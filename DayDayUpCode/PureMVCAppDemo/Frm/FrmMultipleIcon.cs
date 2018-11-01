using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PureMVCAppDemo
{
    public partial class FrmMultipleIcon : Form
    {
        public FrmMultipleIcon()
        {
            InitializeComponent();
            InitEle();
        }
        private void InitEle()
        {
            btnAdd.Click += new EventHandler(Click_Event);
            btnAdd.MouseLeave += new EventHandler(MouseLeave_Event);
            PaintButton(false);
           
        }
        private void Click_Event(object sender,EventArgs e)
        {
            PaintButton(true);
        }
        private void MouseLeave_Event(object sender, EventArgs e)
        {
            PaintButton(false);
        }
        private void PaintButton(bool isClick)
        {
            string  icon = !isClick? @"Resource\addprocedure_normal.png" : @"Resource\addprocedure_active.png";
            string bg = !isClick? @"Resource\commonBtn_normal.png" : @"Resource\commonBtn_active.png";
            btnAdd.BackgroundImage = new Bitmap(bg);
            btnAdd.BackgroundImageLayout = ImageLayout.Zoom;
            btnAdd.Image = new Bitmap(icon);
           
        }
    }
}
