using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class ObjectMane : MonoBehaviour
{
    private bool lightClick;
    private bool gunClick;
    private bool minerClick;
    private bool aroIsMine;

    public Tilemap treeMap;
    public Tilemap objectMap;
    public Tilemap pipeMap;
    public Tilemap mineMap;
    public Tilemap shadeMap;

    public TileBase[] pipeTiles;
    public TileBase[] mines;
    public TileBase tree;


    public GameObject gun;
    public GameObject miner;
    public new GameObject light;
   
    private Vector3Int grid;
    private Vector3Int grid_up;
    private Vector3Int grid_down;

    
    public Counter2 counter2;

    public int lightVision;

    public int[] minerCost;
    public int[] gunCost;
    public int[] lightCost;

    public void GunClick()
    {
        gunClick = true;
    }
    public void MinerClick()
    {
        minerClick = true;
    }
    public void LightClick()
    {
        lightClick = true;
    }

    private void Update()
    {
        GunMane();
        MinerMane();
        LightMane();
    }

    //centerÇ©ÇÁvisionLenthà»ì‡ÇÃshadeÇè¡Ç∑
    public void ClearShade(Vector3Int center, int visionLenth)
    {

        for (int k = -visionLenth + center.x; k <= visionLenth + center.x; k++)
        {

            for (int l = -visionLenth + center.y; l <= visionLenth + center.y; l++)
            {

                if (shadeMap.HasTile(new Vector3Int(k, l, 0)) && GetDistance(center, new Vector3Int(k, l, 0)) <= visionLenth)
                {

                    shadeMap.SetTile(new Vector3Int(k, l, 0), null);

                }
            }
        }
    }
    //A,Bä‘ÇÃãóó£ÇÇæÇ∑
    public int GetDistance(Vector3Int A, Vector3Int B)
    {

        if (Mathf.Abs((A.y % 2)) == Mathf.Abs((B.y % 2)))
        {
            if (Mathf.Abs(A.y - B.y) <= 2 * Mathf.Abs(A.x - B.x))
            {
                //Debug.Log("1");
                return (Mathf.Abs(A.y - B.y)) / 2 + Mathf.Abs(A.x - B.x); ;
            }
            else
            {
                //Debug.Log("2");
                return Mathf.Abs(A.y - B.y);

            }
        }
        else
        {
            if (A.x == B.x)
            {
                // Debug.Log("3");
                return Mathf.Abs(A.y - B.y);
            }
            else if (A.x >= B.x)
            {
                if (A.y % 2 == 0)
                {
                    if ((Mathf.Abs(A.y - B.y) + 1) <= 2 * (Mathf.Abs(A.x - B.x)))
                    {
                        //Debug.Log("4");
                        return (Mathf.Abs(A.y - B.y) + Mathf.Abs(A.x - B.x) - (Mathf.Abs(A.y - B.y) + 1) / 2);
                    }
                    else
                    {
                        // Debug.Log("5");
                        return Mathf.Abs(A.y - B.y);
                    }
                }
                else
                {
                    if ((Mathf.Abs(A.y - B.y) - 1) <= 2 * (Mathf.Abs(A.x - B.x)))
                    {
                        //Debug.Log("6");
                        return (Mathf.Abs(A.y - B.y) + Mathf.Abs(A.x - B.x) - (Mathf.Abs(A.y - B.y) - 1) / 2);
                    }
                    else
                    {
                        //Debug.Log("7");
                        return Mathf.Abs(A.y - B.y);
                    }
                }
            }
            else
            {
                if (B.y % 2 == 0)
                {
                    if ((Mathf.Abs(A.y - B.y) + 1) <= 2 * (Mathf.Abs(A.x - B.x)))
                    {
                        // Debug.Log("8");
                        return (Mathf.Abs(A.y - B.y) + Mathf.Abs(A.x - B.x) - (Mathf.Abs(A.y - B.y) + 1) / 2);
                    }
                    else
                    {
                        //Debug.Log("9");
                        return Mathf.Abs(A.y - B.y);
                    }
                }
                else
                {
                    if ((Mathf.Abs(A.y - B.y) - 1) <= 2 * (Mathf.Abs(A.x - B.x)))
                    {
                        //  Debug.Log("10");
                        return (Mathf.Abs(A.y - B.y) + Mathf.Abs(A.x - B.x) - (Mathf.Abs(A.y - B.y) - 1) / 2);
                    }
                    else
                    {
                        // Debug.Log("11");
                        return Mathf.Abs(A.y - B.y);
                    }
                }
            }
        }

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

    //ïKóvÇ»éëåπÇ™ë´ÇËÇƒÇ¢ÇΩÇÁtrueÇï‘Ç∑ä÷êî
    public bool JudgeResources(int[] arrayA)
    {
        
        for (int i = 0; i < arrayA.Length; i++)
        {
            if(arrayA[i]<=counter2.newScore[i])
            {

            }
            else
            {
                return false;
            }
        }
        return true;
    }

    //éëåπÇè¡îÔÇ∑ÇÈä÷êî
    public void UseResources(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            counter2.newScore[i] -= array[i];
            
        }
        
    }

    
    private void GunMane()
    {
        if (gunClick&&JudgeResources(gunCost))
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
                    UseResources(gunCost);
                }
            }

        }
    }

    private void MinerMane()
    {
        if (minerClick && JudgeResources(minerCost))
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
                        UseResources(minerCost);
                        minerClick = false;
                        
                       
                            
                       
                       



                    }
                }

            }
        }
    }

    private void LightMane()
    {
        if (lightClick&&JudgeResources(lightCost))
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(
                       Input.mousePosition);
                Vector3Int grid_pr = treeMap.WorldToCell(mousePos);
                grid = new Vector3Int(grid_pr.x, grid_pr.y, 0);
               
                if (pipeMap.HasTile(grid))
                {
                    Vector3 worldPos = objectMap.GetCellCenterWorld(grid);
                    Instantiate(light, worldPos, Quaternion.identity);
                    ClearShade(grid, lightVision);
                    lightClick = false;
                    Debug.Log("a");
                    UseResources(lightCost);
                    Debug.Log("1");
                }
            }

        }
    }
}

