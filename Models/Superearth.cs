using Supabase.Postgrest.Models;
using Supabase.Postgrest.Attributes;
using System.Text.Json.Serialization;
namespace HelldiversApi.Models
{
    [Table("Superearth")]
    public class Superearth : BaseModel
    {
        [PrimaryKey("id", false)]
        [JsonIgnore] 
        public int Id { get; set; }

        [Column("department")]
        public string Department { get; set; } = string.Empty;

        [Column("type")]
        public string Type { get; set; } = string.Empty;

        [Column("name")]
        public string Name { get; set; } = string.Empty;

        [Column("penetration")]
        public string Penetration { get; set; } = string.Empty;

        [Column("description")]
        public string Description { get; set; } = string.Empty;

        [Column("photo_url")]
        public string Photo_Url { get; set; } = string.Empty;
    }
}