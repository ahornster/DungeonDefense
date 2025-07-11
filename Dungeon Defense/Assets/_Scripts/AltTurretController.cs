using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltTurretController : MonoBehaviour
{
    public enum TargetPriority
    {
        First,
        Closest,
        //Strongest
    }

    public float range;
    public List<EnemyController> enemyInRange = new List<EnemyController>();
    public EnemyController enemy;

    public TargetPriority targetPriority;
    public bool rotateTowardsTarget;

    public float attackRate;
    private float lastAttackTime;
    public GameObject projectilePrefab;
    public Transform projectileSpawnPos;

    public int projectileDamage;
    public float projectileSpeed;


    private void Update()
    {
        if(Time.time - lastAttackTime > attackRate)
        {
            lastAttackTime = Time.time;
            enemy = GetEnemy();

            if(enemy != null )
            {
                Attack();
            }
        }
    }

    EnemyController GetEnemy()
    {
        enemyInRange.RemoveAll(x => x == null);

        if(enemyInRange.Count == 0 )
        {
            return null;    
        }

        if(enemyInRange.Count == 1)
        {
            return enemyInRange[0];
        }

        switch(targetPriority)
        {
            case TargetPriority.First:
                return enemyInRange[0];

            case TargetPriority.Closest:
                EnemyController closest = null;
                float dist = 99;

                for(int x = 0; x < enemyInRange.Count; x++)
                {
                    float d = (transform.position - enemyInRange[x].transform.position).sqrMagnitude;

                    if(dist < d)
                    {
                        closest = enemyInRange[x];
                        dist = d;
                    }
                }
                return closest;

            //case TargetPriority.Strongest:
            //    GameObject strongest = null;
            //    int strongestHealth = 0;

            //    foreach(GameObject enemy in enemyInRange)
            //    {
            //        if(enemy.health > strongestHealth)
            //        {
            //            strongest = enemy;
            //            strongestHealth = enemy.Health
            //        }
            //    }
            //    return strongest;

            default: return null;
        }
    }

    void Attack()
    { 
        //if(rotateTowardsTarget)
        //{
        //    transform.LookAt(enemy.transform);
        //    transform.eulerAngles = new Vector3(0,transform.eulerAngles.y,0);
        //}

        GameObject proj = Instantiate(projectilePrefab, projectileSpawnPos.position, Quaternion.identity);
        proj.GetComponent<ProjectileController>().Initialize(enemy, projectileDamage, projectileSpeed);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemyInRange.Add(other.GetComponent<EnemyController>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemyInRange.Remove(other.GetComponent<EnemyController>());
        }
    }
}
