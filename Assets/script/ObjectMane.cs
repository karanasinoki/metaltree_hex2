using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class ObjectMane : MonoBehaviour
{
    private bool branchClick;
    private bool gunClick;
    private bool minerClick;
    private bool aroIsMine;

    public Tilemap treeMap;
    public Tilemap objectMap;
    public Tilemap pipeMap;
    public Tilemap mineMap;

    public TileBase[] pipeTiles;
    public TileBase[] mines;
    public TileBase tree;


    public GameObject gun;
    public GameObject miner;

   
    public Vector3Int grid;
    private Vector3Int grid_up;
    private Vector3Int grid_down;
   

    

    
    public void GunClick()
    {
        gunClick = true;
    }
    public void MinerClick()
    {
        minerClick = true;
    }

    private void Update()
    {
        GunMane();
    }

    public bool JudgeTiles(Vector3Int position, Tilemap map, TileBase[] tiles)
    {
        bool a=false;
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


    private void GunMane()
    {
        if (gunClick)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(
                       Input.mousePosition);
                Vector3Int grid_pr = treeMap.WorldToCell(mousePos);
                grid = new Vector3Int(grid_pr.x, grid_pr.y, 0);
                grid_up = grid + new Vector3Int(1, 0, 0);
                grid_down = grid + new Vector3Int(-1, 0, 0);
                if (treeMap.HasTile(grid_up) || treeMap.HasTile(grid_down))
                {
                    Vector3 worldPos = objectMap.GetCellCenterWorld(grid);
                    Instantiate(gun, worldPos, Quaternion.identity);
                    gunClick = false;
                }
            }

        }
    }

    private void MinerMane()
    {
        if(minerClick)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(
                       Input.mousePosition);
                Vector3Int grid_pr = treeMap.WorldToCell(mousePos);
                grid = new Vector3Int(grid_pr.x, grid_pr.y, 0);
                grid_up = grid + new Vector3Int(1, 0, 0);
                grid_down = grid + new Vector3Int(-1, 0, 0);

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
                    if (aroIsMine)
                    {
                        Vector3 worldPos = objectMap.GetCellCenterWorld(grid);
                        Instantiate(miner, worldPos, Quaternion.identity);
                        minerClick = false;
                    }
                }

            }
        }
    }
}

