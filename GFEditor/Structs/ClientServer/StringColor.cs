namespace GFEditor.Structs.ClientServer
{
    public class StringColor
    {
        [JsonProperty]
        public int Alpha;
        [JsonProperty]
        public int Red;
        [JsonProperty]
        public int Green;
        [JsonProperty]
        public int Blue;
        [JsonProperty]
        public int IndexInGame;
        [JsonProperty]
        public SColor Color; // For Form Text Only.

        public override string ToString()
        {
            return $"{Red},{Green},{Blue},{IndexInGame}-";
        }
    }
}
