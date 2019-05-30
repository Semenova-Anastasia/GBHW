using UnityEngine;

namespace GeekBrains
{
    /// <summary>
    /// Контроллер поведения фонарика
    /// </summary>
    public sealed class FlashLightController : BaseController, IOnUpdate, IInitialization
    {
        private FlashLightModel _flashLightModel;   // Ссылка на источник света.
        private FlashLightUi _flashLightUi;

        public void Init()
        {
            _flashLightModel = GameObject.FindObjectOfType<FlashLightModel>();
            _flashLightUi = GameObject.FindObjectOfType<FlashLightUi>();
        }

        public override void On()
        {
            if (IsActive) return;
            if (_flashLightModel == null) return;
            if (_flashLightUi == null) return;
            if (_flashLightModel.BatteryChargeCurrent <= 0) return;
            base.On();
            _flashLightModel.Switch(true);
            _flashLightUi.SetActive(true);
        }

        public override void Off()
        {
            if (!IsActive) return;
            base.Off();
            _flashLightModel.Switch(false);
            //_flashLightUi.SetActive(false);
        }

        public void OnUpdate()
        {
            _flashLightModel.Recharge();
            _flashLightUi.Battery = _flashLightModel.BatteryChargeCurrent;
            if (!IsActive) return;
            _flashLightModel.Rotation();
            if (!_flashLightModel.EditBatteryCharge())
            {
                Off();
            }
        }
    }
}
