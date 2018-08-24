using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraTabbedMdi;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraNavBar;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors.ColorWheel;

namespace DXApp172703
{
    public partial class testForm : DevExpress.XtraEditors.XtraForm
    {
        private DateTime m_LastClick = System.DateTime.Now;
        private XtraMdiTabPage m_lastPage = null;
        public testForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitTabbedMDI();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            InitTabbedMDI();
        }

        /// <summary>
        /// 默认加载主窗口
        /// </summary>
        void InitTabbedMDI()
        {
            Form childForm = new ChildForm();
            AddPageMdiBarItem(childForm, bbchildForm);

            //xtraTabbedMdiManager1.MdiParent = this;   //设置控件的父表单..
            //this.xtraTabbedMdiManager1.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPagesAndTabControlHeader;    //设置标签后面添加删除按钮 ,  多个标签只需要设置一次..
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form childForm = new ChildForm();
            AddPageMdiBarItem(childForm, e.Link.Item);

        }



        // 打开子窗体方法BarItem
        private void AddPageMdiBarItem(Form childForm, BarItem barItem)
        {
            childForm.MdiParent = this;
            // 子窗体的 Text  就是 Tab页中的标题 ,我这里是直接取 navItem中的标题作为 tab页的标题
            childForm.Text = barItem.Caption;
            //显示图标
            xtraTabbedMdiManager1.Pages[childForm].Image = barItem.ImageOptions.LargeImage;
            // 显示 
            childForm.Show();
        }

        // 打开子窗体方法NavBarItem
        private void AddPageMdiNavBarItem(Form childForm, NavBarItem barItem)
        {
            childForm.MdiParent = this;
            // 子窗体的 Text  就是 Tab页中的标题 ,我这里是直接取 navItem中的标题作为 tab页的标题
            childForm.Text = barItem.Caption;
            //显示图标
            xtraTabbedMdiManager1.Pages[childForm].Image = barItem.ImageOptions.LargeImage;
            // 显示 
            childForm.Show();
        }

        private void ribbon_Merge(object sender, DevExpress.XtraBars.Ribbon.RibbonMergeEventArgs e)
        {
            RibbonControl parentRRibbon = sender as RibbonControl;
            RibbonControl childRibbon = e.MergedChild;
            parentRRibbon.StatusBar.MergeStatusBar(childRibbon.StatusBar);
        }

        private void ribbon_UnMerge(object sender, RibbonMergeEventArgs e)
        {
            RibbonControl parentRRibbon = sender as RibbonControl;
            parentRRibbon.StatusBar.UnMergeStatusBar();

        }

        private void navBarItem8_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Form childForm = new ChildForm();
            AddPageMdiNavBarItem(childForm, e.Link.Item);

        }

        /// <summary>
        /// 添加双击页签时,关闭页签事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xtraTabbedMdiManager1_MouseDown(object sender, MouseEventArgs e)
        {
            XtraMdiTabPage curPage = (sender as XtraTabbedMdiManager).SelectedPage;

            if (e.Button == MouseButtons.Left)
            {

                DateTime dt = DateTime.Now;
                TimeSpan span = dt.Subtract(m_LastClick);
                if (span.TotalMilliseconds < 300)  //如果两次点击的时间间隔小于300毫秒，则认为是双击
                {


                    if (this.MdiChildren.Length > 1)
                    {

                        // 限制只有在同一个页签上双击才能关闭.(规避两个页签切换时点太快导致意外关闭页签)
                        if (curPage.Equals(m_lastPage))
                        {
                            //if (this.ActiveMdiChild != m_MapForm)
                            //{
                            this.ActiveMdiChild.Close();
                            //}

                        }
                    }
                    m_LastClick = dt.AddMinutes(-1);
                }
                else
                {
                    m_LastClick = dt;
                    m_lastPage = curPage;
                }
            }
        }

        private void navBarItem9_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Form childForm = new tabbrowse();
            AddPageMdiNavBarItem(childForm, e.Link.Item);

        }


        private void bbColorMix_ItemClick(object sender, ItemClickEventArgs e)
        {
            ColorWheelForm form = new ColorWheelForm();
            form.StartPosition = FormStartPosition.CenterParent;
            form.SkinMaskColor = UserLookAndFeel.Default.SkinMaskColor;
            form.SkinMaskColor2 = UserLookAndFeel.Default.SkinMaskColor2;
            form.ShowDialog(this);
        }

        private void bbPdfViewer_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form childForm = new Forms.PdfViewerForm();
            AddPageMdiBarItem(childForm, e.Link.Item);


        }

        private void bbchildForm_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form childForm = new ChildForm();
            AddPageMdiBarItem(childForm, bbchildForm);
        }



        ////关闭事件里，阻止之间关闭按钮（为了使得用户单机右下角的退出时，能够退出，所以必须使用CloseReason属性）
        //private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        //{

        //    if (e.CloseReason == CloseReason.ApplicationExitCall)
        //    {
        //        Application.Exit();
        //    }
        //    else
        //    {
        //        e.Cancel = true;
        //        this.WindowState = FormWindowState.Minimized;
        //        this.Hide();
        //       // this.notifyIcon1.Visible = true;
        //    }


        //}


        ////双击icon还原
        //private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        //{

        //   // notifyIcon1.Visible = true;
        //    this.Show();
        //    this.Activate();
        //    this.WindowState = FormWindowState.Normal;
        //}

        ////右下角单机退出时，运行退出
        //private void AppExit_Click(object sender, EventArgs e)
        //{
        //    Application.Exit();
        //}
    }
}

