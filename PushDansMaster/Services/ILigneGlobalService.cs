using System.Collections.Generic;

namespace PushDansMaster
{
    public interface ILigneGlobalService
    {

        public List<LignesGlobal> getAll();
        public LignesGlobal insert(LignesGlobal f);
    }
}
