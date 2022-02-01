using System;
using StackFall.PlayerSystem;
using StackFall.Printers;

namespace StackFall.Fx
{
	[Serializable]
	public class FxInitializer
	{
		public FxController FXController { get; private set; }

		public void Initialize(PlayerCollisionHandler handler, SpritePrinter prefab)
		{
			FXController = new FxController(handler, prefab);
		}
	}
}