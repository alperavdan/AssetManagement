using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagement.Model
{
    public class Product:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public long CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
