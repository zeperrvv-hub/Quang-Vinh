using System;
using System.Windows.Forms;

namespace BaiTap4_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                cboCourse.DataSource = DatabaseHelper.GetCourses();
                cboCourse.DisplayMember = "CourseName";
                cboCourse.ValueMember = "CourseId";
                cboCourse.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải danh sách khóa học.\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            bool valid = true;

            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                errorProvider1.SetError(txtFullName, "Vui lòng nhập họ tên.");
                valid = false;
            }

            if (!mtxtPhone.MaskFull)
            {
                errorProvider1.SetError(mtxtPhone, "Vui lòng nhập đủ số điện thoại.");
                valid = false;
            }

            if (cboCourse.SelectedIndex == -1)
            {
                errorProvider1.SetError(cboCourse, "Vui lòng chọn khóa học.");
                valid = false;
            }

            if (!radMale.Checked && !radFemale.Checked)
            {
                errorProvider1.SetError(radMale, "Vui lòng chọn giới tính.");
                valid = false;
            }

            if (!chkOnline.Checked && !chkOffline.Checked)
            {
                errorProvider1.SetError(chkOnline, "Vui lòng chọn hình thức học.");
                valid = false;
            }

            if (chkOnline.Checked && chkOffline.Checked)
            {
                errorProvider1.SetError(
                    chkOnline,
                    "Chỉ chọn một hình thức học.");
                valid = false;
            }

            if (!valid)
            {
                MessageBox.Show(
                    "Vui lòng kiểm tra lại thông tin.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string gender = radMale.Checked ? "Nam" : "Nữ";
            string studyMode = chkOnline.Checked ? "Trực tuyến" : "Trực tiếp";
            Course course = cboCourse.SelectedItem as Course;

            try
            {
                DatabaseHelper.SaveRegistration(
                    txtFullName.Text.Trim(),
                    mtxtPhone.Text,
                    dtpBirthDate.Value,
                    gender,
                    course.CourseId,
                    studyMode);

                MessageBox.Show(
                    "Đăng ký thành công!\n\n" +
                    "Họ tên: " + txtFullName.Text.Trim() + "\n" +
                    "Số điện thoại: " + mtxtPhone.Text + "\n" +
                    "Ngày sinh: " + dtpBirthDate.Value.ToString("dd/MM/yyyy") + "\n" +
                    "Giới tính: " + gender + "\n" +
                    "Khóa học: " + course.CourseName + "\n" +
                    "Hình thức học: " + studyMode,
                    "Kết quả đăng ký",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                txtFullName.Clear();
                mtxtPhone.Clear();
                dtpBirthDate.Value = DateTime.Today;
                cboCourse.SelectedIndex = -1;
                radMale.Checked = false;
                radFemale.Checked = false;
                chkOnline.Checked = false;
                chkOffline.Checked = false;
                txtFullName.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể lưu thông tin đăng ký.\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
