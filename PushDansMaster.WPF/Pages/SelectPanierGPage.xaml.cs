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

        private void Click_Btn_Go_Select_Fournisseur(object sender, RoutedEventArgs e)
        {
            Fournisseurs_DTO fourSelected = (Liste.SelectedItem as Fournisseurs_DTO);
            if (fourSelected is null)
            {
                MessageBox.Show("Selectionnez un panier");
            }
            else
            {
                NavigationService.Navigate(new Uri("Pages/SelectPanierGPage.xaml", UriKind.RelativeOrAbsolute));
            }

        }
        private async void Click_Btn_Actualiser(object sender, RoutedEventArgs e)
        {
            Client clientApi = new Client(new configAPI().getConfig(), new HttpClient());
            System.Collections.Generic.ICollection<Fournisseurs_DTO> fournisseur = await clientApi.Getall2Async();
            Liste.ItemsSource = null;
            Liste.ItemsSource = fournisseur;
        }

    }
}
