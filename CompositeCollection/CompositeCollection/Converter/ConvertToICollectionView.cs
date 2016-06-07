using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace CompositeCollection.Converter
{
    public class ConvertToICollectionView : MarkupExtension, IValueConverter
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var collectionView = (System.Windows.Data.CompositeCollection)value;
            var factory = (ICollectionViewFactory)collectionView;            
            var view = factory.CreateView();
            return view;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
