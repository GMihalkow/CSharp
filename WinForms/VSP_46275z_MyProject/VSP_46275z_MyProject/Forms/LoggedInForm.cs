using System;
using System.Windows.Forms;
using VSP_46275z_MyProject.Dal.Services.CryptService;
using VSP_46275z_MyProject.Dal.Services.CryptService.Contracts;

namespace VSP_46275z_MyProject.Forms
{
    public partial class LoggedInForm : Form
    {
        private string _inputText;
        private readonly ICryptService _cryptService;

        public LoggedInForm()
        {
            this.InitializeComponent();
            this._cryptService = new CryptService();
        }

        private void Text_Input_TextChanged(object sender, EventArgs e)
            => this._inputText = (sender as TextBox).Text;

        private void Encrypt_Btn_Click(object sender, EventArgs e)
        {
            this.Error_Prov.Clear();

            if (this._inputText?.Length == 0)
            {
                this.Error_Prov.SetError(this.Encrypt_Btn, "Input text is empty.");
                return;
            }    

            var encryptedText = this._cryptService.Encrypt(this._inputText);

            this.Result_Text_Box.Text = encryptedText;

            this.ClearInput();
        }

        private void Decrypt_Btn_Click(object sender, EventArgs e)
        {
            this.Error_Prov.Clear();

            if (this._inputText?.Length == 0)
            {
                this.Error_Prov.SetError(this.Encrypt_Btn, "Input text is empty.");
                return;
            }

            try
            {
                var decryptedText = this._cryptService.Decrypt(this._inputText);

                this.Result_Text_Box.Text = decryptedText;
            }
            catch (Exception)
            {
                this.Error_Prov.SetError(this.Decrypt_Btn, "Invalid text provided for Decryption.");
            }

            this.ClearInput();
        }

        private void ClearInput()
        {
            this._inputText = string.Empty;
            this.Text_Input.Clear();
        }
    }
}