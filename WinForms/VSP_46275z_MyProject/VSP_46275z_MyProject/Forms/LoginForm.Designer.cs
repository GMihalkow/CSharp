namespace VSP_46275z_MyProject
{
    partial class LoginForm
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            this.label2 = new System.Windows.Forms.Label();
            this.Username_Input = new System.Windows.Forms.TextBox();
            this.Password_Input = new System.Windows.Forms.TextBox();
            this.Login_Btn = new System.Windows.Forms.Button();
            this.Error_Prov = new System.Windows.Forms.ErrorProvider(this.components);
            this.Register_Btn = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Error_Prov)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(125, 53);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(77, 35);
            label1.TabIndex = 0;
            label1.Text = "Login";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(123, 171);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(70, 20);
            label3.TabIndex = 4;
            label3.Text = "Password";
            label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(103, 282);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(112, 20);
            label4.TabIndex = 6;
            label4.Text = "Not registered?";
            label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(125, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Username";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Username_Input
            // 
            this.Username_Input.Location = new System.Drawing.Point(103, 131);
            this.Username_Input.Name = "Username_Input";
            this.Username_Input.Size = new System.Drawing.Size(125, 27);
            this.Username_Input.TabIndex = 2;
            this.Username_Input.TextChanged += new System.EventHandler(this.Username_Input_TextChanged);
            // 
            // Password_Input
            // 
            this.Password_Input.Location = new System.Drawing.Point(101, 194);
            this.Password_Input.Name = "Password_Input";
            this.Password_Input.PasswordChar = '*';
            this.Password_Input.Size = new System.Drawing.Size(125, 27);
            this.Password_Input.TabIndex = 3;
            this.Password_Input.TextChanged += new System.EventHandler(this.Password_Input_TextChanged);
            // 
            // Login_Btn
            // 
            this.Login_Btn.Location = new System.Drawing.Point(114, 237);
            this.Login_Btn.Name = "Login_Btn";
            this.Login_Btn.Size = new System.Drawing.Size(94, 29);
            this.Login_Btn.TabIndex = 5;
            this.Login_Btn.Text = "Login";
            this.Login_Btn.UseVisualStyleBackColor = true;
            this.Login_Btn.Click += new System.EventHandler(this.Login_Btn_Click);
            // 
            // Error_Prov
            // 
            this.Error_Prov.ContainerControl = this;
            // 
            // Register_Btn
            // 
            this.Register_Btn.Location = new System.Drawing.Point(114, 316);
            this.Register_Btn.Name = "Register_Btn";
            this.Register_Btn.Size = new System.Drawing.Size(94, 29);
            this.Register_Btn.TabIndex = 7;
            this.Register_Btn.Text = "Sign up";
            this.Register_Btn.UseVisualStyleBackColor = true;
            this.Register_Btn.Click += new System.EventHandler(this.Register_Btn_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 361);
            this.Controls.Add(this.Register_Btn);
            this.Controls.Add(label4);
            this.Controls.Add(this.Login_Btn);
            this.Controls.Add(label3);
            this.Controls.Add(this.Password_Input);
            this.Controls.Add(this.Username_Input);
            this.Controls.Add(this.label2);
            this.Controls.Add(label1);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            ((System.ComponentModel.ISupportInitialize)(this.Error_Prov)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Username_Input;
        private System.Windows.Forms.TextBox Password_Input;
        private System.Windows.Forms.Button Login_Btn;
        private System.Windows.Forms.ErrorProvider Error_Prov;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Register_Btn;
    }
}