using System.ComponentModel.DataAnnotations;

namespace battlegameapi.Models
{
    public class Player
    {
        [Key]
        public Guid PlayerId { get; set; }
        public string PlayerName { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public int Level { get; set; }
        public string Email { get; set; }
        public ICollection<PlayerAsset> PlayerAssets { get; set; } = new List<PlayerAsset>();
    }

}