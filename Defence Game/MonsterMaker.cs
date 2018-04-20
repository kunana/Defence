using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMaker : MonoBehaviour {

    public List<GameObject> Enermy = null;
    private float ftime = 0;
    public float enermySpawnTime = 3.0f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ftime += Time.deltaTime;
        if (ftime > enermySpawnTime)
        {
            ftime = 0;
            Instantiate(Enermy[0]);
        }
    }
}

