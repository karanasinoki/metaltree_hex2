using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGenerater : MonoBehaviour
{
    public TileBase[] dartTiles;
    public Tilemap stageMap;
    public int depth = -5;
    public int width = 6;
    public TileBase dart;
    public TileBase iron;
    public TileBase lead;
    public TileBase gold;
    public TileBase rubi; public TileBase safa; public TileBase topa;public TileBase ame;public TileBase dia;
   
    void Start()
    {
        for(int y=-width;y<width+1;y++)
        {
            for(int x=depth;x<0;x++)
            {
       
                stageMap.SetTile(new Vector3Int(x, y, 0), dart);
            }
        }
       
    }

   
}
