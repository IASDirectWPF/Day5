namespace AdventureWorksWebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Production.Products")]
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(15)]
        public string Color { get; set; }

        public decimal Price { get; set; }
    }
}
