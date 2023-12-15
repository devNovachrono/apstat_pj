using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class horse : MonoBehaviour
{
    public float speed;

    public bool[] markers;
    public int pos;
    public int dieChance;
    public bool willDie = false;
    public int chosenTrack = -1;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        markers = new bool[trackData.i.checkpoints];
        dieChance = trackData.i.sortedSpeeds.IndexOf(trackData.i.speeds[pos]) * 20;
        willDie = Die(dieChance);
        if (willDie)
        {
            chosenTrack = Random.Range(0, trackData.i.checkpoints);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            begin = true;
            speed = Random.Range(trackData.i.speeds[pos] - 10, trackData.i.speeds[pos]+5);
        }
        if (!begin) return;
        for (int i = 0; i < markers.Length; i++)
        {
            bool mark = markers[i];
            if (mark) continue;
            if (i == markers.Length - 1) continue;
            if (transform.position.z >= (trackData.i.trackLength / trackData.i.checkpoints) * (i + 1))
            {
                markers[i] = true;
                if (i == chosenTrack)
                {
                    Debug.Log("Racer " + pos + " Eliminated");
                    Destroy(gameObject);
                }
                speed = Random.Range(trackData.i.speeds[pos]-5, trackData.i.speeds[pos]+5);
            }
        }
        if (transform.position.z >= trackData.i.trackLength)
        {
            Debug.Log("Racer " + pos + " Finished!!!");
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, Mathf.Lerp(rb.velocity.z, speed, .01f));
    }

    bool Die(int p)
    {
        int chosenP = Random.Range(0, 100);
        if (chosenP <= p)
        {
            return true;
        }
        return false;
    }

    private Rigidbody rb;
    private bool begin = false;
}
