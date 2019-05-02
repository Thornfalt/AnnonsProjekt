namespace AnnonsService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ContractStatusTypeData")]
    public partial class ContractStatusTypeData
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
    }
}
