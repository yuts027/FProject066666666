namespace FProjectCamping.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RoomService
    {
        public int Id { get; set; }

        public int RoomId { get; set; }

        public int ServiceId { get; set; }

        public virtual Room Room { get; set; }

        public virtual Service Service { get; set; }
    }
}
