namespace AnnonsService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ServiceModifications
    {
        public int Id { get; set; }

        public int UserID { get; set; }

        public DateTime ActionTime { get; set; }

        public int ServiceId { get; set; }

        public virtual Service Service { get; set; }
    }
}
