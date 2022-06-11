using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PushDansMaster.WPF.Pages
{
   
    public partial class EnterPrixPage : Page
    {
        public EnterPrixPage()
        {
            InitializeComponent();
        }


        private async void Click_Btn_Go_PrixSet(object sender, RoutedEventArgs e)
        {
            Client clientApi = new Client(new configAPI().getConfig(), new HttpClient());

            var idfour = Values.SelectedFournisseur.IdFournisseur;
            var idLigneG = Values.SelectedLigneGlobal.Id;
            var prixEntered = EnterPrix.Text;
            int tmpId = 0;
            Prix_DTO IorUPrix = new Prix_DTO();
            ICollection<Prix_DTO> prix_dtos = await clientApi.Getall6Async();
            bool AlreadyExist = false;
            foreach (Prix_DTO prix in prix_dtos)
            {
                if ((prix.Prix >= 0) && (prix.IdFournisseur == idfour) && (prix.IdLigneGlobal == idLigneG))
                {
                    AlreadyExist = true;
                    tmpId = prix.Id;
                }
            }
            if (AlreadyExist)
            {
                IorUPrix.IdFournisseur = idfour;
                IorUPrix.IdLigneGlobal = idLigneG;
                IorUPrix.Prix = int.Parse(prixEntered);

                await clientApi.Update3Async(tmpId, IorUPrix);
            }
            else
            {
                IorUPrix.IdFournisseur = idfour;
                IorUPrix.IdLigneGlobal = idLigneG;
                IorUPrix.Prix = int.Parse(prixEntered);

                await clientApi.Insert7Async(IorUPrix);
            }
          
            NavigationService.GoBack();
            

        }


    }
}
