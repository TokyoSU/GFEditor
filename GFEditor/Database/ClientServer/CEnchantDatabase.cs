namespace GFEditor.Database.ClientServer
{
    public static class CEnchantDatabase
    {
        private static readonly Logger m_Log = LogManager.GetLogger("C_Enchant");
        private static List<Enchantment>? Enchantments = [];
        private static readonly List<Enchantment>? EnchantmentServer = [];
    }
}
