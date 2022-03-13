using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BasicEnemyAI : MonoBehaviour
{

    [SerializeField] private Enemy enemySo;
    [SerializeField] public float curHealth;
    [SerializeField] Slider healthSlider;
    [SerializeField] GameObject healthBarUI;
    [SerializeField] GameObject effect;

    
    private GameObject[] turrets;
    private GameObject enemy;
    private Rigidbody rb;
    private float dist;
    private Vector3 targetPosition;
    private int damageReceived;
    private MeshRenderer mRenderer;
    private Collider mCollider;

    // Start is called before the first frame update
    void Start()
    {
        enemy = gameObject;
        rb = enemy.GetComponent<Rigidbody>();
        curHealth = enemySo.enemyHealth;
        healthSlider.value = CalculatePercentageOfHealth();
        mRenderer = GetComponent<MeshRenderer>();
        mCollider = GetComponent<Collider>();

    }
    // Update is called once per frame
    void Update()
    {
        AdquireTargets();
        dist = Vector3.Distance(enemy.transform.position, turrets[0].transform.position);
        healtUpdate();
    }

    void OnCollisionEnter(Collision bullet)
    {
        if (bullet.gameObject.CompareTag("Bullet"))
        {
            damageReceived = bullet.gameObject.GetComponent<bulletDestroyer>().damage;
            AddjustEnemyHealth(damageReceived);
        }
    }

    private void AddjustEnemyHealth(int damageReceived)
    {
        curHealth -= damageReceived;
    }

    private void FixedUpdate()
    {
        MoveToTarget();
    }
    void AdquireTargets()
    {
        turrets = GameObject.FindGameObjectsWithTag("Turret");
        turrets = turrets.OrderBy(x => Vector3.Distance(transform.position, x.transform.position)).ToArray();
        targetPosition = new Vector3(turrets[0].transform.position.x, turrets[0].transform.position.y, enemy.transform.position.z);
    }

    private void healtUpdate()
    {
        healthSlider.value = CalculatePercentageOfHealth();

        if (curHealth < enemySo.enemyHealth)
        {
            healthBarUI.SetActive(true); 
        }
        if (curHealth <= 0)
        {
            DyingSequence();
        }
        if (curHealth > enemySo.enemyHealth)
        {
            curHealth = enemySo.enemyHealth;
        }
    }

    private void DyingSequence()
    {
        mRenderer.enabled = false;
        mCollider.enabled = false;
        effect.SetActive(true);
        Destroy(gameObject, 1f);
    }

    float CalculatePercentageOfHealth()
    {
       return curHealth / enemySo.enemyHealth;
    }

    private void MoveToTarget()
    {
        if (dist > enemySo.closestDistance)
        {
            turrets = turrets.OrderBy(x => Vector3.Distance(transform.position, x.transform.position)).ToArray();
            enemy.transform.LookAt(turrets[0].transform.position);

            rb.AddForce(transform.forward.normalized * enemySo.enemySpeed);

            //enemy.transform.Translate(Vector3.forward * Time.deltaTime * enemySpeed);
        }
    }
}
