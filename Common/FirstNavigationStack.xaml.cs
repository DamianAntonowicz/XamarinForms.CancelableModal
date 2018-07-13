using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamarinForms.CancelableModal
{
    public partial class FirstNavigationStack : ContentPage//, IModalPage
    {
        public FirstNavigationStack()
        {
            InitializeComponent();
        }

        private void ButtonGoDeeper_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SecondNavigationStack());
        }

//        public void Dismiss()
//        {
//            Navigation.PopAsync();
//        }
    }
}
