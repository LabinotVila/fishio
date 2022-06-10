using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [Range(0,10)]
    public int attackDamage;

    [Range(0, 6)]
    public int hitPoints;
}
