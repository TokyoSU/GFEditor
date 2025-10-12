using Newtonsoft.Json.Converters;
using System.Globalization;

namespace GFEditor.Utils
{
    public static class TranslateUtils
    {
        private const string LanguageFilename = "GFEditor.language.json";
        private const string TranslateFolder = "translations";
        private static JsonTranslate _Json = new();
        private static JsonLanguage _JsonLang = new();

        public static JsonTranslate Json { get { return _Json; } }
        public static JsonLanguage JsonLang { get { return _JsonLang; } }

        public static string GetTranslatedLanguage(TranslatedLanguage language)
        {
            return language switch
            {
                TranslatedLanguage.English => string.Format("{0}/{1}.json", TranslateFolder, language.ToString()),
                TranslatedLanguage.French => string.Format("{0}/{1}.json", TranslateFolder, language.ToString()),
                _ => string.Empty
            };
        }

        public static void Load()
        {
            // Get the language type inside the json.
            _JsonLang = JsonLanguageExtensions.FromJson(File.ReadAllText(LanguageFilename));

            // Now get the file based on the language loaded
            // If null select english by default.
            var filePath = GetTranslatedLanguage(_JsonLang != null ? _JsonLang.Language : TranslatedLanguage.English);
            if (string.IsNullOrEmpty(filePath))
            {
                Console.WriteLine("Selected default language.");
                filePath = TranslateFolder + "/English.json";
            }

            _Json = JsonTranslateExtensions.FromJson(File.ReadAllText(filePath));
            if (_Json == null || _Json.TranslatedValues == null)
                throw new Exception("Translation file is null !");
        }
    }

    public enum TranslatedLanguage
    {
        English,
        French
    }

    public partial class JsonLanguage
    {
        [JsonProperty("Language")]
        public TranslatedLanguage Language;
    }

    public partial class JsonTranslate
    {
        [JsonProperty("TranslatedValues")]
        public EditorTranslate TranslatedValues = new();
    }

    public partial class EditorTranslate
    {
        [JsonProperty("FileBtnName")]
        public string FileBtnName = string.Empty;

        [JsonProperty("EditorBar")]
        public string EditorBar = string.Empty;

        [JsonProperty("ItemEditor")]
        public string ItemEditor = string.Empty;

        [JsonProperty("SelectGameFolder")]
        public string SelectGameFolder = string.Empty;

        [JsonProperty("BackupGameData")]
        public string BackupGameData = string.Empty;

        [JsonProperty("ClientName")]
        public string ClientName = string.Empty;

        [JsonProperty("ServerName")]
        public string ServerName = string.Empty;

        [JsonProperty("TranslateName")]
        public string TranslateName = string.Empty;

        [JsonProperty("IconName")]
        public string IconName = string.Empty;

        [JsonProperty("SelectFolderTitleStr")]
        public string SelectFolderTitleStr = string.Empty;

        [JsonProperty("SelectFolderSuccessStr")]
        public string SelectFolderSuccessStr = string.Empty;

        [JsonProperty("SelectFolderCanceledStr")]
        public string SelectFolderCanceledStr = string.Empty;

        [JsonProperty("SelectFolderFailedStr")]
        public string SelectFolderFailedStr = string.Empty;

        [JsonProperty("ItemEditorName")]
        public string ItemEditorName = string.Empty;

        [JsonProperty("ItemListName")]
        public string ItemListName = string.Empty;

        [JsonProperty("AddBtnName")]
        public string AddBtnName = string.Empty;

        [JsonProperty("RemoveBtnName")]
        public string RemoveBtnName = string.Empty;

        [JsonProperty("UbuntuName")]
        public string UbuntuName = string.Empty;

        [JsonProperty("Connect")]
        public string Connect = string.Empty;

        [JsonProperty("Disconnect")]
        public string Disconnect = string.Empty;

        [JsonProperty("HeaderItemIndex")]
        public string HeaderItemIndex = string.Empty;

        [JsonProperty("HeaderItemName")]
        public string HeaderItemName = string.Empty;

        [JsonProperty("HeaderItemModel")]
        public string HeaderItemModel = string.Empty;

        [JsonProperty("HeaderItemBasics")]
        public string HeaderItemBasics = string.Empty;

        [JsonProperty("HeaderDropName")]
        public string HeaderDropName = string.Empty;

        [JsonProperty("HeaderItemIcon")]
        public string HeaderItemIcon = string.Empty;

        [JsonProperty("HeaderItemStats")]
        public string HeaderItemStats = string.Empty;

        [JsonProperty("HeaderItemCooldown")]
        public string HeaderItemCooldown = string.Empty;

        [JsonProperty("HeaderItemRebirth")]
        public string HeaderItemRebirth = string.Empty;

        [JsonProperty("HeaderItemMiscellaneous")]
        public string HeaderItemMiscellaneous = string.Empty;

        [JsonProperty("HeaderItemDrop")]
        public string HeaderItemDrop = string.Empty;

        [JsonProperty("HeaderItemEffects")]
        public string HeaderItemEffects = string.Empty;

        [JsonProperty("HeaderItemRestriction")]
        public string HeaderItemRestriction = string.Empty;

        [JsonProperty("HeaderItemRestrictionTime")]
        public string HeaderItemRestrictionTime = string.Empty;

        [JsonProperty("HeaderItemFlags")]
        public string HeaderItemFlags = string.Empty;

        [JsonProperty("HeaderItemReputation")]
        public string HeaderItemReputation = string.Empty;

        [JsonProperty("HeaderItemAttribute")]
        public string HeaderItemAttribute = string.Empty;

        [JsonProperty("HeaderItemEnchantments")]
        public string HeaderItemEnchantments = string.Empty;

        [JsonProperty("HeaderItemElf")]
        public string HeaderItemElf = string.Empty;

        [JsonProperty("HeaderItemSpecial")]
        public string HeaderItemSpecial = string.Empty;

        [JsonProperty("HeaderItemPrice")]
        public string HeaderItemPrice = string.Empty;

        [JsonProperty("HeaderItemSockets")]
        public string HeaderItemSockets = string.Empty;

        [JsonProperty("HeaderItemClass")]
        public string HeaderItemClass = string.Empty;

        [JsonProperty("HeaderItemAuction")]
        public string HeaderItemAuction = string.Empty;

        [JsonProperty("HeaderItemExperience")]
        public string HeaderItemExperience = string.Empty;

        [JsonProperty("HeaderItemMissionAndEvents")]
        public string HeaderItemMissionAndEvents = string.Empty;

        [JsonProperty("FighterSection")]
        public string FighterSection = string.Empty;

        [JsonProperty("HunterSection")]
        public string HunterSection = string.Empty;

        [JsonProperty("AcolyteSection")]
        public string AcolyteSection = string.Empty;

        [JsonProperty("SpellcasterSection")]
        public string SpellcasterSection = string.Empty;

        [JsonProperty("MechanicSection")]
        public string MechanicSection = string.Empty;

        [JsonProperty("WandererSection")]
        public string WandererSection = string.Empty;

        [JsonProperty("OpFlags")]
        public string OpFlags = string.Empty;

        [JsonProperty("OpFlagsPlus")]
        public string OpFlagsPlus = string.Empty;

        [JsonProperty("OpFlagsDesc")]
        public OpFlagsDesc OpFlagsDesc = new();

        [JsonProperty("ItemQuality")]
        public string ItemQualityName = string.Empty;

        [JsonProperty("ItemType")]
        public string ItemTypeName = string.Empty;

        [JsonProperty("EquipType")]
        public string EquipTypeName = string.Empty;

        [JsonProperty("DropIndex")]
        public string DropIndexName = string.Empty;

        [JsonProperty("DropRate")]
        public string DropRateName = string.Empty;

        [JsonProperty("DropType")]
        public string DropTypeName = string.Empty;

        [JsonProperty("ClassesNames")]
        public List<string> ClassesNames = [];

        public string GetClassName(ERestrictClass type)
        {
            if (ClassesNames == null || ClassesNames.Count <= 0) return "NullOrEmpty";
            return type switch
            {
                ERestrictClass.Novice => ClassesNames[0],
                ERestrictClass.Fighter => ClassesNames[1],
                ERestrictClass.Warrior => ClassesNames[2],
                ERestrictClass.Paladin => ClassesNames[3],
                ERestrictClass.Berserker => ClassesNames[4],
                ERestrictClass.Hunter => ClassesNames[5],
                ERestrictClass.Archer => ClassesNames[6],
                ERestrictClass.Ranger => ClassesNames[7],
                ERestrictClass.Assassin => ClassesNames[8],
                ERestrictClass.Acolyte => ClassesNames[9],
                ERestrictClass.Priest => ClassesNames[10],
                ERestrictClass.Cleric => ClassesNames[11],
                ERestrictClass.Sage => ClassesNames[12],
                ERestrictClass.Spellcaster => ClassesNames[13],
                ERestrictClass.Mage => ClassesNames[14],
                ERestrictClass.Wizard => ClassesNames[15],
                ERestrictClass.Necromancer => ClassesNames[16],
                ERestrictClass.Warlord => ClassesNames[17],
                ERestrictClass.Templar => ClassesNames[18],
                ERestrictClass.Sharpshooter => ClassesNames[19],
                ERestrictClass.DarkStalker => ClassesNames[20],
                ERestrictClass.Prophet => ClassesNames[21],
                ERestrictClass.Mystic => ClassesNames[22],
                ERestrictClass.Archmage => ClassesNames[23],
                ERestrictClass.Demonologist => ClassesNames[24],
                ERestrictClass.Mechanic => ClassesNames[25],
                ERestrictClass.Machinist => ClassesNames[26],
                ERestrictClass.Enginner => ClassesNames[27],
                ERestrictClass.Demolitionist => ClassesNames[28],
                ERestrictClass.GearMaster => ClassesNames[29],
                ERestrictClass.Gunner => ClassesNames[30],
                ERestrictClass.Deathknight => ClassesNames[31],
                ERestrictClass.Crusader => ClassesNames[32],
                ERestrictClass.Hawkeye => ClassesNames[33],
                ERestrictClass.Windshadow => ClassesNames[34],
                ERestrictClass.Saint => ClassesNames[35],
                ERestrictClass.Shaman => ClassesNames[36],
                ERestrictClass.Avatar => ClassesNames[37],
                ERestrictClass.Shadowlord => ClassesNames[38],
                ERestrictClass.Destroyer => ClassesNames[39],
                ERestrictClass.HolyKnight => ClassesNames[40],
                ERestrictClass.Predator => ClassesNames[41],
                ERestrictClass.Shinobi => ClassesNames[42],
                ERestrictClass.Archangel => ClassesNames[43],
                ERestrictClass.Druid => ClassesNames[44],
                ERestrictClass.Warlock => ClassesNames[45],
                ERestrictClass.Shinigami => ClassesNames[46],
                ERestrictClass.CogMaster => ClassesNames[47],
                ERestrictClass.Bombardier => ClassesNames[48],
                ERestrictClass.MechMaster => ClassesNames[49],
                ERestrictClass.Artillerist => ClassesNames[50],
                ERestrictClass.Wanderer => ClassesNames[51],
                ERestrictClass.Drifter => ClassesNames[52],
                ERestrictClass.VoidRunner => ClassesNames[53],
                ERestrictClass.TimeTraveler => ClassesNames[54],
                ERestrictClass.Dimensionalist => ClassesNames[55],
                ERestrictClass.KeyMaster => ClassesNames[56],
                ERestrictClass.Reaper => ClassesNames[57],
                ERestrictClass.Chronomancer => ClassesNames[58],
                ERestrictClass.Phantom => ClassesNames[59],
                ERestrictClass.ChronoShifter => ClassesNames[60],
                _ => "None",
            };
        }
    }

    public class OpFlagsDesc
    {
        [JsonProperty("CanUse")]
        public string CanUse = string.Empty;
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new()
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    public static class JsonTranslateExtensions
    {
        public static string ToJson(this JsonTranslate self) => JsonConvert.SerializeObject(self, Converter.Settings);
        public static JsonTranslate FromJson(string json)
        {
            var result = JsonConvert.DeserializeObject<JsonTranslate>(json, Converter.Settings);
            return result ?? new JsonTranslate();
        }
    }

    public static class JsonLanguageExtensions
    {
        public static string ToJson(this JsonLanguage self) => JsonConvert.SerializeObject(self, Converter.Settings);
        public static JsonLanguage FromJson(string json)
        {
            var result = JsonConvert.DeserializeObject<JsonLanguage>(json, Converter.Settings);
            return result ?? new JsonLanguage();
        }
    }
}
