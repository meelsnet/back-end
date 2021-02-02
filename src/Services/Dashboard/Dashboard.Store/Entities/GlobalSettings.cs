using System.ComponentModel.DataAnnotations.Schema;

namespace Dashboard.Store.Entities
{
    [Table("GlobalSettings")]
    public class GlobalSettings : Entity
    {
        public string Content { get; set; }
        public string SettingsName { get; set; }
        
    }
}