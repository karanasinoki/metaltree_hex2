using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameMane : MonoBehaviour
{
    public ClickDetection clickDetection;
    public HexPipeline2 hexPipeline2;
    public TileBase[] pipeTiles;
    public TileBase[] mines;
    public Tilemap pipeMap;
    public Tilemap systemMap;
    public TileBase miner;
    private bool a;
    public Tilemap mineMap;
    public bool aroIsMine=false;

    
    void Update()
    {
        
            // ゲームオブジェクトがクリックされた場合の処理をここに追加
            
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("クリックされました！");
                if (clickDetection.isClicked)
                {
                    Vector3 mousePos = Camera.main.ScreenToWorldPoint(
                        Input.mousePosition);
                    Vector3Int grid_pr = pipeMap.WorldToCell(mousePos);
                    Vector3Int grid = new Vector3Int(grid_pr.x, grid_pr.y, 0);
                    if (JudgeTiles(grid, pipeMap, pipeTiles))
                    {
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
                                if (JudgeTiles(aroPos, mineMap, mines))
                                {
                                    aroIsMine = true;
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
                                if (JudgeTiles(aroPos, mineMap, mines))
                                {
                                    aroIsMine = true;
                                }
                            }
                        }
                        if(aroIsMine)
                        {
                            systemMap.SetTile(grid, miner);
                        }
                    }
  
                }
            // クリックの状態をリセット
                clickDetection.isClicked = false;
                aroIsMine = false;
            }
    }

    public bool JudgeTiles(Vector3Int position,Tilemap map,TileBase[] tiles)
    {
        foreach (TileBase pipe_a in tiles)
        {
            a = false;
            TileBase tile_a = map.GetTile(position);
            if (tile_a == pipe_a)
            {
                a = true;
                break;
            }
        }
        return a;
    }
}
