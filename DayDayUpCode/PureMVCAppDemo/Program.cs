using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PureMVCAppDemo.Command;
namespace PureMVCAppDemo
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
            CallPureMVCRegister();
            Application.Run(new MainFrm());
        }
        static void CallPureMVCRegister()
        {
            FacadeEnter fac = new FacadeEnter();
            fac.MVCRegister();
        }
    }
}
