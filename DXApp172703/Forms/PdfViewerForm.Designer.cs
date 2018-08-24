namespace DXApp172703.Forms
{
    partial class PdfViewerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ribbonGallerySkins = new DevExpress.XtraBars.RibbonGalleryBarItem();
            this.pdfViewer = new DevExpress.XtraPdfViewer.PdfViewer();
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonGallerySkins
            // 
            this.ribbonGallerySkins.Caption = "Skins";
            this.ribbonGallerySkins.Id = 1;
            this.ribbonGallerySkins.Name = "ribbonGallerySkins";
            // 
            // pdfViewer
            // 
            this.pdfViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfViewer.Location = new System.Drawing.Point(0, 50);
            this.pdfViewer.Name = "pdfViewer";
            this.pdfViewer.NavigationPaneWidth = 303;
            this.pdfViewer.Size = new System.Drawing.Size(800, 400);
            this.pdfViewer.TabIndex = 3;
            this.pdfViewer.ZoomMode = DevExpress.XtraPdfViewer.PdfZoomMode.FitToWidth;
            // 
            // ribbonControl
            // 
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.ribbonGallerySkins});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.MaxItemId = 2;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.ribbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl.Size = new System.Drawing.Size(800, 50);
            this.ribbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // PdfViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pdfViewer);
            this.Controls.Add(this.ribbonControl);
            this.Name = "PdfViewerForm";
            this.Ribbon = this.ribbonControl;
            this.Text = "PdfViewerForm";
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.RibbonGalleryBarItem ribbonGallerySkins;
        private DevExpress.XtraPdfViewer.PdfViewer pdfViewer;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
    }
}