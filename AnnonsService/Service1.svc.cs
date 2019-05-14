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




        public List<ContractData> GetAllContractData()
        {
            throw new NotImplementedException();
        }

        public List<Service> GetAllServiceData()
        {
            using (ServiceDBModel db = new ServiceDBModel())
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
        }

        public Service GetServiceById(int id)
        {
            using (ServiceDBModel db = new ServiceDBModel())
            {
                var serviceData = db.ServiceData
                .ToList()
                .Where(item => item.Id == id)
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
        List<Service> IService1.LoadServices() // TODO: Ta bort?
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
            if (!String.IsNullOrEmpty(searchString))
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
        public bool CreateService(
            int type,
            int creatorId,
            int serviceStatusId,
            string picture,
            string title,
            string description,
            double price,
            DateTime? startDate,
            DateTime? endDate,
            bool timeNeeded,
            int subCategoryId
        )
        {

            DateTime createdTime = DateTime.Now;


            ServiceData serviceData = new ServiceData(type, subCategoryId, creatorId, serviceStatusId, picture, createdTime, title, description, price, startDate, endDate, timeNeeded);

            using (ServiceDBModel db = new ServiceDBModel())
            {
                try
                {
                    db.ServiceData.Add(serviceData);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public bool EditService(
            int id,
            int type,
            int serviceStatusId,
            string picture,
            string title,
            string description,
            double price,
            DateTime? startDate,
            DateTime? endDate,
            bool timeNeeded,
            int subCategoryId)
        {
            using (ServiceDBModel db = new ServiceDBModel())
            {
                try
                {
                    ServiceData foundService = db.ServiceData.Find(id);
                    foundService.Type = type;
                    foundService.ServiceStatusID = serviceStatusId;
                    foundService.Picture = picture;
                    foundService.Title = title;
                    foundService.Description = description;
                    foundService.Price = price;
                    foundService.StartDate = startDate;
                    foundService.EndDate = endDate;
                    foundService.TimeNeeded = timeNeeded;
                    foundService.Category = subCategoryId;
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {

                    throw e;

                }
            }
        }

        public bool DeleteService(int id)
        {
            using (ServiceDBModel db = new ServiceDBModel())
            {
                try
                {
                    ServiceData foundService = db.ServiceData.Find(id);
                    db.ServiceData.Remove(foundService);
                    db.SaveChanges();
                    return true;

                }
                catch (Exception)
                {

                    throw;
                }
            }


        }

        public List<ServiceType> GetTypes()
        {
            List<ServiceType> serviceTypes = new List<ServiceType>();
            using (ServiceDBModel db = new ServiceDBModel())
            {
                List<ServiceTypeData> temp = db.ServiceTypeData.ToList();

                foreach (ServiceTypeData item in temp)
                {
                    serviceTypes.Add(new ServiceType(item));
                }
            }
            return serviceTypes;
        }

        public List<ServiceStatusType> GetServiceStatusTypes()
        {
            List<ServiceStatusType> serviceStatuses = new List<ServiceStatusType>();

            using (ServiceDBModel db = new ServiceDBModel())
            {
                List<ServiceStatusTypeData> temp = db.ServiceStatusTypeData.ToList();

                foreach (ServiceStatusTypeData item in temp)
                {
                    serviceStatuses.Add(new ServiceStatusType(item));
                }
            }
            return serviceStatuses;
        }

        public List<SubCategory> GetSubCategories()
        {
            List<SubCategory> subCategories = new List<SubCategory>();

            using (ServiceDBModel db = new ServiceDBModel())
            {
                List<SubCategoryData> temp = db.SubCategoryData.ToList();

                foreach (SubCategoryData item in temp)
                {
                    subCategories.Add(new SubCategory(item));
                }
            }
            return subCategories;
        }

        public bool CreateSubCategory(int parentId, string title)
        {
            using (ServiceDBModel db = new ServiceDBModel())
            {
                try
                {
                    SubCategoryData subCategoryData = new SubCategoryData();
                    subCategoryData.Parent = parentId;
                    subCategoryData.Titel = title;
                    db.SubCategoryData.Add(subCategoryData);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }

            }
        }

        public bool DeleteSubCategory(int id)
        {
            using (ServiceDBModel db = new ServiceDBModel())
            {
                try
                {
                    SubCategoryData subCategoryDataToRemove = db.SubCategoryData.Find(id);
                    db.SubCategoryData.Remove(subCategoryDataToRemove);
                    db.SaveChanges();
                    return true;

                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public bool EditSubCategory(int id, int parentId, string title)
        {
            using (ServiceDBModel db = new ServiceDBModel())
            {
                try
                {
                    SubCategoryData subCategoryData = db.SubCategoryData.Find(id);
                    subCategoryData.Parent = parentId;
                    subCategoryData.Titel = title;
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }

            }
        }

        public List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();

            using (ServiceDBModel db = new ServiceDBModel())
            {
                List<CategoryData> temp = db.CategoryData.ToList();

                foreach (CategoryData item in temp)
                {
                    categories.Add(new Category(item));
                }
            }
            return categories;
        }

        public bool CreateCategory(string title)
        {
            using (ServiceDBModel db = new ServiceDBModel())
            {
                try
                {
                    CategoryData categoryData = new CategoryData();
                    categoryData.Titel = title;
                    db.CategoryData.Add(categoryData);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }

            }
        }

        public bool EditCategory(int id, string title)
        {
            using (ServiceDBModel db = new ServiceDBModel())
            {
                try
                {
                    CategoryData categoryData = db.CategoryData.Find(id);
                    categoryData.Titel = title;
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }

            }
        }

        public bool DeleteCategory(int id)
        {
            using (ServiceDBModel db = new ServiceDBModel())
            {
                try
                {
                    CategoryData categoryToRemove = db.CategoryData.Find(id);
                    db.CategoryData.Remove(categoryToRemove);
                    db.SaveChanges();
                    return true;

                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}
