namespace CompositeCollection.Extensions
{
    public static class ObjectExtensions
    {
        public static T Cast<T>(this object source)
        {
            return (T)source;
        }

        public static T As<T>(this object source) where T : class
        {
            return source as T;
        }
    }
}
