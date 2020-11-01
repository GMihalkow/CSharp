namespace VSP_46275z_MyProject
{
    partial class RegisterForm
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.Username_Input = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Password_Input = new System.Windows.Forms.TextBox();
            this.Confirm_Password_Input = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Error_Prov = new System.Windows.Forms.ErrorProvider(this.components);
            this.Login_Btn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Error_Prov)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(189, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Username_Input
            // 
            this.Username_Input.Location = new System.Drawing.Point(168, 141);
            this.Username_Input.Name = "Username_Input";
            this.Username_Input.Size = new System.Drawing.Size(125, 27);
            this.Username_Input.TabIndex = 1;
            this.Username_Input.TextChanged += new System.EventHandler(this.Username_Input_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(189, 193);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Password_Input
            // 
            this.Password_Input.Location = new System.Drawing.Point(170, 216);
            this.Password_Input.Name = "Password_Input";
            this.Password_Input.PasswordChar = '*';
            this.Password_Input.Size = new System.Drawing.Size(125, 27);
            this.Password_Input.TabIndex = 3;
            this.Password_Input.TextChanged += new System.EventHandler(this.Password_Input_TextChanged);
            // 
            // Confirm_Password_Input
            // 
            this.Confirm_Password_Input.Location = new System.Drawing.Point(168, 299);
            this.Confirm_Password_Input.Name = "Confirm_Password_Input";
            this.Confirm_Password_Input.PasswordChar = '*';
            this.Confirm_Password_Input.Size = new System.Drawing.Size(125, 27);
            this.Confirm_Password_Input.TabIndex = 4;
            this.Confirm_Password_Input.TextChanged += new System.EventHandler(this.Confirm_Password_Input_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(168, 276);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Confirm Password";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(184, 351);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 6;
            this.button1.Text = "Register";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Error_Prov
            // 
            this.Error_Prov.ContainerControl = this;
            // 
            // Login_Btn
            // 
            this.Login_Btn.Location = new System.Drawing.Point(184, 415);
            this.Login_Btn.Name = "Login_Btn";
            this.Login_Btn.Size = new System.Drawing.Size(94, 29);
            this.Login_Btn.TabIndex = 7;
            this.Login_Btn.Text = "Sign in";
            this.Login_Btn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Login_Btn.UseVisualStyleBackColor = true;
            this.Login_Btn.Click += new System.EventHandler(this.Login_Btn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(163, 392);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Already registered? ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(184, 46);
            this.label5.MaximumSize = new System.Drawing.Size(100, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 32);
            this.label5.TabIndex = 9;
            this.label5.Text = "Register";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 470);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Login_Btn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Confirm_Password_Input);
            this.Controls.Add(this.Password_Input);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Username_Input);
            this.Controls.Add(this.label1);
            this.Name = "RegisterForm";
            this.Text = "RegisterForm";
            this.Load += new System.EventHandler(this.RegisterForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Error_Prov)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Username_Input;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Password_Input;
        private System.Windows.Forms.TextBox Confirm_Password_Input;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ErrorProvider Error_Prov;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Login_Btn;
    }
}