using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace battlegameapi.Models
{
    public class PlayerAsset
    {
        [Key]
        public Guid PlayerId { get; set; }

        [ForeignKey("PlayerId")]
        public Player? Player { get; set; }

        [Key]
        public Guid AssetId { get; set; }

        [ForeignKey("AssetId")]
        public Asset? Asset { get; set; }
    }

}