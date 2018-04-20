using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;



public class Mob1 : MonoBehaviour
{

    private List<MakePaths.MovePath> movePaths = null;  // 리스트 를 가져옴 & 나우카운트를  맥스까지 반복하면서 무브패스의 좌표를 받음.
    private int nowCount = 0;
    private int MaxCount = 0;
    private float fTime = 0;
    private float SpawnTime = 0;
    public int moveSpeed = 3;
    public int Hp = 10;
    public int Cost = 30;
    public GameObject FlameEffect = null;
    public GameObject CointEffect = null;



    void Start()
    {
        // 카메라에 있는 패스를 저장
        movePaths = Camera.main.GetComponent<MakePaths>().movePath;
    }

    void FixedUpdate()
    {
      
    }
    // Update is called once per frame
    void Update()
    {

        MobMove();
    }

    void MobMove()
    {
        fTime += Time.deltaTime * moveSpeed;
        SpawnTime += Time.deltaTime * 3;

        Vector3 nowPos = new Vector3(movePaths[nowCount].x * 0.64f + 0.32f, movePaths[nowCount].y * 0.64f + 0.64f);
        Vector3 targetPos = new Vector3(movePaths[nowCount + 1].x * 0.64f + 0.32f, movePaths[nowCount + 1].y * 0.64f + 0.64f);
        float x = Mathf.Lerp(nowPos.x, targetPos.x, fTime);
        float y = Mathf.Lerp(nowPos.y, targetPos.y, fTime);
        MaxCount = movePaths.Count;
        transform.position = new Vector3(x, y, 0);


        if (fTime >= 1.0f)
        {
            fTime = 0;
            nowCount++;


            if (nowCount >= MaxCount - 1)
                Destroy(gameObject);
            else
            {
                nowPos = new Vector3(movePaths[nowCount].x * 0.64f + 0.32f, movePaths[nowCount].y * 0.64f + 0.64f);
                targetPos = new Vector3(movePaths[nowCount + 1].x * 0.64f + 0.32f, movePaths[nowCount + 1].y * 0.64f + 0.64f);
                Vector3 dir = (targetPos - nowPos).normalized;
                if (dir == Vector3.up)
                {
                    var ani = GetComponent<Animator>();
                    ani.SetTrigger("Up");
                }
                else if (dir == Vector3.down)
                {
                    var ani = GetComponent<Animator>();
                    ani.SetTrigger("Down");
                }
                else if (dir == Vector3.left)
                {
                    var ani = GetComponent<Animator>();
                    ani.SetTrigger("Left");
                }
                else if (dir == Vector3.right)
                {
                    var ani = GetComponent<Animator>();
                    ani.SetTrigger("Right");
                }
            }


        }
    }

    public void Damage(int Dam)
    {
        Hp -= Dam;
 
        if (Hp <= 0)
        { 
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().scoreUp(10);
            
            Destroy(gameObject);
        }
    }
    private void CoinEffect()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fire")
        {
            Instantiate(FlameEffect, transform.position, Quaternion.identity, transform);
            StartCoroutine(Delay());
        }
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1);
        Hpbar Hp = this.GetComponentInChildren<Hpbar>();
        Damage(1);
        Hp.HpMinus(1);
        yield return new WaitForSeconds(1);
        Damage(1);
        Hp.HpMinus(1);
        yield return null;
    }
   


}



