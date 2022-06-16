using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Fish", menuName = "Types/Fish")]
public class FishTemplate : ScriptableObject
{
    public GameObject fish;
    // public FishType fishType;
    public int maxHp;
    public int xpOnDeath;
    public int baseMovementSpeed;
    public Damage[] baseAttackDamage;
}

[System.Serializable]
public class Damage
{
    public IAttack script;
    public int baseAttackDamage;
}
