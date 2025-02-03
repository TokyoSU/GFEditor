using Newtonsoft.Json;
using System;

namespace GFEditor.Structs
{
    public class TTextIndex : IComparable<TTextIndex>
    {
        [JsonProperty]
        public int Index;
        [JsonProperty]
        public string Value;

        public int CompareTo(TTextIndex other)
        {
            if (Index < other.Index) return -1;
            if (Index > other.Index) return 1;
            return 0;
        }

        public override string ToString()
        {
            return $"{Index}|{Value}|";
        }
    }
}
