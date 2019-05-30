using UnityEngine;

namespace GeekBrains
{
    /// <summary>
    /// Контроллер, который отвечает за горячие клавиши.
    /// </summary>
    public class InputController : BaseController, IOnUpdate
    {
        private KeyCode _activeFlashLight = KeyCode.F;
        private KeyCode _cancel = KeyCode.Escape;
        private KeyCode _reloadClip = KeyCode.R;
        private int currentWeapon;

        public InputController()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        public void OnUpdate()
        {
            if (!IsActive) return;
            if (Input.GetKeyDown(_activeFlashLight))
            {
                Main.Instance.FlashLightController.Switch();
            }
            // реализовать выбор оружия по колесику мыши

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SelectWeapon(0);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SelectWeapon(1);
            }

            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                SelectWeapon(currentWeapon + 1);
            }

            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                SelectWeapon(currentWeapon - 1);
            }

            if (Input.GetKeyDown(_cancel))
            {
                Main.Instance.WeaponController.Off();
                Main.Instance.FlashLightController.Off();
            }

            if (Input.GetKeyDown(_reloadClip))
            {
                Main.Instance.WeaponController.ReloadClip();
            }
        }


        /// <summary>
        /// Выбор оружия
        /// </summary>
        /// <param name="i">Номер оружия</param>
        ///<exception cref="System.NullReferenceException"></exception>
        private void SelectWeapon(int i)
        {
            Main.Instance.WeaponController.Off();

            if (i >= Main.Instance.ObjectManager.Weapons.Length)
                i = 0;
            if (i < 0)
                i = Main.Instance.ObjectManager.Weapons.Length - 1;
            currentWeapon = i;
            var tempWeapon = Main.Instance.ObjectManager.Weapons[i]; // инкапсулировать
            if (tempWeapon != null)
            {
                Main.Instance.WeaponController.On(tempWeapon);
            }
        }
    }
}
