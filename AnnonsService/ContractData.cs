namespace AnnonsService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ContractData")]
    public partial class ContractData
    {
        public int Id { get; set; }

        public int AcceptingUserID { get; set; }

        public int ServiceID { get; set; }

        public int Status { get; set; }
    }
}
