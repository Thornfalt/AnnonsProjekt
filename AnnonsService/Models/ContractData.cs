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
        public ContractData()
        {
        }

        public ContractData(int serviceId, int? counterpartId, int? serviceOwnerId, int serviceOwnerStatus, int counterpartStatus)
        {
            ServiceId = ServiceId;
            CounterpartId = CounterpartId;
            ServiceOwnerId = ServiceOwnerId;         
            ServiceOwnerStatus = ServiceOwnerStatus;
            CounterpartStatus = CounterpartStatus;
        }

        public int Id { get; set; }

        public int ServiceId { get; set; }

        public int CounterpartId { get; set; }

        public int ServiceOwnerId { get; set; }

        public int ServiceOwnerStatus { get; set; }

        public int CounterpartStatus { get; set; }

    }
}
