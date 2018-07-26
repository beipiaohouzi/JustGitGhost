using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.Windows.Forms;
using XPect.Lib.CommonLib.PluginFramework;
using XPect.Lib.CommonLib.Plugins;

namespace XPect.UI.Exam
{
    [Export(typeof(IPluginForm))]
    public class ExamPlugin : IPluginForm
    {
        public Form PluginForm
        {
            get
            {
                return new ExamPreview();
            }
        }

        public string PluginID
        {
            get
            {
                return "ExamPreview";
            }
        }

        public void PerformAction(params object[] pObj)
        {
            XPectFormPluginContext.Instance.RegisterPlugin(PluginID, this);
        }
    }

    [Export(typeof(IPluginForm))]
    public class ExamAPRSettingPlugin : IPluginForm
    {
        public Form PluginForm
        {
            get
            {
                return new ExamAPRSetting();
            }
        }

        public string PluginID
        {
            get
            {
                return "ExamAPRSetting";
            }
        }

        public void PerformAction(params object[] pObj)
        {
            XPectFormPluginContext.Instance.RegisterPlugin(PluginID, this);
        }
    }
}
namespace AppsettingHelp
{
    public class SystemConfig
    {
        static string ReadAppSettingItem(string itemName)
        {
            return System.Configuration.ConfigurationSettings.AppSettings[itemName];
        }
        static string imageSizeIsDynamic;
        public static bool ImageSizeIsDynamic
        {//图片数目动态可变
            get
            {
                if (string.IsNullOrEmpty(imageSizeIsDynamic))
                {
                    imageSizeIsDynamic = ReadAppSettingItem("ImageSizeIsDynamic");
                }
                return imageSizeIsDynamic == "true";
            }
        }
        static string useImageAutoArray;
        public static bool UseAutoSortImageArray
        {
            get
            {
                if (string.IsNullOrEmpty(useImageAutoArray))
                {
                    useImageAutoArray = ReadAppSettingItem("UseAutoSortImageArray");
                }
                return useImageAutoArray == "true";
            }
        }
        #region 图片排列数组规格
        #region 图片显示像素
        static string imagePx;
        public static int[] ImagePX
        {
            get
            {
                if (string.IsNullOrEmpty(imagePx))
                {
                    imagePx = ReadAppSettingItem("StudyExamImagePX");
                }
                string[] pxArr =!string.IsNullOrEmpty(imagePx)?
                    imagePx.Split('*'): "320*280".Split('*');
                int[] px = new int[2];
                px[0] = int.Parse(pxArr[0]);
                px[1] = int.Parse(pxArr[1]);
                return px;
            }
        }
        public static int ImageWidth
        {
            get
            {
                return ImagePX[0];
            }
        }
        /// <summary>
        /// 图片
        /// </summary>
        public static int ImageHeight
        {
            get
            {
                return ImagePX[1];
            }
        }
        #endregion
        
        static string imageMargin;
        static int[] ImageMargin
        {
            get
            {
                imageMargin = string.IsNullOrEmpty(imageMargin)? ReadAppSettingItem("ImageSpanMargin"): imageMargin;
                string[] arr = string.IsNullOrEmpty(imageMargin) ? "20*30".Split('*') : imageMargin.Split('*');
                int[] margin = new int[2];
                margin[0] = int.Parse(arr[0]);
                margin[1] = int.Parse(arr[1]);
                return margin;
            }
        }
        public static int ImageMarginRight
        {
            get
            {
                return ImageMargin[0];
            }
        }
        public static int ImageMarginBottom
        {
            get
            {
                return ImageMargin[1];
            }
        }
        #endregion
        #region 图片排列布局规格
        static string imageArray;
        public static int[] ImageArrayFormat
        {
            get
            {
                if (ImageSizeIsDynamic)
                {
                    return new int[] { 2,2};
                }
                if (string.IsNullOrEmpty(imageArray))
                {
                    imageArray = ReadAppSettingItem("StudyExamImageShowNormal");
                }
                string[] arr = string.IsNullOrEmpty(imageArray) ? "6*3".Split('*') : imageArray.Split('*');
                int[] imgArr = new int[2];
                imgArr[0] = int.Parse(arr[0]);//row
                imgArr[1] = int.Parse(arr[1]);//column
                //如果是动态情况

                return imgArr;
            }
        }
        
        #endregion

        #region 自适应情况下计算应该显示列照片数目
        /// <summary>
        /// 图片排列形式是否使用自适应
        /// </summary>
        /// <param name="containerWidth"></param>
        /// <returns></returns>
        public int[] ImageArray(int containerWidth)
        {
            if(!UseAutoSortImageArray)//如果不启用自适应
            return ImageArrayFormat;
            int[] arr = new int[2];
            int imgSize = ImageArrayFormat[0] * ImageArrayFormat[1];//显示图片总数目
            //计算可以显示多少列图片
            int col = (containerWidth + ImageMarginRight) / (ImageWidth + ImageMarginRight);
            //当列宽小于要显示图片的宽度时：显示一张
            if (col < 1)
            {
                col = 1;
            }
            arr[1] = col;
            arr[0] = imgSize / col + (imgSize % col > 0 ? 1 : 0);
            return arr;
        }
        
        #endregion
        #region 元素默认像素配置
        static string bottomBarHeight;
        public static int BottomBarHeight
        {
            get
            {
                if (string.IsNullOrEmpty(bottomBarHeight))
                {
                    bottomBarHeight = ReadAppSettingItem("BottomBarHeight");
                }
                int height = int.Parse(bottomBarHeight);
                if (height <10)
                {
                    height = 10;
                }
                return height;
            }
        }
        static string marginRight;
        public static int MarginRight
        {
            get
            {
                if (string.IsNullOrEmpty(marginRight))
                {
                    marginRight = ReadAppSettingItem("MarginRight");
                }
                int margin = 0;
                int.TryParse(marginRight, out margin);
                if (margin < 1)
                {
                    margin = 5;
                }
                return margin;
            }
        }
        
        #endregion
        #region  dir auto analysic 
        static string exeDir;
        static string debugDir
        {
            get
            {
                if (string.IsNullOrEmpty(exeDir))
                {
                    exeDir = AppDomain.CurrentDomain.BaseDirectory; 
                }
                return exeDir;
            }
        }
        #endregion
        #region 图片路径管理 配置
        static string ImageDir
        {
            get
            {
                return debugDir + @"\Resource\Image\";
            }
        }
        static string defImgDir;
        public static string DefaultImage
        {
            get
            {
                if (string.IsNullOrEmpty(defImgDir))
                {
                    defImgDir = ImageDir + ReadAppSettingItem("DefaultImage");
                }
                return defImgDir;
            }
        }
        static string addActionIcon;
        public static string AddActionIcon
        {
            get
            {
                if (string.IsNullOrEmpty(addActionIcon))
                    addActionIcon = ImageDir + ReadAppSettingItem("AddActionImage");
                return addActionIcon;
            }
        }
        #endregion
        #region common appsetting
        static string eleHeight;
        public static int TipEleHeight
        {//元素高度
            get
            {
                if (string.IsNullOrEmpty(eleHeight))
                {
                    eleHeight = ReadAppSettingItem("TipEleHeight");
                }
                int height = 0;
                int.TryParse(eleHeight, out height);
                if (height < 1)
                {
                    height = 12;
                }
                return height;
            }
        }
        #endregion
    }

}
namespace CommonHelper
{
    using System.IO;
    public class Logger
    {
        /// <summary>
        /// 将数据写入到日志
        /// </summary>
        /// <param name="text"></param>
        /// <param name="path"></param>
        /// <param name="log"></param>
        /// <param name="fileName"></param>
        /// <param name="existsWrite">存在相同名称的文件进行替换还是追加</param>
        public static void CreateLogFile(string text, string path, string log, string fileName = null, bool existsWrite = false, Encoding encode = null)
        {
            if (string.IsNullOrEmpty(text)) { return; }
            if (!string.IsNullOrEmpty(path) && !Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            DateTime now = DateTime.Now;
            string file = path + "/" + log;
            if (!Directory.Exists(file))
                Directory.CreateDirectory(file);
            string filetype = ".txt";
            if (string.IsNullOrEmpty(fileName))
                file += "/" + log + now.ToString("yyyyMMdd") + filetype;
            else
            {//需要判断是否增加后缀
                if (!fileName.Contains("."))
                {
                    file += "/" + fileName + filetype;
                }
                else
                {
                    file += "/" + fileName;
                }
            }
            FileStream fs;
            if (!existsWrite)
            {
                fs = new FileStream(file, FileMode.Create, FileAccess.Write, FileShare.Write);
            }
            else
            {
                if (File.Exists(file))
                {
                    text = "\r\n" + text;
                    fs = new FileStream(file, FileMode.Append, FileAccess.Write, FileShare.Write);
                }
                else
                {
                    fs = new FileStream(file, FileMode.Create, FileAccess.Write, FileShare.Write);
                }
            }
            if (encode == null)
            {
                encode = Encoding.UTF8;
            }
            StreamWriter sw = new StreamWriter(fs, encode);
            sw.Write(text);
            sw.Close();
            fs.Close();
        }
    }
    public static class LoggerQuickHelp
    {
        public static void WriteLog(this string log,string title)
        {
            DateTime now = DateTime.Now;
            //日志按照月份汇总
            string file = now.ToString("");//日志以天为文件存储
        }
    }
}