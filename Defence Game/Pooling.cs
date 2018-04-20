using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooling : MonoBehaviour
{

    //총알을 가지고 있을 자료구조
    private Queue<GameObject> queueBullet = new Queue<GameObject>();
    private Queue<GameObject> BreathePool = new Queue<GameObject>();

    public GameObject lamp = null;
    public GameObject Breathes = null;
    // Use this for initialization
    void Start()
    {
        //레퍼런스 변수 만 가능한 var 

        if (lamp != null)
        {
            for (int i = 0; i < 10; i++)
            {
                //생성 변수
                var makedLamp = Instantiate(lamp, transform);
                //처음에는 비활성화 시켜서 비용에 영향을 미치지 않게함
                makedLamp.gameObject.SetActive(false);
                //큐에 하나 들어감
                queueBullet.Enqueue(makedLamp);
            }
        }
        if(Breathes != null)
        {
            for (int i = 0; i < 10; i++)
            {
                var fireballs = Instantiate(Breathes, transform);
                fireballs.gameObject.SetActive(false);
                BreathePool.Enqueue(fireballs);

            }
        }
    }

    public GameObject getLamp()
    {
        //하나를 꺼내서 액티브 시키고 큐의 제일 위로 보내서 사용하게끔 한다.
        var Lamp = queueBullet.Dequeue();
        Lamp.gameObject.SetActive(true);
        queueBullet.Enqueue(Lamp);
        return Lamp;
    }
    public GameObject getBreathes()
    {
        //하나를 꺼내서 액티브 시키고 큐의 제일 위로 보내서 사용하게끔 한다.
        var Breathe = BreathePool.Dequeue();
        Breathe.gameObject.SetActive(true);
        BreathePool.Enqueue(Breathe);
        return Breathe;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
