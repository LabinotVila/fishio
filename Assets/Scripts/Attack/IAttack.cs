using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IAttack : MonoBehaviour
{
    public abstract void Attack();
    public abstract void SetDamage(int damage);
}
