using UnityEngine;

public class bulletDestroyer : MonoBehaviour
{
    [SerializeField] private float timeToLive = 3f;
    public int damage;

    private void Start()
    {       
        Destroy(gameObject, timeToLive);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BulletS"))
        {
            damage = other.gameObject.GetComponentInParent<BasicTurretAI>().bulletSo.BulletDamage;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject, 0.3f);
        }
    }
}
