using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace XamarinForms.CancelableModal
{
    public partial class SecondPage : ContentPage, IModalPage
    {
        public SecondPage()
        {
            InitializeComponent();
        }

//        private void ToolbarItemCancel_OnClicked(object sender, EventArgs e)
//        {
//            Navigation.PopModalAsync();
//        }

        private void ButtonGoDeeper_OnClick(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FirstPage());
        }

        public void Dismiss()
        {
            Navigation.PopModalAsync();
        }
    }
}
