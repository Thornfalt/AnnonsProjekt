using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace AnnonsService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {


        [OperationContract]
        List<ServiceData> LoadServices();
        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class ServiceData
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public int Category { get; set; }
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
       public SubCategoryData SubCategory { get; set; }
        [DataMember]
       public  ServiceStatus ServiceStatus { get; set; }
        //[DataMember]
        //public virtual ICollection<ServiceModifications> ServiceModifications { get; set; }
    }

    [DataContract]
    public class SubCategoryData
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int Parent { get; set; }
        [DataMember]
        public string Titel { get; set; }
        [DataMember]
        public Category Category { get; set; }
       // [DataMember]
        //public List<Service> Service { get; set; }
    }
}
