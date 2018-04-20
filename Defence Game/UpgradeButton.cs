using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButton : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDown()
    {
        var ren = GetComponent<SpriteRenderer>();
        ren.material.color = Color.grey;
    }
    private void OnMouseUp()
    {
        var ren = GetComponent<SpriteRenderer>();
        ren.material.color = Color.white;
        //버튼을 누르면 ui와 그의 자식이 원래 자리로 감
        transform.parent.position = new Vector3(-100, 0, 0);

    }
}
