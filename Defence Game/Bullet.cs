using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Bullet : MonoBehaviour {

    public Vector3 target = Vector3.zero;       // 백터 0,0,0 생성
    public GameObject exp = null;
    public int Damage = 1;
    // Use this for initialization
    void Start() {

       
    }

	
	// Update is called once per frame
	void Update () {
      

        if (target != Vector3.zero)
        {
            Vector3 BulletPos = transform.position;
            Vector3 targetPos = target;
            Vector3 dir = (targetPos - BulletPos).normalized;           // 방향을 지정해줌
            BulletPos.x += dir.x * Time.deltaTime * 6.0f;               // x,y 의 좌표값 지정
            BulletPos.y += dir.y * Time.deltaTime * 6.0f;
            transform.position = BulletPos;             // 현재 포지션을 새로운 포지션(불릿포스)로  지정
            float distance = Vector3.Distance(targetPos, BulletPos);
            if (distance < 0.1f)
            {
                Instantiate(exp, transform.position, Quaternion.identity);
                Collider2D[] hitsCol = Physics2D.OverlapCircleAll(transform.position, 1.5f);
                foreach(Collider2D hit in hitsCol)
                {
                    if(hit.gameObject.tag == "Enemy" )
                    {
                        hit.transform.GetComponent<Mob1>().Damage(Damage);
                        hit.transform.GetComponent<Hpbar>().HpMinus(Damage);
                    }
                }
                gameObject.SetActive(false);
                //Destroy(gameObject);
            }
        }

    }
  
    
}
