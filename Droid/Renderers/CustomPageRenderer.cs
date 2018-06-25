using System.Collections.Generic;
using System.Linq;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;
using XamarinForms.CancelableModal.Droid.Renderers;

[assembly: ExportRenderer(typeof(NavigationPage), typeof(CustomPageRenderer))]

namespace XamarinForms.CancelableModal.Droid.Renderers
{
    public class CustomPageRenderer : NavigationPageRenderer
    {
        private Toolbar _modalToolbar;

        public CustomPageRenderer(Context context)
            : base(context)
        {
        }

        protected override void OnAttachedToWindow()
        {
            base.OnAttachedToWindow();

            if (Element.CurrentPage is IModalPage modalPage)
            {
                var activity = Context as FormsAppCompatActivity;
                var content = activity.FindViewById(Android.Resource.Id.Content) as ViewGroup;

                var toolbars = GetChildrenOfType<Toolbar>(content);

                _modalToolbar = toolbars.Last();
                _modalToolbar.NavigationClick += ModalToolbarOnNavigationClick;
            }
        }

        protected override void OnDetachedFromWindow()
        {
            base.OnDetachedFromWindow();

            if (_modalToolbar != null)
            {
                _modalToolbar.NavigationClick -= ModalToolbarOnNavigationClick;
            }
        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);

            if (Element.CurrentPage is IModalPage modalPage)
            {
                _modalToolbar.SetNavigationIcon(Android.Resource.Drawable.IcMenuCloseClearCancel);
            }
        }

        private void ModalToolbarOnNavigationClick(object sender, Toolbar.NavigationClickEventArgs e)
        {
            if (Element.CurrentPage is IModalPage modalPage)
            {
                Element.Navigation.PopModalAsync();
            }
            else
            {
                Element.Navigation.PopAsync();
            }
        }

        private const string PADDING_STRING = "  ";
        private string _currentPadding = "";

        private IList<T> GetChildrenOfType<T>(ViewGroup viewGroup)
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