using Supabase.Postgrest.Models;
using Supabase.Postgrest.Attributes;
using System.Text.Json.Serialization;

namespace HelldiversApi.Models
{
    [Table("Illuminate")]
    public class Illuminate : BaseModel
    {
        [PrimaryKey("id", false)]
        [JsonIgnore] 
        public int Id { get; set; }

        [Column("structure")]
        public bool Structure { get; set; }

        [Column("name")]
        public string Name { get; set; } = string.Empty;

        [Column("resistance")]
        public string Resistance { get; set; } = string.Empty;

        [Column("description")]
        public string Description { get; set; } = string.Empty;

        [Column("photo_url")]
        public string Photo_Url { get; set; } = string.Empty;
    }
}
