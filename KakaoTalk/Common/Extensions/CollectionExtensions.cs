using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Common.Extensions
{
    public static  class CollectionExtensions
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> col)
        {
            if (col == null) return null;
            return new ObservableCollection<T>(col);
        }

        public static int Remove<T>(
            this ObservableCollection<T> coll, Func<T, bool> condition)
        {
            var itemsToRemove = coll.Where(condition).ToList();
            foreach (var itemToRemove in itemsToRemove)
            {
                coll.Remove(itemToRemove);
            }
            return itemsToRemove.Count;
        }

        public static T PickRandom<T>(this IEnumerable<T> source)
        {
            return source.PickRandom(1).Single();
        }

        public static IEnumerable<T> PickRandom<T>(this IEnumerable<T> source, int count)
        {
            return source.Shuffle().Take(count);
        }

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        {
            return source.OrderBy(x => Guid.NewGuid());
        }

        public static void AddRange<T>(this ObservableCollection<T> coll, IEnumerable<T> collection)
        {
            if (collection == null) return;
            foreach (T item in collection)
            {
                coll.Add(item);
            }
        }

        public static void AddRangeFirst<T>(this ObservableCollection<T> coll, IEnumerable<T> collection)
        {
            if (collection == null) return;
            var reverseCollection = collection.Reverse();
            foreach (T item in reverseCollection)
            {
                coll.Insert(0, item);
            }
        }

        public static int RemoveAll<T>(this ObservableCollection<T> coll, Func<T, bool> condition)
        {
            var itemsToRemove = coll.Where(condition).ToList();
            foreach (var itemToRemove in itemsToRemove)
            {
                coll.Remove(itemToRemove);
            }
            return itemsToRemove.Count;
        }
    }
}
