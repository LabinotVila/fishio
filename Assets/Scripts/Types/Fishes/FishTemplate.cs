using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Fish", menuName = "Types/Fish")]
public class SOFish : ScriptableObject
{
    public FishType fishType;
    public int HP;
    public int XP;
}
