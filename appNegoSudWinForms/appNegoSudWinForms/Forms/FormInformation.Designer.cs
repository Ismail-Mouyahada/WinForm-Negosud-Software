namespace appNegoSudWinForms.Forms
{
    partial class FormInformation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInformation));
            this.labelInformationApplication = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelInformationApplication
            // 
            this.labelInformationApplication.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelInformationApplication.AutoSize = true;
            this.labelInformationApplication.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelInformationApplication.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelInformationApplication.Location = new System.Drawing.Point(34, 9);
            this.labelInformationApplication.Name = "labelInformationApplication";
            this.labelInformationApplication.Size = new System.Drawing.Size(883, 504);
            this.labelInformationApplication.TabIndex = 8;
            this.labelInformationApplication.Text = resources.GetString("labelInformationApplication.Text");
            this.labelInformationApplication.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(961, 548);
            this.Controls.Add(this.labelInformationApplication);
            this.Name = "FormInformation";
            this.Text = "Informations";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelInformationApplication;
    }
}