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
using UpKeepV2.App.Views.Medarbejder;
using Microsoft.Toolkit.Uwp.UI.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UpKeepV2.App.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MedarbejderInfoView : Page
    {
        private string _fliterText;
        public List<MedarbejderInfo> Model = new List<MedarbejderInfo>();
        public MedarbejderInfoView()
        {
            this.InitializeComponent();
            Data();
        }
        private async void Data()
        {
            Model = await new MedarbejderInfoDataService().ToList();
            this.DataContext = Model;
            LoadingControl.IsActive = false;
        }
        private void Details(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MedarbejderInfoDetails), (sender as Button).Tag);
        }
        private void Tilføje(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MedarbejderInfoCreate));
        }


        //private void DataGrid_Sorting(object sender, DataGridColumnEventArgs e) =>
        //    (sender as DataGrid).Sort(e.Column, ViewModel.MedarbejderInfo.Sort);
    }
}
