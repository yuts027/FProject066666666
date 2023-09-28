namespace FProjectCamping.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Photo
    {
        public int Id { get; set; }

        public int RoomId { get; set; }

        public int RoomTypeId { get; set; }

        [Required]
        [StringLength(255)]
        public string FileName { get; set; }

        public int DisplayOrder { get; set; }

        public virtual Room Room { get; set; }

        public virtual RoomType RoomType { get; set; }
    }
}
