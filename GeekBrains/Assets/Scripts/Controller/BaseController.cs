namespace GeekBrains
{
    public abstract class BaseController
    {
        public bool IsActive { get; private set; }

        /// <summary>
        /// Включение контроллера
        /// </summary>
        public virtual void On()
        {
            On(null);
        }

        public virtual void On(BaseObjectScene obj)
        {
            IsActive = true;
        }

        /// <summary>
        /// Выключение контроллера
        /// </summary>
        public virtual void Off()
        {
            IsActive = false;
        }

        /// <summary>
        /// Переключение состояния контроллера
        /// </summary>
        public void Switch()
        {
            if (!IsActive)
            {
                On();
            }
            else
            {
                Off();
            }
        }
    }
}
