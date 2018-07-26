using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.Windows.Forms;
using XPect.Lib.CommonLib.PluginFramework;
using XPect.Lib.CommonLib.Plugins;

namespace XPect.UI.CommonState
{
    [Export(typeof(IPluginForm))]
    public class CommonStatePlugin : IPluginForm
    {
        public Form PluginForm
        {
            get
            {
                return new FrmCommonState();
            }
        }

        public string PluginID
        {
            get
            {
                return "FrmCommonState";
            }
        }

        public void PerformAction(params object[] pObj)
        {
            XPectFormPluginContext.Instance.RegisterPlugin(PluginID, this);
        }
    }
}
