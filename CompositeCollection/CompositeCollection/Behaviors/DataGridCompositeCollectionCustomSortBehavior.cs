using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Interactivity;
using CompositeCollection.Extensions;

namespace CompositeCollection.Behaviors
{
    public class DataGridCompositeCollectionCustomSortBehavior : Behavior<DataGrid>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.Sorting += AssociatedObjectSorting;
        }

        private void AssociatedObjectSorting(object sender, DataGridSortingEventArgs e)
        {
            var compositeCollection = AssociatedObject.ItemsSource as System.Windows.Data.CompositeCollection;
            if (compositeCollection == null)
            {
                return;
            }

            ListSortDirection newSortDirection;
            if (e.Column.SortDirection == null)
            {
                newSortDirection = ListSortDirection.Ascending;
            }
            else
            {
                newSortDirection = e.Column.SortDirection.Value == ListSortDirection.Ascending
                                           ? ListSortDirection.Descending
                                           : ListSortDirection.Ascending;
            }

            compositeCollection.TrySetSortDescription(new SortDescription(e.Column.SortMemberPath, newSortDirection));
        }
    }
}
