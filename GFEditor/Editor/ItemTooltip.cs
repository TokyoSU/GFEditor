namespace GFEditor.Editor
{
    public partial class ItemTooltip : Form
    {
        private CSItem? m_Item;

        public ItemTooltip()
        {
            InitializeComponent();
            ControlBox = false;
            TooltipTxt.Font = new Font("Arial Unicode MS", TooltipTxt.Font.Size);
            TooltipTxt.BackColor = SColor.SaddleBrown;
        }

        private bool TranslateCommand(string value)
        {
            if (m_Item == null)
            {
                Console.WriteLine("Failed to translate command, item is null, was it assigned beforehand ?");
                return false;
            }

            TTextIndex? textIndex;
            switch (value)
            {
                case "#9#":
                    switch ((QualityType)m_Item.ItemQuality)
                    {
                        case QualityType.Gray:
                            TooltipTxt.SelectionColor = SColor.Gray;
                            break;
                        case QualityType.White:
                            TooltipTxt.SelectionColor = SColor.White;
                            break;
                        case QualityType.Green:
                            TooltipTxt.SelectionColor = SColor.Green;
                            break;
                        case QualityType.Blue:
                            TooltipTxt.SelectionColor = SColor.Blue;
                            break;
                        case QualityType.Orange:
                            TooltipTxt.SelectionColor = SColor.Orange;
                            break;
                        case QualityType.Gold:
                            TooltipTxt.SelectionColor = SColor.Gold;
                            break;
                        case QualityType.Purple:
                            TooltipTxt.SelectionColor = SColor.Purple;
                            break;
                        case QualityType.Red:
                            TooltipTxt.SelectionColor = SColor.Red;
                            break;
                    }
                    TooltipTxt.AppendText(m_Item.Name + "\n");
                    break;

                case "#12#":
                    TooltipTxt.SelectionColor = SColor.White;
                    textIndex = TTextIndexDatabase.GetByIndex(72);
                    if (textIndex != null)
                        TooltipTxt.AppendText(textIndex.Value + "\n");
                    else
                        TooltipTxt.AppendText("Bind on Equip. (Not from T_TextIndex)\n");
                    break;

                case "#79#": // Reverse bound.
                    TooltipTxt.SelectionColor = SColor.AliceBlue;
                    textIndex = TTextIndexDatabase.GetByIndex(11971);
                    if (textIndex != null)
                        TooltipTxt.AppendText(textIndex.Value + "\n");
                    else
                        TooltipTxt.AppendText("You can reverse this item's bound status. (Not from T_TextIndex)\n");
                    break;
                case "#82#": // Unknown
                    TooltipTxt.SelectionColor = SColor.White;
                    TooltipTxt.AppendText("{Unknown Parameters}\n");
                    break;
                case "#83#": // Star for Holy Equipment. (Graphics)
                    if (m_Item.IsHoly())
                    {
                        TooltipTxt.SelectionColor = SColor.Red;
                        TooltipTxt.AppendText("✩✩✩✩✩\n"); // No text for star.
                    }
                    break;
                case "#84#": // Eligible for Holy Equipment Enchant.
                    if (m_Item.IsHoly())
                    {
                        TooltipTxt.SelectionColor = SColor.AliceBlue;
                        textIndex = TTextIndexDatabase.GetByIndex(16563);
                        if (textIndex != null)
                            TooltipTxt.AppendText(textIndex.Value + "\n"); // 16563 is for the correct text.
                        else
                            TooltipTxt.AppendText("Eligible for Holy Equipment Enchantment. (Not from T_TextIndex)\n");
                    } 
                    break;
                default:
                    TooltipTxt.SelectionColor = SColor.White;
                    TooltipTxt.AppendText(value + "\n");
                    break;
            }

            return true;
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
                    if (!TranslateCommand(str)) // false = no_item, avoid spamming logs with the same info...
                        break;
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
