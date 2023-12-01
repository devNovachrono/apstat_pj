using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class horse : MonoBehaviour
{
    public float speed;

    public bool[] markers;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        markers = new bool[trackData.checkpoints];
    }

    void Update()
    {
        for (int i = 0; i < markers.Length; i++)
        {
            bool mark = markers[i];
            if (mark) continue;
            if (i == markers.Length - 1) continue;
            if (transform.position.z >= (trackData.trackLength / trackData.checkpoints) * (i + 1))
            {
                markers[i] = true;
                speed = Random.Range(50, 100);
            }
        }
        if (transform.position.z >= trackData.trackLength)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, Mathf.Lerp(rb.velocity.z, speed, .01f));
    }

    private Rigidbody rb;
}
