using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deamon_Enemy : Enemy
{
   // [SerializeField]
     private float attackTime;
     private float stopDistance;
     private float timeBetweenAttack;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player!=null)
        {
            if (Vector2.Distance(transform.position, player.position) > stopDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position,player.position,enemyMoveSpeed);
            }
            else
            {
                if (Time.time >= attackTime)
                {
                    StartCoroutine(AttackAnimEnemy());
                    attackTime = Time.time + timeBetweenAttack;
                }
                
            }
           
        }
    }

   IEnumerator AttackAnimEnemy()
    {
        player.GetComponent<PlayerController>().TakeDamage(damage);

        Vector2 originalposition = transform.position;
        Vector2 targetposition = player.position;
        yield return null;
    }
}
