using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Windows.Forms;
using XPect.Lib.XPControl;
using PureMVC.Interfaces;

namespace PureMVCAppDemo
{
    public partial class TestFrm : BasePureMVCMediator
    {
        BackgroundWorker cpuTempBack = new BackgroundWorker();
        int mColWidth = 300, mRowHeight = 260;
        public TestFrm()
        {
            InitializeComponent();
            //Test();
            cpuTempBack.DoWork += new DoWorkEventHandler(CpuBackWork);
           // cpuTempBack.RunWorkerAsync();
            InitEle();
        }
        private void InitEle()
        {
            btnAddRow.Click += new EventHandler(btnAddRow_Click);
            btnDeleteRow.Click += new EventHandler(btnDeleteRow_Click);
            XPImagePanel img = new XPImagePanel()
            {
                Width= mColWidth,
                Height= mRowHeight
            };
            img.RefreshDesc("Index:" + flowLayoutPanel1.Controls.Count);
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Controls.Add(img);

        }
        int click = 0;
        private void btnAddRow_Click(object sender, EventArgs e)
        {
            XPImagePanel img = new XPImagePanel() { Width=mColWidth,Height=mRowHeight};
            img.RefreshDesc("Index:" + flowLayoutPanel1.Controls.Count);
            flowLayoutPanel1.Controls.Add(img);
        }

        private void btnDeleteRow_Click(object sender, EventArgs e)
        {

        }
        void DrawLine()
        {
            Refresh();
            int w = Width;
            int h = Height;
            Graphics g = CreateGraphics();
            int y = 10 + click * 15;
            if (y >= h)
            {
                click = 0;
                y = 10;
            }
            //清除划线痕迹
            System.Drawing.Point begin = new System.Drawing.Point(50, y);
            System.Drawing.Point end = new System.Drawing.Point(w, y);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            System.Drawing.Pen pen = new System.Drawing.Pen(System.Drawing.Color.Red, 2);
            g.DrawLine(pen, begin, end);
        }

        private void btnAgain_Click(object sender, EventArgs e)
        {
            click++;
            DrawLine();
        }

        private void TestFrm_Load(object sender, EventArgs e)
        {

            DrawLine();
        }
        private void CpuBackWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                RealTimeCpuTemplate();
                System.Threading.Thread.Sleep(3 * 1000);
            }
        }
        private void RealTimeCpuTemplate()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => {
                    RealTimeCpuTemplate();
                }));
                return;
            }
            System.Management.ManagementObjectSearcher cpu = new ManagementObjectSearcher(@"root\WMI", "Select * From MSAcpi_ThermalZoneTemperature");
            try
            {
                foreach (System.Management.ManagementObject mo in cpu.Get())
                /*
                An unhandled exception of type 'System.Management.ManagementException' occurred in System.Management.dll
                  Additional information: 拒绝访问
                 */

                {

                    double tem = Convert.ToDouble(Convert.ToDouble(mo.GetPropertyValue("CurrentTemperature").ToString()) - 2732) / 10;
                   // rtbTip.Text += string.Format("Cpu template:{0} °", tem)+"\r\n";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
               // rtbTip.Text += ex.ToString() + "\r\n";
            }
        }
        #region  overide
        public override void HandleNotification(INotification notification)
        {
            switch (notification.Name)
            {
                case NotifyData.Cmd_Account:
                    string msg = notification.Body as string;
                    Console.WriteLine(string.Format("form :{0} receiver msg:{1}", this.GetType().Name,msg));
                    SendNotification(NotifyData.Cmd_Account_Over, string.Format("the flag is response from {0},time={1}", this.GetType().Name,DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")), string.Empty);
                    break;
            }
        }
        public override string[] ListNotificationInterests()
        {
            return new string[] {
                NotifyData.Cmd_Grid,
                NotifyData.Cmd_Account
           };
        }
        #endregion 

    }
}
