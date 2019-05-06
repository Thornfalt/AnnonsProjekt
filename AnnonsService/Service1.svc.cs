using AnnonsService.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

using System.Data.Entity;


namespace AnnonsService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        ServiceDatasController serviceDatasController = new ServiceDatasController();
        private ServiceDBModel db = new ServiceDBModel();

        public List<ContractData> GetAllContractData()
        {
            throw new NotImplementedException();
        }

        public List<ServiceData> GetAllServiceData()
        {
            var serviceData = db.ServiceData.Include(s => s.ServiceModificationsData).Include(s => s.ServiceStatusData).Include(s => s.ServiceTypeData).Include(s => s.SubCategoryData);
            return serviceData.ToList();

        }

        public ServiceData GetServiceById(int id)
        {
            throw new NotImplementedException();
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

    }

}
