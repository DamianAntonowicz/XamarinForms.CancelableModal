using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamarinForms.CancelableModal
{
    public partial class FirstModalStack : ContentPage//, IModalPage
    {
        public FirstModalStack()
        {
            InitializeComponent();
        }

//        public void Dismiss()
//        {
//            Navigation.PopModalAsync();
//        }

        private void ButtonGoDeeper_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SecondModalStack());
        }

        private void ButtonCloseModal_OnClicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void MenuItemCancel_OnClicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}
