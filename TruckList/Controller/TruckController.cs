using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckList.Model;

namespace TruckList.Controller
{
    internal class TruckController
    {
        public List<TruckTable> GetAll()
        {
            using (MainModel db = new MainModel())
            {
                return db.TruckTables.ToList();
            }
        }
        public List<TruckTable> ShowAllTrucks()
        {
            using (MainModel model = new MainModel())
            {
                var trucks = model.TruckTables.ToList();
                return trucks;
            }
        }
        public void CreateTrucks(TruckTable t)
        {
            using (MainModel model = new MainModel())
            {
                t.Id = model.TruckTables.ToList().LastOrDefault().Id + 1;
                model.TruckTables.Add(t);
                model.SaveChanges();

            }
        }
        public void DelateTrucks(int id)
        {
            using (MainModel model = new MainModel())
            {
                var truckToDelate = model.TruckTables.Where(t => t.Id == id).FirstOrDefault();
                if (truckToDelate != null)
                {
                    model.TruckTables.Remove(truckToDelate);
                    model.SaveChanges();
                }
            }
        }
        public void UpdateTrucks(int id, TruckTable truck)
        {
            using (MainModel model = new MainModel())
            {
                var truckToUpdate = model.TruckTables.Where(t => t.Id == id).FirstOrDefault();
                if (truckToUpdate != null)
                {
                    truckToUpdate.Id = id;
                    truckToUpdate.Brand = truck.Brand;
                    truckToUpdate.Price = truck.Price;
                    model.SaveChanges();
                }
            }
        }
    }
}
