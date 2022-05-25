using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLSP.Common.Extensions
{
    public static class ListsExtensions
    {
		/// <summary>
		/// 将List分成多个子List
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="original"></param>
		/// <param name="partSize">子List所含有的成员数量</param>
		/// <returns></returns>
		public static List<List<T>> Split<T>(this List<T> original, int partSize = 50)
		{
			List<List<T>> list = new List<List<T>>();
			for (int i = 0; i < original.Count; i += partSize)
			{
				list.Add(original.GetRange(i, Math.Min(partSize, original.Count - i)));
			}
			return list;
		}

	}
}
