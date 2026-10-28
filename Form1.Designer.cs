namespace BaiTap4_2
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblBirthDate = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblCourse = new System.Windows.Forms.Label();
            this.lblStudyMode = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.mtxtPhone = new System.Windows.Forms.MaskedTextBox();
            this.dtpBirthDate = new System.Windows.Forms.DateTimePicker();
            this.radMale = new System.Windows.Forms.RadioButton();
            this.radFemale = new System.Windows.Forms.RadioButton();
            this.cboCourse = new System.Windows.Forms.ComboBox();
            this.chkOnline = new System.Windows.Forms.CheckBox();
            this.chkOffline = new System.Windows.Forms.CheckBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(105, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(290, 26);
            this.lblTitle.Text = "ĐĂNG KÝ KHÓA HỌC";

            this.lblFullName.AutoSize = true;
            this.lblFullName.Location = new System.Drawing.Point(35, 80);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(54, 16);
            this.lblFullName.Text = "Họ tên:";

            this.txtFullName.Location = new System.Drawing.Point(160, 76);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(260, 22);

            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(35, 120);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(82, 16);
            this.lblPhone.Text = "Điện thoại:";

            this.mtxtPhone.Location = new System.Drawing.Point(160, 116);
            this.mtxtPhone.Mask = "(000) 000-0000";
            this.mtxtPhone.Name = "mtxtPhone";
            this.mtxtPhone.Size = new System.Drawing.Size(260, 22);

            this.lblBirthDate.AutoSize = true;
            this.lblBirthDate.Location = new System.Drawing.Point(35, 160);
            this.lblBirthDate.Name = "lblBirthDate";
            this.lblBirthDate.Size = new System.Drawing.Size(68, 16);
            this.lblBirthDate.Text = "Ngày sinh:";

            this.dtpBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBirthDate.CustomFormat = "dd/MM/yyyy";
            this.dtpBirthDate.Location = new System.Drawing.Point(160, 156);
            this.dtpBirthDate.MaxDate = System.DateTime.Today;
            this.dtpBirthDate.Name = "dtpBirthDate";
            this.dtpBirthDate.Size = new System.Drawing.Size(260, 22);

            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(35, 200);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(60, 16);
            this.lblGender.Text = "Giới tính:";

            this.radMale.AutoSize = true;
            this.radMale.Location = new System.Drawing.Point(160, 198);
            this.radMale.Name = "radMale";
            this.radMale.Size = new System.Drawing.Size(51, 20);
            this.radMale.Text = "Nam";

            this.radFemale.AutoSize = true;
            this.radFemale.Location = new System.Drawing.Point(250, 198);
            this.radFemale.Name = "radFemale";
            this.radFemale.Size = new System.Drawing.Size(47, 20);
            this.radFemale.Text = "Nữ";

            this.lblCourse.AutoSize = true;
            this.lblCourse.Location = new System.Drawing.Point(35, 240);
            this.lblCourse.Name = "lblCourse";
            this.lblCourse.Size = new System.Drawing.Size(65, 16);
            this.lblCourse.Text = "Khóa học:";

            this.cboCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCourse.FormattingEnabled = true;
            this.cboCourse.Location = new System.Drawing.Point(160, 236);
            this.cboCourse.Name = "cboCourse";
            this.cboCourse.Size = new System.Drawing.Size(260, 24);

            this.lblStudyMode.AutoSize = true;
            this.lblStudyMode.Location = new System.Drawing.Point(35, 280);
            this.lblStudyMode.Name = "lblStudyMode";
            this.lblStudyMode.Size = new System.Drawing.Size(83, 16);
            this.lblStudyMode.Text = "Hình thức học:";

            this.chkOnline.AutoSize = true;
            this.chkOnline.Location = new System.Drawing.Point(160, 278);
            this.chkOnline.Name = "chkOnline";
            this.chkOnline.Size = new System.Drawing.Size(91, 20);
            this.chkOnline.Text = "Trực tuyến";

            this.chkOffline.AutoSize = true;
            this.chkOffline.Location = new System.Drawing.Point(270, 278);
            this.chkOffline.Name = "chkOffline";
            this.chkOffline.Size = new System.Drawing.Size(83, 20);
            this.chkOffline.Text = "Trực tiếp";

            this.btnRegister.Location = new System.Drawing.Point(160, 330);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(120, 35);
            this.btnRegister.Text = "Đăng ký";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);

            this.btnExit.Location = new System.Drawing.Point(300, 330);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(120, 35);
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);

            this.errorProvider1.ContainerControl = this;

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 400);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.mtxtPhone);
            this.Controls.Add(this.lblBirthDate);
            this.Controls.Add(this.dtpBirthDate);
            this.Controls.Add(this.lblGender);
            this.Controls.Add(this.radMale);
            this.Controls.Add(this.radFemale);
            this.Controls.Add(this.lblCourse);
            this.Controls.Add(this.cboCourse);
            this.Controls.Add(this.lblStudyMode);
            this.Controls.Add(this.chkOnline);
            this.Controls.Add(this.chkOffline);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.btnExit);
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bài 4.2 - Đăng ký khóa học";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblBirthDate;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblCourse;
        private System.Windows.Forms.Label lblStudyMode;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.MaskedTextBox mtxtPhone;
        private System.Windows.Forms.DateTimePicker dtpBirthDate;
        private System.Windows.Forms.RadioButton radMale;
        private System.Windows.Forms.RadioButton radFemale;
        private System.Windows.Forms.ComboBox cboCourse;
        private System.Windows.Forms.CheckBox chkOnline;
        private System.Windows.Forms.CheckBox chkOffline;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
