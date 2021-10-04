using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BussinessLayer;
using DataLayer;
namespace THUEPHONG
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        SYS_USER _sysUser;
        
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Trim() == "")
            {
                MessageBox.Show("Tên đăng nhập không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            bool us = _sysUser.checkUserExist(txtUsername.Text.Trim());
            if (!us)
            {
                MessageBox.Show("Tên đăng nhập không tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //string pass = Encryptor.Encrypt(txtPassword.Text,"ffgfgfggf@12332",true);
            tb_SYS_USER user = _sysUser.getItem(txtUsername.Text.Trim(),txtPassword.Text);

            bool pass = _sysUser.checkUserExist(txtPassword.Text);
            if (pass ==true)
            {
                frmMain frm = new frmMain(user);
                frm.ShowDialog();
                this.Hide();
            }

            else
            {
                MessageBox.Show("Mật khẩu không đúng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }  
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            _sysUser = new SYS_USER();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}