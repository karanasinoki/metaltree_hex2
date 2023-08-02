using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HexPipeline : MonoBehaviour
{
    public TileBase testtile;
    public Tilemap stageMap;
    public TileBase[] tiles = new TileBase[11];
    private bool a;
    int tileCount = 0;
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(
                Input.mousePosition);
            Vector3Int grid = stageMap.WorldToCell(mousePos);
            
           
            if (grid.y%2==0)
            {
                Vector3Int[] hexPoses1 = new Vector3Int[]
                {
                    new Vector3Int(1,0,0)+new Vector3Int(grid.x,grid.y,0),
                    new Vector3Int(0,1,0)+new Vector3Int(grid.x,grid.y,0),
                    new Vector3Int(-1,1,0)+new Vector3Int(grid.x,grid.y,0),
                    new Vector3Int(-1,0,0)+new Vector3Int(grid.x,grid.y,0),
                    new Vector3Int(-1,-1,0)+new Vector3Int(grid.x,grid.y,0),
                    new Vector3Int(0,-1,0)+new Vector3Int(grid.x,grid.y,0),
                };
                
                foreach(Vector3Int number in hexPoses1)
                {
                    if (CountTile(number))
                    {
                        tileCount++;
                    }
                    
                }
                Debug.Log(tileCount);
               
                tileCount = 0;
            }
            else
            {
                Vector3Int[] hexPoses2 = new Vector3Int[]
                {
                    new Vector3Int(1,0,0)+new Vector3Int(grid.x,grid.y,0),
                    new Vector3Int(1,1,0)+new Vector3Int(grid.x,grid.y,0),
                    new Vector3Int(0,1,0)+new Vector3Int(grid.x,grid.y,0),
                    new Vector3Int(-1,0,0)+new Vector3Int(grid.x,grid.y,0),
                    new Vector3Int(0,-1,0)+new Vector3Int(grid.x,grid.y,0),
                    new Vector3Int(1,-1,0)+new Vector3Int(grid.x,grid.y,0),
                };
                int tileCount = 0;
                foreach (Vector3Int number in hexPoses2)
                {
                    if (CountTile(number))
                    {
                        tileCount++;
                    }

                }
                Debug.Log(tileCount);
                tileCount = 0;

            }
        }
    }
    public bool CountTile(Vector3Int position)
    {
        foreach(TileBase pipe_a in tiles)
        {
             a = false;
            TileBase tile_a = stageMap.GetTile(position);
            if( tile_a ==pipe_a)
            {
                 a = true;
                break;
            }
        }
        return a;
    }
    public void MainComand()
    {

        if(tileCount==0)
        {
            stageMap.SetTile()
        }
    }
}
