using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CollectNet.Models
{
    public class List
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Collection name must be fewer than 50 characters.")]
        public string ListName { get; set; }
        [StringLength(50)]
        public string ListTypes { get; set; }
        [StringLength(50)]
        public string ListTags { get; set; }

        public List<Item> ListItems { get; set; }
    }
}
