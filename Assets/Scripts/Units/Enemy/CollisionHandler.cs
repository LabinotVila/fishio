using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    // Player variables
    public GameObject playerGameObject;
    private Collider2D playerCollider;
    private Unit playerUnit;

    // NPC variables
    private Unit unit;

    void Awake()
    {
        playerCollider = playerGameObject.GetComponent<Collider2D>();
        playerUnit = playerGameObject.GetComponent<Unit>();

        unit = GetComponent<Unit>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider == playerGameObject.GetComponent<Collider2D>())
        {
            // You, as a fish, have hit the player, suffer the consequences
            unit.hitPoints = unit.hitPoints - playerUnit.hitPoints;

            if (unit.hitPoints <= 0)
            {
                Destroy(gameObject);

                Debug.Log("The HP was decreased and the attacked fish died.");
            }
            else
            {
                Debug.Log("Fish was attacked but is still living!");
            }
        }
    }
}
