using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TreeGene : MonoBehaviour
{
    
    public float waitTime = 2.0f;
    public int treeWidth = 20;
    public int attempts = 30;
    public Tilemap mapTree;
    public TileBase tree;
    public int treeTop = 25;

    private IEnumerator Start()
    {
        for(int i=0; i<attempts;i++)
        {
            
            int rand_width = Random.Range(-10, 10);
            yield return new WaitForSeconds(waitTime);
            
            for(i=0;i<100;i++)
            {
                
                if(mapTree.HasTile(new Vector3Int(rand_width,treeTop,0)))
                {
                    treeTop++;
                }
                else
                {
                    mapTree.SetTile(new Vector3Int(rand_width, treeTop, 0), tree);
                    break;
                }
                
            }
            treeTop = 25;
            
        }
    }
    private void Update()
    {
        
    }
}
