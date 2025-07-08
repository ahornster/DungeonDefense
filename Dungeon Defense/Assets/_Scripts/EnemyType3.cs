using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType3 : EnemyController
{
    private void Start()
    {
        damage = 10;
        attackCooldown = 5;
        health = 200;
        movementSpeed = 1;
        defeatReward = 30;
    }

}
