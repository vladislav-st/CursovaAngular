using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Project_927.DataAccess.Entity
{
    [Table("Products")]
    public class Products
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
        public string Img_URL { get; set; }
        public float Price { get; set; }
    }
}
