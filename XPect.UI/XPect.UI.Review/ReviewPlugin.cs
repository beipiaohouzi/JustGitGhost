using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.Windows.Forms;
using XPect.Lib.CommonLib.PluginFramework;
using XPect.Lib.CommonLib.Plugins;

namespace XPect.UI.Review
{
    /// <summary>
    /// Review包括查看图像、打印图像、查看发送和打印队列，【以及报告】
    /// </summary>
    [Export(typeof(IPluginForm))]
    public class ReviewPlugin : IPluginForm
    {
        public Form PluginForm
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string PluginID
        {
            get
            {
                return "ReviewPluginForm";
            }
        }

        public void PerformAction(params object[] pObj)
        {
            XPectFormPluginContext.Instance.RegisterPlugin(PluginID, this);
        }
    }
}
