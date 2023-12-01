using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour
{
    public horse[] horses;

    public int tick = 0;

    void Update()
    {
        if (tick >= 300)
        {
            tick = 0;
            horse selectedHorse = horses[Random.Range(0, horses.Length - 1)];
            transform.SetParent(selectedHorse.gameObject.transform,false);
        }
    }

    void FixedUpdate()
    {
        tick++;
    }
}
