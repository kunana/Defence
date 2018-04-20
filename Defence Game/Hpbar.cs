using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hpbar : MonoBehaviour {

    // Use this for initialization
    public GameObject HpBarLeft = null;
    public GameObject HpBarMiddle = null;
    public GameObject HpBarRight = null;

    private int  HpPercent = 10;
    private GameObject Left = null;
    private GameObject Middle = null;
    private GameObject Right = null;
    void Start () {

        

        //미들 HP바는 원점에서 시작 y축은 부모 오브젝트에서 -0.5f만큼
        Middle = Instantiate(HpBarMiddle, transform);
        Middle.transform.position = transform.position;
        Middle.transform.position += new Vector3(0, -0.5f, 0);

        //프리팹 설정 스케일 0.25 * 10 == 2.5f 
        Middle.transform.localScale = new Vector3(Middle.transform.localScale.x * HpPercent, Middle.transform.localScale.y);

        // 원점인 미들의 포지션에서 왼쪽 사이드의 절반값 + 0.45의 100퍼픽셀 * 퍼센트만큼 곱하여서 포지션을 구한다.
        Left = Instantiate(HpBarLeft,transform);
        Left.transform.position = Middle.transform.position - new Vector3(0.0225f + 0.045f * HpPercent, 0, 0);

        Right = Instantiate(HpBarRight,transform);
        Right.transform.position = Middle.transform.position + new Vector3(0.0225f + 0.045f * HpPercent, 0, 0);
    
        
    }
   
    void Update () {

      
    }
    
    public void HpMinus(int Dmg)
    {
        HpPercent -= Dmg;
        
        Middle.transform.localScale = new Vector3(0.25f * HpPercent ,Middle.transform.localScale.y);
        Left.transform.position = Middle.transform.position - new Vector3(0.0225f + 0.045f * HpPercent, 0, 0);
        Right.transform.position = Middle.transform.position + new Vector3(0.0225f + 0.045f * HpPercent, 0, 0);
        if (HpPercent <= 0)
            Destroy(gameObject);
      
    }
}
