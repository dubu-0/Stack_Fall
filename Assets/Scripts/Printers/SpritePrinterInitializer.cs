using System;
using UnityEngine;

namespace StackFall.Printers
{
	[Serializable]
	public class SpritePrinterInitializer
	{
		[SerializeField] private SpritePrinter _spritePrinterPrefab;

		public SpritePrinter SpritePrinterPrefab => _spritePrinterPrefab;

		public void Initialize()
		{
			_spritePrinterPrefab.Initialize();
		}
	}
}