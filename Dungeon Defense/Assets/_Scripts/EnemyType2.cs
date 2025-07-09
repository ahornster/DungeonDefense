using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType2 : EnemyController  
{
    private void Start()
    {
        damage = 20;
        attackCooldown = 5;
        health = 100;
        movementSpeed = 3;
        defeatReward = 20;

        //StartCoroutine(EnemyAttack()); //Seems to freeze unit when activated
    }

}
