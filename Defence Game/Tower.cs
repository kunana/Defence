using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Tower : MonoBehaviour {

    public GameObject lamp = null;
    private GameObject closeEnemy = null; // 가장 가까운 적을 저장;
    private List<GameObject> collEnemys = new List<GameObject>();
    private float fTime = 0;
    public bool ui_On = false;


    // Use this for initialization
    void Start () {
	
     

    }
	
	// 타워에서 가장 가까운 적을 때리고 그 적이 나가면 그다음 가까운 적을 때린다.
	void Update () {
        fTime += Time.deltaTime;
        
        if (fTime > 0.5f && collEnemys.Count > 0)
        {
            fTime = 0;
            GameObject target = collEnemys[0];
            //풀링의 태그를 찾고
            var pool = GameObject.FindGameObjectWithTag("BulletPooling");
            // 풀이 null 이 아니면
            if(pool != null)
            {   //풀링 스크립트를 가져와서
                var Bulletpooling = pool.GetComponent<Pooling>();

                //디큐 함수를 부르고
                var Bullet = Bulletpooling.getLamp();

                //타겟의 위치를 지정해주고
                Bullet.transform.position = transform.position;
                Bullet.GetComponent<Bullet>().target = target.transform.position;

                //태그를 달아준다
                Bullet.tag = "Bullet";
            }
            //var bullet = Instantiate(lamp, transform.position, Quaternion.identity, transform);     // 변수 생성
            //bullet.GetComponent<Bullet>().target = target.transform.position;       // 불릿에 있는 벡터3 타겟에 타겟의 방향을 지정
        }

	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
            collEnemys.Add(collision.gameObject);

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        foreach(GameObject go in collEnemys)
        {
            if (go == collision.gameObject)
            { 
                collEnemys.Remove(go);
                break;
            }
            if(collision.tag == "Bullet")
            {
                Destroy(collision.gameObject);
            }
        }
    }

    //타워 ui를 해당 타워의 자리로 불러옴
    private void OnMouseUp()
    {
        ui_On = true;
        var ui = GameObject.FindGameObjectWithTag("TowerUI");
        ui.transform.position = transform.position;
        //var Canvas = GetComponent<Canvas>();
        ui.GetComponent<TowerUI>().setTower(gameObject);
        ui.transform.localScale = new Vector3(0.001f, 0.001f, 1);
        ui.transform.DOScale(0.004f, 0.7f);


    }
  


}
