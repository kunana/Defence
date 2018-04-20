using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class DamageUI : MonoBehaviour {
    public int SetDamText = 0;
    private float ftime = 0;
    private bool _MyActive = false;
    public bool MyActive
    {
        get
        {
            return _MyActive;
        }
        set
        {
            _MyActive = value;
            if(_MyActive == true)
            {
                ftime = 0;
               
                GetComponent<Rigidbody2D>().gravityScale = 0.5f;
               

            }
        }
    }

	// Use this for initialization
	void Start () {
          
    }
    // Update is called once per frame
    void Update () {
        if (MyActive == false)
            return;
        ftime += Time.deltaTime;
        if(ftime > 2.0f)
        {   
            GetComponent<Rigidbody2D>().gravityScale = -1;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            
        }
        
    }

   
           
  
}
