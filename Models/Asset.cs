namespace battlegameapi.Models{
    public class Asset
{
    public Guid AssetId { get; set; }
    public string AssetName { get; set; }
    public int LevelRequire { get; set; }
    public ICollection<PlayerAsset> PlayerAssets { get; set; } = new List<PlayerAsset>();
}

}