using UnityEngine;

[CreateAssetMenu]

public class Enemy : ScriptableObject
{
    [SerializeField] public float enemySpeed;
    [SerializeField] public int damage;
    [SerializeField] public float closestDistance;
    [SerializeField] public int enemyHealth;
 }
