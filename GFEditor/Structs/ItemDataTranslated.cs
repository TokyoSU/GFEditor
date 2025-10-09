namespace GFEditor.Structs
{
    public class ItemDataTranslated
    {
        [JsonProperty("id")]
        public IdType m_nId;
        [JsonProperty("name")]
        public string m_kName = string.Empty;
        [JsonProperty("tip")]
        public string m_kTip = string.Empty;

        public override string ToString()
        {
            return $"{m_nId}";
        }
    }
}
