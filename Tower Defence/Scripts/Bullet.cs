using UnityEngine;

[CreateAssetMenu(fileName = " new bullet", menuName = "Bullet")]

public class Bullet : ScriptableObject
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private int bulletDamage;
    [SerializeField] private Rigidbody bulletPrefab;

    public float BulletSpeed => bulletSpeed;
    public int BulletDamage => bulletDamage;
    public Rigidbody BulletPrefab => bulletPrefab;
}
