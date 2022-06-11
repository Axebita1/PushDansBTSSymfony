using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PushDansMaster.Services
{
    public interface IPrixService
    {
        public List<Prix> getAll();

        public Prix getbyID(int id);

        public Prix insert(Prix p);

        public Prix update(Prix p);

        public void delete(Prix p);

        public void deleteByID(int ID);
    }
}
