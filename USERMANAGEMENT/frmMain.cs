using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BussinessLayer;
using DataLayer;
using USERMANAGEMENT.MyComments;
namespace USERMANAGEMENT
{
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        MyTreeViewCombo _treeView;
        CONGTY _conty;
        DONVI _donvi;
        bool _isRoot;
        string _macty;
        string _madvi;
        private void frmMain_Load(object sender, EventArgs e)
        {
            _conty = new CONGTY();
            _donvi = new DONVI();
            _isRoot = true;
            loadTreeView();
        }

        void loadTreeView()
        {
            _treeView = new MyTreeViewCombo(pnNhom.Width, 300);
            _treeView.Font = new Font("Tahoma",10,FontStyle.Bold);
            var lstCTY = _conty.getAll();
            foreach (var item in lstCTY)
            {
                TreeNode parentNode = new TreeNode();
                parentNode.Text = item.MACTY + " - " + item.TENCTY;
                parentNode.Tag = item.MACTY;
                parentNode.Name = item.MACTY;
                _treeView.TreeView.Nodes.Add(parentNode);
                foreach(var dv in _donvi.getAll(item.MACTY))
                {
                    TreeNode childNode = new TreeNode();
                    childNode.Text = dv.MADVI + " - " + dv.MADVI;
                    childNode.Tag = dv.MADVI;
                    childNode.Name = dv.MADVI;
                    _treeView.TreeView.Nodes[parentNode.Name].Nodes.Add(childNode);
                }
            }
            _treeView.TreeView.ExpandAll();
            pnNhom.Controls.Add(_treeView);
            _treeView.Width = pnNhom.Width;
            _treeView.Height = pnNhom.Height;
            _treeView.TreeView.AfterSelect += TreeView_AfterSelect;
        }

        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            _treeView.Text = _treeView.TreeView.SelectedNode.Text;
            if (_treeView.TreeView.SelectedNode.Parent==null)
            {
                _isRoot = true;
                _macty = _treeView.TreeView.SelectedNode.Tag.ToString();
                _madvi = "~";

            }
            else
            {

            }
        }

        private void btnGroup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnUser_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnCapNhat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnChucNang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnBaoCao_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnThoát_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        
    }
}
