using System.IO;
using System.Text;

namespace GFEditor.Utils
{
    public static class TooltipHelper
    {
        public static void MakeTooltipDecryptor()
        {
            var stringBuilder = new StringBuilder();
            for (int i = 0; i < 101; i++) // From 0 to 100
            {
                stringBuilder.AppendLine($"ID{i}: #{i}#");
            }
            File.WriteAllText("Tooltip.txt", stringBuilder.ToString());
        }

    }
}
