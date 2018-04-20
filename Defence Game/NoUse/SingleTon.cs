using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTon : MonoBehaviour {

    // Use this for initialization
    private static SingleTon _instance = null;
    public static SingleTon instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new SingleTon();
            }
            return _instance;
        }
        
    }
    private int count = 0;
    public void printCount()
    {
        count++;
        print(count);
    }
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
