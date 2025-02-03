namespace GFEditor.Editor
{
    partial class ItemTooltip
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemTooltip));
            this.TooltipTxt = new System.Windows.Forms.RichTextBox();
            this.OKBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TooltipTxt
            // 
            this.TooltipTxt.DetectUrls = false;
            this.TooltipTxt.Location = new System.Drawing.Point(0, 0);
            this.TooltipTxt.Name = "TooltipTxt";
            this.TooltipTxt.ReadOnly = true;
            this.TooltipTxt.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.TooltipTxt.ShortcutsEnabled = false;
            this.TooltipTxt.Size = new System.Drawing.Size(553, 828);
            this.TooltipTxt.TabIndex = 0;
            this.TooltipTxt.TabStop = false;
            this.TooltipTxt.Text = "";
            this.TooltipTxt.WordWrap = false;
            // 
            // OKBtn
            // 
            this.OKBtn.Location = new System.Drawing.Point(466, 838);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(75, 23);
            this.OKBtn.TabIndex = 1;
            this.OKBtn.Text = "Ok";
            this.OKBtn.UseVisualStyleBackColor = true;
            this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
            // 
            // ItemTooltip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 873);
            this.Controls.Add(this.OKBtn);
            this.Controls.Add(this.TooltipTxt);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ItemTooltip";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "GF - Item - Tooltip Overview";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox TooltipTxt;
        private System.Windows.Forms.Button OKBtn;
    }
}