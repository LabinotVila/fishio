using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiteAttack : IAttack
{
    public int damage;
    public float attackCooldown;
    private bool canAttack = true;

    
    public override void Attack()
    {
        StartCoroutine(AttackCooldown());
    }

    IEnumerator AttackCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (canAttack)
        {
            Transform parent = transform.root;
            Transform colParent = col.transform.root;

            Vector3 forceDirection = parent.position - colParent.position;
            forceDirection = forceDirection.normalized;
            print(parent.name + " attacked " + colParent.name + " for " + damage + " damage!");
            Attack();
        }
        else
            print("Cannot attack!");
    }
}
