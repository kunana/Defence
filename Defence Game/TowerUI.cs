using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TowerUI : MonoBehaviour
{

    private GameObject tower = null;
    public Text Timer;
    public float ftime = 0;
    private int times = 5;

    private bool a = true;
    // Use this for initialization
    void Start()
    {

        var Timer = this.GetComponent<TowerUI>().GetComponentInChildren<Text>().text;
    }

    // Update is called once per frame
    void Update()
    {
        ftime += Time.deltaTime;
        var ui = GameObject.FindGameObjectWithTag("Tower").GetComponent<Tower>().ui_On;
        if (ui == true && a)
        {
            times = 5;
            a = false;
            StartCoroutine(UIDelay());
        }
    }
    //어느 타워를 선택 하였는지 알려주기 위함.
    public void setTower(GameObject t)
    {
        tower = t;
    }

    IEnumerator UIDelay()
    {
        var ui = GameObject.FindGameObjectWithTag("TowerUI");
        for (int i = 0; i < 6; i++)
        {
            yield return new WaitForSeconds(1);
            Timer.text = times.ToString();
            times--;
        }
        a = true;
        GameObject.FindGameObjectWithTag("Tower").GetComponent<Tower>().ui_On = false;
        times = 5;
        ui.transform.position = new Vector3(-100, 0, 0);
        yield return null;
    }
}
