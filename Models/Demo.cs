using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace api.Models
{
        [Table("Demo")]
    public class Demo : BaseModel
    {
        [PrimaryKey("id", false)]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; } = string.Empty;

        [Column("read_time")]
        public int ReadTime { get; set; } // Assuming read time is in minutes (int)

        [Column("description")]
        public string Description { get; set; } = string.Empty;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}