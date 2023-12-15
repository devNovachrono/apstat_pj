using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trackData : MonoBehaviour
{
    public static trackData i;
    public List<GameObject> pModels;
    public float trackLength = 1500;
    public int checkpoints = 2;
    public List<int> speeds = new List<int>();
    public List<int> sortedSpeeds = new List<int>();
    void Awake()
    {
        i = this;
        for (int i = 0; i < 5; i++)
        {
            int v = Random.Range(50,150);
            bool has = false;
            for (int y = 0; y < speeds.Count; y++)
            {
                if (speeds[y] == v)
                {
                    has = true;
                    break;
                }
            }
            if (has)
            {
                i--;
            }
            else
            {
               speeds[i] = v; 
            }
            speeds[i] = Random.Range(50,150);
        }
        sortedSpeeds = speeds;
        sortedSpeeds.Sort();
    }
}
