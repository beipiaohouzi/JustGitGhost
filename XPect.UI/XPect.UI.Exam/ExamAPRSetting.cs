using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XPect.Lib.WinFormsUI.Docking;
namespace XPect.UI.Exam
{
    public delegate void FrmCallEvent(object data);//窗体间交互的方法
    public partial class ExamAPRSetting : DockContent
    {
        public ExamAPRSetting()
        {
            InitializeComponent();
            //new StudyParamFrm(this);
            InitEle();
        }

        /// <summary>
        ///影像联动曝光参数的响应事件 
        /// </summary>
        public FrmCallEvent StudyLinkageFocuParam { get;private set; }
        void InitEle()
        {
            BindEvent();
            
        }
        /// <summary>
        /// 请求底层硬件
        /// </summary>
        /// <param name="callMachineAction">请求硬件的动作</param>
        public void CallMachine(FrmCallEvent callMachineAction)
        {
            //页面处理完毕之后进行的动作
            FocusParam param = new FocusParam()
            {
                Kvp = int.Parse(lblKvpValue.Text),
                Mas = int.Parse(lblMasValue.Text)
            };
            if (callMachineAction != null)
            {
                callMachineAction(param);
            }
        }
        void BindEvent()
        {
            btnAEC.Click += new EventHandler(Button_Click);
            btnDense.Click += new EventHandler(Button_Click);
            btnFatty.Click += new EventHandler(Button_Click);
            btnFocus.Click += new EventHandler(Button_Click);
            btnManual.Click += new EventHandler(Button_Click);
            btnmAs.Click += new EventHandler(Button_Click);
            btnNormal.Click += new EventHandler(Button_Click);
            btnReset.Click += new EventHandler(Button_Click);
            btnTime.Click += new EventHandler(Button_Click);
            //设置元素参数
            btnLoseKvp.Tag = new ButtonTagParam() { doAction = -1, tagetEleId = "lblKvpValue" };
            btnAddKvp.Tag = new ButtonTagParam() { doAction = 1, tagetEleId = "lblKvpValue" };
            btnLoseMas.Tag = new ButtonTagParam() { doAction = -1, tagetEleId = "lblMasValue" };
            btnAddMas.Tag = new ButtonTagParam() { doAction = 1, tagetEleId = "lblMasValue" };
            StudyLinkageFocuParam = ApiResponse;
        }
        void Button_Click(object sender,EventArgs e)
        {

        }
        class ButtonTagParam
        {
            public string tagetEleId { get; set; }
            public int doAction { get; set; }
        }
        void ChangeParamValue_Click(object sender,EventArgs e)
        {
            Button btn = sender as Button;
            object tag = btn.Tag;//操作的对象【api参数目标】
            ButtonTagParam param = tag == null ? null : (tag as ButtonTagParam);
            //进行的动作分类
            Control ele = apiParamPanel.Controls.Find(param.tagetEleId,false)[0];
            string value = ele.Text;
            ele.Text = (int.Parse(value) + param.doAction * 1).ToString();
        }
        void ApiResponse(object data)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(()=> { ApiResponse(data); }) );
                return;
            }
            FocusParam param = data as FocusParam;
            lblKvpValue.Text = param.Kvp.ToString();
            lblMasValue.Text = param.Mas.ToString();
        }
    }
    public class FocusParam
    {
        public int Kvp { get; set; }
        public int Mas { get; set; }
    }
}
