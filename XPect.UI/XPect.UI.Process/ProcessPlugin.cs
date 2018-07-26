using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.Windows.Forms;
using XPect.Lib.CommonLib.PluginFramework;
using XPect.Lib.CommonLib.Plugins;

namespace XPect.UI.Process
{
    [Export(typeof(IPluginForm))]
    public class ProcessPlugin : IPluginForm
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
                return "ProcessPluginForm";
            }
        }

        public void PerformAction(params object[] pObj)
        {
            XPectFormPluginContext.Instance.RegisterPlugin(PluginID, this);
        }
    }
}
