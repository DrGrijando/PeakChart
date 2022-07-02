namespace FlowChart.Converters
{
    using System;
    using System.Collections;
    using System.Globalization;
    using Xamarin.Forms;

    /// <summary>
    ///     <para>Returns a visibility value depending on whether the given collection is empty or not.</para>
    ///     <para>If no parameter is supplied, it will return false if the collection is empty, and true otherwise.</para>
    /// </summary>
    public class CollectionEmptyToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool result = false;

            if (value == null || !(value is ICollection collection))
                return result;
            
            if (parameter != null)
                result = bool.Parse((string)parameter);

            return collection.Count == 0 ? result : !result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) { return null; }
    }
}
