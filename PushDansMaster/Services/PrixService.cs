using PushDansMaster.DAL;
using PushDansMaster.Services;
using System.Collections.Generic;
using System.Linq;

namespace PushDansMaster
{
    public class PrixService : IPrixService
    {
        private readonly PrixDepot_DAL depot = new PrixDepot_DAL();

        public void delete(Prix p)
        {
            Prix_DAL prix = new Prix_DAL(p.getPrix,p.getIDFournisseur,p.getIDLignesGlobal);
            depot.delete(prix);
        }

       public void deleteByID(int ID)
        {
            depot.deleteByID(ID);
        }

        public List<Prix> getAll()
        {
            List<Prix> prix = depot.getAll()
               .Select(f => new Prix(f.getIDPrix,f.getPrix,f.getIDFournisseur,f.getIDLignesGlobal)).ToList();

            return prix;
        }

        public Prix getbyID(int ID)
        {
            Prix_DAL p = depot.getByID(ID);


            return new Prix(p.getIDPrix, p.getPrix,p.getIDFournisseur,p.getIDLignesGlobal);
        }

        public Prix insert(Prix p)
        {
            Prix_DAL prix = new Prix_DAL(p.getPrix, p.getIDFournisseur, p.getIDLignesGlobal) ;
            depot.insert(prix);

            return p;
        }

        public Prix update(Prix p)
        {
            Prix_DAL prix = new Prix_DAL( p.getPrix,p.getIDFournisseur,p.getIDLignesGlobal) ;
            depot.update(prix);

            return p;
        }
    }
}
