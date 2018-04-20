using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DragonTower : MonoBehaviour
{
    
    
    public float FireInterval = 3.0f;
    private float fTime = 0;
    private int Direction = 0;

    public int Direct()
    {
        return Direction;
    }
    // Use this for initialization
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        fTime += Time.deltaTime;
        if (fTime > FireInterval && GameObject.FindWithTag("Enemy") != null)
        {
            fTime = 0;


            Vector2 Up = transform.TransformDirection(Vector2.up);
            Vector2 Down = transform.TransformDirection(Vector2.down);
            Vector2 Left = transform.TransformDirection(Vector2.left);
            Vector2 Right = transform.TransformDirection(Vector2.right);

            RaycastHit2D[] HitUp = Physics2D.RaycastAll(transform.position, Up, 5.0f);
            RaycastHit2D[] HitDown = Physics2D.RaycastAll(transform.position, Down, 5.0f);
            RaycastHit2D[] HitRight = Physics2D.RaycastAll(transform.position, Right, 5.0f);
            RaycastHit2D[] HitLeft = Physics2D.RaycastAll(transform.position, Left, 5.0f);

            int UpLen = HitUp.Length;
            int DownLen = HitDown.Length;
            int RightLen = HitRight.Length;
            int LeftLen = HitLeft.Length;
            int Xlen = RightLen + LeftLen;
            int YLen = UpLen + DownLen;

            var pool = GameObject.FindGameObjectWithTag("BulletPooling");
            if(pool != null)
            {
                
                if (LeftLen > RightLen) // 왼쪽 방향 == 1
                {
                    Direction = 1;
                    //Breathes.transform.eulerAngle = new Vector3(0,0,0);
                    //Instantiate(Breathe, transform.position, Quaternion.Euler(0, 0, 0), transform);
                    Direct();
                }
                else if (LeftLen < RightLen) // 오른쪽 방향 == 2
                {
                    Direction = 2;
                    //var Breathes = BreathesPooling.getBreathes();
                    //Breathes.transform.position = transform.position;
                    //Breathes.transform.eulerAngle = new Vector3(0, 0, 0);
                    Direct();
                }
                else if (UpLen > DownLen) // 위쪽 방향 == 3
                {
                    Direction = 3;
                    //Instantiate(Breathe, transform.position, Quaternion.Euler(0, 0, -90), transform);
                    Direct();
                }
                else if (UpLen < DownLen) // 아래쪽 방향 == 4
                {
                    Direction = 4;
                    //Instantiate(Breathe, transform.position, Quaternion.Euler(0, 0, 90), transform);
                    Direct();
                }
                var BreathesPooling = pool.GetComponent<Pooling>();
                var Breathes = BreathesPooling.getBreathes();
                var s = Breathes.GetComponent<Breathe>();
                var dir = s.Dir = Direction;
                Breathes.transform.position = transform.position;
            }

        }
    }
    //타워 ui를 해당 타워의 자리로 불러옴
    private void OnMouseUp()
    {
        var ui = GameObject.FindGameObjectWithTag("TowerUI");
        ui.transform.position = transform.position;
        ui.GetComponent<TowerUI>().setTower(this.gameObject);

        //자연스러운 UI확대 효과 최소에서 3.0f까지
        ui.transform.localScale = new Vector3(0.001f, 0.001f, 1);
        ui.transform.DOScale(0.004f, 0.7f);
    }
    
}
