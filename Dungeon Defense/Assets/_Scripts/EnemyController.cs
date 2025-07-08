using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    protected int damage;
    protected float attackCooldown;
    protected int health;
    protected float movementSpeed;
    protected int defeatReward;
    bool chestInRange;

    public GUIController guiController;
    public WaveController waveController;
   
    
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(EnemyAttack());
    }

    

    // Update is called once per frame
    void Update()
    {
        if(waveController == null || guiController == null) //populating controller scripts here because they wouldn't populate in start. using a null check because we dont need to update them continously
        {
            waveController = GameObject.FindGameObjectWithTag("GameManager").GetComponent<WaveController>();
            guiController = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GUIController>();
        }
    }

    IEnumerator EnemyAttack()
    {
        while (true)
        {
            if (chestInRange)
            {
                guiController.DamageDefenderHealth(damage);
                yield return new WaitForSeconds(attackCooldown);
            }
            
        }  
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
