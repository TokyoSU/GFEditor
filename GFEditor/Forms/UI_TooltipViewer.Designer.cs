namespace GFEditor.Editor
{
    partial class UI_TooltipViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI_TooltipViewer));
            TooltipTxt = new RichTextBox();
            OKBtn = new Button();
            SuspendLayout();
            // 
            // TooltipTxt
            // 
            TooltipTxt.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TooltipTxt.BackColor = SColor.Black;
            TooltipTxt.BorderStyle = BorderStyle.None;
            TooltipTxt.DetectUrls = false;
            TooltipTxt.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TooltipTxt.ForeColor = SystemColors.Window;
            TooltipTxt.Location = new System.Drawing.Point(0, 0);
            TooltipTxt.Margin = new Padding(4, 3, 4, 3);
            TooltipTxt.Name = "TooltipTxt";
            TooltipTxt.ReadOnly = true;
            TooltipTxt.ScrollBars = RichTextBoxScrollBars.Horizontal;
            TooltipTxt.ShortcutsEnabled = false;
            TooltipTxt.Size = new System.Drawing.Size(644, 626);
            TooltipTxt.TabIndex = 0;
            TooltipTxt.TabStop = false;
            TooltipTxt.Text = "";
            // 
            // OKBtn
            // 
            OKBtn.Location = new System.Drawing.Point(544, 632);
            OKBtn.Margin = new Padding(4, 3, 4, 3);
            OKBtn.Name = "OKBtn";
            OKBtn.Size = new System.Drawing.Size(88, 27);
            OKBtn.TabIndex = 1;
            OKBtn.Text = "Ok";
            OKBtn.UseVisualStyleBackColor = true;
            OKBtn.Click += TooltipCloseBtn_Click;
            // 
            // UI_TooltipViewer
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(645, 671);
            ControlBox = false;
            Controls.Add(OKBtn);
            Controls.Add(TooltipTxt);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UI_TooltipViewer";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GF - Item - Tooltip Overview";
            Shown += TooltipViewer_Shown;
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.RichTextBox TooltipTxt;
        private System.Windows.Forms.Button OKBtn;
    }
}