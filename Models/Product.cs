using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace api.Models
{
    // [Table("products")]
    // public class Product : BaseModel
    // {
    //     [PrimaryKey("id", false)]
    //     public int Id { get; set; }
 
    //     [Column("name")]
    //     public string Name { get; set; } = string.Empty;
 
    //     [Column("price")]
    //     public decimal Price { get; set; }


    //     [Column("created_at")]
    //     public DateTime CreatedAt { get; set; }
    // }
     [Table("products")] // Ensure this matches the table name in your Supabase database
    public class Product : BaseModel
    {
        [PrimaryKey("id", false)]
        public int id { get; set; }

        [Column("productName")]
        public string productName { get; set; }

        [Column("description")]
        public string description { get; set; }

        [Column("price")]
        public decimal price { get; set; }

  
        [Column("originalPrice")]
        public decimal originalPrice { get; set; }

        [Column("discount")]
        public string discount { get; set; }

        [Column("imageURL")]
        public string imageURL { get; set; }

        [Column("information")]
        public string information { get; set; }

        [Column("additionalInformation")]
        public string additionalInformation { get; set; }

        [Column("descriptionImages")]
        public List<Image> descriptionImages { get; set; } = [];

        [Column("additionalImages")]
        public List<Image> additionalImages { get; set; } = [];

        [Column("SKU")]
        public string SKU { get; set; }

        [Column("category")]
        public string category { get; set; }

        [Column("sizes")]
        public List<string> sizes { get; set; } = [];

        [Column("tags")]
        public List<string> tags { get; set; } = [];

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
    }

    public class Image
    {
        public string alt { get; set; } = string.Empty;
        public string imageURL { get; set; } = string.Empty;
    }
}


