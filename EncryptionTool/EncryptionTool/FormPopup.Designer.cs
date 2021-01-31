
namespace EncryptionTool
{
    partial class FormPopup
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
            this.popupLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // popupLabel
            // 
            this.popupLabel.AutoSize = true;
            this.popupLabel.Location = new System.Drawing.Point(365, 172);
            this.popupLabel.Name = "popupLabel";
            this.popupLabel.Size = new System.Drawing.Size(33, 13);
            this.popupLabel.TabIndex = 0;
            this.popupLabel.Text = "blank";
            // 
            // FormPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.popupLabel);
            this.Name = "FormPopup";
            this.Text = "blank";
            this.Load += new System.EventHandler(this.FormPopup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label popupLabel;
    }
}