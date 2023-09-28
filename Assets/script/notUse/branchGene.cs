using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class branchGene : MonoBehaviour
{
    public Tilemap mapTree;
    public TileBase tree;
    public float waitTime =1.0f;
    public int branchLenth;
    int upCount = 0;
    int rightCount = 0;
    public Vector3Int grid = new Vector3Int(12, 28, 0);
    //private IEnumerator Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        Debug.Log("a");
    //        Vector3 mousePos = Camera.main.ScreenToWorldPoint(
    //            Input.mousePosition);
    //        Vector3Int grid_pr = mapTree.WorldToCell(mousePos);
    //        Vector3Int grid = new Vector3Int(grid_pr.x, grid_pr.y, 0);
    //        for(int i=0;i<3;i++)
    //        {
    //            mapTree.SetTile(new Vector3Int(grid.x+i,grid.y,0), tree);
    //            yield return new WaitForSeconds(waitTime);
    //        }
    //        for (int j = 0; j <= branchLenth; j++) 
    //        {
    //            int rand10 = Random.Range(1, 11);
    //            if (rand10 % 3 == 0)
    //            {
    //                upCount++;
    //                mapTree.SetTile(new Vector3Int(grid.x + 2+rightCount, grid.y +upCount, 0), tree);
                    
    //            }
    //            else
    //            {
    //                rightCount++;
    //                mapTree.SetTile(new Vector3Int(grid.x + 2+rightCount, grid.y + upCount, 0), tree);
                    
    //            }
    //            yield return new WaitForSeconds(waitTime);
    //        }

           
    //    }
    //}
    private IEnumerator Start()
    {
        for (int i = 0; i < 3; i++)
        {
            mapTree.SetTile(new Vector3Int(grid.x + i, grid.y, 0), tree);
            yield return new WaitForSeconds(waitTime);
        }
        for (int j = 0; j <= branchLenth; j++)
        {
            int rand10 = Random.Range(1, 11);
            if (rand10 % 3 == 0)
            {
                upCount++;
                mapTree.SetTile(new Vector3Int(grid.x + 2 + rightCount, grid.y + upCount, 0), tree);

            }
            else
            {
                rightCount++;
                mapTree.SetTile(new Vector3Int(grid.x + 2 + rightCount, grid.y + upCount, 0), tree);

            }
            yield return new WaitForSeconds(waitTime);
        }
    }
}
