using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagement.Service.Shared
{
    public class BaseEntityDto
    {
        public long Id { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string AddedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
