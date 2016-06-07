using System;
using System.ComponentModel;

namespace CompositeCollection.Extensions
{
    public static class CollectionViewExtensions
    {
        public static void UpdateSortDescription(this ICollectionView collectionView, SortDescription sortDescription)
        {
            if (collectionView == null)
            {
                throw new ArgumentNullException("collectionView");
            }

            if (sortDescription == null)
            {
                throw new ArgumentNullException("sortDescription");
            }

            collectionView.SortDescriptions.Clear();
            collectionView.SortDescriptions.Add(sortDescription);
        }
    }
}
