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
using XPect.Lib.XPControl;
using AppsettingHelp;
using CommonHelper;
namespace XPect.UI.Exam
{
    public partial class ExamPreview : DockContent
    {
        
        string activePicture = string.Empty;//被激活的图片控件
        int changeNum = 0;
        double left = 0.3, right = 0.7;//布局
        XPTableLayoutPanel layout = new XPTableLayoutPanel() { Name = "layoutPanel", Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 1 };//单行两列
        int[] imageTables = SystemConfig.ImageArrayFormat;
        int imageHeightSpan = SystemConfig.ImageMarginBottom, imageWightSpan = SystemConfig.ImageMarginRight;//图片的高度/宽度间隔
        int imageWidth = SystemConfig.ImageWidth, imageHeight = SystemConfig.ImageHeight;//图片的比例
        string imageIdFormat = "image{0}";
        int tipEleHeight = SystemConfig.TipEleHeight;
        public ExamPreview()
        {
            InitializeComponent();
            InitEle();
        }
        void InitEle()
        {
            this.Controls.Add(layout);
            layout.SizeChanged += new EventHandler(PanelSizeChange);
        }
        void PanelSizeChange(object sender, EventArgs e)
        {
            changeNum++;
            if (changeNum > 1)
            {
                PageSizeChange();
            }
            else
            {
                InitDrawEle();
            }
            
        }
        #region 渲染元素
        void InitDrawEle()
        {
            int w = this.Width;
            double lw = w * left, rw = right * w;
            int h = this.Height;
            //是首次渲染还是调整窗体的大小
            XPPanel leftP = null, rightP = null;
            leftP = new XPPanel() { Name = "leftPanel", BackColor = Color.FromArgb(204, 255, 255), Dock = DockStyle.Left };
            rightP = new XPPanel() { Name = "rightPanel", Dock = DockStyle.Right};
            layout.Controls.Add(leftP);
            //追加底部工具栏
            //1 图片容器  2 工具栏容器
            int bottomH = SystemConfig.BottomBarHeight;
            XPPanel pictureContainerPanel = new XPPanel()
            {
                Name = "pictureContainerPanel",
                Location = new Point(rightP.Location.X, rightP.Location.Y),
                Height = rightP.Height - bottomH,
                AutoScroll = true,
                Dock=DockStyle.Fill
            };
            XPPanel bottomBar = new XPPanel()
            {
                Name="bottomBarPanel",
                Location = new Point(rightP.Location.X, rightP.Height - bottomH),
                Width = rightP.Width,
                Dock = DockStyle.Bottom
            };
            DrawBottomToolBar(bottomBar);
            AppendPicture(pictureContainerPanel);
            rightP.Controls.Add(pictureContainerPanel);
            rightP.Controls.Add(bottomBar);
            layout.Controls.Add(rightP);
            leftP.Width = (int)lw;
            leftP.Height = h;
            rightP.Width = (int)rw;
            rightP.Height = h;
            Point parent = layout.Location;
            leftP.Location = new Point(parent.X, parent.Y);
            rightP.Location = new Point(parent.X + leftP.Width, parent.Y);
            layout.Controls.Add(leftP);
            layout.Controls.Add(rightP);
            this.Refresh();//界面刷新
        }
        void AppendPicture(XPPanel contain)
        {
            int row = imageTables[0];//行数目
            int column = imageTables[1];//列 
            for (int r = 0; r < row; r++)
            {//第几行
                for (int c = 0; c < column; c++)
                {//列数目
                 //判断该图片是否为增加按钮
                    bool isLast = (column * r + c) == (row * column - 1);
                    XPImagePanel xp = new XPImagePanel(tipEleHeight)
                    {
                        Width = imageWidth,
                        Height = imageHeight,
                        Name= string.Format(imageIdFormat,isLast?0: (c + column * r + 1)),
                        Location = new Point(c * imageWidth + imageWightSpan * c, imageHeight * r + imageHeightSpan * r)
                         
                    };
                    if (!isLast)
                    {
                        xp.RefreshImage(SystemConfig.DefaultImage);
                        xp.RefreshDesc(DateTime.Now.ToString("yyyyMMdd"));
                        xp.Click+=new EventHandler (CommonPcitureBoxClick);//图片 被选中
                        //选中图片同样触发
                    }
                    else
                    {
                        xp.RefreshImage(SystemConfig.AddActionIcon);
                        xp.Click += new EventHandler(AddPictureBoxClick);//图片 被选中
                    }
                    contain.Controls.Add(xp);
                }
            }
        }
        void DrawBottomToolBar(Control container)
        {
            //增加工具按钮
            List<XPButton> btns = new List<XPButton>();
            AppendButton("btnProduce", "Add Procedure", btns);
            AppendButton("btnDelete", "Delete /Recover", btns);
            AppendButton("btnCopy", "Copy View", btns);
            AppendButton("btnEdit", "Edit View", btns);
            int width = container.Width;
            Point loc = container.Location;
            int num = btns.Count;
            int avgWidth = width / num;
            for (int i = 0; i < btns.Count; i++)
            {
                btns[i].Location = new Point(loc.X + i * avgWidth, loc.Y);
                container.Controls.Add(btns[i]);
            }
        }
        void AppendButton(string id, string text, List<XPButton> btns)
        {
            XPButton btn = new XPButton()
            {
                Name = id,
                Text = text,
                Height=30,
                ForeColor=Color.Black,
                BackColor=Color.White
            };
            btns.Add(btn);
        }
        #endregion
        #region 尺寸变动
        void PageSizeChange()
        {
            int w = this.Width;
            double lw = w * left, rw = right * w;
            int h = this.Height;
            //是首次渲染还是调整窗体的大小
            XPPanel leftP = layout.Controls.Find("leftPanel", false)[0] as XPPanel;
            XPPanel rightP = layout.Controls.Find("rightPanel", false)[0] as XPPanel;
            XPPanel pictureContainer = rightP.Controls.Find("pictureContainerPanel", true)[0] as XPPanel;
            leftP.Width = (int)lw;
            leftP.Height = h;
            rightP.Width = (int)rw;
            rightP.Height = h;
            Point parent = layout.Location;
            leftP.Location = new Point(parent.X, parent.Y);
            rightP.Location = new Point(parent.X + leftP.Width, parent.Y);
            ResizePicture(pictureContainer);
            //底部工具栏调整
            XPPanel bottom= rightP.Controls.Find("bottomBarPanel",false)[0] as XPPanel;
            BottonsLocaltionChange(bottom);
            this.Refresh();//界面刷新
        }
        void ResizePicture(XPPanel contain)
        {
            /*
            根据容器来动态变化图片显示
            */
            int[] layoutSize = imageTables;
            int count = imageTables[0] * imageTables[1];
            if (SystemConfig.UseAutoSortImageArray)
            {
                layoutSize = new SystemConfig().ImageArray(contain.Width);
            }
            int row = layoutSize[0];//行数目
            int column = layoutSize[1];//列
            int heightSpanNum = (row - 1) * imageHeightSpan; //图片上下间隔总数
            int imageSize = row * column;
            for (int r = 0; r < row; r++) 
            {
                bool isEnd = false;
                for (int c = 0; c < column; c++)
                {
                    int index = c + r * column + 1;
                    if (index > count)
                    {
                        isEnd = true;
                        break;
                    }
                    string name = string.Format(imageIdFormat, index);//ele  id
                    Control[] ele = contain.Controls.Find(name, false);
                    if (ele.Length == 0)
                    {//实际上增加的元素数目少于自动调整窗体大小之后可以排放的数目
                        continue;
                    }
                    XPImagePanel pic = ele[0] as XPImagePanel;
                    pic.Location = new Point(c * imageWidth + imageWightSpan * c, imageHeight * r + imageHeightSpan * r);
                    pic.Width = imageWidth;
                    pic.Height = imageHeight;
                    if (index == count)
                    {
                       // pic.BackgroundImageLayout = ImageLayout.Zoom;
                    }
                    else if ( pic.BackgroundImage != null && pic.Width < pic.BackgroundImage.Width)
                    {//最后一张图片不需要进行自适应
                      //  pic.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                }
                if (isEnd)
                {
                    break;
                }
            }
            this.Refresh();
        }
        void BottonsLocaltionChange(XPPanel container)
        {
            int w = container.Parent.Width;
            Control.ControlCollection eles = container.Controls;
            int start = container.Parent.Location.X;
            int len = eles.Count;
            int avgW = (w-len*SystemConfig.MarginRight) / len;//减去元素间隔
            for (int i = 0; i <len; i++)
            {
                eles[i].Width = avgW;
                eles[i].Location = new Point(avgW*i+i*SystemConfig.MarginRight, eles[i].Location.Y);
            }
        }
        #endregion
        #region event
        void PictureSelect(object sender, EventArgs e)
        {
            #region 做标记 -选中与否
            XPImagePanel pb = sender as XPImagePanel;
            //上一次选中的元素是否为当前元素
            bool lastSelect = pb.IsClick;
            Graphics pictureborder = pb.CreateGraphics();
            Pen noSelect=new Pen(Color.White,4);//设置取消选中的背景色
            foreach (Control c in pb.Parent.Controls)
            {
                XPImagePanel p1 = c as XPImagePanel;
                if (pb != p1)
                {
                    Graphics pictureborder1 = p1.CreateGraphics();
                    if (noSelect == null)
                    {
                        noSelect = new Pen(p1.BackColor, 4);
                    }
                    pictureborder1.DrawRectangle(noSelect, p1.ClientRectangle.X,
                        p1.ClientRectangle.Y, p1.ClientRectangle.X + p1.ClientRectangle.Width,
                        p1.ClientRectangle.Y + p1.ClientRectangle.Height);
                    p1.IsClick = false;
                }
            }
            Pen pen =lastSelect?noSelect: new Pen(Color.Red, 4);
            pictureborder.DrawRectangle(pen, pb.ClientRectangle.X, pb.ClientRectangle.Y,
                pb.ClientRectangle.X + pb.ClientRectangle.Width,
                pb.ClientRectangle.Y + pb.ClientRectangle.Height);
            pb.IsClick = !pb.IsClick;
            #endregion
            #region 联动操作
            //特殊动作：选中最后一个图片时进行其他系统的交互，加载第三方的影像
           

            #endregion
        }
        void CommonPcitureBoxClick(object sender,EventArgs e)
        {
            PictureSelect(sender, e);//边框渲染
            XPImagePanel pic = sender as XPImagePanel;
            //判断是否进行的是取消
            if (pic.IsClick)
            {
                activePicture = string.Empty;
                ("Cancel "+pic.Name).WriteLog("ClickId");
                return;
            }
            activePicture = pic.Name;
            //影像窗体中传递参数为摆位图 +参数页面参数列表 传递给硬件api
            //影像联动曝光参数进行参数显示变动

            pic.Name.WriteLog("ClickId");
        }
        void AddPictureBoxClick(object sender,EventArgs e)
        {
            PictureSelect(sender, e);//边框渲染
            /*
            如果动作逻辑为动态加载影像（数目动态），则逻辑需要进行变动
            */
            XPImagePanel add = sender as XPImagePanel;
            add.Name.WriteLog("ClickId");
            string image = SystemConfig.DefaultImage;//这是执行新增获取到的图片路径【在实际应用中这个路径需要改动】
            if (SystemConfig.ImageSizeIsDynamic)
            {//如果动态
               
                Control parent = add.Parent;
                int pw = parent.Width;
                int[] matrix = new SystemConfig().ImageArray(pw);//排列数目
                int column = matrix[1];
                int margin = SystemConfig.ImageMarginRight;
                //判断是否能在最后一行添加图片：1 添加，并将新增图标后移，2 替换最后元素的位置
                Point temp = add.Location;
                int newW = temp.X + 2 * imageWidth + margin;
                XPImagePanel newp = new XPImagePanel(tipEleHeight)
                {
                    Location = new Point(temp.X, temp.Y),
                    Width = add.Width,
                    Height = add.Height,
                    Name = string.Format(imageIdFormat, parent.Controls.Count+1)
                };
                newp.RefreshDesc(DateTime.Now.ToString("yyyyMM"));
                newp.RefreshImage(image);
                //进行图片替换测试
                // SystemConfig.DeadAheadImg
                string ele = string.Format(imageIdFormat, parent.Controls.Count/2);
                (parent.Controls.Find(ele, false)[0] as XPImagePanel).RefreshImage(SystemConfig.DeadAheadImg);
                newp.Click += new EventHandler(CommonPcitureBoxClick);
                parent.Controls.Add(newp);
                if (newW <= pw)
                {
                    add.Location = new Point(temp.X + imageWidth + margin, temp.Y);
                }
                else
                {//这是要考虑的换行情形
                    add.Location = new Point(parent.Location.X, temp.Y + imageHeightSpan+imageHeight);
                }

            }
            //如果固定：按照顺序加载到图片列表中
            else
            {
                //对操作的下一个图片进行影像替换/加载
            }
        }
        #endregion
    }
    #region  this ext controls
    public class XPRichTextBox : RichTextBox
    { }
    public class XPImagePanel : XPPanel
    {
        public bool IsClick { get; set; }
        XPPictureBox Study { get; set; }
        XPTextBox descEle { get; set; }
        int descEleHeight;
        int penWight = 4;//画笔像素
        public XPImagePanel(int tipHeight)
        {
            SetLayout(tipHeight);
            this.SizeChanged += new EventHandler(SizeChange_Event);
            Study.Click += new EventHandler(StudyClick);
            Click += new EventHandler(PanelClick_event);
        }
        #region auto event
        void SetLayout(int descHeight)
        {
            descEleHeight = descHeight;
            Point local = this.Location;
            int w = this.Width;
            int h = this.Height;
            Study = new XPPictureBox();
            descEle = new XPTextBox()
            {
                ReadOnly = true,
                Visible=false,//先预设不显示提示框
            TextAlign = HorizontalAlignment.Center
            };
            if (descHeight < 1)
            {
                descEle.Hide();
            }
            AutoResize();
            this.Controls.Add(Study);
            this.Controls.Add(descEle);
        }
        void AutoResize()
        {
            Point local = this.Location;
            int w = this.Width;
            int h = this.Height;
            Study.Width = w - penWight;
            Study.Height = h - descEleHeight - penWight;
            Study.Location = new Point(local.X + penWight / 2, local.Y + penWight / 2);
            descEle.Location = new Point(local.X + penWight / 2, local.Y + (h - descEleHeight) - penWight / 2);
            descEle.Width = w - penWight;
        }
        void SizeChange_Event(object sender, EventArgs e)
        {
            AutoResize();
        }
        public void BindPanelClick(EventHandler PanelClick)
        {
            this.Click += new EventHandler(PanelClick);
        }
        #endregion
        #region update
        public void RefreshDesc(string desc)
        {
            descEle.Text = desc;
            descEle.Visible = !string.IsNullOrEmpty(desc);
        }
        public void RefreshImage(string imgDir)
        {
            Study.BackgroundImage = new Bitmap(imgDir);
            Study.Refresh();
            this.Refresh();
        }
        void StudyClick(object sender, EventArgs e)
        {
            this.OnClick(e);
        }
        void PanelClick_event(object sender, EventArgs e)
        {

        }
        #endregion
    }
    public class XPPictureBox : PictureBox
    {
        public bool IsClick { get; set; }
        XPTextBox lbl = null;
        int tipHeight = SystemConfig.TipEleHeight;
        public XPPictureBox(string desc = null)
        {
            AppendTipEle(desc);
        }
        public void AppendTipEle(string desc)
        {
            if (!string.IsNullOrEmpty(desc))
            {
                //增加label
                lbl = new XPTextBox() { Height = tipHeight, Text = desc, Name = "lblImgType", ForeColor = Color.Black };
                setLblPosotion();
                SizeChanged += new EventHandler(ContainSizeChange);
            }
        }
        void setLblPosotion()
        {
            Point pic = this.Location;
            Point lp = new Point(pic.X, pic.Y + this.Height - tipHeight);
            lbl.Location = lp;
            lbl.Width = this.Width;
            this.Controls.Add(lbl);
        }
        //窗体大小变动需要 调整描述显示的位置
        void ContainSizeChange(object sender, EventArgs e)
        {
            Point pic = this.Location;
            Point lp = new Point(pic.X, pic.Y + this.Height - tipHeight);
            lbl.Location = lp;
            lbl.Width = this.Width;
        }
    }
    #endregion
    #region 这是影像参数页面 -会与影像列表页进行互动
    public class StudyParamFrm
    {
        Control container;
        public StudyParamFrm(DockContent parent)
        {
            container = parent;
            //container.SizeChanged += new EventHandler(SizeChange_event);
           // InitLayout();
        }
        #region init page
        void InitLayout()
        {
            XPTableLayoutPanel lay = new XPTableLayoutPanel() { ColumnCount = 1, RowCount = 3,Name="table" ,Dock=DockStyle.Fill};
            XPPanel rulePanel = new XPPanel() { Name = "rulePanel",Dock=DockStyle.Fill };
            DrawRuleEle(rulePanel);
            lay.Controls.Add(rulePanel, 0, 0);
            XPPanel paramPanel = new XPPanel() { Name = "paramPanel", Dock = DockStyle.Fill };
            DrawParamArea(paramPanel);
            lay.Controls.Add(paramPanel, 0, 1);
            XPPanel msgPanel = new XPPanel() { Name = "msgPanel", Dock = DockStyle.Fill };
            lay.Controls.Add(msgPanel, 0, 2);

            container.Controls.Add(lay);
            container.Refresh();
        }
        #region head
        void DrawRuleEle(Control parent)
        {
            XPPanel rulePanel = new XPPanel() { Name = "rulePanel", Dock = DockStyle.Top };
            XPRichTextBox rule = new XPRichTextBox()
            {
                Text = "\t\tFPD工作状态\r\n\t正常、装备开窗、开窗、读窗",
                Location = parent.Location,
                Dock = DockStyle.Top,
                Enabled = false
            };
            rulePanel.Controls.Add(rule);
            parent.Controls.Add(rulePanel);
            XPRichTextBox statue = new XPRichTextBox()
            {
                Text = "\t\tGen工作状态\r\n\t正常、准备出线、出线、错误",
                BackColor = Color.FromArgb(204, 255, 255),
                Location = new Point(parent.Location.X,parent.Location.Y+30),
                Dock = DockStyle.Fill,
                Enabled=false
            };
            XPButton btn = new XPButton() { Text = "Reset",Name="btnReset",Dock=DockStyle.Right };
            btn.Click += new EventHandler(BtnReset);
            XPPanel statuePanel = new XPPanel() { Name = "statuePanel", Dock = DockStyle.Fill };
            statuePanel.Controls.Add(statue);
            statuePanel.Controls.Add(btn);
            parent.Controls.Add(statuePanel);//状态提示内容
            
        }
        #endregion
        #region param area
        void DrawParamArea(Control parent)
        {
            string[] actionBtns = new string[] { "Normal","Fatty","Dense"};
            string[] actionBtnsId = new string[] { "btnNormal", "btnFatty", "btnDense" };
            string[] lightBtns = new string[] { "AEC","Manual","Focus","Time","mAs" };
            string[] lightBtnsId = new string[] { "btnAEC", "btnManual", "btnFocus", "btnTime", "btnmAs" };
            XPPanel action = new XPPanel();
            Dictionary<string, string> actiondic = new Dictionary<string, string>();
            for (int i = 0; i < actionBtns.Length; i++)
            {
                actiondic.Add(actionBtnsId[i], actionBtns[i]);
            }
            DrawBtns(actiondic, action);
            Dictionary<string, string> lightdic = new Dictionary<string, string>();
            for (int i = 0; i < lightBtnsId.Length; i++)
            {
                lightdic.Add(lightBtnsId[i], lightBtns[i]);
            }
            DrawBtns(lightdic, action);
        }
        void DrawBtns(Dictionary<string,string> btns,Control parent)
        {
            int count = btns.Count;
            int c = 0;
            foreach (var item in btns)
            {
                c++;
                Point p = new Point(parent.Location.X + c * (SystemConfig.MarginRight) + 50);
                XPButton btn = new XPButton()
                {
                    Name = item.Key,
                    Text = item.Value,
                    Location=p
                };
                btn.Click += new EventHandler(Button_Click);
                parent.Controls.Add(btn);
            }
        }
        #endregion
        void InitText(Control target,string msg)
        {
            target.Text = msg;
        }
        void RefreshStatuePanel(Control target,string msg)
        {
            if (target.InvokeRequired)
            {//这是进行异步请求
                target.Invoke(new Action(()=>
                {
                    RefreshStatuePanel(target, msg);
                }));
                return;
            }
            target.Text = msg;
            target.Refresh();
        }
        #endregion
        #region size change event
        void SizeChange_event(object sender,EventArgs e)
        {
            //判断是否渲染了其他元素
            int w = container.Width;
            int h = container.Height;
            //0.2 0.5 0.3
            XPTableLayoutPanel table = container.Controls.Find("table",false)[0] as XPTableLayoutPanel ;
            table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0f));
            table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0f));
            table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.0f));
        }
        
        #endregion
        #region api response
        void BtnReset(object sender, EventArgs e)
        { }
        void Button_Click(object sender,EventArgs e)
        {

        }
        #endregion
    }
    #endregion
}
