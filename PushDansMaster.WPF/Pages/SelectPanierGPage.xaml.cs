using System;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace PushDansMaster.WPF.Pages
{
    /// <summary>
    /// Logique d'interaction pour SelectPanierGPage.xaml
    /// </summary>
    public partial class SelectPanierGPage : Page
    {
        public SelectPanierGPage()
        {
            InitializeComponent();
        }

        private async void WindowIsOpen(object sender, RoutedEventArgs e)
        {
            Client clientApi = new Client(new configAPI().getConfig(), new HttpClient());
            System.Collections.Generic.ICollection<PanierGlobal_DTO> PanierG = await clientApi.Getall5Async();
            Liste.ItemsSource = PanierG;
        }

        private async void OnPageLoad(object sender, RoutedEventArgs e)
        {
            Client clientApi = new Client(new configAPI().getConfig(), new HttpClient());
            System.Collections.Generic.ICollection<PanierGlobal_DTO> PanierG = await clientApi.Getall5Async();
            Liste.ItemsSource = PanierG;
        }

        private void Click_Btn_Go_Select_Panier(object sender, RoutedEventArgs e)
        {
            PanierGlobal_DTO PGSelected = (Liste.SelectedItem as PanierGlobal_DTO);
            if (PGSelected is null)
            {
                MessageBox.Show("Selectionnez un panier");
            }
            else
            {
                NavigationService.Navigate(new Uri("Pages/SelectLigneGPage.xaml", UriKind.RelativeOrAbsolute));
            }

        }
        private async void Click_Btn_Actualiser(object sender, RoutedEventArgs e)
        {
            Client clientApi = new Client(new configAPI().getConfig(), new HttpClient());
            System.Collections.Generic.ICollection<PanierGlobal_DTO> panierGlobal = await clientApi.Getall5Async();
            Liste.ItemsSource = null;
            Liste.ItemsSource = panierGlobal;
        }

    }
}
