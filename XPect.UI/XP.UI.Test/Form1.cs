using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XPect.Lib.CommonLib;
using XPect.Lib.CommonLib.PluginFramework;
using XPect.Lib.CommonLib.Plugins;
using XPect.Lib.DataModel.XMLEntity;

namespace XP.UI.Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void xpButton1_Click(object sender, EventArgs e)
        {
            XPectConfiguration.Instance.LoadFramework();

            XPectFormPluginContext.Instance.Plugins.Keys.ToList().ForEach(p=> Console.WriteLine("===" + p + " ====="));

            XPectScreenLayoutPluginContext.Instance.Plugins.Keys.ToList().ForEach(p => Console.WriteLine(" ==== " + p + " =====")) ;
        }
    }
}
