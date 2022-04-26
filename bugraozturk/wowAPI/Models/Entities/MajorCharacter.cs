using System.ComponentModel.DataAnnotations.Schema;
using wowAPI.Enums;

namespace wowAPI.Entities
{
    public class MajorCharacter : BaseEntity
    {
        public string Name { get; set;}

        public Gender Gender { get; set;}

        public int Level { get; set;}

        [ForeignKey("ClassId")]
        
        public int ClassId { get; set; }
        
        public virtual Class Class { get; set; }

        [ForeignKey("ExpansionId")]
        
        public virtual Expansion Expansion {get; set;}

        [ForeignKey("Race")]

        public int RaceId { get; set; }
        
        public virtual Race Race { get; set; }
        
        public Faction Faction {get; set;}

        
    }
}
