namespace GFEditor
{
    public static class Constants
    {
        // Path

        public static string AssetItemPath = "Assets/Items/";
        public static string AssetChestPath = "Assets/DropChest/";
        public static string AssetDataPath = "Assets/Data/";
        public static string AssetSoundPath = "Assets/Sounds/";
        public static string AssetClientPath = AssetDataPath + "Client/";
        public static string AssetServerPath = AssetDataPath + "Server/";
        public static string AssetTranslatePath = AssetDataPath + "Translate/";
        public static string AssetGenClientPath = AssetDataPath + "Generated/Client/";
        public static string AssetGenServerPath = AssetDataPath + "Generated/Server/";
        public static string AssetGenTranslatePath = AssetDataPath + "Generated/Translate/";
        public static string AssetGenDatabasePath = AssetDataPath + "Generated/Database/";

        // Inis

        public static string AssetOrigCItemPath = AssetClientPath + "c_item.ini";
        public static string AssetOrigSItemPath = AssetServerPath + "S_Item.ini";

        public static string AssetOrigTTextIndex = AssetTranslatePath + "T_TextIndex.ini";

        // Inis Destination

        public static string AssetCItemPath = AssetGenClientPath + "C_Item.ini";
        public static string AssetSItemPath = AssetGenServerPath + "S_Item.ini";

        public static string AssetTTextIndex = AssetGenTranslatePath + "T_TextIndex.ini";

        // Database

        public static string AssetJItemPath = AssetGenDatabasePath + "Items.json";
        public static string AssetJTTextIndex = AssetGenDatabasePath + "TextIndex.json";

        // Images

        public static string NoChestDropImg = AssetChestPath + "NoChestDrop.png";
        public static string G00001Img = AssetChestPath + "G00001.png";
        public static string G00002Img = AssetChestPath + "G00002.png";
        public static string G00003Img = AssetChestPath + "G00003.png";
        public static string G00004Img = AssetChestPath + "G00004.png";
        public static string G00005Img = AssetChestPath + "G00005.png";
        public static string G00006Img = AssetChestPath + "G00006.png";
        public static string G00007Img = AssetChestPath + "G00007.png";
        public static string G00008Img = AssetChestPath + "G00008.png";
        public static string G00009Img = AssetChestPath + "G00009.png";
        public static string G00010Img = AssetChestPath + "G00010.png";
        public static string G00020Img = AssetChestPath + "G00020.png";
    }
}
