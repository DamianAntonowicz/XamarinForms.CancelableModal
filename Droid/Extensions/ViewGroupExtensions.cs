using System.Collections.Generic;

namespace Android.Views
{
    public static class ViewGroupExtensions
    {
        private const string PADDING_STRING = "  ";
        private static string _currentPadding = "";

        public static IList<T> GetChildrenOfType<T>(this ViewGroup viewGroup)
            where T : class
        {
            var listToReturn = new List<T>();

            System.Diagnostics.Debug.WriteLine(_currentPadding + viewGroup.GetType().Name + " (ViewGroup)");
            
            _currentPadding += PADDING_STRING;

            for (int i = 0; i < viewGroup.ChildCount; i++)
            {
                Android.Views.View child = viewGroup.GetChildAt(i);
                
                if (!(child is ViewGroup))
                {
                    System.Diagnostics.Debug.WriteLine(_currentPadding + child.GetType().Name);
                }

                if (child.GetType() == typeof(T))
                {
                    listToReturn.Add(child as T);
                }

                if (child is ViewGroup childViewGroup)
                {
                    listToReturn.AddRange(GetChildrenOfType<T>(childViewGroup));
                }
            }

            _currentPadding = _currentPadding.Remove(_currentPadding.Length - PADDING_STRING.Length);

            return listToReturn;
        }
    }
}