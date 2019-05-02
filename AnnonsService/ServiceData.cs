namespace AnnonsService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ServiceData")]
    public partial class ServiceData
    {
        public int Id { get; set; }

        public int Type { get; set; }

        public int Category { get; set; }

        public int CreatorID { get; set; }

        public int ServiceStatusID { get; set; }

        public string Picture { get; set; }

        public DateTime CreatedTime { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public double Price { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool TimeNeeded { get; set; }

        public int? Modified { get; set; }

        public virtual ServiceModificationsData ServiceModificationsData { get; set; }

        public virtual ServiceTypeData ServiceTypeData { get; set; }

        public virtual SubCategoryData SubCategoryData { get; set; }

        public virtual ServiceStatusData ServiceStatusData { get; set; }
    }
}