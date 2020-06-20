using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using UpKeepV2.App.Data;
using UpKeepV2.App.Models;
using Windows.UI.Popups;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UpKeepV2.App.Views.Medarbejder
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
   
    public sealed partial class MedarbejderInfoDetails : Page
    {
        private MedarbejderInfo Model = new MedarbejderInfo();
        public MedarbejderInfoDetails()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter != null)
            {
                Model.Medarbejder_InfoID = (int)e.Parameter;
                Data();
            }
        }
        private async void Data()
        {
            Model = await new MedarbejderInfoDataService().Find(Model.Medarbejder_InfoID);
            this.DataContext = Model;
            LoadingControl.IsActive = false;
        }
        private void tilbageTilListen(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MedarbejderInfoView));
        }
        private void Rediger(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MedarbejderInfoEdit), (sender as Button).Tag);
        }
        private async void Slet(object sender, RoutedEventArgs e)
        {
            var dialog = new MessageDialog("Slet Mebarbejder: " + Model.Medarbejder_InfoID);
            dialog.Title = "Slet Mebarbejder";

            dialog.Commands.Add(new UICommand("Slet", new UICommandInvokedHandler(this.CommandInvokedHandler)));
            dialog.Commands.Add(new UICommand("Cancel"));
            dialog.DefaultCommandIndex = 1;
            dialog.CancelCommandIndex = 1;

            await dialog.ShowAsync();
        }
        private async void CommandInvokedHandler(IUICommand command)
        {
            LoadingControl.IsActive = true;
            await new MedarbejderInfoDataService().Remove(Model.Medarbejder_InfoID);
            this.Frame.Navigate(typeof(MedarbejderInfoView));
            LoadingControl.IsActive = false;
        }
    }
}
