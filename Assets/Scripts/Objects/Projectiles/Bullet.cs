using Core.Pooling;
using UnityEngine;

namespace Objects.Projectiles
{
    public class Bullet : MonoBehaviour
    {
        public float damage;
        private void OnCollisionEnter(Collision other)
        {
            if(other.gameObject.CompareTag("Damagable"))
                other.gameObject.GetComponent<DamagableObject>().ReduceHealth(damage);
            
            GetComponent<PoolObject>().ReturnToPool ();
        }
    }
}
