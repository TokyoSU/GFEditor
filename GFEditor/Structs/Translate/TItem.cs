namespace GFEditor.Structs.Translate
{
    public class TItem : IComparable<TItem>
    {
        [JsonProperty]
        public int Index;
        [JsonProperty]
        public required string Name;
        [JsonProperty]
        public required string Description;

        public int CompareTo(TItem? other)
        {
            if (other == null) return 1;
            if (Index < other.Index) return -1;
            if (Index > other.Index) return 1;
            return 0;
        }

        public override string ToString()
        {
            return $"{Index}|{Name}|{Description}|";
        }
    }
}
