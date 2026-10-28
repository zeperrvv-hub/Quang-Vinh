
using System;
using System.Windows.Forms;
using Npgsql;

namespace BaiTap4_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            chkShowPassword.CheckedChanged +=
                chkShowPassword_CheckedChanged;

            btnLogin.Click += btnLogin_Click;
            btnExit.Click += btnExit_Click;

            txtUsername.TextChanged +=
                txtUsername_TextChanged;

            txtPassword.TextChanged +=
                txtPassword_TextChanged;

            try
            {
                DatabaseHelper.InitializeDatabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể kết nối CSDL PostgreSQL.\n" + ex.Message,
                    "Lỗi kết nối",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void chkShowPassword_CheckedChanged(
            object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar =
                !chkShowPassword.Checked;
        }

        private bool ValidateInput()
        {
            errorProvider1.Clear();

            bool valid = true;

            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                errorProvider1.SetError(
                    txtUsername, "Vui lòng nhập tên đăng nhập.");

                valid = false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                errorProvider1.SetError(
                    txtPassword, "Vui lòng nhập mật khẩu.");

                valid = false;
            }

            if (!valid)
            {
                if (string.IsNullOrWhiteSpace(txtUsername.Text))
                    txtUsername.Focus();
                else
                    txtPassword.Focus();
            }

            return valid;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            btnLogin.Enabled = false;

            try
            {
                bool success = DatabaseHelper.Login(
                    txtUsername.Text.Trim(),
                    txtPassword.Text);

                if (success)
                {
                    MessageBox.Show(
                        "Đăng nhập thành công!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(
                        "Tên đăng nhập hoặc mật khẩu không đúng.",
                        "Đăng nhập thất bại",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(
                    "Lỗi PostgreSQL: " + ex.Message,
                    "Lỗi CSDL",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi: " + ex.Message,
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                btnLogin.Enabled = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtUsername_TextChanged(
            object sender, EventArgs e)
        {
            errorProvider1.SetError(txtUsername, "");
        }

        private void txtPassword_TextChanged(
            object sender, EventArgs e)
        {
            errorProvider1.SetError(txtPassword, "");
        }
    }
}
