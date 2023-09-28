namespace FProjectCamping.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OrderItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OrderItem()
        {
            Reservations = new HashSet<Reservation>();
        }

        public int Id { get; set; }

        public int OrderId { get; set; }

        public int RoomId { get; set; }

        [Required]
        [StringLength(50)]
        public string RoomName { get; set; }

        public int Days { get; set; }

        [Column(TypeName = "date")]
        public DateTime CheckInDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime CheckOutDate { get; set; }

        public bool ExtraBed { get; set; }

        public int ExtraBedPrice { get; set; }

        public int SubTotal { get; set; }

        public virtual Order Order { get; set; }

        public virtual Room Room { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
