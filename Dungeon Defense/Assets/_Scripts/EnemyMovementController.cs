using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementController : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent agent;
    private Transform target;
    private GameObject targetChest;

    public float movementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        targetChest = GameObject.FindGameObjectWithTag("TargetChest"); 
        
    }

    // Update is called once per frame
    void Update()
    {
        //agent.speed = movementSpeed;
        target = targetChest.transform;
        agent.SetDestination(target.position);
        

        if (Vector3.Distance(transform.position, target.transform.position) < 1.5f)
        {
            agent.isStopped = true;
        }
        else
        {
            agent.isStopped = false;
        }
        
        
    }
}
