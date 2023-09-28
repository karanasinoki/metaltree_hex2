using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MinerMane : MonoBehaviour
{
    
    
    public TileBase[] mines;

    public int[] myMinesCount;
    public int myIronCount;
    public int myLeadCount;
    public int myGoldCount;
    public int myRubyCount;
    public int mySapphireCount;
    public int[] minerPower;
    public int minerInterval;


    private bool isRunning=true;
    

    private void Start()
    {
        GameObject mineMap_ = GameObject.Find("MineMap");
        Tilemap mineMap = mineMap_.GetComponent<Tilemap>();

        GameObject objectMap_ = GameObject.Find("ObjectMap");
        Tilemap objectMap = objectMap_.GetComponent<Tilemap>();

        GameObject counter2_ = GameObject.Find("test");
        Counter2 counter2 = counter2_.GetComponent<Counter2>();

        Vector3 myWorldPos = transform.position;
        Vector3Int grid = objectMap.WorldToCell(myWorldPos);
        if (grid.y % 2 == 0)
        {
            Vector3Int[] hexPosAro = new Vector3Int[]
            {
                new Vector3Int(1,0,0)+new Vector3Int(grid.x,grid.y,0),
                new Vector3Int(0,1,0)+new Vector3Int(grid.x,grid.y,0),
                new Vector3Int(-1,1,0)+new Vector3Int(grid.x,grid.y,0),
                new Vector3Int(-1,0,0)+new Vector3Int(grid.x,grid.y,0),
                new Vector3Int(-1,-1,0)+new Vector3Int(grid.x,grid.y,0),
                new Vector3Int(0,-1,0)+new Vector3Int(grid.x,grid.y,0),

            };
            foreach (Vector3Int aroPos in hexPosAro)
            {
               
                if (JudgeTile(aroPos, mineMap, mines[0]))
                {
                    myMinesCount[0]++;
                    Debug.Log("0");
                }
                if (JudgeTile(aroPos, mineMap, mines[1]))
                {
                    myMinesCount[1]++;
                }
                if (JudgeTile(aroPos, mineMap, mines[2]))
                {
                    myMinesCount[2]++;
                }
                if (JudgeTile(aroPos, mineMap, mines[3]))
                {
                    myMinesCount[3]++;
                }
                if (JudgeTile(aroPos, mineMap, mines[4]))
                {
                    myMinesCount[4]++;
                    Debug.Log("1");
                }
            }
        }
        else
        {
            Vector3Int[] hexPosAro = new Vector3Int[]
            {
                new Vector3Int(1,0,0)+new Vector3Int(grid.x,grid.y,0),
                new Vector3Int(1,1,0)+new Vector3Int(grid.x,grid.y,0),
                new Vector3Int(0,1,0)+new Vector3Int(grid.x,grid.y,0),
                new Vector3Int(-1,0,0)+new Vector3Int(grid.x,grid.y,0),
                new Vector3Int(0,-1,0)+new Vector3Int(grid.x,grid.y,0),
                new Vector3Int(1,-1,0)+new Vector3Int(grid.x,grid.y,0),

            };


            foreach (Vector3Int aroPos in hexPosAro)
            {
                if (JudgeTile(aroPos, mineMap, mines[0]))
                {
                    myMinesCount[0]++;
                }
                if (JudgeTile(aroPos, mineMap, mines[1]))
                {
                    myMinesCount[1]++;
                }
                if (JudgeTile(aroPos, mineMap, mines[2]))
                {
                    myMinesCount[2]++;
                }
                if (JudgeTile(aroPos, mineMap, mines[3]))
                {
                    myMinesCount[3]++;
                }
                if (JudgeTile(aroPos, mineMap, mines[4]))
                {
                    myMinesCount[4]++;
                    Debug.Log("1");
                }
                
            }
        }
        StartCoroutine(IncreaseMines(counter2));
    }

    private int[] increase=new int [5];
    IEnumerator IncreaseMines(Counter2 counter2)
    {
        while (isRunning)
        {


            for (int i = 0; i < mines.Length; i++)
            {
               
                
                counter2.newScore[i] +=myMinesCount[i] * minerPower[i];
            }
            counter2.update++;
            yield return new WaitForSeconds(minerInterval);
        }
    }

    public bool JudgeTiles(Vector3Int position,Tilemap map,TileBase[] tiles)
    {
        bool a = false;
        foreach (TileBase pipe_a in tiles)
        {
           
            TileBase tile_a = map.GetTile(position);
            if (tile_a == pipe_a)
            {
                a = true;
                break;
            }
        }
        return a;
    }

    public bool JudgeTile(Vector3Int position, Tilemap map, TileBase tile)
    {
        bool a = false;
        TileBase tile_a = map.GetTile(position);
        if (tile_a == tile)
        {
            a = true;

        }
        return a;
    }
}
