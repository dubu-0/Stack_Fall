using StackFall.PlayerSystem;
using StackFall.Printers;

namespace StackFall.Fx
{
	public class SpritePrinterController
	{
		private readonly PlayerCollisionHandler _playerCollisionHandler;
		private readonly SpritePrinter _spritePrinterPrefab;

		public SpritePrinterController(PlayerCollisionHandler playerCollisionHandler, SpritePrinter spritePrinterPrefab)
		{
			_playerCollisionHandler = playerCollisionHandler;
			_spritePrinterPrefab = spritePrinterPrefab;
		}

		public void Subscribe()
		{
			_playerCollisionHandler.OnShapePartTouched += _spritePrinterPrefab.Print;
		}

		public void Unsubscribe()
		{
			_playerCollisionHandler.OnShapePartTouched -= _spritePrinterPrefab.Print;
		}
	}
}