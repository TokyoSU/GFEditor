namespace GFEditor.Forms
{
    partial class UI_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI_Main));
            ShowItemBtn = new Button();
            ShowEnchantBtn = new Button();
            TranslateAutoCBox = new CheckBox();
            SuspendLayout();
            // 
            // ShowItemBtn
            // 
            ShowItemBtn.Location = new System.Drawing.Point(12, 12);
            ShowItemBtn.Name = "ShowItemBtn";
            ShowItemBtn.Size = new System.Drawing.Size(99, 23);
            ShowItemBtn.TabIndex = 0;
            ShowItemBtn.Text = "Item Editor";
            ShowItemBtn.UseVisualStyleBackColor = true;
            ShowItemBtn.Click += ShowItemBtn_Click;
            // 
            // ShowEnchantBtn
            // 
            ShowEnchantBtn.Location = new System.Drawing.Point(12, 41);
            ShowEnchantBtn.Name = "ShowEnchantBtn";
            ShowEnchantBtn.Size = new System.Drawing.Size(99, 23);
            ShowEnchantBtn.TabIndex = 1;
            ShowEnchantBtn.Text = "Enchant Editor";
            ShowEnchantBtn.UseVisualStyleBackColor = true;
            ShowEnchantBtn.Click += ShowEnchantBtn_Click;
            // 
            // TranslateAutoCBox
            // 
            TranslateAutoCBox.AutoSize = true;
            TranslateAutoCBox.Location = new System.Drawing.Point(166, 12);
            TranslateAutoCBox.Name = "TranslateAutoCBox";
            TranslateAutoCBox.Size = new System.Drawing.Size(152, 19);
            TranslateAutoCBox.TabIndex = 2;
            TranslateAutoCBox.Text = "Translate when loaded ?";
            TranslateAutoCBox.UseVisualStyleBackColor = true;
            TranslateAutoCBox.CheckedChanged += TranslateAutoCBox_CheckedChanged;
            // 
            // UI_Main
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(365, 80);
            Controls.Add(TranslateAutoCBox);
            Controls.Add(ShowEnchantBtn);
            Controls.Add(ShowItemBtn);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UI_Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GF - Main";
            FormClosing += Main_FormClosing;
            Load += Main_Load;
            Shown += Main_Shown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button ShowItemBtn;
        private Button ShowEnchantBtn;
        private CheckBox TranslateAutoCBox;
    }
}