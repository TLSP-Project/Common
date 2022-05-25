

namespace TLSP.Common.Extensions
{
    public static class DictionaryExtensions
    {
        public static TKey FindKey<TKey, TValue>(this Dictionary<TKey, TValue> dic, TValue value) 
        {

            return dic.First(p => p.Value.Equals(value)).Key;
        }
    }
}
