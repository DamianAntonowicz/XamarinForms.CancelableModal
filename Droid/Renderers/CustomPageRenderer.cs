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

                var toolbars = content.GetChildrenOfType<Toolbar>();

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

            if (Element.CurrentPage is IModalPage)
            {
                _modalToolbar.SetNavigationIcon(Resource.Drawable.baseline_close_white_24);
            }
        }

        private void ModalToolbarOnNavigationClick(object sender, Toolbar.NavigationClickEventArgs e)
        {
            if (Element.CurrentPage is IModalPage modalPage)
            {
                modalPage.Dismiss();
            }
            else
            {
                Element.Navigation.PopAsync();
            }
        }
    }
}