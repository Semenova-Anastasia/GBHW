using UnityEngine;

namespace GeekBrains
{
	public sealed class Bullet : Ammunition
	{
        private void OnCollisionEnter(UnityEngine.Collision collision)
		{
			// дописать доп урон
			var tempObj = collision.gameObject.GetComponent<ISetDamage>();
			
			if (tempObj != null)
			{
				tempObj.SetDamage(new InfoCollision(_curDamage, Rigidbody.velocity));
			}

            if (Type == AmmunitionType.Grenade)
            {
                Instantiate(_impactFX, transform.position, transform.rotation);
            }

			Destroy(gameObject);
			// Вернуть в пул
		}
	}
}