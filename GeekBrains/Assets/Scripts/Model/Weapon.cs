using System.Collections.Generic;
using UnityEngine;

namespace GeekBrains
{
	public abstract class Weapon : BaseObjectScene
	{
        [SerializeField] private int _clipAmmo = 20;
        [SerializeField] private int _clipAmount = 5;
		public Ammunition Ammunition;
		public Clip Clip;
        //public bool IsVisible;

        protected AmmunitionType[] _ammunitionType = {AmmunitionType.Bullet};

		[SerializeField] protected Transform _barrel;
        [SerializeField] private AudioClip _audio;
        protected AudioSource _audioSource;
		[SerializeField] protected float _force = 999;
		[SerializeField] protected float _fireRate = 0.2f;
		private Queue<Clip> _clips = new Queue<Clip>();

		protected bool _isReady = true;
        
		//protected Timer _timer = new Timer();

		private void Start()
		{
			for (var i = 0; i <= _clipAmount; i++)
			{
				AddClip(new Clip { CountAmmunition = _clipAmmo });
			}

			ReloadClip();
            _audioSource = GetComponent<AudioSource>();
            _audioSource.clip = _audio;
        }

        public void PlaySound()
        {
            _audioSource.Play();
        }

		public abstract void Fire();

		//protected virtual void Update()
		//{
		//	_timer.Update();
		//	if (_timer.IsEvent())
		//	{
		//		ReadyShoot();
		//	}
		//}

		protected void ReadyShoot()
		{
			_isReady = true;
		}

		protected void AddClip(Clip clip)
		{
			_clips.Enqueue(clip);
		}

		public void ReloadClip()
		{
			if (CountClip <= 0) return;
            if (Clip.CountAmmunition == _clipAmmo) return;
			Clip = _clips.Dequeue();
		}

		public int CountClip => _clips.Count;
	}
}