using System.Linq;
using System.Collections;
using UnityEngine;

public class BasicTurretAI : MonoBehaviour
{
    public Bullet bulletSo;

    [SerializeField] private GameObject turret;
    [SerializeField] private GameObject[] enemy;
    [SerializeField] private float cooldown = 1;
    [SerializeField] private GameObject bulletSpawn;
    [SerializeField] private float range = 5;
    [SerializeField] private GameObject target;

    private bool attacking = false;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AdquireTargets());
        StartCoroutine(AimToTargets());
        StartCoroutine(Attack());
    }

    // Update is called once per frame
    void Update()
    {
        CheckStatus();
    }

    private void CheckStatus()
    {
        if (enemy.Length > 0)
        {
            target = enemy[0];
            attacking = true;

        }
        else
        {
            attacking = false;
        }
    }

    IEnumerator AimToTargets()
    {
        while (this)
        {
            while (target)
            {
                turret.transform.LookAt(enemy[0].transform.position);
                bulletSpawn.transform.LookAt(enemy[0].transform);
                yield return new WaitForSeconds(Time.deltaTime * 1.15F);
            }
            yield return new WaitForSeconds(0.042f);
        }
    }

    IEnumerator AdquireTargets()
    {
        while (this)
        {           
            enemy = GameObject.FindGameObjectsWithTag("Enemy");
            enemy = enemy.OrderBy(x => Vector3.Distance(transform.position, x.transform.position)).ToArray();
            yield return new WaitForSeconds(0.042f);
        }

    }
    IEnumerator Attack()
    {
        while (this)
        {
            while (target)
            {
                if (Vector3.Distance(transform.position, enemy[0].transform.position) <= range || attacking == false)
                {
                    Rigidbody bullet;
                    bullet = Instantiate(bulletSo.BulletPrefab, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
                    bullet.AddForce(bullet.transform.TransformDirection(Vector3.forward * bulletSo.BulletSpeed));
                    attacking = true;
                    yield return new WaitForSeconds(cooldown);
                }
                else
                {
                    attacking = true;
                    yield return new WaitForSeconds(cooldown);
                }
                yield return new WaitForSeconds(cooldown);
            }
           yield return new WaitForSeconds(cooldown);
        }
    }
}
