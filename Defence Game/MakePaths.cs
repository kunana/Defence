using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Json;
using UnityEngine.UI;
using DG.Tweening;

public class MakePaths : MonoBehaviour {

    private bool bRbuttonDown = false;
    private Vector2 preMousePos = Vector2.zero;
    public class MovePath
    {   
        //길을 만들기위한 클래스 x,y 좌표 생성
        public int x = 0;
        public int y = 0;
        public MovePath(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    public List<MovePath> movePath = new List<MovePath>(); // 경로만들기 리스트 생성
    public int[,] data = new int[21, 13];       // 데이터를 저장할 2차원 배열
    
    void Start () {

        /*mapMaker();*/
       
        LoadJson();
        tileDeco();
        print("끝");
       
    }

	void Update ()
    {   
        //버튼을 눌렀을때 버튼다운 트리거를 켜고 위치를 기록한다.
        if (Input.GetMouseButtonDown(1)) 
        {   
            bRbuttonDown = true;
            preMousePos = Input.mousePosition;

        }
        if (Input.GetMouseButtonUp(1))
        {
            bRbuttonDown = false;
        }
        if (bRbuttonDown == true)
        {
            Vector2 nowMouseMove =
                Input.mousePosition;
            Vector2 move = nowMouseMove - preMousePos;
            move /= 100.0f;
            preMousePos = nowMouseMove;
            transform.Translate(move);
        }
        if(Input.GetMouseButtonDown(2))
        {

            var DamageUI = GameObject.FindGameObjectWithTag("DamageUI");
            if (DamageUI != null)
            {
                Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                pos.z = 0;
                DamageUI.transform.position = pos;
                DamageUI.GetComponent<DamageUI>().MyActive = true;
                float randX = Random.Range(0, 2.0f);
                var rig = DamageUI.GetComponent<Rigidbody2D>();
                rig.AddForce(new Vector2(randX, 1.0f) * 10.0f);

                var text = DamageUI.GetComponentInChildren<Text>();
                text.color = Color.blue;
                text.DOFade(0, 1.0f);

            }
        }

    }

    public void MakeTile(MovePath path, string filename, int order = 1)
    {   
       
        GameObject gameTile = Resources.Load("TileObject", typeof(GameObject)) as GameObject;
        GameObject instance = Instantiate(gameTile) as GameObject;
        SpriteRenderer pRenderer = instance.AddComponent<SpriteRenderer>();

        Sprite tile = Resources.Load(filename, typeof(Sprite)) as Sprite;
        pRenderer.sprite = tile;
        pRenderer.sortingOrder = order;

        Vector3 pos = new Vector3(path.x * 0.64f + 0.32f, path.y * 0.64f + 0.32f, 0);
        instance.transform.position = pos;
        

    }

    public void tileDeco()
    {
        foreach (MovePath path in movePath)  // 무브패스에 있는 가상의 길만큼.
        {
           
            //위아래
            if (data[path.x, path.y + 1] == 1 || data[path.x, path.y - 1] == 1)
                
            {
                MovePath LeftPath = new MovePath(path.x - 1, path.y);
                MovePath RightPath = new MovePath(path.x + 1, path.y);
                MakeTile(LeftPath, "rpgTile020", 2);
                MakeTile(RightPath, "rpgTile018" ,2);
                if (path.y == 11)
                {
                    MovePath TopLeftPath = new MovePath(path.x - 1, path.y);
                    MovePath TopRightPath = new MovePath(path.x + 1, path.y);
                    
                    MakeTile(TopLeftPath, "rpgTile002", 4);
                    MakeTile(TopRightPath, "rpgTile000" ,4);
                    
                }
                if (path.y == 0 )
                {
                    MovePath DownLeftPath = new MovePath(path.x - 1, path.y);
                    MovePath DownRightPath = new MovePath(path.x + 1, path.y);
                    MakeTile(DownLeftPath, "rpgTile038" ,4);
                    MakeTile(DownRightPath, "rpgTile036" ,4);
                }
               
            }
            //좌우
            if (data[path.x + 1, path.y] == 1 || data[path.x - 1, path.y] == 1)
            {
                MovePath UpPath = new MovePath(path.x, path.y + 1);
                MovePath DownPath = new MovePath(path.x, path.y - 1);
                MakeTile(UpPath, "rpgTile037" ,2);
                MakeTile(DownPath, "rpgTile001" ,2);
                if (path.x == 0)
                {
                    MovePath StarUpPath = new MovePath(path.x, path.y + 1);
                    MovePath StartDownPath = new MovePath(path.x, path.y - 1);
                    MakeTile(StarUpPath, "rpgTile036",4);
                    MakeTile(StartDownPath, "rpgTile000",4);
                }
                if (path.x == 19)
                {
                    MovePath EndUpPath = new MovePath(path.x, path.y + 1);
                    MovePath EndDownPath = new MovePath(path.x , path.y - 1);
                    MakeTile(EndUpPath, "rpgTile038" ,4);
                    MakeTile(EndDownPath, "rpgTile002",4);
                }
                
            }
         
            // ┘ 모양일때
            if (data[path.x, path.y+1] == 1 && data[path.x-1 ,path.y] == 1 && data[path.x + 1, path.y] == 0 && data[path.x, path.y - 1] == 0)
            { 
                
                    MovePath LeftupPath = new MovePath(path.x - 1, path.y + 1);
                    MovePath upPath = new MovePath(path.x , path.y + 1);
                    MovePath leftPath = new MovePath(path.x - 1, path.y);
                    MovePath RightDownPath = new MovePath(path.x +1, path.y -1);

                    MakeTile(LeftupPath, "rpgTile038", 3);
                    MakeTile(upPath, "rpgTile024", 3);
                    MakeTile(leftPath, "rpgTile024", 3);
                    MakeTile(RightDownPath, "rpgTile022", 3);
            }
             //┐ 모양일때
            if (data[path.x, path.y + 1] == 0 && data[path.x + 1, path.y] == 0)
            {
                if (data[path.x - 1, path.y] == 1 && data[path.x, path.y - 1] == 1 )
                { 
                    MovePath LeftDownPath = new MovePath(path.x - 1, path.y - 1);
                    MovePath downPath = new MovePath(path.x, path.y - 1);
                    MovePath leftPath = new MovePath(path.x - 1, path.y);
                    MovePath RightUpPath = new MovePath(path.x + 1, path.y + 1);

                    MakeTile(LeftDownPath, "rpgTile002", 3);
                    MakeTile(downPath, "rpgTile024", 3);
                    MakeTile(leftPath, "rpgTile024", 3);
                    MakeTile(RightUpPath, "rpgTile004", 3);
                }
            }

            //┌ 모양일때
            if (data[path.x + 1, path.y] == 1 && data[path.x, path.y -1] == 1)
            {
                if (data[path.x, path.y + 1] == 0 && data[path.x -1, path.y ] == 0)
                {
                    MovePath RightDownPath = new MovePath(path.x + 1, path.y - 1);
                    MovePath downPath = new MovePath(path.x, path.y - 1);
                    MovePath RightPath = new MovePath(path.x + 1, path.y);
                    MovePath leftUpPath = new MovePath(path.x - 1, path.y + 1);
                    
                    MakeTile(RightDownPath, "rpgTile000", 3);
                    MakeTile(leftUpPath, "rpgTile003", 3);
                    MakeTile(downPath, "rpgTile024", 3);
                    MakeTile(RightPath, "rpgTile024", 3);

                }
            }

            //└ 모양일때
            if (data[path.x + 1, path.y] == 1 && data[path.x, path.y + 1] == 1)
            {
                if (data[path.x, path.y - 1] == 0 && data[path.x - 1, path.y] == 0)
                {
                    MovePath RightUpPath = new MovePath(path.x + 1, path.y + 1);
                    MovePath UpPath = new MovePath(path.x, path.y + 1);
                    MovePath RightPath = new MovePath(path.x + 1, path.y);
                    MovePath leftDownPath = new MovePath(path.x - 1, path.y - 1);

                    MakeTile(RightUpPath, "rpgTile036", 3);
                    MakeTile(UpPath, "rpgTile024", 3);
                    MakeTile(RightPath, "rpgTile024", 3);
                    MakeTile(leftDownPath, "rpgTile021", 3);

                }
            }
            // 십자교차로
            if (data[path.x + 1, path.y] == 1 && data[path.x, path.y + 1] == 1
                && data[path.x - 1, path.y] == 1 && data[path.x, path.y - 1] == 1
                && data[path.x + 1, path.y + 1] == 0 && data[path.x - 1, path.y - 1] == 0
                && data[path.x - 1, path.y + 1] == 0 && data[path.x + 1, path.y - 1] == 0)
            {

                MovePath RightPath = new MovePath(path.x + 1, path.y);
                MovePath UpPath = new MovePath(path.x, path.y + 1);
                MovePath DownPath = new MovePath(path.x, path.y - 1);
                MovePath leftPath = new MovePath(path.x - 1, path.y);

                MovePath RightUpPath = new MovePath(path.x + 1, path.y + 1);
                MovePath RightDownPath = new MovePath(path.x + 1, path.y - 1);
                MovePath leftUpPath = new MovePath(path.x - 1, path.y + 1);
                MovePath leftDownPath = new MovePath(path.x - 1, path.y - 1);

                MakeTile(RightPath, "rpgTile024", 3);
                MakeTile(UpPath, "rpgTile024", 3);
                MakeTile(DownPath, "rpgTile024", 3);
                MakeTile(leftPath, "rpgTile024", 3);
                MakeTile(RightUpPath, "rpgTile036", 3);
                MakeTile(RightDownPath, "rpgTile000", 3);
                MakeTile(leftUpPath, "rpgTile038", 3);
                MakeTile(leftDownPath, "rpgTile002", 3);
            }
            //// ㅜ 교차로
            //if(data[path.x + 1, path.y] == 1 && data[path.x, path.y - 1] == 1 &&
            //    data[path.x - 1, path.y] == 1 && data[path.x, path.y + 1] == 0
            //        && data[path.x, path.y - 2] == 1)
            //{
            //    MovePath RightPath = new MovePath(path.x + 1, path.y);
            //    MovePath LeftPath = new MovePath(path.x + 1, path.y);
            //    MovePath RightDownPath = new MovePath(path.x + 1, path.y);
            //    MovePath LeftDownPath = new MovePath(path.x + 1, path.y);

            //    MakeTile(RightPath, "rpgTile024", 3);
            //    MakeTile(LeftPath, "rpgTile024", 3);
            //    MakeTile(RightDownPath, "rpgTile000", 3);
            //    MakeTile(LeftDownPath, "rpgTile002", 3);

            //}

        }
    }
   
    public void mapMaker()
    {   //미사용 함수
        for (int i = 11; i > 9; i--) // 2.11 ~ 2. 10
        {
            movePath.Add(new MovePath(2, i));
            data[2, i] = 1;
        }
        for (int i = 2; i < 7; i++) // 2.9 ~  6.9
        {
            movePath.Add(new MovePath(i, 9));
            data[i, 9] = 1;
        }
        for (int i = 8; i > 2; i--) //6.8 ~ 6.2
        {
            movePath.Add(new MovePath(6, i));
            data[6, i] = 1;
        }
        for (int i = 6; i > 2; i--) // 6.2 ~ 3.2
        {
            movePath.Add(new MovePath(i, 2)); 
            data[i, 2] = 1;
        }
        for (int i = 2; i < 7; i++) // 2.2 ~ 2.6
        {
            movePath.Add(new MovePath(2, i));
            data[2, i] = 1;
        }
        for (int i = 3; i < 17; i++)  // 3.6 ~ 16. 6
        {
            movePath.Add(new MovePath(i, 6));
            data[i, 6] = 1;
        }
        for (int i = 5; i > 1; i--) //  16.5 ~ 16.2
        {
            movePath.Add(new MovePath(16, i));
            data[16, i] = 1;
        }
        for (int i = 15; i > 9; i--) // 15.2 ~ 10.2
        {
            movePath.Add(new MovePath(i, 2));
            data[i, 2] = 1;
        }
        for (int i = 2; i < 10; i++) // 9.2 ~ 9.9
        {
            movePath.Add(new MovePath(9, i));
            data[9, i] = 1;
        }
        for (int i = 10; i < 20; i++) // 10.9~ 10.19
        {
            movePath.Add(new MovePath(i, 9));
            data[i, 9] = 1;
        }
       
       

        
    }

    private void LoadJson()
    {
        string LoadPos = System.IO.File.ReadAllText("Assets/Resources/PathData.json");
        JsonTextParser textParser = new JsonTextParser();
        JsonObjectCollection root = textParser.Parse(LoadPos) as JsonObjectCollection;
        JsonArrayCollection array = root["path"] as JsonArrayCollection;
        foreach (JsonObjectCollection obj in array)
        {
            double x = (obj["X"] as JsonNumericValue).Value;
            double y = (obj["Y"] as JsonNumericValue).Value;
            movePath.Add(new MovePath((int)x / 64, 11 - (int)y / 64));
            data[(int)x / 64, 11 - (int)y / 64] = 1;
            foreach (MovePath path in movePath)  // 무브패스에 있는 가상의 길만큼.
            {
                MakeTile(path, "rpgTile024", 1);
            }
        }
    }

}
