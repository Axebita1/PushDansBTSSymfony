using PushDansMaster.DAL;
using System.Collections.Generic;
using System.Linq;

namespace PushDansMaster
{
    public class LigneGlobalService : ILigneGlobalService
    {
        private readonly LignesGlobalDepot_DAL depot = new LignesGlobalDepot_DAL();

        public List<LignesGlobal> getAll()
        {
            List<LignesGlobal> ligne = depot.getAll()
                .Select(f => new LignesGlobal(f.getIDLigneGlobal, f.getId_panier, f.getQuantite, f.getReference, f.getId_reference))

                .ToList();
            return ligne;
        }

        public LignesGlobal insert(LignesGlobal f)
        {
            LignesGlobal_DAL line = new LignesGlobal_DAL(f.getIDPanier, f.getQuantite, f.getReference, f.getIDReference);
            depot.insert(line);

            return f;
        }
    }
}
