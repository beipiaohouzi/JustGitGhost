using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PureMVC.Interfaces;
namespace PureMVCAppDemo
{
    public partial class ImgShowFrm : BasePureMVCMediator
    {
        public ImgShowFrm()
        {
            InitializeComponent();
            bg.DoWork += new DoWorkEventHandler(BackWorkTodo);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            ValidPathSpecialChar();
        }

        #region private member 
        List<string> files = new List<string>();
        BackgroundWorker bg = new BackgroundWorker();
        private int curIndex = 0;
        private bool isRun = false;
        #endregion
        #region contructor 
        #endregion
        #region  overide
        public override void HandleNotification(INotification notification)
        {
            switch (notification.Name)
            {
                case NotifyData.Cmd_Account:
                    string msg = notification.Body as string;
                    Console.WriteLine(string.Format("form :{0} receiver msg:{1}", this.GetType().Name, msg));
                    break;
                case NotifyData.Cmd_Image_PathSelect:
                    string[] select = notification.Body as string[];
                    files.AddRange(select);
                    RunCycle();
                    break;
            }
        }
        public override string[] ListNotificationInterests()
        {
            return new string[] {
                NotifyData.Cmd_Grid,
                NotifyData.Cmd_Account,
                NotifyData.Cmd_Image_PathSelect
           };
        }
        #endregion

        #region event
        private void BackWorkTodo(object sender,DoWorkEventArgs e)
        {
            isRun = true;
            while (true)
            {
                ShowImage();
                if (!isRun)
                {
                    return;
                }
                System.Threading.Thread.Sleep(2 * 1000);
            }
        }

        #endregion

        #region self function
        private void ShowImage()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(()=> { ShowImage(); }));
                    return;
                }
                if (files.Count == 0)
                {
                    isRun = false;
                }
                curIndex = curIndex % files.Count;
                string file = files[curIndex];
                curIndex++;
                pictureBox1.BackgroundImage = new Bitmap(file);
                
            }
            catch (Exception ex)
            {

            }
        }
        private void RunCycle()
        {
            if (!bg.IsBusy)
            {
                isRun = true;
                bg.RunWorkerAsync();
            }
        }
        private void ValidPathSpecialChar()
        {
            //特殊字符校验
            string regex = @"(.*\.*)(.*\*.*)";
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(regex);
            string input = @"张三风";//判断是否含有某某字符
            System.Text.RegularExpressions.Match mc= reg.Match(input);
            if (mc.Groups.Count > 1)
            {

            }
        }
        #endregion

        private void btnClear_Click(object sender, EventArgs e)
        {
            files.Clear();
        }
    }
}
