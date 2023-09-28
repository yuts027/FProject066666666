namespace FProjectCamping.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CartItem
    {
        public int Id { get; set; }

        public int CartId { get; set; }

        public int RoomId { get; set; }

        public int Days { get; set; }

        [Column(TypeName = "date")]
        public DateTime CheckInDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime CheckOutDate { get; set; }

        public bool ExtraBed { get; set; }

        public int ExtraBedPrice { get; set; }

        public int SubTotal { get; set; }

        public virtual Cart Cart { get; set; }

        public virtual Room Room { get; set; }
    }
}
