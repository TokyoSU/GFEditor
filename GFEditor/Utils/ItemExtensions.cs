using GFEditor.Enums;
using GFEditor.Structs;
using System.Windows.Forms;

namespace GFEditor.Utils
{
    public static class ItemExtensions
    {
        public static void SetOpFlags(this CSItem item, CheckBox box, ItemOpFlags flags)
        {
            if (item == null || box == null) return;
            if (box.Checked)
                item.OpFlags |= (uint)flags;
            else
                item.OpFlags &= ~(uint)flags;
        }

        public static void SetClassFlags(this CSItem item, CheckBox box, ClassTypeEnum flags)
        {
            if (item == null || box == null) return;
            if (box.Checked)
                item.RestrictClass |= (ulong)flags;
            else
                item.RestrictClass &= ~(ulong)flags;
        }
    }
}
