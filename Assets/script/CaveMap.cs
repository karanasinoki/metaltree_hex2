using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CaveMap : MonoBehaviour
{
    public Tilemap stageMap;
    public TileBase[] darts = new TileBase[24];
    public int leftMax;
    public int rightMax;
    public int depth;

    private void Start()
    {
        for(int x=leftMax;x<=rightMax;x++)
        {
            for(int y=0;y>=depth;y--)
            {
                int dartNum = Random.Range(0, 25);
                stageMap.SetTile(new Vector3Int(x, y, 0), darts[dartNum]);
            }
        }
    }
}
