using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPack : MonoBehaviour
{
    private int triggerRange = 750;
    public int TriggerRange { get; }

    private int triggerCooldown = 15;
    public int TriggerCooldown { get; }
}
