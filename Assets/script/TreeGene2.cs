using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Linq;

public class TreeGene2 : MonoBehaviour
{
    public Tilemap treeMap;
    public TileBase tree;


    public float growInterval;
    public float branchInterval;
    public int branchLenth;
    public int growMax;
    public int treeRadi;
    public int upProbability;
    public Vector3Int grid;

    public int[] treeMount;

    public bool branchClick = false;
    private bool J;
    private bool onTrees = false;
    private bool canRight = false;
    private bool canLeft = false;

    private bool isBranchClick=false;
    private bool onCreateBranch=false;

    public void BranchClich()
    {
        isBranchClick = true;
        branchClick = true;
        if (!onCreateBranch)
        {
            StartCoroutine(CreateBranch());
            onCreateBranch = true;
        }
        else
        {
            Debug.Log("まだ作ってる");
        }
        
    }
   
  

    private Vector3Int value;
    private void Start()
    {
        InitialTree();
        StartCoroutine(CreateTree());
      
        

    }
    private void InitialTree()
    {
        for (int a = 1; a <= 2; a++)
        {
            for (int b = -treeRadi; b <= treeRadi; b++)
            {
                treeMap.SetTile(new Vector3Int(a, b, 0), tree);
            }
        }
    }
    private IEnumerator CreateTree()
    {
        
        for (int i = 0; i <= growMax; i++)
        {
           
            int rand_treeRadi = Random.Range(-treeRadi, treeRadi + 1);
            if (treeMount[rand_treeRadi + treeRadi] <= treeMount.Min() + 2)
            {
                yield return new WaitForSeconds(growInterval);
                treeMount[rand_treeRadi + treeRadi] += 1;
                int j = treeMount[rand_treeRadi + treeRadi] + 2;
                treeMap.SetTile(new Vector3Int(j, rand_treeRadi), tree);
               
            }

        }
    }
    
    private void Update()
    {
       
        
    }

    //上下nmberマスにタイルがないときtrueを返す
    private bool VerticalJudge(int number,Tilemap tilemap,Vector3Int vector3Int)
    {
        for(int i=1;i<=number;i++)
        {
            if(tilemap.HasTile(new Vector3Int(vector3Int.x+i,vector3Int.y,vector3Int.z)))
            {
                return false;
            }
            else
            {
               
            }
        }
        for (int i = -1; i >= -number; i--)
        {
            if (tilemap.HasTile(new Vector3Int(vector3Int.x + i, vector3Int.y, vector3Int.z)))
            {
                return false;
            }
            else
            {

            }
        }
        Debug.Log("true");
        return true;

    }

    private IEnumerator CreateBranch()
    {
        
       
            
            
           
        if (!canRight && !canLeft)
        {
            yield return new WaitUntil(() => isBranchClick);
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            if (Input.GetMouseButtonDown(0))
            {
                    
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(
                    Input.mousePosition);
                Vector3Int grid_pr = treeMap.WorldToCell(mousePos);
                grid = new Vector3Int(grid_pr.x, grid_pr.y, 0);
                Debug.Log(grid);
                if(VerticalJudge(3,treeMap,grid))
                {
                    if (grid.y % 2 == 0)
                    {
                        if (JudgeTiles(new Vector3Int(grid.x, grid.y - 1, 0), treeMap, new TileBase[] { tree }) &
                                JudgeTiles(new Vector3Int(grid.x - 1, grid.y - 1, 0), treeMap, new TileBase[] { tree })
                                )
                        {
                            onTrees = true;
                        }
                        if (JudgeTiles(new Vector3Int(grid.x, grid.y + 1, 0), treeMap, new TileBase[] { tree }) &
                                JudgeTiles(new Vector3Int(grid.x - 1, grid.y + 1, 0), treeMap, new TileBase[] { tree })
                                )
                        {
                            onTrees = true;
                        }


                    }
                    else
                    {
                        if (JudgeTiles(new Vector3Int(grid.x - 1, grid.y - 1, 0), treeMap, new TileBase[] { tree }) &
                                JudgeTiles(new Vector3Int(grid.x, grid.y - 1, 0), treeMap, new TileBase[] { tree })
                                )
                        {
                            onTrees = true;
                        }
                        if (JudgeTiles(new Vector3Int(grid.x - 1, grid.y + 1, 0), treeMap, new TileBase[] { tree }) &
                            JudgeTiles(new Vector3Int(grid.x, grid.y + 1, 0), treeMap, new TileBase[] { tree })
                                )
                        {
                            onTrees = true;
                        }


                    }
                }
                
                if (onTrees && branchClick)
                {
                    Debug.Log("dd");
                    treeMap.SetTile(grid, tree);
                    branchClick = false;

                        
                    if (grid.y == treeRadi + 1)
                    {
                        canRight = true;
                    }
                    else if (grid.y == -treeRadi - 1)
                    {
                        canLeft = true;
                    }

                }
            }
        }
           


                


                
        if (canRight || canLeft)
        {
            yield return null;
            Debug.Log("a");
                    
        }
        for (int f = 0; f < branchLenth; f++)
        {
                    
            yield return new WaitForSeconds(branchInterval);
            if (canRight)
            {

                Debug.Log(grid);
                int R = Random.Range(1, 101);
                if (grid.y % 2 == 0)
                {

                    if (R >= upProbability)
                    {
                        grid.y++;
                        treeMap.SetTile(grid, tree);


                    }
                    else
                    {
                        grid.x--;
                        grid.y++;
                        treeMap.SetTile(grid, tree);


                    }

                }
                else
                {
                    if (R >= upProbability)
                    {
                        grid.x++;
                        grid.y++;
                        treeMap.SetTile(grid, tree);


                    }
                    else
                    {
                        grid.y++;
                        treeMap.SetTile(grid, tree);


                    }
                }

            }
            if (canLeft)
            {

                int R = Random.Range(1, 101);
                if (grid.y % 2 == 0)
                {

                    if (R >= upProbability)
                    {
                        grid.y--;
                        treeMap.SetTile(grid, tree);

                    }
                    else
                    {
                        grid.x--;
                        grid.y--;
                        treeMap.SetTile(grid, tree);

                    }
                }
                else
                {
                    if (R >= upProbability)
                    {
                        grid.x++;
                        grid.y--;
                        treeMap.SetTile(grid, tree);

                    }
                    else
                    {
                        grid.y--;
                        treeMap.SetTile(grid, tree);

                    }
                }

            }
        }
        canLeft = false;
        canRight = false;
        onTrees = false;
        onCreateBranch = false;
        
    }
    

    public bool JudgeTiles(Vector3Int position, Tilemap map, TileBase[] tiles)
    {
        foreach (TileBase pipe_a in tiles)
        {
            J = false;
            TileBase tile_a = map.GetTile(position);
            if (tile_a == pipe_a)
            {
                J = true;
                break;
            }
        }
        return J;
    }
   
}
