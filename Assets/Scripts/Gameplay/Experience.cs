using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experience : MonoBehaviour
{
    private int numLevels = 25;
    private int[,] ranges;
    private int level = 1;
    private int xp = 0;

    void Awake()
    {
        for (int i = 1; i <= numLevels; i++)
        {
            ranges[i, 0] = (i * 1000) - 1000;
            ranges[i, 1] = (i * 1000) - 1;
        }
    }

    public void setXP(int xp)
    {
        this.xp = xp;

        updateLevelBasedOnXP();
    }

    public int getXP()
    {
        return this.xp;
    }

    public void updateLevelBasedOnXP()
    {
        for (int i = 0; i < ranges.Length; i++)
        {
            if (this.xp >= ranges[i, 0] && this.xp <= ranges[i, 1])
            {
                this.level = i;
            }
        }
    }
}
