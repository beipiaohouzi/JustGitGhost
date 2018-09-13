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
namespace PureMVCAppDemo
{
    public partial class TestFrm : Form
    {
        BackgroundWorker cpuTempBack = new BackgroundWorker();
        public TestFrm()
        {
            InitializeComponent();
            //Test();
            cpuTempBack.DoWork += new DoWorkEventHandler(CpuBackWork);
            cpuTempBack.RunWorkerAsync();
        }
        int click = 0;
        private void btnAddRow_Click(object sender, EventArgs e)
        {

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

            // g.Dispose();
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
            new System.Threading.Thread(() =>
            {
                System.Management.ManagementObjectSearcher cpu = new ManagementObjectSearcher(@"root\WMI", "Select * From MSAcpi_ThermalZoneTemperature");
                foreach (System.Management.ManagementObject mo in cpu.Get())
                /*
                An unhandled exception of type 'System.Management.ManagementException' occurred in System.Management.dll
                  Additional information: 拒绝访问
                 */

                {

                    double tem = Convert.ToDouble(Convert.ToDouble(mo.GetPropertyValue("CurrentTemperature").ToString()) - 2732) / 10;
                    rtbTip.Text = string.Format("Cpu template:{0} °", tem);
                }
            }).Start();

        }

    }
}
