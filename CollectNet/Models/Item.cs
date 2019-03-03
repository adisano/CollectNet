using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CollectNet.Models
{
    public class Item
    {
        public int ID { get; set; }
        [StringLength(50, ErrorMessage = "Item name must be fewer than 50 characters.")]
        public string ItemName { get; set; }
        [StringLength(50)]
        public string ItemTypes { get; set; }
        [StringLength(50)]
        public string ItemTags { get; set; }
        public int ListID { get; set; }

        public List List { get; set; }
    }
}
