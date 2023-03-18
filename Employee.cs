namespace FProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            Export_Permission = new HashSet<Export_Permission>();
            Warehouses = new HashSet<Warehouse>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Emp_Id { get; set; }

        [StringLength(20)]
        public string Emp_Name { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Emp_BD { get; set; }

        [StringLength(20)]
        public string Emp_Phone { get; set; }

        [StringLength(20)]
        public string Emp_Address { get; set; }

        [StringLength(20)]
        public string Emp_Department { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Export_Permission> Export_Permission { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Warehouse> Warehouses { get; set; }
    }
}
