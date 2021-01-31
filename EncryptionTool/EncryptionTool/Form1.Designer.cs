
namespace EncryptionTool
{
    partial class Form1
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
            this.inputFileTextBox = new System.Windows.Forms.TextBox();
            this.inputStringLabel = new System.Windows.Forms.Label();
            this.encryptButton = new System.Windows.Forms.Button();
            this.decryptButton = new System.Windows.Forms.Button();
            this.keyTextBox = new System.Windows.Forms.TextBox();
            this.inputKeyLabel = new System.Windows.Forms.Label();
            this.cipherInputLabel = new System.Windows.Forms.Label();
            this.cipherComboBox = new System.Windows.Forms.ComboBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.versionLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // inputFileTextBox
            // 
            this.inputFileTextBox.Location = new System.Drawing.Point(180, 255);
            this.inputFileTextBox.Name = "inputFileTextBox";
            this.inputFileTextBox.Size = new System.Drawing.Size(525, 20);
            this.inputFileTextBox.TabIndex = 0;
            // 
            // inputStringLabel
            // 
            this.inputStringLabel.AutoSize = true;
            this.inputStringLabel.Location = new System.Drawing.Point(54, 258);
            this.inputStringLabel.Name = "inputStringLabel";
            this.inputStringLabel.Size = new System.Drawing.Size(120, 13);
            this.inputStringLabel.TabIndex = 1;
            this.inputStringLabel.Text = "File To Encrypt/Decrypt";
            // 
            // encryptButton
            // 
            this.encryptButton.Location = new System.Drawing.Point(322, 281);
            this.encryptButton.Name = "encryptButton";
            this.encryptButton.Size = new System.Drawing.Size(62, 24);
            this.encryptButton.TabIndex = 2;
            this.encryptButton.Text = "Encrypt";
            this.encryptButton.UseVisualStyleBackColor = true;
            this.encryptButton.Click += new System.EventHandler(this.encryptButton_Click);
            // 
            // decryptButton
            // 
            this.decryptButton.Location = new System.Drawing.Point(437, 281);
            this.decryptButton.Name = "decryptButton";
            this.decryptButton.Size = new System.Drawing.Size(62, 24);
            this.decryptButton.TabIndex = 5;
            this.decryptButton.Text = "Decrypt";
            this.decryptButton.UseVisualStyleBackColor = true;
            this.decryptButton.Click += new System.EventHandler(this.decryptButton_Click);
            // 
            // keyTextBox
            // 
            this.keyTextBox.Location = new System.Drawing.Point(180, 174);
            this.keyTextBox.Name = "keyTextBox";
            this.keyTextBox.Size = new System.Drawing.Size(222, 20);
            this.keyTextBox.TabIndex = 6;
            // 
            // inputKeyLabel
            // 
            this.inputKeyLabel.AutoSize = true;
            this.inputKeyLabel.Location = new System.Drawing.Point(149, 177);
            this.inputKeyLabel.Name = "inputKeyLabel";
            this.inputKeyLabel.Size = new System.Drawing.Size(25, 13);
            this.inputKeyLabel.TabIndex = 7;
            this.inputKeyLabel.Text = "Key";
            // 
            // cipherInputLabel
            // 
            this.cipherInputLabel.AutoSize = true;
            this.cipherInputLabel.Location = new System.Drawing.Point(498, 177);
            this.cipherInputLabel.Name = "cipherInputLabel";
            this.cipherInputLabel.Size = new System.Drawing.Size(64, 13);
            this.cipherInputLabel.TabIndex = 8;
            this.cipherInputLabel.Text = "Cipher Type";
            // 
            // cipherComboBox
            // 
            this.cipherComboBox.FormattingEnabled = true;
            this.cipherComboBox.Location = new System.Drawing.Point(568, 174);
            this.cipherComboBox.Name = "cipherComboBox";
            this.cipherComboBox.Size = new System.Drawing.Size(137, 21);
            this.cipherComboBox.TabIndex = 9;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Elephant", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(252, 21);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(295, 41);
            this.titleLabel.TabIndex = 10;
            this.titleLabel.Text = "Encryption Tool";
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Font = new System.Drawing.Font("Elephant", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versionLabel.Location = new System.Drawing.Point(252, 62);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(61, 25);
            this.versionLabel.TabIndex = 11;
            this.versionLabel.Text = "v. 1.0";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Elephant", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(649, 416);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(139, 25);
            this.nameLabel.TabIndex = 12;
            this.nameLabel.Text = "Jake Leggore";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.cipherComboBox);
            this.Controls.Add(this.cipherInputLabel);
            this.Controls.Add(this.inputKeyLabel);
            this.Controls.Add(this.keyTextBox);
            this.Controls.Add(this.decryptButton);
            this.Controls.Add(this.encryptButton);
            this.Controls.Add(this.inputStringLabel);
            this.Controls.Add(this.inputFileTextBox);
            this.Name = "Form1";
            this.Text = "Encryption Tool";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputFileTextBox;
        private System.Windows.Forms.Label inputStringLabel;
        private System.Windows.Forms.Button encryptButton;
        private System.Windows.Forms.Button decryptButton;
        private System.Windows.Forms.TextBox keyTextBox;
        private System.Windows.Forms.Label inputKeyLabel;
        private System.Windows.Forms.Label cipherInputLabel;
        private System.Windows.Forms.ComboBox cipherComboBox;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Label nameLabel;
    }
}

