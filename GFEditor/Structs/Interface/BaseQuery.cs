namespace GFEditor.Structs.Interface
{
    public class BaseQuery<KEY, VALUE>
        where KEY: notnull
        where VALUE: class
    {
        protected Dictionary<KEY, VALUE> m_kMap = [];

        public virtual void ReadFile(string filePath) {}
    }
}
