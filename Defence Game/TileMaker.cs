using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMaker : MonoBehaviour
{   

    void Start()
    {   // 가로가 1부터 8 까지, 세로가 1부터 18까지;
        GameObject gameTile = Resources.Load("TileObject", typeof(GameObject)) as GameObject;

        //첫줄
        float y = 7.36f;
        makeTile(gameTile, "rpgTile000", new Vector3(0.32f, y, 0));
        
        for(int i = 1; i < 19; i++)
        {
            makeTile(gameTile, "rpgTile001", new Vector3(0.32f + (float)i * 0.64f, y, 0));
            
        }
        makeTile(gameTile, "rpgTile002", new Vector3(0.32f + 19.0f * 0.64f, y, 0));

        //가운데줄
        for(int i = 1; i < 11; i++)
        {
            y = 7.36f - (float)i * 0.64f;
            makeTile(gameTile, "rpgTile018", new Vector3(0.32f, y, 0));
            for (int j = 1; j < 19; j++)
            {
                makeTile(gameTile, "rpgTile019", new Vector3(0.32f + (float)j * 0.64f, y, 0));
            }
            makeTile(gameTile, "rpgTile020", new Vector3(0.32f + 19.0f * 0.64f, y, 0));
        }
        //마지막줄
        makeTile(gameTile, "rpgTile036", new Vector3(0.32f, 0.33f, 0));
        for (int i = 1; i < 19; i++)
        {
            makeTile(gameTile, "rpgTile037", new Vector3(0.32f + (float)i * 0.64f, 0.33f, 0));
        }
        makeTile(gameTile, "rpgTile038", new Vector3(12.48f, 0.33f, 0));

    }

    void makeTile(GameObject gameTile, string fileName, Vector3 position)
    {
        GameObject instance = Instantiate(gameTile) as GameObject;
        SpriteRenderer pRenderer = instance.AddComponent<SpriteRenderer>();
        Sprite tile = Resources.Load(fileName, typeof(Sprite)) as Sprite;
        pRenderer.sprite = tile;
        instance.transform.position = position;
    }

    void Update()
    {
       
    }

}
