namespace ECom.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            ProductAttributes = new HashSet<ProductAttribute>();
        }

        public int ProductId { get; set; }

        public int CategoryId { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductAttribute> ProductAttributes { get; set; }
    }
}
