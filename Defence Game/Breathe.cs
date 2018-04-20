using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breathe : MonoBehaviour
{   
    private GameObject Tower;
    private float DelayTime = 0;
    private int _dir = 0;
    public int Dir
    {
        set
        {
            _dir = value;
            switch (_dir)
            {

                case 1:
                    transform.Rotate(new Vector3(0,0,0));
                    break;
                case 2:
                    transform.Rotate(new Vector3(0, 0, -180.0f));
                    break;
                case 3:
                    transform.Rotate(new Vector3(0, 0, -90.0f));
                    break;
                case 4:
                    transform.Rotate(new Vector3(0, 0, 90.0f));
                    break;
            }
        }
    }
    void Start()
    {

    }

    // 드래곤 타워에서 몬스터의 수가 가장많은 쪽의 방향을 받아 발사해준다.

    void Update()
    {

        Vector2 OriginPos = transform.position;

        switch (_dir)
        {

            case 1:
                {
                    //왼쪽 방향
                    transform.position = new Vector2(OriginPos.x - 0.1f, OriginPos.y);
                    break;
                }
            case 2:
                {
                    //오른쪽 방향
                    transform.position = new Vector2(OriginPos.x + 0.1f, OriginPos.y);
                    break;
                }
            case 3:
                {   //위쪽 방향
                    transform.position = new Vector2(OriginPos.x, OriginPos.y + 0.1f);
                    break;
                }
            case 4:
                {   //아랫쪽 방향
                    transform.position = new Vector2(OriginPos.x, OriginPos.y - 0.1f);
                    break;
                }
        }

        //화면 벗어날시에 발사체 사제
        if (this.transform.position.x <= -1.0f || transform.position.x >= 13.0f
                       || transform.position.y <= -1.0f || transform.position.y >= 13.0f)
        {
            gameObject.SetActive(false);
        }

    }
}





