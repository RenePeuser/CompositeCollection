using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;

namespace CompositeCollection.Extensions
{
    public static class CompositeCollectionExtensions
    {
        public static void TrySetSortDescription(this System.Windows.Data.CompositeCollection compositeCollection, SortDescription sortDescription)
        {
            if (compositeCollection == null)
            {
                throw new ArgumentNullException(nameof(compositeCollection));
            }

            if (sortDescription == null)
            {
                throw new ArgumentNullException(nameof(sortDescription));
            }

            var collectionViews = compositeCollection.ContainerCollectionsOfType<ICollectionView>().ToList();

            if (!collectionViews.Any())
            {
                throw new ArgumentException("CompositeCollection does not contains ICollectionView to set sortdescription");
            }

            collectionViews.ForEach(item => item.UpdateSortDescription(sortDescription));
        }

        public static IEnumerable<T> ContainerCollectionsOfType<T>(this System.Windows.Data.CompositeCollection compositeCollection) where T : ICollectionView
        {
            if (compositeCollection == null)
            {
                throw new ArgumentNullException();
            }

            var collectionViews = compositeCollection.OfType<CollectionContainer>()
                                                     .Select(item => item.Collection)
                                                     .OfType<T>();
            return collectionViews;
        }
    }
}
