using AnnonsService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace AnnonsService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public List<Service> AdvancedSearch(SearchService searchService)
        {
            List<Service> output = new List<Service>();
            using (ServiceDBModel db = new ServiceDBModel())
            {
                Searcher searcher = new Searcher();
                var searchResults = db.ServiceData
                    .ToList()
                    .Where(item => searcher.ObjectSearch(item, searchService))
                    .ToList();
                output = ServiceDataToService(searchResults);

            }
                return output;
        }


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

        private List<Service> ServiceDataToService(List<ServiceData> serviceDatas)
        {
            List<Service> output = new List<Service>();

            foreach (ServiceData serviceData in serviceDatas)
            {
                output.Add(new Service(serviceData));
            }
            return output;
        } 
    }
}
