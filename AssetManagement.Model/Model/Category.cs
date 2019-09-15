using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagement.Model
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
