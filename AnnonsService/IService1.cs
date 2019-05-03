using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace AnnonsService
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        List<Service> AdvancedSearch(SearchService searchService);
        [OperationContract]
        List<Service> LoadServices();
        // TODO: Add your service operations here
    }

    [DataContract]
    public class PriceRange
    {
        [DataMember]
        public double Max { get; set; }

        [DataMember]
        public double Min { get; set; }
    }

    public class DateRange
    {
        [DataMember]
        public DateTime? Start { get; set; }
        [DataMember]
        public DateTime? End { get; set; }
    }

    [DataContract]
    public class SearchService
    {
        [DataMember]
        public int CreatorID { get; set; }

        [DataMember]
        public DateRange CreatedTime { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public PriceRange Price { get; set; }
        [DataMember]
        public DateRange StartDate { get; set; }
        [DataMember]
        public DateRange EndDate { get; set; }

        [DataMember]
        public List<ServiceType> ServiceTypes { get; set; }
        [DataMember]
        public List<SubCategory> SubCategories { get; set; }
        [DataMember]
        public ServiceStatus ServiceStatus { get; set; }
    }
    [DataContract]
    public class Service
    {
        public Service(ServiceData serviceData)
        {
            // Constructor för att konvertera entity model till output-klass.
            Id = serviceData.Id;
            Type = serviceData.Type;
            CreatorID = serviceData.CreatorID;
            ServiceStatusID = serviceData.ServiceStatusID;
            Picture = serviceData.Picture;
            CreatedTime = serviceData.CreatedTime;
            Title = serviceData.Title;
            Description = serviceData.Description;
            Price = serviceData.Price;
            StartDate = serviceData.StartDate;
            EndDate = serviceData.EndDate;
            TimeNeeded = serviceData.TimeNeeded;
            SubCategory = new SubCategory(serviceData.SubCategoryData);
            ServiceModifications = new ServiceModifications(serviceData.ServiceModificationsData);
            ServiceStatus = new ServiceStatus(serviceData.ServiceStatusData);
            ServiceType = new ServiceType(serviceData.ServiceTypeData);
            Modified = serviceData.Modified;

        }

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int Type { get; set; }
        [DataMember]
        public int CreatorID { get; set; }
        [DataMember]
        public int ServiceStatusID { get; set; }
        [DataMember]
        public string Picture { get; set; }
        [DataMember]
        public DateTime CreatedTime { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public double Price { get; set; }
        [DataMember]
        public DateTime? StartDate { get; set; }
        [DataMember]
        public DateTime? EndDate { get; set; }
        [DataMember]
        public bool TimeNeeded { get; set; }
        [DataMember]
        public int? Modified { get; set; }
        [DataMember]
        public ServiceModifications ServiceModifications { get; set; }
        [DataMember]
        public ServiceType ServiceType { get; set; }
        [DataMember]
        public SubCategory SubCategory { get; set; }
        [DataMember]
        public ServiceStatus ServiceStatus { get; set; }
    }

    [DataContract]
    public class ServiceModifications
    {
        public ServiceModifications(ServiceModificationsData serviceModificationsData)
        {
            Id = serviceModificationsData.Id;
            UserID = serviceModificationsData.UserID;
            ActionTime = serviceModificationsData.ActionTime;
            //ServiceData = serviceModificationsData.ServiceData;
            // TODO: Fixa den här, ska den vara list? Ska den bara vara en service? Behövs den ens?
        }

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int UserID { get; set; }
        [DataMember]
        public DateTime ActionTime { get; set; }
        //[DataMember]
        //public List<Service> ServiceData { get; set; }
    }

    [DataContract]
    public class ServiceType
    {
        public ServiceType(ServiceTypeData serviceTypeData)
        {
            Id = serviceTypeData.Id;
            Name = serviceTypeData.Name;
            //ServiceData = serviceTypeData.ServiceData;
            // TODO: Fixa den här, ska den vara list? Ska den bara vara en service? Behövs den ens?

        }

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        //[DataMember]
        //public ICollection<ServiceData> ServiceData { get; set; }
        // TODO: Fixa den här, ska den vara list? Ska den bara vara en service? Behövs den ens?

    }

    [DataContract]
    public class SubCategory
    {
        public SubCategory(SubCategoryData subCategoryData)
        {
            Id = subCategoryData.Id;
            Parent = subCategoryData.Parent;
            Titel = subCategoryData.Titel;
            ParentCategory = new Category(subCategoryData.CategoryData);
            //ServiceData = subCategoryData.ServiceData;
        }

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int Parent { get; set; }
        [DataMember]
        public string Titel { get; set; }
        [DataMember]
        public Category ParentCategory { get; set; }
        //[DataMember]
        //public ICollection<ServiceData> ServiceData { get; set; } Behövs den ens?
    }

    [DataContract]
    public class Category
    {
        public Category(CategoryData categoryData)
        {
            Id = categoryData.Id;
            Titel = categoryData.Titel;
            //SubCategoryData = categoryData.SubCategoryData; Behövs den ens?
        }
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Titel { get; set; }
        //[DataMember]
        //public ICollection<SubCategoryData> SubCategoryData { get; set; } Behövs den ens?
    }

    [DataContract]
    public class ServiceStatus
    {
        public ServiceStatus(ServiceStatusData ServiceStatusData)
        {
            Id = ServiceStatusData.Id;
            StatusTypeID = ServiceStatusData.StatusTypeID;
            FromDate = ServiceStatusData.FromDate;
            ToDate = ServiceStatusData.ToDate;
            //Service = ServiceStatusData.Service;
            ServiceStatusType = new ServiceStatusType(ServiceStatusData.ServiceStatusTypeData);
        }

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int StatusTypeID { get; set; }
        [DataMember]
        public DateTime FromDate { get; set; }
        [DataMember]
        public DateTime? ToDate { get; set; }
        //[DataMember]
        //public ICollection<ServiceData> Service { get; set; }
        [DataMember]
        public ServiceStatusType ServiceStatusType { get; set; }
    }

    [DataContract]
    public class ServiceStatusType
    {
        public ServiceStatusType(ServiceStatusTypeData serviceStatusTypeData)
        {
            Id = serviceStatusTypeData.Id;
            Name = serviceStatusTypeData.Name;
            //ServiceStatusData = serviceStatusTypeData.ServiceStatusData;
        }

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        //[DataMember]
        //public ICollection<ServiceStatusData> ServiceStatusData { get; set; }
    }

}
