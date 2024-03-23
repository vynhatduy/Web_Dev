using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityModel;

namespace EntityController.Core
{
    public abstract class Base
    {
        public Model db;
        public Base()
        {
            db = new Model();
        }
    }
}
