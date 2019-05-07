namespace AnnonsService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ServiceStatusData")]
    public partial class ServiceStatusData
    {

        public ServiceStatusData(ServiceStatus serviceStatus)
        {
            if (serviceStatus != null)
            {
                Id = serviceStatus.Id;
                StatusTypeID = serviceStatus.StatusTypeID;
                FromDate = serviceStatus.FromDate;
                ToDate = serviceStatus.ToDate;
                ServiceStatusTypeData = new ServiceStatusTypeData(serviceStatus.ServiceStatusType);
            }
         
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ServiceStatusData()
        {
            ServiceData = new HashSet<ServiceData>();
        }

        public int Id { get; set; }

        public int StatusTypeID { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceData> ServiceData { get; set; }

        public virtual ServiceStatusTypeData ServiceStatusTypeData { get; set; }
    }
}
