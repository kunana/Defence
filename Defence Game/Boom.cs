using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour {

    private float fTime = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        fTime += Time.deltaTime;
        if (fTime > 0.3f)
            Destroy(gameObject);

    }
}
