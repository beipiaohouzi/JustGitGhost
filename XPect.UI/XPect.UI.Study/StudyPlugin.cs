using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.Windows.Forms;
using XPect.Lib.CommonLib.PluginFramework;
using XPect.Lib.CommonLib.Plugins;

namespace XPect.UI.Study
{
    [Export(typeof(IPluginForm))]
    public class StudyListPlugin : IPluginForm
    {
        public Form PluginForm
        {
            get
            {
                return new FrmStudyList();
            }
        }

        public string PluginID
        {
            get
            {
                return "FrmStudyList";
            }
        }

        // todo: 1.加个启动项目；2.加个主页面，一个子页面。主页面承载所有子页面。子页面继承DOCCKCONTENT;
        // TODO: 1.勾勒检查、注册、列表页面原型。
        public void PerformAction(params object[] pObj)
        {
            XPectFormPluginContext.Instance.RegisterPlugin(PluginID, this);
        }
    }

    [Export(typeof(IPluginForm))]
    public class StudyToolbarPlugin : IPluginForm
    {
        public Form PluginForm
        {
            get
            {
                return new FrmStudyToolbar();
            }
        }

        public string PluginID
        {
            get
            {
                return "FrmStudyToolbar";
            }
        }

        // todo: 1.加个启动项目；2.加个主页面，一个子页面。主页面承载所有子页面。子页面继承DOCCKCONTENT;
        // TODO: 1.勾勒检查、注册、列表页面原型。
        public void PerformAction(params object[] pObj)
        {
            XPectFormPluginContext.Instance.RegisterPlugin(PluginID, this);
        }
    }
}
