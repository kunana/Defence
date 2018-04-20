using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coroutine : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        


	}

    private IEnumerable print5()
    {
        for(int i = 0; i < 100; i++)
        {
            print(i + 1);
            if(i % 10 == 0)
            yield return i;
        }
        yield return new WaitForSeconds(5.0f);
    }   
}
