using System.Collections.Generic;
namespace DKGame
{
	public static class DKGameUtilities
	{
		public static void ListDifference<T>(List<T> list1, List<T> list2, List<T> notInList1, List<T> notInList2)
		{
			foreach (T obj in list1)
			{
				if (!list2.Contains(obj))
				{
					notInList2.Add(obj);
				}
			}
			foreach (T obj in list2)
			{
				if (!list1.Contains(obj))
				{
					notInList1.Add(obj);
				}
			}
		}
	}
}

