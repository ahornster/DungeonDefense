using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private EnemyController target;
    private int damage;
    private float moveSpeed;

    public GameObject hitSpawnPrefab;

    private void Update()
    {
        if(target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
            
            transform.LookAt(transform.position);

            if(Vector3.Distance(transform.position, target.transform.position) < 0.2f)
            {
                (target).TakeDamage(damage);

                if(hitSpawnPrefab != null )
                {
                    Instantiate(hitSpawnPrefab, transform.position, Quaternion.identity);
                }

                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Initialize(EnemyController target, int damage, float moveSpeed)
    {
        this.target = target;
        this.damage = damage;
        this.moveSpeed = moveSpeed;
    }
}
