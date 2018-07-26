using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel.Composition;
using XPect.Lib.CommonLib;
using XPect.Lib.CommonLib.PluginFramework;
using XPect.Lib.CommonLib.Plugins;
using XPect.Lib.DataModel.XMLEntity;


namespace XPect.UI.ScreenLayout
{
    [Export(typeof(IPlugin))]
    public class ScreenLayoutPlugin : IPlugin
    {
        public string PluginID
        {
            get
            {
                return "ScreenLayoutPlugin";
            }
        }

        /// <summary>
        /// 加载布局配置文件XPectLayout.xml，并把各布局对象注册到XPectScreenLayoutPluginContext中。
        /// </summary>
        /// <param name="pObj"></param>
        public void PerformAction(params object[] pObj)
        {
            XPectScreens xps =  XPectConfiguration.Instance.GetConfiguration<XPectScreens>(Path.Combine(Environment.CurrentDirectory,@"Layout\XPectLayout.xml"));

            if (xps.Screens != null)
            {
                xps.Screens.ForEach(screen => XPectScreenLayoutPluginContext.Instance.RegisterPlugin(screen.ScreenId, screen));
            }
        }
    }
}
