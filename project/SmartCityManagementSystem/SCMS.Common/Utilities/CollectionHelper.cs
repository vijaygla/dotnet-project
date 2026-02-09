using System;
using System.Collections.Generic;
using System.Linq;

namespace SCMS.Common.Utilities
{
    public static class CollectionHelper
    {
        public static List<T> Filter<T>(List<T> items, Predicate<T> condition)
        {
            return items.FindAll(condition);
        }

        public static T FindMax<T>(List<T> items) where T : IComparable<T>
        {
            return items.OrderByDescending(x => x).FirstOrDefault();
        }

        public static void Swap<T>(T[] array, int i, int j)
        {
            T temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
