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
using UpKeepV2.App.Models;
using UpKeepV2.App.Views;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UpKeepV2.App
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public string Title;
        public MainPage()
        {
            this.InitializeComponent();
            Navigation.Header = "Start";
        }
        private void RootFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Error: " + e.SourcePageType.FullName);
        }

        private void Navigation_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
                Navigation.Header = "Configuración";
                rootFrame.Navigate(typeof(Setting));
            }
            else
            {
                var selectedItem = (NavigationViewItem)args.SelectedItem;
                string pageName = ((string)selectedItem.Tag);
                sender.Header = pageName;
                switch (pageName)
                {
                    case "MedarbejderInfo":
                        rootFrame.Navigate(typeof(MedarbejderInfoView));
                        break;
                    default:
                        this.Frame.Navigate(typeof(MainPage));
                        break;

                }
            }
        }
    }
}
