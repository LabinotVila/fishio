using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private double bleed = 0;
    public double Bleed { get; set; }

    private int xp = 0;
    public int XP { get; set; }

    private int level = 1;
    public int Level { get; set; }
}
