using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakingWindow : MonoBehaviour
{

    private int ClickCount = 0;
    private float ftime = 0;
    private bool isitOpen = false;
    private static MakingWindow _CircleWindow;
    public static MakingWindow CirlcleWindow
    {
        get
        {

            if (!_CircleWindow)
            {
                GameObject container = new GameObject();
                container.name = "CirlceUI";
                _CircleWindow = container.AddComponent(typeof(MakingWindow)) as MakingWindow;

                //Canvas canvas = container.AddComponent<Canvas>();
                //Image image = container.AddComponent<Image>();

            }


            return _CircleWindow;
        }

    }

    ///마우스 두번클릭
    ///원형의 캔버스가 마우스의 위치로 스케이이 최소에서  기본크기까지 커진다.
    ///캔버스안에는 타워생성 버튼이있다.
    ///이때 마우스는 마우스를 두번다시 눌러서 끌수있고 , 스위치가 켜진 상태에서는 원형 안의 범위만 움직일수있다.
    /// var circle = GameObject.FindGameObjectWithTag("Circle");
    /// circle.GetComponent<Image>().fillAmount = 1;
    ///
    private void Awake()
    {
        var circle = GameObject.FindGameObjectWithTag("Circle");
        circle.GetComponent<Image>().fillAmount = 0;
        circle.transform.Rotate(new Vector3(0, 0, 360));
        circle.SetActive(false);
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void CreateCircle()
    {

        var circle = GameObject.FindGameObjectWithTag("Circle");
       
        if (circle != null)
        {
            if (ClickCount > 2 && isitOpen == false)
            {   
                
                ftime += Time.deltaTime;
                circle.SetActive(true);
                circle.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                isitOpen = true;
                for (float i = ftime; i < 1.0f;)
                {   
                    circle.GetComponent<Image>().fillAmount = i;
                    circle.transform.rotation = transform.rotation;
                    
                }
                
            }



        }

    }
    private void OnMouseDown()
    {
        
    }
    private void OnMouseUp()
    {
        
    }
}
