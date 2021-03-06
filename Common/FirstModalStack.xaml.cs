﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamarinForms.CancelableModal
{
    public partial class FirstModalStack : ContentPage, IModalPage
    {
        public FirstModalStack()
        {
            InitializeComponent();
        }

        public void Dismiss()
        {
            Navigation.PopModalAsync();
        }

        private void ButtonGoDeeper_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SecondModalStack());
        }
    }
}
