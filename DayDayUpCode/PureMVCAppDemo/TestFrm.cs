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
    public partial class TestFrm : Form
    {
        public TestFrm()
        {
            InitializeComponent();
            Test();
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
             
        }

        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
           
        }
        void Test()
        {
            string icon = @"E:\Code\ExampleCore\deleteSign.png";
            string core = @"E:\Code\ExampleCore\微信图片_20180818150330.jpg";
            corePic.BackgroundImage = new Bitmap(core);
            iconPic.BackgroundImage = new Bitmap(icon);
        }
    }

}
