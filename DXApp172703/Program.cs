using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;

namespace DXApp172703
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);


            //新建的form继承dev的样式
            SkinManager.EnableFormSkins();
            SkinManager.EnableMdiFormSkins();
            BonusSkins.Register();
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
            Application.EnableVisualStyles();
            //用于新控件的默认值。 
            //如果为 true，则支持 UseCompatibleTextRendering 的新控件使用基于 GDI+ 的 Graphics 类进行文本呈现；
            //如果为 false，则新控件使用基于 GDI 的 TextRenderer 类。
            Application.SetCompatibleTextRenderingDefault(false);



            #region 设置默认字体、日期格式、汉化dev
            DevExpress.Utils.AppearanceObject.DefaultFont = new System.Drawing.Font("Tahoma", 9);
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-Hans");  //使用DEV汉化资源文件
            //设置程序区域语言设置中日期格式
            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("zh-Hans");
            System.Globalization.DateTimeFormatInfo di = (System.Globalization.DateTimeFormatInfo)System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.Clone();
            di.DateSeparator = "-";
            di.ShortDatePattern = "yyyy-MM-dd";
            di.LongDatePattern = "yyyy'年'M'月'd'日'";
            di.ShortTimePattern = "H:mm:ss";
            di.LongTimePattern = "H'时'mm'分'ss'秒'";
            ci.DateTimeFormat = di;
            System.Threading.Thread.CurrentThread.CurrentCulture = ci;
            #endregion


            //运行主框架窗口frmMain
            //先登录在进入主框架窗口loginForm
            Application.Run(new LoginForm());

            //try
            //{
            //    LoginForm loginform = new LoginForm();

            //    if (args.Length == 0)
            //    {
            //        loginform = new LoginForm();
            //        loginform.ShowDialog();
            //        if (loginform.DialogResult == DialogResult.OK)
            //        {
            //            Application.Run(new frmMain());
            //        }
            //    }
            //    else
            //    {
            //        loginform = new LoginForm(args);
            //        if (loginform.Open)
            //        {
            //            Application.Run(new frmMain(loginform.account));
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception(ex.Message);
            //}


        }


        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            //MessageBox.Show("抱歉，您的操作没有能够完成，请再试一次或者联系软件提供商");
            LogUnhandledException(e.ExceptionObject);
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            //MessageBox.Show("抱歉，您的操作没有能够完成，请再试一次或者联系软件提供商");
            LogUnhandledException(e.Exception);
        }

        static void LogUnhandledException(object exceptionobj)
        {
            MessageBox.Show(exceptionobj.ToString());
            //Log the exception here or report it to developer
        }

    }
}
