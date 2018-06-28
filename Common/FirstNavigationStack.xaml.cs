using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamarinForms.CancelableModal
{
    public partial class FirstNavigationStack : ContentPage
    {
        public FirstNavigationStack()
        {
            InitializeComponent();
        }

        private void ButtonGoDeeper_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SecondNavigationStack());
        }
    }
}
