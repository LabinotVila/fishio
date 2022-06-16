using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attributes : MonoBehaviour
{
    public int baseHP;
    public int baseDeathXP;
    public int baseMovementSpeed;
    public Damage[] attackTypes;
    void Start()
    {
        GetComponent<Movement>().maxMoveSpeed = baseMovementSpeed;
        foreach (Damage type in attackTypes)
        {
            if (type.script)
                type.script.SetDamage(type.baseAttackDamage);
        }
    }
}

[System.Serializable]
public class Damage
{
    public IAttack script;
    public int baseAttackDamage;
}
