
namespace GeekBrains
{
	public sealed class Gun : Weapon
	{
		public override void Fire()
		{
			if (!_isReady) return;
            if (Clip.CountAmmunition <= 0)
            {
                ReloadClip();
                return;
            }
			if (!Ammunition) return;
			var temAmmunition = Instantiate(Ammunition, _barrel.position, _barrel.rotation);// Pool object
			temAmmunition.AddForce(_barrel.forward * _force);
			Clip.CountAmmunition--;
            PlaySound();
			_isReady = false;
			Invoke(nameof(ReadyShoot), _fireRate);
			//_timer.Start(_rechergeTime);
		}
	}
}