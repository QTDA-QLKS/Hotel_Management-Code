
namespace USERMANAGEMENT
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnGroup = new DevExpress.XtraBars.BarButtonItem();
            this.btnUser = new DevExpress.XtraBars.BarButtonItem();
            this.btnCapNhat = new DevExpress.XtraBars.BarButtonItem();
            this.btnChucNang = new DevExpress.XtraBars.BarButtonItem();
            this.btnBaoCao = new DevExpress.XtraBars.BarButtonItem();
            this.btnThoát = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnNhom = new System.Windows.Forms.Panel();
            this.gcUser = new DevExpress.XtraGrid.GridControl();
            this.gvUser = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.DISABLED = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IDUSER = new DevExpress.XtraGrid.Columns.GridColumn();
            this.USERNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FULLNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MACTY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MADVI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ISGROUP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUser)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.btnGroup,
            this.btnUser,
            this.btnCapNhat,
            this.btnChucNang,
            this.btnBaoCao,
            this.btnThoát});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 8;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(864, 150);
            // 
            // btnGroup
            // 
            this.btnGroup.Caption = "Nhóm người dùng";
            this.btnGroup.Id = 1;
            this.btnGroup.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGroup.ImageOptions.Image")));
            this.btnGroup.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnGroup.ImageOptions.LargeImage")));
            this.btnGroup.Name = "btnGroup";
            this.btnGroup.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnGroup.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGroup_ItemClick);
            // 
            // btnUser
            // 
            this.btnUser.Caption = "Người dùng";
            this.btnUser.Id = 2;
            this.btnUser.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnUser.ImageOptions.Image")));
            this.btnUser.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnUser.ImageOptions.LargeImage")));
            this.btnUser.Name = "btnUser";
            this.btnUser.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnUser.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnUser_ItemClick);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Caption = "Cập nhật thông tin";
            this.btnCapNhat.Id = 3;
            this.btnCapNhat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCapNhat.ImageOptions.Image")));
            this.btnCapNhat.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnCapNhat.ImageOptions.LargeImage")));
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnCapNhat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCapNhat_ItemClick);
            // 
            // btnChucNang
            // 
            this.btnChucNang.Caption = "Phân quyền chức năng";
            this.btnChucNang.Id = 5;
            this.btnChucNang.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnChucNang.ImageOptions.Image")));
            this.btnChucNang.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnChucNang.ImageOptions.LargeImage")));
            this.btnChucNang.Name = "btnChucNang";
            this.btnChucNang.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnChucNang.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnChucNang_ItemClick);
            // 
            // btnBaoCao
            // 
            this.btnBaoCao.Caption = "Phân quyền báo cáo";
            this.btnBaoCao.Id = 6;
            this.btnBaoCao.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBaoCao.ImageOptions.Image")));
            this.btnBaoCao.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnBaoCao.ImageOptions.LargeImage")));
            this.btnBaoCao.Name = "btnBaoCao";
            this.btnBaoCao.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnBaoCao.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBaoCao_ItemClick);
            // 
            // btnThoát
            // 
            this.btnThoát.Caption = "Thoát";
            this.btnThoát.Id = 7;
            this.btnThoát.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThoát.ImageOptions.Image")));
            this.btnThoát.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnThoát.ImageOptions.LargeImage")));
            this.btnThoát.Name = "btnThoát";
            this.btnThoát.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnThoát.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThoát_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup3});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Chức năng";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ribbonPageGroup1.ImageOptions.Image")));
            this.ribbonPageGroup1.ItemLinks.Add(this.btnGroup, true);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnUser, true);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnCapNhat, true);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Tài khoản";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnChucNang, true);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnBaoCao, true);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Phân Quyền";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.btnThoát);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "Hệ thống";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pnNhom);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 150);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(864, 31);
            this.panel1.TabIndex = 1;
            // 
            // pnNhom
            // 
            this.pnNhom.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnNhom.Location = new System.Drawing.Point(609, 0);
            this.pnNhom.Name = "pnNhom";
            this.pnNhom.Size = new System.Drawing.Size(255, 31);
            this.pnNhom.TabIndex = 0;
            // 
            // gcUser
            // 
            this.gcUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcUser.Location = new System.Drawing.Point(0, 181);
            this.gcUser.MainView = this.gvUser;
            this.gcUser.MenuManager = this.ribbonControl1;
            this.gcUser.Name = "gcUser";
            this.gcUser.Size = new System.Drawing.Size(864, 293);
            this.gcUser.TabIndex = 2;
            this.gcUser.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvUser});
            // 
            // gvUser
            // 
            this.gvUser.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.DISABLED,
            this.IDUSER,
            this.USERNAME,
            this.FULLNAME,
            this.MACTY,
            this.MADVI,
            this.ISGROUP});
            this.gvUser.GridControl = this.gcUser;
            this.gvUser.Name = "gvUser";
            this.gvUser.OptionsView.ShowGroupPanel = false;
            // 
            // DISABLED
            // 
            this.DISABLED.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.DISABLED.AppearanceHeader.Options.UseFont = true;
            this.DISABLED.Caption = "DIS";
            this.DISABLED.FieldName = "DISABLED";
            this.DISABLED.MaxWidth = 35;
            this.DISABLED.MinWidth = 35;
            this.DISABLED.Name = "DISABLED";
            this.DISABLED.Visible = true;
            this.DISABLED.VisibleIndex = 0;
            this.DISABLED.Width = 35;
            // 
            // IDUSER
            // 
            this.IDUSER.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.IDUSER.AppearanceHeader.Options.UseFont = true;
            this.IDUSER.Caption = "ID";
            this.IDUSER.FieldName = "IDUSER";
            this.IDUSER.Name = "IDUSER";
            // 
            // USERNAME
            // 
            this.USERNAME.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.USERNAME.AppearanceHeader.Options.UseFont = true;
            this.USERNAME.Caption = "USERNAME";
            this.USERNAME.FieldName = "USERNAME";
            this.USERNAME.MaxWidth = 150;
            this.USERNAME.MinWidth = 100;
            this.USERNAME.Name = "USERNAME";
            this.USERNAME.Visible = true;
            this.USERNAME.VisibleIndex = 1;
            this.USERNAME.Width = 100;
            // 
            // FULLNAME
            // 
            this.FULLNAME.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.FULLNAME.AppearanceHeader.Options.UseFont = true;
            this.FULLNAME.Caption = "FULLNAME";
            this.FULLNAME.FieldName = "FULLNAME";
            this.FULLNAME.MaxWidth = 250;
            this.FULLNAME.MinWidth = 150;
            this.FULLNAME.Name = "FULLNAME";
            this.FULLNAME.Visible = true;
            this.FULLNAME.VisibleIndex = 2;
            this.FULLNAME.Width = 150;
            // 
            // MACTY
            // 
            this.MACTY.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.MACTY.AppearanceHeader.Options.UseFont = true;
            this.MACTY.Caption = "MACTY";
            this.MACTY.FieldName = "MACTY";
            this.MACTY.Name = "MACTY";
            // 
            // MADVI
            // 
            this.MADVI.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.MADVI.AppearanceHeader.Options.UseFont = true;
            this.MADVI.Caption = "MADVI";
            this.MADVI.FieldName = "MADVI";
            this.MADVI.Name = "MADVI";
            // 
            // ISGROUP
            // 
            this.ISGROUP.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.ISGROUP.AppearanceHeader.Options.UseFont = true;
            this.ISGROUP.Caption = "GROUP";
            this.ISGROUP.FieldName = "ISGROUP";
            this.ISGROUP.MaxWidth = 60;
            this.ISGROUP.MinWidth = 40;
            this.ISGROUP.Name = "ISGROUP";
            this.ISGROUP.Visible = true;
            this.ISGROUP.VisibleIndex = 3;
            this.ISGROUP.Width = 50;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(542, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "ĐƠN VỊ";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 474);
            this.Controls.Add(this.gcUser);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "frmMain";
            this.Text = "Quản lí người dùng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem btnGroup;
        private DevExpress.XtraBars.BarButtonItem btnUser;
        private DevExpress.XtraBars.BarButtonItem btnCapNhat;
        private DevExpress.XtraBars.BarButtonItem btnChucNang;
        private DevExpress.XtraBars.BarButtonItem btnBaoCao;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem btnThoát;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnNhom;
        private DevExpress.XtraGrid.GridControl gcUser;
        private DevExpress.XtraGrid.Views.Grid.GridView gvUser;
        private DevExpress.XtraGrid.Columns.GridColumn DISABLED;
        private DevExpress.XtraGrid.Columns.GridColumn IDUSER;
        private DevExpress.XtraGrid.Columns.GridColumn USERNAME;
        private DevExpress.XtraGrid.Columns.GridColumn FULLNAME;
        private DevExpress.XtraGrid.Columns.GridColumn MACTY;
        private DevExpress.XtraGrid.Columns.GridColumn MADVI;
        private DevExpress.XtraGrid.Columns.GridColumn ISGROUP;
        private System.Windows.Forms.Label label1;
    }
}

