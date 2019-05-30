using UnityEngine;

namespace GeekBrains
{
	public class UiInterface
	{
		private FlashLightUi _flashLightUiBar;

		public FlashLightUi FlashLightUiBar
		{
			get
			{
				if (!_flashLightUiBar)
					_flashLightUiBar = Object.FindObjectOfType<FlashLightUi>();
				return _flashLightUiBar;
			}
		}

		private WeaponUiText _weaponUiText;

		public WeaponUiText WeaponUiText
		{
			get
			{
				if (!_weaponUiText)
					_weaponUiText = Object.FindObjectOfType<WeaponUiText>();
				return _weaponUiText;
			}
		}

		private SelectionObjMessageUi _selectionObjMessageUi;

		public SelectionObjMessageUi SelectionObjMessageUi
		{
			get
			{
				if (!_selectionObjMessageUi)
					_selectionObjMessageUi = Object.FindObjectOfType<SelectionObjMessageUi>();
				return _selectionObjMessageUi;
			}
		}
	}
}