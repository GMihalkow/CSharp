using System;
using System.Windows.Forms;
using VSP_46275z_MyProject.Dal.Infrastructure;
using VSP_46275z_MyProject.Dal.Models.Users;
using VSP_46275z_MyProject.Dal.Services.Users;

namespace VSP_46275z_MyProject
{
    public partial class RegisterForm : Form
    {
        private string _username;
        private string _password;
        private string _confirmPassword;
        private readonly UsersService _usersService;

        public RegisterForm()
        {
            this._usersService = new UsersService();
            this.InitializeComponent();
        }

        private void RegisterForm_Load(object sender, EventArgs e) { }

        private void Password_Input_TextChanged(object sender, EventArgs e)
            => this._password = (sender as TextBox).Text;

        private void Username_Input_TextChanged(object sender, EventArgs e)
            => this._username = (sender as TextBox).Text;

        private void Confirm_Password_Input_TextChanged(object sender, EventArgs e)
            => this._confirmPassword = (sender as TextBox).Text;

        private void button1_Click(object sender, EventArgs e)
        {
            this.ValidateForm();

            var model = new RegisterInputModel
            {
                Username = this._username,
                Password = this._password,
                ConfirmPassword = this._confirmPassword
            };

            if (!model.Validate()) return;

            this.Error_Prov.Clear();

            this._usersService.Register(model);
            this.Close();
        }
        
        private void ValidateForm()
        {
            this.Error_Prov.Clear();

            if (this._username.IsNullOrEmpty() || this._username.Length > ValidationConstants.UsernameMaxLength)
                this.Error_Prov.SetError(this.Username_Input, string.Format(ValidationConstants.BaseErrorMessage, "Username", 250));
            else if (this._password.IsNullOrEmpty() || this._password.Length > ValidationConstants.PasswordMaxLength)
                this.Error_Prov.SetError(this.Password_Input, string.Format(ValidationConstants.BaseErrorMessage, "Password", 250));
            else if (this._confirmPassword.IsNullOrEmpty() || this._confirmPassword.Length > ValidationConstants.PasswordMaxLength)
                this.Error_Prov.SetError(this.Confirm_Password_Input, string.Format(ValidationConstants.BaseErrorMessage, "Confirm Password", 250));
            else if (this._password != this._confirmPassword)
                this.Error_Prov.SetError(this.button1, "Password and confirm password fields must be equal.");

            var user = this._usersService.GetByName(this._username);
            
            if (user != null)
                this.Error_Prov.SetError(this.button1, "User already exists!");
        }

        private void Login_Btn_Click(object sender, EventArgs e)
        {
            var loginForm = new LoginForm();

            loginForm.OnHide += this.On_Login_Form_Hide;
            loginForm.Disposed += this.On_Login_Form_Disposed;

            this.Hide();
            loginForm.ShowDialog(this);
        }

        private void On_Login_Form_Disposed(object sender, EventArgs e)
            => this.Close();

        private void On_Login_Form_Hide(object sender) => this.Show();
    }
}