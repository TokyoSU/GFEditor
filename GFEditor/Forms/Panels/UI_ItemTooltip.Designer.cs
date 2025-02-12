namespace GFEditor.Editor
{
    partial class UI_ItemTooltip
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI_ItemTooltip));
            TooltipTxt = new RichTextBox();
            OKBtn = new Button();
            SuspendLayout();
            // 
            // TooltipTxt
            // 
            TooltipTxt.DetectUrls = false;
            TooltipTxt.Location = new System.Drawing.Point(0, 0);
            TooltipTxt.Margin = new Padding(4, 3, 4, 3);
            TooltipTxt.Name = "TooltipTxt";
            TooltipTxt.ReadOnly = true;
            TooltipTxt.ScrollBars = RichTextBoxScrollBars.None;
            TooltipTxt.ShortcutsEnabled = false;
            TooltipTxt.Size = new System.Drawing.Size(644, 955);
            TooltipTxt.TabIndex = 0;
            TooltipTxt.TabStop = false;
            TooltipTxt.Text = "";
            TooltipTxt.WordWrap = false;
            // 
            // OKBtn
            // 
            OKBtn.Location = new System.Drawing.Point(544, 967);
            OKBtn.Margin = new Padding(4, 3, 4, 3);
            OKBtn.Name = "OKBtn";
            OKBtn.Size = new System.Drawing.Size(88, 27);
            OKBtn.TabIndex = 1;
            OKBtn.Text = "Ok";
            OKBtn.UseVisualStyleBackColor = true;
            OKBtn.Click += OKBtn_Click;
            // 
            // UI_ItemTooltip
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(645, 1007);
            ControlBox = false;
            Controls.Add(OKBtn);
            Controls.Add(TooltipTxt);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UI_ItemTooltip";
            StartPosition = FormStartPosition.CenterParent;
            Text = "GF - Item - Tooltip Overview";
            Shown += ItemTooltip_Shown;
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.RichTextBox TooltipTxt;
        private System.Windows.Forms.Button OKBtn;
    }
}