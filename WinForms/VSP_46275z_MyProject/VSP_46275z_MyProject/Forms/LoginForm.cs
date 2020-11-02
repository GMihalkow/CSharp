using System;
using System.Windows.Forms;
using VSP_46275z_MyProject.Dal.Infrastructure;
using VSP_46275z_MyProject.Dal.Models.Users;
using VSP_46275z_MyProject.Dal.Services.Users;
using VSP_46275z_MyProject.Dal.Services.Users.Contracts;

namespace VSP_46275z_MyProject
{
    public partial class LoginForm : Form
    {
        private string _username;
        private string _password;
        private readonly IUsersService _usersService;
        public delegate void OnHideHandler(object sender, object e);

        public LoginForm()
        {
            this.InitializeComponent();
            this._usersService = new UsersService();
        }

        public event OnHideHandler OnHide;

        private void Username_Input_TextChanged(object sender, EventArgs e)
            => this._username = (sender as TextBox).Text;

        private void Password_Input_TextChanged(object sender, EventArgs e)
            => this._password = (sender as TextBox).Text;

        private void Login_Btn_Click(object sender, EventArgs e)
        {
            this.ValidateForm();

            var model = new LoginInputModel
            {
                Username = this._username,
                Password = this._password
            };

            if (!model.Validate())
                return;

            var loginSucceeded = this._usersService.Login(model);

            if (!loginSucceeded)
                this.Error_Prov.SetError(this.Login_Btn, "Login failed.");
            else 
                this.Close();
        }

        private void ValidateForm()
        {
            this.Error_Prov.Clear();

            if (this._username.IsNullOrEmpty() || this._username.Length > ValidationConstants.UsernameMaxLength)
                this.Error_Prov.SetError(this.Username_Input, string.Format(ValidationConstants.BaseErrorMessage, "Username", 250));
            else if (this._password.IsNullOrEmpty() || this._password.Length > ValidationConstants.PasswordMaxLength)
                this.Error_Prov.SetError(this.Password_Input, string.Format(ValidationConstants.BaseErrorMessage, "Password", 250));

            var user = this._usersService.GetByName(this._username);

            if (user == null)
                this.Error_Prov.SetError(this.Login_Btn, "User not found.");
        }

        private void Register_Btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.OnHide?.Invoke(this, null);
        }
    }
}