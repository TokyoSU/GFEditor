namespace GFEditor.Utils
{
    public class GFStringReader(List<string> strings)
    {
        private readonly List<string> Strings = strings;
        private int CurrentIndex = 0;
        public bool EndOfStrings => CurrentIndex >= Strings.Count;

        public string ReadString()
        {
            if (EndOfStrings) throw new InvalidOperationException("No more strings to read.");
            return Strings[CurrentIndex++];
        }

        public int ReadInt()
        {
            var str = ReadString();
            return str.AsInt();
        }

        public uint ReadUInt()
        {
            var str = ReadString();
            return str.AsUInt();
        }

        public short ReadShort()
        {
            var str = ReadString();
            return str.AsShort();
        }

        public ushort ReadUShort()
        {
            var str = ReadString();
            return str.AsUShort();
        }

        public char ReadChar()
        {
            var str = ReadString();
            return str.AsChar();
        }

        public byte ReadByte()
        {
            var str = ReadString();
            return str.AsByte();
        }

        public sbyte ReadSByte()
        {
            var str = ReadString();
            return str.AsSByte();
        }

        public long ReadLong()
        {
            var str = ReadString();
            return str.AsLong();
        }

        public ulong ReadULong()
        {
            var str = ReadString();
            return str.AsULong();
        }

        public float ReadFloat()
        {
            var str = ReadString();
            return str.AsSingle();
        }

        public double ReadDouble()
        {
            var str = ReadString();
            return str.AsDouble();
        }

        public bool ReadBool()
        {
            var str = ReadString();
            return str.AsByte() != 0;
        }

        public ulong ReadHex()
        {
            var str = ReadString();
            return str.AsHex();
        }
    }
}
