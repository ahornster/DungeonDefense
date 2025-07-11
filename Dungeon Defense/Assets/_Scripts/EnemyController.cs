using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    protected int damage;
    [SerializeField]
    protected float attackCooldown;
    [SerializeField]
    protected int health;
    [SerializeField]
    protected float movementSpeed;
    [SerializeField]
    protected int defeatReward;
    [SerializeField]
    bool chestInRange;
    [SerializeField]
    bool tryAttacks = false;

    public GUIController guiController;
    public WaveController waveController;
    public EnemyMovementController enemyMovementController;
   
    
    // Start is called before the first frame update
    void Start()
    {
        //enemyMovementController = gameObject.GetComponent<EnemyMovementController>();
        
        //StartCoroutine(EnemyAttack());
    }

    

    // Update is called once per frame
    void Update()
    {
        //enemyMovementController.movementSpeed = movementSpeed;

        if (waveController == null || guiController == null) //populating controller scripts here because they wouldn't populate in start. using a null check because we dont need to update them continously
        {
            waveController = GameObject.FindGameObjectWithTag("GameManager").GetComponent<WaveController>();
            guiController = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GUIController>();
            //enemyMovementController = gameObject.GetComponent<EnemyMovementController>();
        }

        if(!tryAttacks)
        {
            tryAttacks = true;
            StartCoroutine(EnemyAttack());
            
        }

        if(health <= 0)
        {
            Destroy(gameObject);
        }

    }

     IEnumerator EnemyAttack()
    {
        while(tryAttacks)
        {
            if (chestInRange)
            {
                //Debug.Log("EnemyAttack has been attempted");
                guiController.DamageDefenderHealth(damage);
                yield return new WaitForSeconds(attackCooldown);
            }

        yield return null;
        }
               
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    private void OnDestroy()
    {
        waveController.currentEnemyCount--;
        guiController.AddMoney(defeatReward);
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "TargetChest")
        {
            //Debug.Log("Chest is within an enemys range");
            chestInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "TargetChest")
        {
            chestInRange = false;
        }
    }
}
