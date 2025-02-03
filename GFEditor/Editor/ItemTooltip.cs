using GFEditor.Database;
using GFEditor.Enums;
using GFEditor.Structs;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GFEditor.Editor
{
    public partial class ItemTooltip : Form
    {
        private CSItem m_Item;

        public ItemTooltip()
        {
            InitializeComponent();
            ControlBox = false;
            TooltipTxt.Font = new Font("Arial Unicode MS", TooltipTxt.Font.Size);
            TooltipTxt.BackColor = Color.SaddleBrown;
        }

        private void TranslateCommand(string value)
        {
            TTextIndex textIndex;
            switch (value)
            {
                case "#9#":
                    switch ((ItemQualityEnum)m_Item.ItemQuality)
                    {
                        case ItemQualityEnum.Gray:
                            TooltipTxt.SelectionColor = Color.Gray;
                            break;
                        case ItemQualityEnum.White:
                            TooltipTxt.SelectionColor = Color.White;
                            break;
                        case ItemQualityEnum.Green:
                            TooltipTxt.SelectionColor = Color.Green;
                            break;
                        case ItemQualityEnum.Blue:
                            TooltipTxt.SelectionColor = Color.Blue;
                            break;
                        case ItemQualityEnum.Orange:
                            TooltipTxt.SelectionColor = Color.Orange;
                            break;
                        case ItemQualityEnum.Gold:
                            TooltipTxt.SelectionColor = Color.Gold;
                            break;
                        case ItemQualityEnum.Purple:
                            TooltipTxt.SelectionColor = Color.Purple;
                            break;
                        case ItemQualityEnum.Red:
                            TooltipTxt.SelectionColor = Color.Red;
                            break;
                    }
                    TooltipTxt.AppendText(m_Item.Name + "\n");
                    break;

                case "#12#":
                    TooltipTxt.SelectionColor = Color.White;
                    textIndex = TTextIndexDatabase.GetByIndex(72);
                    if (textIndex != null)
                        TooltipTxt.AppendText(textIndex.Value + "\n");
                    else
                        TooltipTxt.AppendText("Bind on Equip. (Not from T_TextIndex)\n");
                    break;

                case "#79#": // Reverse bound.
                    TooltipTxt.SelectionColor = Color.AliceBlue;
                    textIndex = TTextIndexDatabase.GetByIndex(11971);
                    if (textIndex != null)
                        TooltipTxt.AppendText(textIndex.Value + "\n");
                    else
                        TooltipTxt.AppendText("You can reverse this item's bound status. (Not from T_TextIndex)\n");
                    break;
                case "#82#": // Unknown
                    TooltipTxt.SelectionColor = Color.White;
                    TooltipTxt.AppendText("{Unknown Parameters}\n");
                    break;
                case "#83#": // Star for Holy Equipment. (Graphics)
                    if (m_Item.IsHoly())
                    {
                        TooltipTxt.SelectionColor = Color.Red;
                        TooltipTxt.AppendText("✩✩✩✩✩\n"); // No text for star.
                    }
                    break;
                case "#84#": // Eligible for Holy Equipment Enchant.
                    if (m_Item.IsHoly())
                    {
                        TooltipTxt.SelectionColor = Color.AliceBlue;
                        textIndex = TTextIndexDatabase.GetByIndex(16563);
                        if (textIndex != null)
                            TooltipTxt.AppendText(textIndex.Value + "\n"); // 16563 is for the correct text.
                        else
                            TooltipTxt.AppendText("Eligible for Holy Equipment Enchantment. (Not from T_TextIndex)\n");
                    } 
                    break;
                default:
                    TooltipTxt.SelectionColor = Color.White;
                    TooltipTxt.AppendText(value + "\n");
                    break;
            }
        }

        private void MakeTooltip()
        {
            TooltipTxt.Clear(); // Remove previous text if any.
            // First, get the tooltip format in the translation file (T_TextIndex)
            var tooltipText = TTextIndexDatabase.GetByStringInText("#9#");
            if (tooltipText != null)
            {
                var list = tooltipText.Value.Split('\n');
                foreach (var str in list)
                {
                    TranslateCommand(str);
                }
            }
            else
            {
                Console.WriteLine("[ItemTooltip] Failed to get the tooltip format in T_TextIndex by using #9# !");
            }
        }

        public void SetItem(CSItem item)
        {
            m_Item = item;
            if (m_Item != null)
                MakeTooltip();
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
