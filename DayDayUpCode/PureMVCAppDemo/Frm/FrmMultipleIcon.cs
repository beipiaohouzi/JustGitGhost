using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PureMVCAppDemo
{
    public partial class FrmMultipleIcon : Form
    {
        bool loadImage = false;
        public FrmMultipleIcon()
        {
            InitializeComponent();
            InitEle();
        }
        private void InitEle()
        {
            btnAdd.Click += new EventHandler(Click_Event);
            btnAdd.MouseLeave += new EventHandler(MouseLeave_Event);
            if (loadImage)
                PaintButton(false);
            else
                DrawImage2Ele(false,btnAdd.Size);
           
        }
        private void Click_Event(object sender,EventArgs e)
        {
            if (loadImage)
                PaintButton(true);
            else
                DrawImage2Ele(true,btnAdd.Size);
        }
        private void MouseLeave_Event(object sender, EventArgs e)
        {
            if (loadImage)
                PaintButton(false);
            else
                DrawImage2Ele(false,btnAdd.Size);
        }
        private void PaintButton(bool isClick)
        {
            string  icon = !isClick? @"Resource\addprocedure_normal.png" : @"Resource\addprocedure_active.png";
            string bg = !isClick? @"Resource\commonBtn_normal.png" : @"Resource\commonBtn_active.png";
            btnAdd.BackgroundImage = new Bitmap(bg);
            btnAdd.BackgroundImageLayout = ImageLayout.Zoom;
            btnAdd.Image = new Bitmap(icon);
           
        }
        private void DrawImage2Ele(bool isClick,Size container)
        {
            string icon = !isClick ? @"Resource\addprocedure_normal.png" : @"Resource\addprocedure_active.png";
            string bg = !isClick ? @"Resource\commonBtn_normal.png" : @"Resource\commonBtn_active.png";
            btnAdd.BackgroundImage = GraphsicImage(bg,container);
            btnAdd.Image = GraphsicImage(icon, container);
            btnAdd.BackgroundImageLayout = ImageLayout.Zoom;
        }
        private Image GraphsicImage(string path,Size targetSize)
        {//这个函数实际上是进行图片截图
            //读取文件流
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            Image origin = new Bitmap(fs);
            Image tar = new Bitmap(targetSize.Width, targetSize.Height);
            Graphics g = Graphics.FromImage(tar);
            Rectangle rect = new Rectangle(new Point(0, 0), targetSize);//应该是进行等比例缩放

            Rectangle origRect = new Rectangle(new Point(0, 0), origin.Size);//原图位置（默认从原图中截取的图片大小等于目标图片的大小）
            g.DrawImage(origin, rect, origRect, GraphicsUnit.Pixel);
            //tar.Save(DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg");//本地文件检测是否和显示文件为同一个
            fs.Close();
            origin.Dispose();
            return tar;
        }
    }
}
