using System;
using System.Drawing;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.Utils;
using DevExpress.Utils.Frames;
using DevExpress.Data.Utils;
using DevExpress.XtraPdfViewer;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Ribbon.ViewInfo;

namespace DXApp172703.Forms
{
    public partial class PdfViewerForm : RibbonForm
    {
        const string glyphImagePath = "{0}_16x16.png";
        const string largeGlyphImagePath = "{0}_32x32.png";

        static void StartProcess(string name)
        {
            try
            {
                Process process = new Process();
                ProcessStartInfo startInfo = process.StartInfo;
                startInfo.FileName = name + "?gldata=" + AssemblyInfo.VersionShort + "_DevExpress.XtraPdfViewer.Demos.Main|Winforms&platform=Winforms";
                startInfo.Arguments = String.Empty;
                startInfo.Verb = "Open";
                startInfo.WindowStyle = ProcessWindowStyle.Normal;
                process.Start();
            }
            catch
            {
            }
        }
        static Image GetImageFromResources(string imageName)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream stream = assembly.GetManifestResourceStream(imageName);
            if (stream == null)
                stream = assembly.GetManifestResourceStream("Images." + imageName);
            return ImageTool.ImageFromStream(stream);
        }
        static Stream GetDocumentStream()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream stream = assembly.GetManifestResourceStream("Demo.pdf");
            if (stream == null)
                return assembly.GetManifestResourceStream("Data.Demo.pdf");
            return stream;
        }

        readonly PopupMenu popupSkins = new PopupMenu();
        readonly BarCheckItem checkItemAllowFormSkins;
        readonly string mainFormText;

        public PdfViewerForm()
        {
            InitializeComponent();
            UpdateGlass();
            pdfViewer.DocumentCreator = "PDF Viewer Demo";
            pdfViewer.DocumentProducer = "Developer Express Inc., " + AssemblyInfo.Version;
            UserLookAndFeel.Default.SetSkinStyle("Office 2016 Colorful");
            pdfViewer.CreateRibbon();
            foreach (RibbonPage page in ribbonControl.Pages)
                if (page.Text == "PDF Viewer")
                {
                    popupSkins.BeginUpdate();
                    popupSkins.Ribbon = ribbonControl;
                    checkItemAllowFormSkins = new BarCheckItem(ribbonControl.Manager);
                    checkItemAllowFormSkins.Caption = "Allow Form Skins";
                    checkItemAllowFormSkins.ItemClick += new ItemClickEventHandler(OnAllowFormSkinsItemClick);
                    popupSkins.AddItem(checkItemAllowFormSkins);
                    SkinHelper.InitSkinPopupMenu(popupSkins);
                    popupSkins.ItemLinks[1].BeginGroup = true;
                    popupSkins.EndUpdate();
                    popupSkins.Popup += new EventHandler(OnPmSkinsPopup);
                    RibbonPageGroup skinsPage = new RibbonPageGroup(ribbonGallerySkins.Caption);
                    SkinHelper.InitSkinGallery(ribbonGallerySkins, true);
                    skinsPage.CaptionButtonClick += new RibbonPageGroupEventHandler(OnSkinsPageCaptionButtonClick);
                    skinsPage.ItemLinks.Add(ribbonGallerySkins);
                    RibbonPageGroup devExpressPage = new RibbonPageGroup("DevExpress");
                    devExpressPage.ShowCaptionButton = false;
                    AddBarItem(devExpressPage, "Getting Started", "GetStarted", OnGettingStartedItemClicked);
                    AddBarItem(devExpressPage, "Get Free Support", "GetSupport", OnGetFreeSupportItemClicked);
                    AddBarItem(devExpressPage, "Buy Now", "BuyNow", OnBuyNowItemClicked);
                    AddBarItem(devExpressPage, "About", "Info", OnAboutItemClicked);
                    page.Groups.AddRange(new RibbonPageGroup[] { skinsPage, devExpressPage });
                    break;
                }
            mainFormText = Text;
            pdfViewer.DocumentChanged += new PdfDocumentChangedEventHandler(OnPdfViewerDocumentChanged);
            pdfViewer.UriOpening += OnPdfViewerUriOpening;
            pdfViewer.LoadDocument(GetDocumentStream());
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (pdfViewer.IsDocumentChanged)
                e.Cancel = !pdfViewer.ShowDocumentClosingWarning();
        }
        void AddBarItem(RibbonPageGroup page, string caption, string imageName, ItemClickEventHandler handler)
        {
            BarButtonItem item = new BarButtonItem(ribbonControl.Manager, caption);
            item.Glyph = GetImageFromResources(String.Format(glyphImagePath, imageName));
            item.LargeGlyph = GetImageFromResources(String.Format(largeGlyphImagePath, imageName));
            item.ItemClick += handler;
            page.ItemLinks.Add(item);
        }
        void UpdateGlass()
        {
            AllowFormGlass = SkinManager.AllowFormSkins ? DefaultBoolean.False : DefaultBoolean.True;
        }
        void OnPdfViewerUriOpening(object sender, PdfUriOpeningEventArgs e)
        {
            Uri uri = e.Uri;
            e.Handled = uri.IsAbsoluteUri && String.Compare(uri.AbsoluteUri, AssemblyInfo.DXLinkGetStarted, true) == 0;
        }
        void OnPdfViewerDocumentChanged(object sender, PdfDocumentChangedEventArgs e)
        {
            string fileName = Path.GetFileName(e.DocumentFilePath);
            if (String.IsNullOrEmpty(fileName))
                Text = mainFormText;
            else
                Text = fileName + " - " + mainFormText;
        }
        void OnRibbonControlPaint(object sender, PaintEventArgs e)
        {

        }
        void OnPmSkinsPopup(object sender, EventArgs e)
        {
            checkItemAllowFormSkins.Checked = SkinManager.AllowFormSkins;
            string activeSkinName = UserLookAndFeel.Default.ActiveSkinName;
            checkItemAllowFormSkins.Enabled = !activeSkinName.Contains("Office 2013") && !activeSkinName.Contains("Office 2016");
        }
        void OnAllowFormSkinsItemClick(object sender, ItemClickEventArgs e)
        {
            if (SkinManager.AllowFormSkins)
                SkinManager.DisableFormSkins();
            else
                SkinManager.EnableFormSkins();
            UpdateGlass();
        }
        void OnSkinsPageCaptionButtonClick(object sender, RibbonPageGroupEventArgs e)
        {
            popupSkins.ShowPopup(MousePosition);
        }
        void OnGettingStartedItemClicked(object sender, ItemClickEventArgs e)
        {
            StartProcess(AssemblyInfo.DXLinkGetStarted);
        }
        void OnGetFreeSupportItemClicked(object sender, ItemClickEventArgs e)
        {
            StartProcess(AssemblyInfo.DXLinkGetSupport);
        }
        void OnBuyNowItemClicked(object sender, ItemClickEventArgs e)
        {
            StartProcess(AssemblyInfo.DXLinkBuyNow);
        }
        void OnAboutItemClicked(object sender, ItemClickEventArgs e)
        {
            PdfViewer.About();
        }
    }
}
