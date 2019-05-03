using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace AnnonsService
{

    public class Service1 : IService1
    {

        /**
         * Laddar in alla servicar och returnerar dem
         */
        List<Service> IService1.LoadServices()
        {
            List<Service> output = new List<Service>();
            using (ServiceDBModel db = new ServiceDBModel())
            {
                var services = db.ServiceData.ToList();
                foreach (var service in services)
                {
                    Service tempService = new Service(service);
                    output.Add(tempService);
                }
                return output;
            }
        }

        public List<Service> Search(string searchString)
        {
            List<Service> output = new List<Service>();
            if(!String.IsNullOrEmpty(searchString))
            {
                using (ServiceDBModel db = new ServiceDBModel())
                {
                    var services = db.ServiceData.ToList();
                    List<ServiceData> foundServices = services.Where(s =>
                    {
                        if (s.Title.ToLower().Contains(searchString.ToLower()) ||
                        s.Description.ToLower().Contains(searchString.ToLower()) || 
                        s.SubCategoryData.Titel.ToLower().Contains(searchString.ToLower()) ||
                        s.SubCategoryData.CategoryData.Titel.ToLower().Contains(searchString.ToLower()))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }).ToList();
                    foreach (var foundService in foundServices)
                    {
                        Service tempService = new Service(foundService);
                        output.Add(tempService);
                    }
                    return output;
                }
            }

            return output;
        }


    }
}
