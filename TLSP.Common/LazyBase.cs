
namespace TLSP.Common
{
	public class LazyBase<T> where T : class, new()
	{

		public static T Instance
		{
			get
			{
				return a.Value;
			}
		}

		private static readonly Lazy<T> a = new Lazy<T>(true);

	}
}
