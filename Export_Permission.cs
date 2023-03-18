namespace FProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Export_Permission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Perm_no { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Perm_Date { get; set; }

        public int? W_Id { get; set; }

        public int? Goods_Id { get; set; }

        [Column("Q/G")]
        public int? Q_G { get; set; }

        public int? SuppE_Id { get; set; }

        public int? Client_Id { get; set; }

        public virtual Client Client { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Good Good { get; set; }

        public virtual Warehouse Warehouse { get; set; }
    }
}
