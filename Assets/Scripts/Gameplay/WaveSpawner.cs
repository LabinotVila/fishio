using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public FishTemplate fishTemplate;

    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(fishTemplate.fish, Vector3.zero, Quaternion.identity);
        }
    }
}
