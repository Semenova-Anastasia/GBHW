using UnityEngine;

namespace GeekBrains
{
	public class WeaponController : BaseController, IOnUpdate, IInitialization
	{
		private Weapon _weapon;
		private int _mouseButton = (int)MouseButton.LeftButton;
        
        private WeaponUiText _weaponUiText;

        public void Init()
        {
            _weaponUiText = GameObject.FindObjectOfType<WeaponUiText>();
        }

        public void OnUpdate()
		{
			if (!IsActive) return;
			if (Input.GetMouseButton(_mouseButton))
			{
				_weapon.Fire();
                _weaponUiText.ShowData(_weapon.Clip.CountAmmunition, _weapon.CountClip);
			}
		}

		public override void On(BaseObjectScene weapon)
		{
			if (IsActive) return;
			base.On(weapon);

			_weapon = weapon as Weapon;
			if (_weapon == null) return;
			_weapon.IsVisible = true;
            _weaponUiText.SetActive(true);
            _weaponUiText.ShowData(_weapon.Clip.CountAmmunition, _weapon.CountClip);
		}

		public override void Off()
		{
			if (!IsActive) return;
			base.Off();
			_weapon.IsVisible = false;
			_weapon = null;
            _weaponUiText.SetActive(false);
		}

		public void ReloadClip()
		{
			if (_weapon == null) return;
			_weapon.ReloadClip();
            _weaponUiText.ShowData(_weapon.Clip.CountAmmunition, _weapon.CountClip);
		}
	}
}