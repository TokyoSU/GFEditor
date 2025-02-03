namespace GFEditor.Editor
{
    partial class ItemOpPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemOpPanel));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.OnlyEquip = new System.Windows.Forms.CheckBox();
            this.UnbindItem = new System.Windows.Forms.CheckBox();
            this.NoTransNode = new System.Windows.Forms.CheckBox();
            this.NoInField = new System.Windows.Forms.CheckBox();
            this.NoInBattlefield = new System.Windows.Forms.CheckBox();
            this.Replaceable5 = new System.Windows.Forms.CheckBox();
            this.Replaceable4 = new System.Windows.Forms.CheckBox();
            this.Replaceable3 = new System.Windows.Forms.CheckBox();
            this.Replaceable2 = new System.Windows.Forms.CheckBox();
            this.Replaceable1 = new System.Windows.Forms.CheckBox();
            this.Only5 = new System.Windows.Forms.CheckBox();
            this.Only4 = new System.Windows.Forms.CheckBox();
            this.Only3 = new System.Windows.Forms.CheckBox();
            this.Only2 = new System.Windows.Forms.CheckBox();
            this.Only1 = new System.Windows.Forms.CheckBox();
            this.ForDead = new System.Windows.Forms.CheckBox();
            this.LinkQuest = new System.Windows.Forms.CheckBox();
            this.NoInInstance = new System.Windows.Forms.CheckBox();
            this.NoInCave = new System.Windows.Forms.CheckBox();
            this.NoInTown = new System.Windows.Forms.CheckBox();
            this.NoInBattle = new System.Windows.Forms.CheckBox();
            this.NoSameBuff = new System.Windows.Forms.CheckBox();
            this.AccumTime = new System.Windows.Forms.CheckBox();
            this.BindOnEquip = new System.Windows.Forms.CheckBox();
            this.Combinable = new System.Windows.Forms.CheckBox();
            this.NoRepair = new System.Windows.Forms.CheckBox();
            this.NoEnchance = new System.Windows.Forms.CheckBox();
            this.NoDiscard = new System.Windows.Forms.CheckBox();
            this.NoTrade = new System.Windows.Forms.CheckBox();
            this.NoDecrease = new System.Windows.Forms.CheckBox();
            this.Useable = new System.Windows.Forms.CheckBox();
            this.OKBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.OnlyEquip);
            this.groupBox1.Controls.Add(this.UnbindItem);
            this.groupBox1.Controls.Add(this.NoTransNode);
            this.groupBox1.Controls.Add(this.NoInField);
            this.groupBox1.Controls.Add(this.NoInBattlefield);
            this.groupBox1.Controls.Add(this.Replaceable5);
            this.groupBox1.Controls.Add(this.Replaceable4);
            this.groupBox1.Controls.Add(this.Replaceable3);
            this.groupBox1.Controls.Add(this.Replaceable2);
            this.groupBox1.Controls.Add(this.Replaceable1);
            this.groupBox1.Controls.Add(this.Only5);
            this.groupBox1.Controls.Add(this.Only4);
            this.groupBox1.Controls.Add(this.Only3);
            this.groupBox1.Controls.Add(this.Only2);
            this.groupBox1.Controls.Add(this.Only1);
            this.groupBox1.Controls.Add(this.ForDead);
            this.groupBox1.Controls.Add(this.LinkQuest);
            this.groupBox1.Controls.Add(this.NoInInstance);
            this.groupBox1.Controls.Add(this.NoInCave);
            this.groupBox1.Controls.Add(this.NoInTown);
            this.groupBox1.Controls.Add(this.NoInBattle);
            this.groupBox1.Controls.Add(this.NoSameBuff);
            this.groupBox1.Controls.Add(this.AccumTime);
            this.groupBox1.Controls.Add(this.BindOnEquip);
            this.groupBox1.Controls.Add(this.Combinable);
            this.groupBox1.Controls.Add(this.NoRepair);
            this.groupBox1.Controls.Add(this.NoEnchance);
            this.groupBox1.Controls.Add(this.NoDiscard);
            this.groupBox1.Controls.Add(this.NoTrade);
            this.groupBox1.Controls.Add(this.NoDecrease);
            this.groupBox1.Controls.Add(this.Useable);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(526, 232);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "OpFlags Properties";
            // 
            // OnlyEquip
            // 
            this.OnlyEquip.AutoSize = true;
            this.OnlyEquip.Location = new System.Drawing.Point(213, 52);
            this.OnlyEquip.Name = "OnlyEquip";
            this.OnlyEquip.Size = new System.Drawing.Size(77, 17);
            this.OnlyEquip.TabIndex = 30;
            this.OnlyEquip.Text = "Only Equip";
            this.OnlyEquip.UseVisualStyleBackColor = true;
            this.OnlyEquip.CheckedChanged += new System.EventHandler(this.OnlyEquip_CheckedChanged);
            // 
            // UnbindItem
            // 
            this.UnbindItem.AutoSize = true;
            this.UnbindItem.Location = new System.Drawing.Point(124, 52);
            this.UnbindItem.Name = "UnbindItem";
            this.UnbindItem.Size = new System.Drawing.Size(83, 17);
            this.UnbindItem.TabIndex = 29;
            this.UnbindItem.Text = "Unbind Item";
            this.UnbindItem.UseVisualStyleBackColor = true;
            this.UnbindItem.CheckedChanged += new System.EventHandler(this.UnbindItem_CheckedChanged);
            // 
            // NoTransNode
            // 
            this.NoTransNode.AutoSize = true;
            this.NoTransNode.Location = new System.Drawing.Point(207, 139);
            this.NoTransNode.Name = "NoTransNode";
            this.NoTransNode.Size = new System.Drawing.Size(117, 17);
            this.NoTransNode.TabIndex = 28;
            this.NoTransNode.Text = "No Transport Node";
            this.NoTransNode.UseVisualStyleBackColor = true;
            this.NoTransNode.CheckedChanged += new System.EventHandler(this.NoTransNode_CheckedChanged);
            // 
            // NoInField
            // 
            this.NoInField.AutoSize = true;
            this.NoInField.Location = new System.Drawing.Point(124, 139);
            this.NoInField.Name = "NoInField";
            this.NoInField.Size = new System.Drawing.Size(77, 17);
            this.NoInField.TabIndex = 27;
            this.NoInField.Text = "No In Field";
            this.NoInField.UseVisualStyleBackColor = true;
            this.NoInField.CheckedChanged += new System.EventHandler(this.NoInField_CheckedChanged);
            // 
            // NoInBattlefield
            // 
            this.NoInBattlefield.AutoSize = true;
            this.NoInBattlefield.Location = new System.Drawing.Point(17, 139);
            this.NoInBattlefield.Name = "NoInBattlefield";
            this.NoInBattlefield.Size = new System.Drawing.Size(101, 17);
            this.NoInBattlefield.TabIndex = 26;
            this.NoInBattlefield.Text = "No In Battlefield";
            this.NoInBattlefield.UseVisualStyleBackColor = true;
            this.NoInBattlefield.CheckedChanged += new System.EventHandler(this.NoInBattlefield_CheckedChanged);
            // 
            // Replaceable5
            // 
            this.Replaceable5.AutoSize = true;
            this.Replaceable5.Location = new System.Drawing.Point(421, 205);
            this.Replaceable5.Name = "Replaceable5";
            this.Replaceable5.Size = new System.Drawing.Size(95, 17);
            this.Replaceable5.TabIndex = 25;
            this.Replaceable5.Text = "Replaceable 5";
            this.Replaceable5.UseVisualStyleBackColor = true;
            this.Replaceable5.CheckedChanged += new System.EventHandler(this.Replaceable5_CheckedChanged);
            // 
            // Replaceable4
            // 
            this.Replaceable4.AutoSize = true;
            this.Replaceable4.Location = new System.Drawing.Point(320, 205);
            this.Replaceable4.Name = "Replaceable4";
            this.Replaceable4.Size = new System.Drawing.Size(95, 17);
            this.Replaceable4.TabIndex = 24;
            this.Replaceable4.Text = "Replaceable 4";
            this.Replaceable4.UseVisualStyleBackColor = true;
            this.Replaceable4.CheckedChanged += new System.EventHandler(this.Replaceable4_CheckedChanged);
            // 
            // Replaceable3
            // 
            this.Replaceable3.AutoSize = true;
            this.Replaceable3.Location = new System.Drawing.Point(219, 205);
            this.Replaceable3.Name = "Replaceable3";
            this.Replaceable3.Size = new System.Drawing.Size(95, 17);
            this.Replaceable3.TabIndex = 23;
            this.Replaceable3.Text = "Replaceable 3";
            this.Replaceable3.UseVisualStyleBackColor = true;
            this.Replaceable3.CheckedChanged += new System.EventHandler(this.Replaceable3_CheckedChanged);
            // 
            // Replaceable2
            // 
            this.Replaceable2.AutoSize = true;
            this.Replaceable2.Location = new System.Drawing.Point(118, 205);
            this.Replaceable2.Name = "Replaceable2";
            this.Replaceable2.Size = new System.Drawing.Size(95, 17);
            this.Replaceable2.TabIndex = 22;
            this.Replaceable2.Text = "Replaceable 2";
            this.Replaceable2.UseVisualStyleBackColor = true;
            this.Replaceable2.CheckedChanged += new System.EventHandler(this.Replaceable2_CheckedChanged);
            // 
            // Replaceable1
            // 
            this.Replaceable1.AutoSize = true;
            this.Replaceable1.Location = new System.Drawing.Point(17, 205);
            this.Replaceable1.Name = "Replaceable1";
            this.Replaceable1.Size = new System.Drawing.Size(95, 17);
            this.Replaceable1.TabIndex = 21;
            this.Replaceable1.Text = "Replaceable 1";
            this.Replaceable1.UseVisualStyleBackColor = true;
            this.Replaceable1.CheckedChanged += new System.EventHandler(this.Replaceable1_CheckedChanged);
            // 
            // Only5
            // 
            this.Only5.AutoSize = true;
            this.Only5.Location = new System.Drawing.Point(265, 182);
            this.Only5.Name = "Only5";
            this.Only5.Size = new System.Drawing.Size(56, 17);
            this.Only5.TabIndex = 20;
            this.Only5.Text = "Only 5";
            this.Only5.UseVisualStyleBackColor = true;
            this.Only5.CheckedChanged += new System.EventHandler(this.Only5_CheckedChanged);
            // 
            // Only4
            // 
            this.Only4.AutoSize = true;
            this.Only4.Location = new System.Drawing.Point(203, 182);
            this.Only4.Name = "Only4";
            this.Only4.Size = new System.Drawing.Size(56, 17);
            this.Only4.TabIndex = 19;
            this.Only4.Text = "Only 4";
            this.Only4.UseVisualStyleBackColor = true;
            this.Only4.CheckedChanged += new System.EventHandler(this.Only4_CheckedChanged);
            // 
            // Only3
            // 
            this.Only3.AutoSize = true;
            this.Only3.Location = new System.Drawing.Point(141, 182);
            this.Only3.Name = "Only3";
            this.Only3.Size = new System.Drawing.Size(56, 17);
            this.Only3.TabIndex = 18;
            this.Only3.Text = "Only 3";
            this.Only3.UseVisualStyleBackColor = true;
            this.Only3.CheckedChanged += new System.EventHandler(this.Only3_CheckedChanged);
            // 
            // Only2
            // 
            this.Only2.AutoSize = true;
            this.Only2.Location = new System.Drawing.Point(79, 182);
            this.Only2.Name = "Only2";
            this.Only2.Size = new System.Drawing.Size(56, 17);
            this.Only2.TabIndex = 17;
            this.Only2.Text = "Only 2";
            this.Only2.UseVisualStyleBackColor = true;
            this.Only2.CheckedChanged += new System.EventHandler(this.Only2_CheckedChanged);
            // 
            // Only1
            // 
            this.Only1.AutoSize = true;
            this.Only1.Location = new System.Drawing.Point(17, 182);
            this.Only1.Name = "Only1";
            this.Only1.Size = new System.Drawing.Size(56, 17);
            this.Only1.TabIndex = 16;
            this.Only1.Text = "Only 1";
            this.Only1.UseVisualStyleBackColor = true;
            this.Only1.CheckedChanged += new System.EventHandler(this.Only1_CheckedChanged);
            // 
            // ForDead
            // 
            this.ForDead.AutoSize = true;
            this.ForDead.Location = new System.Drawing.Point(17, 52);
            this.ForDead.Name = "ForDead";
            this.ForDead.Size = new System.Drawing.Size(102, 17);
            this.ForDead.TabIndex = 15;
            this.ForDead.Text = "For Dead Player";
            this.ForDead.UseVisualStyleBackColor = true;
            this.ForDead.CheckedChanged += new System.EventHandler(this.ForDead_CheckedChanged);
            // 
            // LinkQuest
            // 
            this.LinkQuest.AutoSize = true;
            this.LinkQuest.Location = new System.Drawing.Point(427, 29);
            this.LinkQuest.Name = "LinkQuest";
            this.LinkQuest.Size = new System.Drawing.Size(93, 17);
            this.LinkQuest.TabIndex = 14;
            this.LinkQuest.Text = "Link To Quest";
            this.LinkQuest.UseVisualStyleBackColor = true;
            this.LinkQuest.CheckedChanged += new System.EventHandler(this.LinkQuest_CheckedChanged);
            // 
            // NoInInstance
            // 
            this.NoInInstance.AutoSize = true;
            this.NoInInstance.Location = new System.Drawing.Point(372, 116);
            this.NoInInstance.Name = "NoInInstance";
            this.NoInInstance.Size = new System.Drawing.Size(96, 17);
            this.NoInInstance.TabIndex = 13;
            this.NoInInstance.Text = "No In Instance";
            this.NoInInstance.UseVisualStyleBackColor = true;
            this.NoInInstance.CheckedChanged += new System.EventHandler(this.NoInInstance_CheckedChanged);
            // 
            // NoInCave
            // 
            this.NoInCave.AutoSize = true;
            this.NoInCave.Location = new System.Drawing.Point(288, 116);
            this.NoInCave.Name = "NoInCave";
            this.NoInCave.Size = new System.Drawing.Size(80, 17);
            this.NoInCave.TabIndex = 12;
            this.NoInCave.Text = "No In Cave";
            this.NoInCave.UseVisualStyleBackColor = true;
            this.NoInCave.CheckedChanged += new System.EventHandler(this.NoInCave_CheckedChanged);
            // 
            // NoInTown
            // 
            this.NoInTown.AutoSize = true;
            this.NoInTown.Location = new System.Drawing.Point(200, 116);
            this.NoInTown.Name = "NoInTown";
            this.NoInTown.Size = new System.Drawing.Size(82, 17);
            this.NoInTown.TabIndex = 11;
            this.NoInTown.Text = "No In Town";
            this.NoInTown.UseVisualStyleBackColor = true;
            this.NoInTown.CheckedChanged += new System.EventHandler(this.NoInTown_CheckedChanged);
            // 
            // NoInBattle
            // 
            this.NoInBattle.AutoSize = true;
            this.NoInBattle.Location = new System.Drawing.Point(112, 116);
            this.NoInBattle.Name = "NoInBattle";
            this.NoInBattle.Size = new System.Drawing.Size(82, 17);
            this.NoInBattle.TabIndex = 10;
            this.NoInBattle.Text = "No In Battle";
            this.NoInBattle.UseVisualStyleBackColor = true;
            this.NoInBattle.CheckedChanged += new System.EventHandler(this.NoInBattle_CheckedChanged);
            // 
            // NoSameBuff
            // 
            this.NoSameBuff.AutoSize = true;
            this.NoSameBuff.Location = new System.Drawing.Point(17, 116);
            this.NoSameBuff.Name = "NoSameBuff";
            this.NoSameBuff.Size = new System.Drawing.Size(92, 17);
            this.NoSameBuff.TabIndex = 9;
            this.NoSameBuff.Text = "No Same Buff";
            this.NoSameBuff.UseVisualStyleBackColor = true;
            this.NoSameBuff.CheckedChanged += new System.EventHandler(this.NoSameBuff_CheckedChanged);
            // 
            // AccumTime
            // 
            this.AccumTime.AutoSize = true;
            this.AccumTime.Location = new System.Drawing.Point(274, 29);
            this.AccumTime.Name = "AccumTime";
            this.AccumTime.Size = new System.Drawing.Size(147, 17);
            this.AccumTime.TabIndex = 8;
            this.AccumTime.Text = "Accumulate Time On Use";
            this.AccumTime.UseVisualStyleBackColor = true;
            this.AccumTime.CheckedChanged += new System.EventHandler(this.AccumTime_CheckedChanged);
            // 
            // BindOnEquip
            // 
            this.BindOnEquip.AutoSize = true;
            this.BindOnEquip.Location = new System.Drawing.Point(175, 29);
            this.BindOnEquip.Name = "BindOnEquip";
            this.BindOnEquip.Size = new System.Drawing.Size(94, 17);
            this.BindOnEquip.TabIndex = 7;
            this.BindOnEquip.Text = "Bind On Equip";
            this.BindOnEquip.UseVisualStyleBackColor = true;
            this.BindOnEquip.CheckedChanged += new System.EventHandler(this.BindOnEquip_CheckedChanged);
            // 
            // Combinable
            // 
            this.Combinable.AutoSize = true;
            this.Combinable.Location = new System.Drawing.Point(88, 29);
            this.Combinable.Name = "Combinable";
            this.Combinable.Size = new System.Drawing.Size(81, 17);
            this.Combinable.TabIndex = 6;
            this.Combinable.Text = "Combinable";
            this.Combinable.UseVisualStyleBackColor = true;
            this.Combinable.CheckedChanged += new System.EventHandler(this.Combinable_CheckedChanged);
            // 
            // NoRepair
            // 
            this.NoRepair.AutoSize = true;
            this.NoRepair.Location = new System.Drawing.Point(372, 93);
            this.NoRepair.Name = "NoRepair";
            this.NoRepair.Size = new System.Drawing.Size(74, 17);
            this.NoRepair.TabIndex = 5;
            this.NoRepair.Text = "No Repair";
            this.NoRepair.UseVisualStyleBackColor = true;
            this.NoRepair.CheckedChanged += new System.EventHandler(this.NoRepair_CheckedChanged);
            // 
            // NoEnchance
            // 
            this.NoEnchance.AutoSize = true;
            this.NoEnchance.Location = new System.Drawing.Point(274, 93);
            this.NoEnchance.Name = "NoEnchance";
            this.NoEnchance.Size = new System.Drawing.Size(92, 17);
            this.NoEnchance.TabIndex = 4;
            this.NoEnchance.Text = "No Enchance";
            this.NoEnchance.UseVisualStyleBackColor = true;
            this.NoEnchance.CheckedChanged += new System.EventHandler(this.NoEnchance_CheckedChanged);
            // 
            // NoDiscard
            // 
            this.NoDiscard.AutoSize = true;
            this.NoDiscard.Location = new System.Drawing.Point(189, 93);
            this.NoDiscard.Name = "NoDiscard";
            this.NoDiscard.Size = new System.Drawing.Size(79, 17);
            this.NoDiscard.TabIndex = 3;
            this.NoDiscard.Text = "No Discard";
            this.NoDiscard.UseVisualStyleBackColor = true;
            this.NoDiscard.CheckedChanged += new System.EventHandler(this.NoDiscard_CheckedChanged);
            // 
            // NoTrade
            // 
            this.NoTrade.AutoSize = true;
            this.NoTrade.Location = new System.Drawing.Point(112, 93);
            this.NoTrade.Name = "NoTrade";
            this.NoTrade.Size = new System.Drawing.Size(71, 17);
            this.NoTrade.TabIndex = 2;
            this.NoTrade.Text = "No Trade";
            this.NoTrade.UseVisualStyleBackColor = true;
            this.NoTrade.CheckedChanged += new System.EventHandler(this.NoTrade_CheckedChanged);
            // 
            // NoDecrease
            // 
            this.NoDecrease.AutoSize = true;
            this.NoDecrease.Location = new System.Drawing.Point(17, 93);
            this.NoDecrease.Name = "NoDecrease";
            this.NoDecrease.Size = new System.Drawing.Size(89, 17);
            this.NoDecrease.TabIndex = 1;
            this.NoDecrease.Text = "No Decrease";
            this.NoDecrease.UseVisualStyleBackColor = true;
            this.NoDecrease.CheckedChanged += new System.EventHandler(this.NoDecrease_CheckedChanged);
            // 
            // Useable
            // 
            this.Useable.AutoSize = true;
            this.Useable.Location = new System.Drawing.Point(17, 29);
            this.Useable.Name = "Useable";
            this.Useable.Size = new System.Drawing.Size(65, 17);
            this.Useable.TabIndex = 0;
            this.Useable.Text = "Useable";
            this.Useable.UseVisualStyleBackColor = true;
            this.Useable.CheckedChanged += new System.EventHandler(this.Useable_CheckedChanged);
            // 
            // OKBtn
            // 
            this.OKBtn.Location = new System.Drawing.Point(463, 250);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(75, 23);
            this.OKBtn.TabIndex = 1;
            this.OKBtn.Text = "Ok";
            this.OKBtn.UseVisualStyleBackColor = true;
            this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
            // 
            // ItemOpPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 282);
            this.Controls.Add(this.OKBtn);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ItemOpPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "GF - Item - Restrict Use";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox NoTrade;
        private System.Windows.Forms.CheckBox NoDecrease;
        private System.Windows.Forms.CheckBox Useable;
        private System.Windows.Forms.CheckBox Replaceable2;
        private System.Windows.Forms.CheckBox Replaceable1;
        private System.Windows.Forms.CheckBox Only5;
        private System.Windows.Forms.CheckBox Only4;
        private System.Windows.Forms.CheckBox Only3;
        private System.Windows.Forms.CheckBox Only2;
        private System.Windows.Forms.CheckBox Only1;
        private System.Windows.Forms.CheckBox ForDead;
        private System.Windows.Forms.CheckBox LinkQuest;
        private System.Windows.Forms.CheckBox NoInInstance;
        private System.Windows.Forms.CheckBox NoInCave;
        private System.Windows.Forms.CheckBox NoInTown;
        private System.Windows.Forms.CheckBox NoInBattle;
        private System.Windows.Forms.CheckBox NoSameBuff;
        private System.Windows.Forms.CheckBox AccumTime;
        private System.Windows.Forms.CheckBox BindOnEquip;
        private System.Windows.Forms.CheckBox Combinable;
        private System.Windows.Forms.CheckBox NoRepair;
        private System.Windows.Forms.CheckBox NoEnchance;
        private System.Windows.Forms.CheckBox NoDiscard;
        private System.Windows.Forms.CheckBox OnlyEquip;
        private System.Windows.Forms.CheckBox UnbindItem;
        private System.Windows.Forms.CheckBox NoTransNode;
        private System.Windows.Forms.CheckBox NoInField;
        private System.Windows.Forms.CheckBox NoInBattlefield;
        private System.Windows.Forms.CheckBox Replaceable5;
        private System.Windows.Forms.CheckBox Replaceable4;
        private System.Windows.Forms.CheckBox Replaceable3;
        private System.Windows.Forms.Button OKBtn;
    }
}