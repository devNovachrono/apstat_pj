using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour
{
    public List<horse> horses;

    public int tick = 0;
    public GameObject point;

    void Update()
    {
        horses.RemoveAll(x => x == null);
        if (horses.Count == 0) return;
        if (tick >= 300)
        {
            tick = 0;
            horse selectedHorse = horses[Random.Range(0, horses.Count - 1)];
            point = selectedHorse.gameObject;
        }
        if (point != null)
        {
            transform.position = point.transform.position + new Vector3(0, 2, -15);
        }
        else
        {
            tick = 0;
            horse selectedHorse = horses[Random.Range(0, horses.Count - 1)];
            point = selectedHorse.gameObject;
        }
    }

    void FixedUpdate()
    {
        tick++;
    }
}
