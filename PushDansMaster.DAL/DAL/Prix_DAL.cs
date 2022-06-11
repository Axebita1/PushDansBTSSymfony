using System.Data.SqlClient;

namespace PushDansMaster.DAL
{
    public class Prix_DAL
    {
        public int prix;
        public int ID;
        public int idFournisseur;
        public int idLignesGlobal;

        #region Getters / Setters
        public int getIDPrix
        {
            get => ID;
            set => ID = value;
        }
        public int getPrix
        {
            get => prix;
            private set => prix = value;
        }
        public int getIDFournisseur
        {
            get => idFournisseur;
            private set => idFournisseur = value;
        }
        public int getIDLignesGlobal
        {
            get => idLignesGlobal;
            private set => idLignesGlobal = value;
        }
        #endregion

        #region Constructeur
        public Prix_DAL(int Prix, int IdFournisseur, int IdLignesGlobal)
        {
            (prix, idFournisseur, idLignesGlobal) = (Prix, IdFournisseur, IdLignesGlobal);
        }
        public Prix_DAL(int id, int Prix, int IdFournisseur, int IdLignesGlobal)
        {
            (ID ,prix, idFournisseur, idLignesGlobal) = (id, Prix, IdFournisseur, IdLignesGlobal);
        }
        #endregion

        #region Methodes
        internal void insert(SqlConnection connection)
        {
            // On insert un point dans la BDD
            using (SqlCommand command = new SqlCommand())
            {
                // Définir la connexion à utiliser
                command.Connection = connection;
                command.CommandText = "INSERT INTO prix(prix, id_fournisseur, id_lignesglobal) values (@prix, @id_fournisseur, @id_lignesglobal";

                command.Parameters.Add(new SqlParameter("@prix", prix));
                command.Parameters.Add(new SqlParameter("@id_fournisseur", idFournisseur));
                command.Parameters.Add(new SqlParameter("@id_lignesglobal", idLignesGlobal));

                command.ExecuteNonQuery();
            }
        }
        #endregion
    }
}
