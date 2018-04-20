using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedButton : MonoBehaviour
{
    public GameObject character = null;
    public GameObject Tower = null;
    private GameObject MakeCharacter = null;

    //타워 생성을 위한 UI
    void Start()
    {
        MakeCharacter = Instantiate(character);
        MakeCharacter.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDown()
    {
        var ren = GetComponent<SpriteRenderer>();
        ren.material.color = Color.gray;
        var child = transform.GetChild(0);
        child.GetComponent<SpriteRenderer>().material.color = Color.gray;
        MakeCharacter.gameObject.SetActive(true);
        Vector3 pos =
            Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        MakeCharacter.transform.position = pos;
    }
    private void OnMouseUp()
    {
        var ren = GetComponent<SpriteRenderer>();
        ren.material.color = Color.white;
        var child = transform.GetChild(0);
        child.GetComponent<SpriteRenderer>().material.color = Color.white;
        MakeCharacter.gameObject.SetActive(false);

        Vector3 pos =
           Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        var t = Instantiate(Tower, pos, Quaternion.identity);
        t.GetComponent<SpriteRenderer>().sortingOrder = 20;
    }
    private void OnMouseDrag()
    {
        Vector3 pos =
            Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        MakeCharacter.transform.position = pos;
    }
}
