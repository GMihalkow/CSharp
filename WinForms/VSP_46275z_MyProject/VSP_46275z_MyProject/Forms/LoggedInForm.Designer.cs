namespace VSP_46275z_MyProject.Forms
{
    partial class LoggedInForm
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
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            this.Text_Input = new System.Windows.Forms.TextBox();
            this.Encrypt_Btn = new System.Windows.Forms.Button();
            this.Error_Prov = new System.Windows.Forms.ErrorProvider(this.components);
            this.Result_Text_Box = new System.Windows.Forms.TextBox();
            this.Decrypt_Btn = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Error_Prov)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(125, 68);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(269, 35);
            label1.TabIndex = 0;
            label1.Text = "Logged in successfully.";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(125, 225);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(43, 20);
            label2.TabIndex = 4;
            label2.Text = "Input";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(125, 135);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(55, 20);
            label3.TabIndex = 5;
            label3.Text = "Output";
            // 
            // Text_Input
            // 
            this.Text_Input.Location = new System.Drawing.Point(125, 260);
            this.Text_Input.Name = "Text_Input";
            this.Text_Input.Size = new System.Drawing.Size(269, 27);
            this.Text_Input.TabIndex = 1;
            this.Text_Input.TextChanged += new System.EventHandler(this.Text_Input_TextChanged);
            // 
            // Encrypt_Btn
            // 
            this.Encrypt_Btn.Location = new System.Drawing.Point(125, 303);
            this.Encrypt_Btn.Name = "Encrypt_Btn";
            this.Encrypt_Btn.Size = new System.Drawing.Size(94, 29);
            this.Encrypt_Btn.TabIndex = 2;
            this.Encrypt_Btn.Text = "Encrypt";
            this.Encrypt_Btn.UseVisualStyleBackColor = true;
            this.Encrypt_Btn.Click += new System.EventHandler(this.Encrypt_Btn_Click);
            // 
            // Error_Prov
            // 
            this.Error_Prov.ContainerControl = this;
            // 
            // Result_Text_Box
            // 
            this.Result_Text_Box.Location = new System.Drawing.Point(125, 173);
            this.Result_Text_Box.Name = "Result_Text_Box";
            this.Result_Text_Box.ReadOnly = true;
            this.Result_Text_Box.Size = new System.Drawing.Size(510, 27);
            this.Result_Text_Box.TabIndex = 3;
            // 
            // Decrypt_Btn
            // 
            this.Decrypt_Btn.Location = new System.Drawing.Point(252, 303);
            this.Decrypt_Btn.Name = "Decrypt_Btn";
            this.Decrypt_Btn.Size = new System.Drawing.Size(94, 29);
            this.Decrypt_Btn.TabIndex = 6;
            this.Decrypt_Btn.Text = "Decrypt";
            this.Decrypt_Btn.UseVisualStyleBackColor = true;
            this.Decrypt_Btn.Click += new System.EventHandler(this.Decrypt_Btn_Click);
            // 
            // LoggedInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Decrypt_Btn);
            this.Controls.Add(label3);
            this.Controls.Add(label2);
            this.Controls.Add(this.Result_Text_Box);
            this.Controls.Add(this.Encrypt_Btn);
            this.Controls.Add(this.Text_Input);
            this.Controls.Add(label1);
            this.Name = "LoggedInForm";
            this.Text = "LoggedInForm";
            ((System.ComponentModel.ISupportInitialize)(this.Error_Prov)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Text_Input;
        private System.Windows.Forms.Button Encrypt_Btn;
        private System.Windows.Forms.ErrorProvider Error_Prov;
        private System.Windows.Forms.TextBox Result_Text_Box;
        private System.Windows.Forms.Button Decrypt_Btn;
    }
}