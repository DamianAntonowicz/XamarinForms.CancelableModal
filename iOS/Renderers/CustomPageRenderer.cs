using UIKit;
using Xamarin.Forms;
using XamarinForms.CancelableModal.iOS.Renderers;

[assembly: ExportRenderer(typeof(Page), typeof(CustomPageRenderer))]
namespace XamarinForms.CancelableModal.iOS.Renderers
{
    public class CustomPageRenderer : Xamarin.Forms.Platform.iOS.PageRenderer
    {
        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            if (Element is IModalPage modalPage)
            {
                NavigationController.TopViewController.NavigationItem.LeftBarButtonItem =
                    new UIBarButtonItem(title: "Cancel",
                        style: UIBarButtonItemStyle.Plain,
                        handler: (sender, args) => { modalPage.Dismiss(); });
            }
        }
    }
}