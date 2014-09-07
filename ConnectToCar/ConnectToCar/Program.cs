using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mojio.Client;
using Mojio;
using Mojio.Events;
using System.Threading;

namespace ConnectToCar
{
    class Program
    {
        static private DBFunctions dbFunctions = new DBFunctions();
        static void Main(string[] args)
        {
            while (true)
            {
                Guid appID = new Guid("XXX");
                Guid secretKey = new Guid("XXX");

                MojioClient client = new MojioClient(
                                    appID,
                                    secretKey,
                                    MojioClient.Live
                                );
                client.SetUser("XXX", "XXX");
                client.PageSize = 15;
                // Fetch first page of 15 trips
                Results<Event> eventList = client.Get<Event>(1, null, true, null);
                Event mostRecent = eventList.Data.First();

                VehicleLocation vl = new VehicleLocation();
                vl.dateTimeStamp = mostRecent.Time;
                vl.lat = Convert.ToDecimal(mostRecent.Location.Lat);
                vl.lng = Convert.ToDecimal(mostRecent.Location.Lng);
                vl.vehicleGUID = mostRecent.VehicleId.ToString();

                dbFunctions.addVehicleLocation(vl);


                Thread.Sleep(5000);
                /*
                foreach (Event eventItem in eventList.Data)
                {
                    //if (eventItem.Type == Mojio.
                    String x = "";
                } */
                /*
            Results<Trip> results = client.Get<Trip>();
            // Iterate over each trip
            foreach (Trip trip in results.Data)
            {
                String x = "";
            }
                 */
            }
        }
    }
}
