namespace AnnonsService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ServiceTypeData")]
    public partial class ServiceTypeData
    {
        public ServiceTypeData(ServiceType serviceType)
        {
            if (serviceType != null)
            {
                Id = serviceType.Id;
                Name = serviceType.Name;
            }
           
        } 

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ServiceTypeData()
        {
            ServiceData = new HashSet<ServiceData>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceData> ServiceData { get; set; }
    }
}
