using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour

{
    [Header("Objects Variables")]
    [SerializeField] private GameObject spawn;
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private GameObject[] listOfEnemies;
    [SerializeField] private Transform levelDirection;

    [Header("Level Variables")]
    [SerializeField] private float cooldown = 3;
    [SerializeField] private float randomPositionX;
    [SerializeField] private float randomPositionZ;
    [SerializeField] private int randomMonster;
    [SerializeField] private int minRange;
    [SerializeField] private float maxRange;
    [SerializeField] private int maxEnemies;

    private void Awake()
    {
        levelDirection = GameObject.FindGameObjectWithTag("levelDirection").transform;
        StartCoroutine(SpawnMonster());
    }

     IEnumerator SpawnMonster()
    {
        while (this)
        {
            if (enemies.Length < maxEnemies)
            {
                randomPositionX = Random.Range(-maxRange, maxRange);
                randomPositionZ = Random.Range(-maxRange, maxRange);
                randomMonster = 0;
                Vector3 relativePos = levelDirection.position - transform.position;
                Quaternion rotationLevel = Quaternion.LookRotation(relativePos, Vector3.up);
                Instantiate(listOfEnemies[randomMonster], new Vector3(randomPositionX + minRange, spawn.transform.position.y, randomPositionZ + minRange), spawn.transform.rotation, spawn.transform);
                enemies = GameObject.FindGameObjectsWithTag("Enemy");
                yield return new WaitForSeconds(cooldown);
            }
            yield return new WaitForSeconds(cooldown);
        }
    }
}
