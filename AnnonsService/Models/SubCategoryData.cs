namespace AnnonsService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SubCategoryData")]
    public partial class SubCategoryData
    {
        public SubCategoryData(SubCategory subCategory)
        {
            if (subCategory != null)
            {
                Id = subCategory.Id;
                Parent = subCategory.Parent;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SubCategoryData()
        {
            ServiceData = new HashSet<ServiceData>();
        }

        public int Id { get; set; }

        public int Parent { get; set; }

        [Required]
        [StringLength(100)]
        public string Titel { get; set; }

        public virtual CategoryData CategoryData { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceData> ServiceData { get; set; }
    }
}
