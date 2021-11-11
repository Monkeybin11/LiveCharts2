﻿using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using ViewModelsSamples.Lines.AutoUpdate;

namespace MauiSample.StepLines.AutoUpdate
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class View : ContentPage
    {
        private bool? isStreaming = false;

        public View()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            var vm = (ViewModel)BindingContext;

            isStreaming = isStreaming is null ? true : !isStreaming;

            while (isStreaming.Value)
            {
                vm.RemoveFirstItem();
                vm.AddItem();
                await Task.Delay(1000);
            }
        }
    }
}
