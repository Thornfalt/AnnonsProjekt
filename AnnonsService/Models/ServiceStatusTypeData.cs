namespace AnnonsService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ServiceStatusTypeData")]
    public partial class ServiceStatusTypeData
    {
        private ServiceStatusType serviceStatusType;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ServiceStatusTypeData()
        {
            ServiceStatusData = new HashSet<ServiceStatusData>();
        }

        public ServiceStatusTypeData(ServiceStatusType serviceStatusType)
        {
            if (serviceStatusType != null)
            {
                this.serviceStatusType = serviceStatusType;
            }
     
        }

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceStatusData> ServiceStatusData { get; set; }
    }
}
