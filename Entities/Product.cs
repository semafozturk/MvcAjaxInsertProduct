using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int productId { get; set; }
        public string? productName { get; set; }
        public string? productDetail { get; set; }
        public int categoryId { get; set; }
        public Category? Category { get; set; }
    }
}
