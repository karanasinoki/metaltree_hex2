using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class MineGene : MonoBehaviour
{
    public Tilemap mineMap;
    public Tilemap pipeMap;

    public TileBase gold;

    public Vector3Int leftUpPos;
    public int rightMax;
    public int downMax;
    public int boxHeight;
    public int boxWidth;

    private void Start()
    {
        for(int x=leftUpPos.x;x>=downMax;x-=boxHeight)
        {
            for (int y= leftUpPos.y; y <= rightMax; y += boxWidth)
            {
                int tilePosNum = Random.Range(1, boxHeight * boxWidth + 1);
                int x_Offset = tilePosNum / boxWidth;
                int y_Offset = tilePosNum % boxWidth;
                mineMap.SetTile(new Vector3Int(x - x_Offset, y + y_Offset - 1, 0), gold);
            }
        }
        //HexPipeline2 hexPipeline2;
        //GameObject obj = GameObject.Find("test");
        //hexPipeline2 = obj.GetComponent<HexPipeline2>();
        //Vector3Int corePos = hexPipeline2.startCorePos;
        //if(mineMap.HasTile(corePos))
        //{
            
        //    Debug.Log("‚ ‚é");
        //}
        //else
        //{
        //    Debug.Log("‚È‚¢");
        //}

    }
}
