using System.ComponentModel.DataAnnotations;

namespace Dashboard.Store.Entities
{
    public abstract class Entity
    {
     [Key] public int Id { get; set; }
    }
}