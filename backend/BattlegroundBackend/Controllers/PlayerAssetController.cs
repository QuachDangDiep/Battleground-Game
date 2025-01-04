using battlegameapi.Models;
using battlegameapi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace battlegameapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerAssetController : ControllerBase
    {
        private readonly BattleGameDbContext _context;

        public PlayerAssetController(BattleGameDbContext context)
        {
            _context = context;
        }

        // GET: api/PlayerAsset
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerAsset>>> GetPlayerAssets()
        {
            return await _context.PlayerAssets.Include(pa => pa.Player).Include(pa => pa.Asset).ToListAsync();
        }

        // GET: api/PlayerAsset/{playerId}/{assetId}
        [HttpGet("{playerId}/{assetId}")]
        public async Task<ActionResult<PlayerAsset>> GetPlayerAsset(Guid playerId, Guid assetId)
        {
            var playerAsset = await _context.PlayerAssets
                .Include(pa => pa.Player)
                .Include(pa => pa.Asset)
                .FirstOrDefaultAsync(pa => pa.PlayerId == playerId && pa.AssetId == assetId);

            if (playerAsset == null)
            {
                return NotFound();
            }

            return playerAsset;
        }

        // POST: api/PlayerAsset
        [HttpPost]
        public async Task<ActionResult<PlayerAsset>> PostPlayerAsset(PlayerAsset playerAsset)
        {
            _context.PlayerAssets.Add(playerAsset);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPlayerAsset), new { playerId = playerAsset.PlayerId, assetId = playerAsset.AssetId }, playerAsset);
        }

        // DELETE: api/PlayerAsset/{playerId}/{assetId}
        [HttpDelete("{playerId}/{assetId}")]
        public async Task<IActionResult> DeletePlayerAsset(Guid playerId, Guid assetId)
        {
            var playerAsset = await _context.PlayerAssets
                .FirstOrDefaultAsync(pa => pa.PlayerId == playerId && pa.AssetId == assetId);

            if (playerAsset == null)
            {
                return NotFound();
            }

            _context.PlayerAssets.Remove(playerAsset);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
