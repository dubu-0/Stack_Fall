using StackFall.PlayerSystem;
using StackFall.Printers;

namespace StackFall.Fx
{
	public class FxController
	{
		private readonly PlayerCollisionHandler _playerCollisionHandler;
		private readonly SpritePrinter _spritePrinterPrefab;

		public FxController(PlayerCollisionHandler playerCollisionHandler, SpritePrinter spritePrinterPrefab)
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