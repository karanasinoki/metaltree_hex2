using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Linq;

public class TreeGene : MonoBehaviour
{
    public Tilemap treeMap;
    public TileBase tree;

    public float growInterval;
    public float branchInterval;
    public int branchLenth;
    public int growMax;
    public int treeRadi;
    public int upProbability;
    public Vector3Int grid1;

    public int[] treeMount;

    //private bool branchClick = false;
    //private bool J;
    //private bool onTrees = false;
    //private bool canRight = false;
    //private bool canLeft = false;
    // private bool oneTime = true;


   // private float branchTimer = 0.0f;
    private float timer = 0.0f;

    private void Start()
    {
        //èâä˙îzíu
        for (int a = 1; a <= 3; a++)
        {
            for (int b = -treeRadi; b <= treeRadi; b++)
            {
                treeMap.SetTile(new Vector3Int(a, b, 0), tree);
            }
        }
    }

    private void Update()
    {
        //BranchGene();
        // branchTimer += Time.deltaTime;
        timer += Time.deltaTime;
        if (timer >= growInterval)
        {
            for (int i = 0; i <= growMax; i++)
            {

                int rand_treeRadi = Random.Range(-treeRadi, treeRadi + 1);
                if (treeMount[rand_treeRadi + treeRadi] <= treeMount.Min() + 2)
                {
                    treeMount[rand_treeRadi + treeRadi] += 1;
                    int j = treeMount[rand_treeRadi + treeRadi] + 2;
                    treeMap.SetTile(new Vector3Int(j, rand_treeRadi), tree);
                    break;
                }

            }
            timer = 0.0f;
        }
        //Vector3Int grid3 = BranchGene();
        //Debug.Log("5");

        //Debug.Log("6");
        //GrowBranch(grid3);

    }
}
//    public void GrowBranch(Vector3Int grid1)
//    {
//        Debug.Log("4");
//        //oneTime = false;
       


//            if (branchTimer >= branchInterval)
//            {
//                branchTimer = 0;


//                if (canRight)
//                {

//                    int R = Random.Range(1, 101);
//                    if (grid1.y % 2 == 0)
//                    {
                        
//                        if (R >= upProbability)
//                        {
//                            grid1.y++;
//                            treeMap.SetTile(grid1, tree);


//                        }
//                        else
//                        {
//                            grid1.x--;
//                            grid1.y++;
//                            treeMap.SetTile(grid1, tree);


//                        }

//                    }
//                    else
//                    {
//                        if (R >= upProbability)
//                        {
//                            grid1.x++;
//                            grid1.y++;
//                            treeMap.SetTile(grid1, tree);


//                        }
//                        else
//                        {
//                            grid1.y++;
//                            treeMap.SetTile(grid1, tree);


//                        }
//                    }

//                }
//            }



//            if (branchTimer >= branchInterval)
//            {
//                branchTimer = 0;

//                if (canLeft)
//                {
                    
//                    int R = Random.Range(1, 101);
//                    if (grid1.y % 2 == 0)
//                    {

//                        if (R >= upProbability)
//                        {
//                            grid1.y--;
//                            treeMap.SetTile(grid1, tree);

//                        }
//                        else
//                        {
//                            grid1.x--;
//                            grid1.y--;
//                            treeMap.SetTile(grid1, tree);

//                        }
//                    }
//                    else
//                    {
//                        if (R >= upProbability)
//                        {
//                            grid1.x++;
//                            grid1.y--;
//                            treeMap.SetTile(grid1, tree);

//                        }
//                        else
//                        {
//                            grid1.y--;
//                            treeMap.SetTile(grid1, tree);

//                        }
//                    }

//                }
//            }

        
//    }

//    public void CreateBranch()
//    {
//        branchClick = true;
//    }
//    public Vector3Int BranchGene()
//    {
        
//        if (branchClick)
//        {
            
//            if (Input.GetMouseButtonDown(0))
//            {
//                Debug.Log("3");
//                Vector3 mousePos = Camera.main.ScreenToWorldPoint(
//                    Input.mousePosition);
//                Vector3Int grid_pr = treeMap.WorldToCell(mousePos);
//                Vector3Int grid = new Vector3Int(grid_pr.x, grid_pr.y, 0);
                
//                if(grid.y%2==0)
//                {
//                    if(  JudgeTiles(new Vector3Int(grid.x, grid.y - 1, 0), treeMap, new TileBase[] { tree })&
//                         JudgeTiles(new Vector3Int(grid.x-1, grid.y - 1, 0), treeMap, new TileBase[] { tree })
//                          )
//                    {
//                        onTrees = true; 
//                    }
//                    if (JudgeTiles(new Vector3Int(grid.x, grid.y + 1, 0), treeMap, new TileBase[] { tree }) &
//                         JudgeTiles(new Vector3Int(grid.x - 1, grid.y + 1, 0), treeMap, new TileBase[] { tree })
//                          )
//                    {
//                        onTrees = true; 
//                    }
                    

//                }
//                else
//                {
//                    if (JudgeTiles(new Vector3Int(grid.x-1, grid.y - 1, 0), treeMap, new TileBase[] { tree }) &
//                         JudgeTiles(new Vector3Int(grid.x , grid.y - 1, 0), treeMap, new TileBase[] { tree })
//                          )
//                    {
//                        onTrees = true; 
//                    }
//                    if (JudgeTiles(new Vector3Int(grid.x - 1, grid.y + 1, 0), treeMap, new TileBase[] { tree }) &
//                        JudgeTiles(new Vector3Int(grid.x, grid.y + 1, 0), treeMap, new TileBase[] { tree })
//                         )
//                    {
//                        onTrees = true; 
//                    }
                   

//                }
//                if (onTrees)
//                {
//                    treeMap.SetTile(grid, tree);
                    


//                    if (grid.y == treeRadi + 1)
//                    {
//                        canRight = true; return grid;




//                    }
//                    else if (grid.y == -treeRadi - 1 & onTrees)
//                    {
//                        canLeft = true; return grid;


//                    }
//                    return grid;
//                }
//                return grid;
//            }
//            return new Vector3Int(0, 0, 0);
            
//        }
//        return new Vector3Int(0, 0, 0);
//    }
//    public bool JudgeTiles(Vector3Int position, Tilemap map, TileBase[] tiles)
//    {
//        foreach (TileBase pipe_a in tiles)
//        {
//            J = false;
//            TileBase tile_a = map.GetTile(position);
//            if (tile_a == pipe_a)
//            {
//                J = true;
//                break;
//            }
//        }
//        return J;
//    }
    
//}
