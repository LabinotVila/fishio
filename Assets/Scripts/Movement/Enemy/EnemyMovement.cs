using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    
    private Movement _movement;
    
    private float _distanceWithTarget = Mathf.NegativeInfinity;
    private bool _isRoaming = true;
    
    private const float TriggerDistance = 15;

    // The roaming method implementation
    private IEnumerator Roam()
    {
        // The minimum and maximum time that a fish can randomly float in one direction
        float time = Random.Range(3, 6);

        var roamingDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        _movement.SetDirection(roamingDirection);

        // The fishes keep roaming 'one direction' until this timer passes
        yield return new WaitForSeconds(time);

        // If not within trigger distance, repeat this co routine 
        if (_distanceWithTarget >= TriggerDistance)  StartCoroutine(Roam());
    }

    // The chase target method implementation
    private void ChaseTarget()
    {
        Vector3 direction = player.position - transform.position;
        direction.Normalize();

        _movement.SetDirection(direction);
    }

    private void Start()
    {
        _movement = GetComponent<Movement>();

        // We auto start the co-routine and let all fishes roam around lead headless dogs
        StartCoroutine(Roam());
    }


    private void Update()
    {
        // We keep checking for the distance between the fish and the target (the Player)
        _distanceWithTarget = Vector3.Distance(transform.position, player.position);

        // If distance is less than 30 (in this case), ChaseTarget() is executed in Update
        if (_distanceWithTarget < TriggerDistance) 
        {
            if (_isRoaming) 
            {
                _isRoaming = false;

                StopCoroutine(Roam());
            }

            ChaseTarget();
        } 
        else // Otherwise, set Roaming to true, this method is executed every 3 seconds (the fishes change the way they swim every 3 seconds)
        {
            if (_isRoaming) return;
            _isRoaming = true;

            StartCoroutine(Roam());
        }
    }
}
