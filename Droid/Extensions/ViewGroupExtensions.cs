using System.Collections.Generic;

namespace Android.Views
{
    public static class ViewGroupExtensions
    {
        public static IEnumerable<T> GetChildrenOfType<T>(this ViewGroup viewGroup)
            where T : View
        {
            for (int i = 0; i < viewGroup.ChildCount; i++)
            {
                View child = viewGroup.GetChildAt(i);

                if (child is T expectedChild)
                {
                    yield return expectedChild;
                }

                if (child is ViewGroup childViewGroup)
                {
                    foreach (var expectedInnerChild in GetChildrenOfType<T>(childViewGroup))
                    {
                        yield return expectedInnerChild;
                    }
                }
            }
        }

#if DEBUG
        private const string PADDING_STRING = "  ";
        private static string _currentPadding = "";
        
        /// <summary>
        /// Helper method for printing on output all children from ViewGroup.
        /// </summary>
        public static void PrintChildren(this ViewGroup viewGroup)
        {
            System.Diagnostics.Debug.WriteLine(_currentPadding + viewGroup.GetType().Name + " (ViewGroup)");
            
            _currentPadding += PADDING_STRING;

            for (int i = 0; i < viewGroup.ChildCount; i++)
            {
                View child = viewGroup.GetChildAt(i);
                
                if (!(child is ViewGroup))
                {
                    System.Diagnostics.Debug.WriteLine(_currentPadding + child.GetType().Name);
                }

                if (child is ViewGroup childViewGroup)
                {
                    PrintChildren(childViewGroup);
                }
            }

            _currentPadding = _currentPadding.Remove(_currentPadding.Length - PADDING_STRING.Length);
        }
    #endif
    }
}