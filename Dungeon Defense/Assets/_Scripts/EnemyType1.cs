using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType1 : EnemyController
{
    private void Start()
    {
        damage = 5;
        attackCooldown = 3;
        health = 100;
        movementSpeed = 3;
        defeatReward = 10;

        //StartCoroutine(EnemyAttack()); //Seems to freeze unit when activated
    }

}
