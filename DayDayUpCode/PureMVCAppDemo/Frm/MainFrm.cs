using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PureMVCAppDemo
{
    public partial class MainFrm : BasePureMVCMediator
    {
        public MainFrm()
        {
            InitializeComponent();
            InitMainPage();
            CallPureMVCRegister();
        }
        void InitMainPage()
        {
            List<string> forms = new List<string>();
            forms.Add(typeof(LoginFrm).Name);
            forms.Add(typeof(LoginListFrm).Name);
            forms.Add(typeof(RegisterFrm).Name);
            forms.Add(typeof(RegisterListFrm).Name);
            forms.Add(typeof(ImgPathSelectFrm).Name);
            forms.Add(typeof(ImgShowFrm).Name);
            forms.Add(typeof(TestFrm).Name);
            Point p = this.Location;
            for (int i = 0; i < forms.Count; i++)
            {
                Button btn = new Button()
                {
                    Name = forms[i],
                    Text = forms[i],
                    Location = new Point(p.X, p.Y + i * 35)
                };
                btn.Click += new EventHandler(Button_Click);
                this.Controls.Add(btn);

                //进行puremvc注册
                string name = forms[i];
            }
        }
        void Button_Click(object sender, EventArgs e)
        {
            Button b = (sender as Button);
            string formName = b.Name;
            Form frm = FacadeFactory.GetInstance().RetrieveMediator(formName) as Form;
            if (!frm.IsHandleCreated)
            {//判断窗体是否已经加载
                if (!frm.IsDisposed)//如果没有被销毁【窗体为进行关闭】
                    frm.Show();
                else { }
            }
            string tip = this.GetType().Name + " call " + frm.GetType().Name;
           // FormFacade fc = new FormFacade(formName, this);
           // OutSideCall.SendNotify(typeof(LoginFrm).Name, tip);
        }
        static void CallPureMVCRegister()
        {
            try
            {
                //初始化声明窗体
                TestFrm test = new TestFrm();
                LoginListFrm llf = new LoginListFrm();
                GridFrm gf = new GridFrm();
                LoginFrm lf = new LoginFrm();
                RegisterFrm rf = new RegisterFrm();
                RegisterListFrm rlf = new RegisterListFrm();
                ImgShowFrm isf = new ImgShowFrm();
                ImgPathSelectFrm s = new ImgPathSelectFrm();
                ToolTipFrm tip = new ToolTipFrm();
            }
            catch (Exception ex)
            {
                ex.ToString().WriteLog("Trace failure");
            }
        }
    }
}
