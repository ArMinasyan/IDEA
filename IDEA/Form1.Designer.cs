namespace IDEA
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        
        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.txt_Key = new System.Windows.Forms.TextBox();
            this.txt_Text = new System.Windows.Forms.TextBox();
            this.txt_EncDecText = new System.Windows.Forms.TextBox();
            this.btn_Encrypt = new System.Windows.Forms.Button();
            this.btn_Decrypt = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_Key
            // 
            this.txt_Key.Location = new System.Drawing.Point(12, 25);
            this.txt_Key.MaxLength = 16;
            this.txt_Key.Name = "txt_Key";
            this.txt_Key.Size = new System.Drawing.Size(266, 20);
            this.txt_Key.TabIndex = 0;
            // 
            // txt_Text
            // 
            this.txt_Text.Location = new System.Drawing.Point(12, 64);
            this.txt_Text.Multiline = true;
            this.txt_Text.Name = "txt_Text";
            this.txt_Text.Size = new System.Drawing.Size(266, 93);
            this.txt_Text.TabIndex = 1;
            // 
            // txt_EncDecText
            // 
            this.txt_EncDecText.Location = new System.Drawing.Point(12, 176);
            this.txt_EncDecText.Multiline = true;
            this.txt_EncDecText.Name = "txt_EncDecText";
            this.txt_EncDecText.Size = new System.Drawing.Size(266, 93);
            this.txt_EncDecText.TabIndex = 2;
            // 
            // btn_Encrypt
            // 
            this.btn_Encrypt.Location = new System.Drawing.Point(12, 279);
            this.btn_Encrypt.Name = "btn_Encrypt";
            this.btn_Encrypt.Size = new System.Drawing.Size(118, 23);
            this.btn_Encrypt.TabIndex = 3;
            this.btn_Encrypt.Text = "Encrypt";
            this.btn_Encrypt.UseVisualStyleBackColor = true;
            this.btn_Encrypt.Click += new System.EventHandler(this.btn_Encrypt_Click);
            // 
            // btn_Decrypt
            // 
            this.btn_Decrypt.Location = new System.Drawing.Point(160, 279);
            this.btn_Decrypt.Name = "btn_Decrypt";
            this.btn_Decrypt.Size = new System.Drawing.Size(118, 23);
            this.btn_Decrypt.TabIndex = 4;
            this.btn_Decrypt.Text = "Decrypt";
            this.btn_Decrypt.UseVisualStyleBackColor = true;
            this.btn_Decrypt.Click += new System.EventHandler(this.btn_Decrypt_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Key";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Text";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Encrypted/Decrypted Text";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 322);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Decrypt);
            this.Controls.Add(this.btn_Encrypt);
            this.Controls.Add(this.txt_EncDecText);
            this.Controls.Add(this.txt_Text);
            this.Controls.Add(this.txt_Key);
            this.MaximumSize = new System.Drawing.Size(310, 360);
            this.MinimumSize = new System.Drawing.Size(310, 360);
            this.Name = "Form1";
            this.Text = "IDEA";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Key;
        private System.Windows.Forms.TextBox txt_Text;
        private System.Windows.Forms.TextBox txt_EncDecText;
        private System.Windows.Forms.Button btn_Encrypt;
        private System.Windows.Forms.Button btn_Decrypt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

