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
using System.Text.RegularExpressions;
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
            CodeGenerate();
            if (loadImage)
                PaintButton(false);
            // ImageShow.ImageShow img = new ImageShow.ImageShow();
            GetImages();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawUnderLine();
            DrawUnderLine(underLinePanel);
        }
        private void CodeGenerate()
        {
            System.Windows.Forms.PictureBox cp = new PictureBox();
            Label lbl = new Label() { };
            lbl.AutoSize = true;
            lbl.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            lbl.Location = new System.Drawing.Point(60, 10);
            lbl.Name = "lblTextCode";
            lbl.Size = new System.Drawing.Size(275, 12);
            lbl.TabIndex = 222;
            lbl.Text = "代码生成透明背景数据";
            Panel pCode = new Panel() { };
            pCode.Controls.Add(lbl);
            pCode.Controls.Add(cp);
            pCode.Location = new System.Drawing.Point(450, 100);
            pCode.Name = "cpCode";
            pCode.Size = new System.Drawing.Size(275, 40);
            pCode.TabIndex = 111;

           

            cp.BackgroundImage = global::PureMVCAppDemo.Properties.Resources.radiobtn_active;
            cp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            cp.Location = new System.Drawing.Point(00, 0);
            cp.Name = "pCode";
            cp.Padding = new System.Windows.Forms.Padding(103, 0, 0, 0);
            cp.Size = new System.Drawing.Size(275, 33);
            cp.TabIndex = 3330;
            cp.TabStop = false;

            this.Controls.Add(pCode);

        }
        private void Click_Event(object sender,EventArgs e)
        {
            if (loadImage)
                PaintButton(true);
            
        }
        private void MouseLeave_Event(object sender, EventArgs e)
        {
            if (loadImage)
                PaintButton(false);
            else
            { }
        }
        private void PaintButton(bool isClick)
        {
            string  icon = !isClick? @"Resource\addprocedure_normal.png" : @"Resource\addprocedure_active.png";
            string bg = !isClick? @"Resource\commonBtn_normal.png" : @"Resource\commonBtn_active.png";
          
           
        }
        private void DrawImage2Ele(bool isClick,Size container)
        {
            string icon = !isClick ? @"Resource\addprocedure_normal.png" : @"Resource\addprocedure_active.png";
            string bg = !isClick ? @"Resource\commonBtn_normal.png" : @"Resource\commonBtn_active.png";
         
        }
        private Image GraphsicImage2Ele(string dir,Control ele,Point showLoc)
        {
            Image generate = new Bitmap(dir);
            Graphics ge= ele.CreateGraphics();
            
            return generate;
        }
        private Image GraphsicImage(string path,Size targetSize)
        {//这个函数实际上是进行图片截图
            //读取文件流
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            Image origin = new Bitmap(fs);
            Image tar = new Bitmap(targetSize.Width, targetSize.Height);
            Graphics g = Graphics.FromImage(tar);
            Rectangle rect = new Rectangle(new Point(0, 0), targetSize);//这样设置进行的是图片裁剪
            //应该是进行等比例缩放
            Rectangle origRect = new Rectangle(new Point(0, 0), origin.Size);//原图位置（默认从原图中截取的图片大小等于目标图片的大小）
            g.DrawImage(origin, rect, origRect, GraphicsUnit.Pixel);
            tar.Save(DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg");//本地文件检测是否和显示文件为同一个
            fs.Close();
            origin.Dispose();
            return tar;
        }

        private void DrawUnderLine()
        {
            Graphics g =  CreateGraphics();
            Pen pen = new Pen(Color.Red, 2);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            g.DrawLine(pen, 100,40,500,40);
        }
        private void DrawUnderLine(Control ele)
        {
            Graphics g = CreateGraphics();// ele.CreateGraphics();
            Pen pen = new Pen(Color.Black, 4);
            g.DrawLine(pen, ele.Location.X, ele.Location.Y, ele.Width + ele.Location.X, ele.Location.Y);
        }
        private void btnUnderLine_Click(object sender, EventArgs e)
        {
            Control ctl = sender as Control;
            bool isLine = ctl.Tag == null;
            DrawBorder(isLine);
            ctl.Tag = isLine ? DateTime.Now.ToString() : null;
           // DrawUnderLine(underLinePanel);
        }
        private void DrawBorder(bool isUnderLine)
        {
            Color pc = isUnderLine?Color.Gray: Color.Red;
            Pen pen = new Pen(pc, 1);
            int[] padding = new int[] { 10, 10, 10, 10 };
            int recH = isUnderLine ? 1 : Height - padding[0] - padding[2]-15*2;//绘制的是边框还是下划线
            //Rectangle rc = new Rectangle(new Point(padding[3], padding[0]), new Size(Width - padding[1] - padding[3], recH));
            Graphics g = CreateGraphics();// ele.CreateGraphics();
            g.DrawRectangle(pen,padding[3],padding[0],Width-padding[1]-padding[3]-10,recH);
        }
       
        int curIndex = 0;
        int sum = 0;
        string[] imgs = null;
        private void GetImages()
        {
            string path = @"E:\Web\";
            var searchPattern = new Regex(@"$(?<=\.(jpg|png|bmp))", RegexOptions.IgnoreCase);
            //GetFiles的只能匹配单个模式// "(*.jpg|*.bmp)"
            DirectoryInfo dis = new DirectoryInfo(path);
            FileInfo[] fis = dis.GetFiles().Where(f=>searchPattern.IsMatch(f.FullName)).ToArray();
            sum = fis.Length;
            imgs = fis.Select(s => s.FullName).ToArray();
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (curIndex == sum)
            {
                curIndex = 0;
            }
            DrawImage(imgs[curIndex]);
            curIndex++;
        }
        private void DrawImage(string path)
        {
            FileInfo fi = new FileInfo(path);
            Image img = ImageHelper.GraphsicImage(path);
            Graphics g = imgPanel.CreateGraphics();
            //首先的清除历史绘图痕迹
            g.Clear(Color.Transparent);
            string text = btnImage.Text;
            int cw = imgPanel.Width, ch = imgPanel.Height;
            int textH = 20;
            //图片的安装比例进行调整
            g.DrawImage(img,5, textH, cw-10,ch- textH*2);//设置图片显示区域
            //绘制显示的文本
            SolidBrush sbrush = new SolidBrush(Color.Red);
            Font f = new Font("宋体", 12);
            //直达文本显示位置
            g.DrawString(text, f, sbrush, 0, ch- textH+3);//绘图，并在图中增加水印
            //g.MeasureString(btnImage.Text, f);
            g.Dispose();
            img.Dispose();
            //img.Save("E:/WaterText/" + DateTime.Now.ToString("yyyyMMddHHmmss") + fi.Extension);
            //如果绘制的控件是panel可以保留绘图效果，但是是button时会在鼠标悬浮之后清除掉绘图，要实现保留形式，则需要反复绘图（导致占用大量内存，CPU资源占用问题）

        }
    }

    public class ImageHelper
    {
        /// <summary>
        /// 生成图片的文件流
        /// </summary>
        /// <param name="path">图片路径</param> 
        /// <returns></returns>
        public static Image GraphsicImage(string path)
        {//转换为文件流避免出现文件占用
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            Image origin = new Bitmap(fs);
            Image tar = new Bitmap(origin.Width, origin.Height);
            Graphics g = Graphics.FromImage(tar);
            Rectangle rect = new Rectangle(new Point(0, 0), new Size(origin.Width, origin.Height));//这样设置进行的是图片裁剪
            //应该是进行等比例缩放
            Rectangle origRect = new Rectangle(new Point(0, 0), origin.Size);//原图位置（默认从原图中截取的图片大小等于目标图片的大小）
            g.DrawImage(origin, rect, origRect, GraphicsUnit.Pixel);
            fs.Close();
            origin.Dispose();
            return tar;
        }
    }
}
