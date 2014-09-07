using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectToCar
{
    class DBFunctions
    {
        public void addVehicleLocation(VehicleLocation vl)
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                db.VehicleLocations.InsertOnSubmit(vl);
                db.SubmitChanges();
            }
        }
    }
}
