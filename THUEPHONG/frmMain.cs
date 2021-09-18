using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using BussinessLayer;
using DevExpress.XtraNavBar;
using DevExpress.Utils.Drawing;
using DevExpress.XtraBars.Ribbon;
using DataLayer;
using System.Collections.Generic;
using DevExpress.XtraBars.Ribbon.ViewInfo;

namespace THUEPHONG
{
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        TANG _tang;
        PHONG _phong;
        FUNC _func;
        GalleryItem  item = null;

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            _tang = new TANG();
            _phong = new PHONG();
             _func = new FUNC();
            leftMenu();
            showRoom();
        }
        void leftMenu()
        {
            int i = 0;
            var _lsParent = _func.getParent();
            foreach(var _pr in _lsParent)
            {
                NavBarGroup navBar = new NavBarGroup(_pr.DESCRIPTION);
                navBar.Tag = _pr.FUNC_CODE;
                navBar.Name = _pr.FUNC_CODE;
                navBar.ImageOptions.LargeImageIndex = i;
                i++;
                navBarMain.Groups.Add(navBar);

                var _lsChild = _func.getChild(_pr.FUNC_CODE);
                foreach(var _ch in _lsChild)
                {
                    NavBarItem navItem = new NavBarItem(_ch.DESCRIPTION);
                    navItem.Tag = _ch.FUNC_CODE;
                    navItem.Name = _ch.FUNC_CODE;
                    navItem.ImageOptions.SmallImageIndex = 0;
                    navBar.ItemLinks.Add(navItem);
                }
                navBarMain.Groups[navBar.Name].Expanded = true;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void showRoom()
        {
            var lsTang = _tang.getAll();
            gControl.Gallery.ItemImageLayout = ImageLayoutMode.ZoomInside;
            gControl.Gallery.ImageSize = new Size(64, 64);
            gControl.Gallery.ShowItemText = true;
            gControl.Gallery.ShowGroupCaption = true;
            foreach(var t in lsTang)
            {
                var galleryItem = new GalleryItemGroup();
                galleryItem.Caption = t.TENTANG;
                galleryItem.CaptionAlignment = GalleryItemGroupCaptionAlignment.Stretch;
                List <tb_Phong> lsPhong = _phong.getByTang(t.IDTANG);
                foreach (var p in lsPhong)
                {
                    var gc_item = new GalleryItem();
                    gc_item.Caption = p.TENPHONG;
                    gc_item.Value = p.IDPHONG;
                    if (p.STATUS == true)
                        gc_item.ImageOptions.Image = imageList3.Images[1];
                    else
                        gc_item.ImageOptions.Image = imageList3.Images[0];
                    galleryItem.Items.Add(gc_item);
                }
                gControl.Gallery.Groups.Add(galleryItem);
            }
            
        }

        private void navBarMain_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            string func_code = e.Link.Item.Tag.ToString();
            switch (func_code)
            {
                case "CONGTY":
                    {
                        frmCongTy frm = new frmCongTy();
                        frm.ShowDialog();
                        break;
                    }
                case "DONVI":
                    {
                         frmDonVi frm = new frmDonVi();
                        frm.ShowDialog();
                        break;
                    }
            }
        }

        private void popupMenu1_Popup(object sender, EventArgs e)
        {
            Point point = gControl.PointToClient(Control.MousePosition);
            RibbonHitInfo hitInfo = gControl.CalcHitInfo(point);
            if (hitInfo.InGalleryItem || hitInfo.HitTest == RibbonHitTest.GalleryImage)
                item = hitInfo.GalleryItem;
        }

        private void btnDatPhong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var gc_item = new GalleryItem();
            string id = item.Value.ToString();
            MessageBox.Show(id);
        }
    }
}
