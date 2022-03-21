using System;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace PushDansMaster.WPF.Pages
{
    /// <summary>
    /// Logique d'interaction pour SetPrixPage.xaml
    /// </summary>
    public partial class SelectFourForPrixPage : Page
    {
        public SelectFourForPrixPage()
        {
            InitializeComponent();
        }

        private async void WindowIsOpen(object sender, RoutedEventArgs e)
        {
            Client clientApi = new Client(new configAPI().getConfig(), new HttpClient());
            System.Collections.Generic.ICollection<Fournisseurs_DTO> fournisseur = await clientApi.Getall2Async();
            ListeFournisseur.ItemsSource = fournisseur;
        }
        private async void OnPageLoad(object sender, RoutedEventArgs e)
        {
            Client clientApi = new Client(new configAPI().getConfig(), new HttpClient());
            System.Collections.Generic.ICollection<Fournisseurs_DTO> fournisseur = await clientApi.Getall2Async();
            ListeFournisseur.ItemsSource = fournisseur;
        }


        private async void Click_Btn_Actualiser(object sender, RoutedEventArgs e)
        {
            Client clientApi = new Client(new configAPI().getConfig(), new HttpClient());
            System.Collections.Generic.ICollection<Fournisseurs_DTO> fournisseur = await clientApi.Getall2Async();
            ListeFournisseur.ItemsSource = null;
            ListeFournisseur.ItemsSource = fournisseur;
        }


        private void Click_Btn_Go_Select_Fournisseur(object sender, RoutedEventArgs e)
        {
            Fournisseurs_DTO fourSelected = (ListeFournisseur.SelectedItem as Fournisseurs_DTO);
            if (fourSelected is null)
            {
                MessageBox.Show("Selectionnez un fournisseur");
            }
            else
            {
                 NavigationService.Navigate(new Uri("Pages/SelectPanierGPage.xaml", UriKind.RelativeOrAbsolute));
            }
            
        }
    }
}
