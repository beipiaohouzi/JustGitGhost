using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using XPect.Lib.UIFramework.UI.Splasher;
using XPect.Lib.UIFramework.Layout;
using XPect.Lib.CommonLib;

namespace XP.UI.Startup
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //todo: 预处理，如运行状态、权限，有效性等

            //加载布局框架
            XPectConfiguration.Instance.LoadFramework();

            //Splasher必须先弹出来，再运行上下文环境。
            Splasher.Show(typeof(FrmSplasher));

            SystemApplicationContext context = new SystemApplicationContext();

            Application.Run(context);
        }
    }

    internal class SystemApplicationContext : ApplicationContext
    {
        private FrmMain mMainFrm;

        public SystemApplicationContext()
        {
            try
            {
                Splasher.Status = "Initializing.......";

                //todo: 这里是测试关闭进度页面的。需要处理页面的加载过程其实。
                System.Threading.Thread.Sleep(2000);
                mMainFrm = new FrmMain();

                //todo: 初始化硬件连接、DICOM环境、网络连接等。期间要设置登录状态Splasher.Status = "Initializing.......";
                mMainFrm.Show();

                //todo:需要设置第一个显示的页面，注册页面or列表页面

            }
            catch (Exception ex)
            {

            }
        }
    } 
}
