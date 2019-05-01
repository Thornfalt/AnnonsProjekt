namespace AnnonsService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CategoryData")]
    public partial class CategoryData
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CategoryData()
        {
            SubCategoryData = new HashSet<SubCategoryData>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Titel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SubCategoryData> SubCategoryData { get; set; }
    }
}
