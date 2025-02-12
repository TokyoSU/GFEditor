namespace GFEditor.Editor
{
    partial class UI_Loader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI_Loader));
            MaxProgress = new ProgressBar();
            MaxLabel = new Label();
            CurLabel = new Label();
            CurProgress = new ProgressBar();
            ItemProgress = new ProgressBar();
            ItemLabel = new Label();
            SuspendLayout();
            // 
            // MaxProgress
            // 
            MaxProgress.Location = new System.Drawing.Point(12, 32);
            MaxProgress.Name = "MaxProgress";
            MaxProgress.Size = new System.Drawing.Size(776, 23);
            MaxProgress.Style = ProgressBarStyle.Continuous;
            MaxProgress.TabIndex = 0;
            // 
            // MaxLabel
            // 
            MaxLabel.AutoSize = true;
            MaxLabel.Location = new System.Drawing.Point(12, 7);
            MaxLabel.Name = "MaxLabel";
            MaxLabel.Size = new System.Drawing.Size(57, 15);
            MaxLabel.TabIndex = 1;
            MaxLabel.Text = "MaxLabel";
            // 
            // CurLabel
            // 
            CurLabel.AutoSize = true;
            CurLabel.Location = new System.Drawing.Point(12, 63);
            CurLabel.Name = "CurLabel";
            CurLabel.Size = new System.Drawing.Size(54, 15);
            CurLabel.TabIndex = 2;
            CurLabel.Text = "CurLabel";
            // 
            // CurProgress
            // 
            CurProgress.Location = new System.Drawing.Point(12, 88);
            CurProgress.Name = "CurProgress";
            CurProgress.Size = new System.Drawing.Size(776, 23);
            CurProgress.Style = ProgressBarStyle.Continuous;
            CurProgress.TabIndex = 3;
            // 
            // ItemProgress
            // 
            ItemProgress.Location = new System.Drawing.Point(12, 142);
            ItemProgress.Name = "ItemProgress";
            ItemProgress.Size = new System.Drawing.Size(776, 23);
            ItemProgress.Style = ProgressBarStyle.Continuous;
            ItemProgress.TabIndex = 5;
            // 
            // ItemLabel
            // 
            ItemLabel.AutoSize = true;
            ItemLabel.Location = new System.Drawing.Point(12, 119);
            ItemLabel.Name = "ItemLabel";
            ItemLabel.Size = new System.Drawing.Size(59, 15);
            ItemLabel.TabIndex = 4;
            ItemLabel.Text = "ItemLabel";
            // 
            // UI_Loader
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 178);
            Controls.Add(ItemProgress);
            Controls.Add(ItemLabel);
            Controls.Add(CurProgress);
            Controls.Add(CurLabel);
            Controls.Add(MaxLabel);
            Controls.Add(MaxProgress);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UI_Loader";
            StartPosition = FormStartPosition.CenterParent;
            Text = "GF - Loader";
            Load += LoaderPanel_Load;
            Shown += LoaderPanel_Shown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ProgressBar MaxProgress;
        private Label MaxLabel;
        private Label CurLabel;
        private ProgressBar CurProgress;
        private ProgressBar ItemProgress;
        private Label ItemLabel;
    }
}