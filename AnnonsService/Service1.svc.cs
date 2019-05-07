using AnnonsService.Controllers;
using AnnonsService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

using System.Data.Entity;


namespace AnnonsService
{

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
                output = ServiceDataListToServiceList(searchResults);

            }
                return output;
        }


        ServiceDatasController serviceDatasController = new ServiceDatasController();
        private ServiceDBModel db = new ServiceDBModel();

        public List<ContractData> GetAllContractData()
        {
            throw new NotImplementedException();
        }

        public List<Service> GetAllServiceData()
        {
            var services = db.ServiceData
                .Include(s => s.ServiceModificationsData)
                .Include(s => s.ServiceStatusData)
                .Include(s => s.ServiceTypeData)
                .Include(s => s.SubCategoryData).ToList();

            List<Service> output = new List<Service>();
            output = ServiceDataListToServiceList(services);

            return output;
        }

        public Service GetServiceById(int id)
        {

            using (ServiceDBModel db = new ServiceDBModel())
            {

                var serviceData = db.ServiceData
                .ToList()
                .Where( item => item.Id == id)
                .ToList();

                if (serviceData.Count == 1)
                {
                    Service output = ServiceDataObjectToService(serviceData[0]);

                    if (serviceData == null)
                    {
                        return null;
                    }

                    return output;
                }

                else
                {
                    return null;
                }

            }

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


        public List<Service> Search(string searchString)
        {
            List<Service> output = new List<Service>();
            if(!String.IsNullOrEmpty(searchString))
            {
                using (ServiceDBModel db = new ServiceDBModel())
                {
                    Searcher searcher = new Searcher();
                    var searchResults = db.ServiceData
                    .ToList()
                    .Where(item =>
                    {
                        return searcher.
                        SearchInDatabase(item.Title, item.Description, item.SubCategoryData.Titel, item.SubCategoryData.CategoryData.Titel, searchString);

                    }).ToList();
                    output = ServiceDataListToServiceList(searchResults);
                    return output;
                }
            }

            return output;
        }


        private List<Service> ServiceDataListToServiceList(List<ServiceData> serviceDatas)
        {
            List<Service> output = new List<Service>();

            foreach (ServiceData serviceData in serviceDatas)
            {
                output.Add(new Service(serviceData));
            }
            return output;

        }

        private Service ServiceDataObjectToService(ServiceData serviceData)
        {

            Service output = new Service(serviceData);
            
            return output;

        }

        List<Contract> IService1.GetAllContractData()
        {
            throw new NotImplementedException();
        }

        //Inte färdigt
        public bool CreateService(Service service)
        {

            ServiceData serviceData = new ServiceData(service);

            db.ServiceData.Add(serviceData);
            db.SaveChanges();
            return true;
            

            throw new NotImplementedException();
        }

        public bool EditService(Service service)
        {
       

            throw new NotImplementedException();
        }

        public bool DeleteService(int id)
        {

            throw new NotImplementedException();
        }
    }

}
