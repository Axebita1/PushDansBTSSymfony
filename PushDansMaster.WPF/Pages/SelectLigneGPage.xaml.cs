using System;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace PushDansMaster.WPF.Pages
{
    /// <summary>
    /// Logique d'interaction pour SelectLigneGPage.xaml
    /// </summary>
    public partial class SelectLigneGPage : Page
    {
        public SelectLigneGPage()
        {
            InitializeComponent();
        }
        private async void WindowIsOpen(object sender, RoutedEventArgs e)
        {
            Client clientApi = new Client(new configAPI().getConfig(), new HttpClient());
            System.Collections.Generic.ICollection<LigneGlobal_DTO> ligneGlobal = await clientApi.Getall3Async();
            ListeLignes.ItemsSource = ligneGlobal;
        }

        private async void OnPageLoad(object sender, RoutedEventArgs e)
        {
            Client clientApi = new Client(new configAPI().getConfig(), new HttpClient());
            System.Collections.Generic.ICollection<LigneGlobal_DTO> ligneGlobal = await clientApi.Getall3Async();
            ListeLignes.ItemsSource = ligneGlobal;
        }


        private async void Click_Btn_Actualiser(object sender, RoutedEventArgs e)
        {
            Client clientApi = new Client(new configAPI().getConfig(), new HttpClient());
            System.Collections.Generic.ICollection<LigneGlobal_DTO> ligneGlobal = await clientApi.Getall3Async();
            ListeLignes.ItemsSource = null;
            ListeLignes.ItemsSource = ligneGlobal;
        }

        private void Click_Btn_Go_Select_Ligne(object sender, RoutedEventArgs e)
        {
            LigneGlobal_DTO PGSelected = (ListeLignes.SelectedItem as LigneGlobal_DTO);
            if (PGSelected is null)
            {
                MessageBox.Show("Selectionnez une ligne");
            }
            else
            {
                NavigationService.Navigate(new Uri("Pages/SelectLigneGPage.xaml", UriKind.RelativeOrAbsolute));
            }
        }
    }
}
