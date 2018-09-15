namespace ECom.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProductAttribute
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AttributeId { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(250)]
        public string AttributeValue { get; set; }

        public virtual ProductAttributeLookup ProductAttributeLookup { get; set; }

        public virtual Product Product { get; set; }
    }
}
