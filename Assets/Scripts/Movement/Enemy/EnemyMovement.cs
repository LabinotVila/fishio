using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    private Movement movement;
    private float distanceWithTarget = Mathf.NegativeInfinity;
    private bool isRoaming = true;
    private float triggerDistance = 15;

    // The roaming method implementation
    IEnumerator Roam()
    {
        // The minimum and maximum time that a fish can randomly float in one direction
        float time = Random.Range(3, 6);

        Vector2 roamingDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        movement.SetDirection(roamingDirection);

        // The fishes keep roaming 'one direction' until this timer passes
        yield return new WaitForSeconds(time);

        // If not within trigger distance, repeat this co routine 
        if (distanceWithTarget >= triggerDistance)  StartCoroutine(Roam());
    }

    // The chase target method implementation
    void ChaseTarget()
    {
        Vector3 direction = player.position - transform.position;
        direction.Normalize();

        movement.SetDirection(direction);
    }

    void Start()
    {
        movement = GetComponent<Movement>();

        // We auto start the co-routine and let all fishes roam around lead hedless dogs
        StartCoroutine(Roam());
    }


    void Update()
    {
        // We keep checking for the distance between the fish and the target (the Player)
        distanceWithTarget = Vector3.Distance(transform.position, player.position);

        // If distance is less than 30 (in this case), ChaseTarget() is executed in Update
        if (distanceWithTarget < triggerDistance) 
        {
            if (isRoaming) 
            {
                isRoaming = false;

                StopCoroutine(Roam());
            }

            ChaseTarget();
        } 
        else // Otherwise, set Roaming to true, this method is executed every 3 seconds (the fishes change the way they swim every 3 seconds)
        {
            if (!isRoaming) 
            {
                isRoaming = true;

                StartCoroutine(Roam());
            }
        }
    }
}
