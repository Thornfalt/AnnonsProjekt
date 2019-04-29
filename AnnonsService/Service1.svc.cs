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


        /**
         * Laddar in alla servicar och returnerar dem
         */
        public List<ServiceData> LoadServices()
        {
            List<ServiceData> output = new List<ServiceData>();

            using (ServiceDBModel db = new ServiceDBModel())
            {
                var services = db.Service.ToList();
                
                foreach (var service in services)
                {
                    SubCategoryData tempSubCategory = new SubCategoryData();
                    tempSubCategory.Id = service.SubCategory.Id;
                    tempSubCategory.Titel = service.SubCategory.Titel;
                    tempSubCategory.Parent = service.SubCategory.Parent;
                    //tempSubCategory.Service = service.SubCategory.Service.ToList();
                    tempSubCategory.Category = service.SubCategory.Category;


                    ServiceData tempService = new ServiceData();
                    tempService.Id = service.Id;
                    tempService.Title = service.Title;
                    tempService.Description = service.Description;
                    tempService.Category = service.Category;

                    tempService.SubCategory = tempSubCategory;
                    tempService.Type = service.Type;

                    output.Add(tempService);
                } 
                return output;

            }
        }
    }
}
