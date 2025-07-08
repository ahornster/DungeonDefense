using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public bool isActiveTurret;
    public bool isNearTurret;

    public GameObject turretbody;
    public GameObject[] turretType;
    public GameObject turretProjectile;

    public float turretDamage = 5;
    public float turretSpeed = 1;
    public float shootDelay = 3;

    public GameObject defendersChest;

    public List<GameObject> enemiesInRange;
    public GameObject closestEnemy;
    private Vector3 previousEnemyDistance;
    private Vector3 thisEnemyDistance;

    public GUIController guiController;

    // Start is called before the first frame update
    void Start()
    {
        guiController = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GUIController>();

        StartCoroutine(ShootAtEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        if (isActiveTurret)
        {
            if (enemiesInRange.Count > 0)
            {
                if (closestEnemy == null)
                {
                    AcquireTarget();
                }
                else
                {
                    
                }
            }
        }

        if (isNearTurret && Input.GetKeyDown(KeyCode.E))
        {
            guiController.HideDirectionalPrompt();
            SetTurretActive(1);

        }
    }

     IEnumerator ShootAtEnemy()
    {
        while (isActiveTurret)
        {
            //shoot enemy

            yield return new WaitForSeconds(shootDelay);
        }
    }

    void AcquireTarget()
    {
        foreach(GameObject enemy in enemiesInRange)
        {
            thisEnemyDistance = defendersChest.transform.position - enemy.transform.position;
            
            if((thisEnemyDistance.x + thisEnemyDistance.z) < (previousEnemyDistance.x + previousEnemyDistance.z))
            {
                closestEnemy = enemy;
            }
        }
    }

    void SetTurretActive(int typeID)
    {

        turretbody.SetActive(true);
        turretType[typeID].SetActive(true);
        isActiveTurret = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !isActiveTurret)
        {
            guiController.DisplayDirectionalPrompt("Press [E] to create Turret. (Costs 100 Coins).");

            isNearTurret = true;
        }

        if (other.gameObject.tag == "Enemy")
        {
            enemiesInRange.Add(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && !isActiveTurret)
        {
            guiController.HideDirectionalPrompt();

            isNearTurret = false;
        }

        if (other.gameObject.tag == "Enemy")
        {
            enemiesInRange.Remove(other.gameObject);
        }
    }


}
