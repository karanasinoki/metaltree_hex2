using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class MineGene : MonoBehaviour
{
    public Tilemap mineMap;
    public Tilemap pipeMap;
    public Tilemap shadeMap;
    public TileBase[] mines;

    

    public int boxHeight;
    public int boxWidth;
    public int boxWidth_Sur=3;
    public int rightMax;
    public int leftMax;
    public int downMax; 
    public int goldTopPos;
    public int jewelTopPos;
    public int rareBoxHeight;
    public int rareBoxWidth;
   
   
    

    public Vector3Int a;
    public Vector3Int b;
    private void Start()
    {
        InitialResource();
        SurfaceMineGene();
        DeepMineGene_iron_lead();
        RareMinesGene();
    }

    public void MinesGene(TileBase mine, Vector3Int leftUp, int boxWidth)
    {
        for (int x = leftUp.x; x >= downMax; x -= boxHeight)
        {
            for (int y = leftUp.y; y <= rightMax; y += boxWidth)
            {
                int tilePosNum = Random.Range(1, boxHeight * boxWidth + 1);
                int x_Offset = tilePosNum / boxWidth;
                int y_Offset = tilePosNum % boxWidth;
                mineMap.SetTile(new Vector3Int(x - x_Offset, y + y_Offset - 1, 0), mine);
            }
        }
    }
    

    private void InitialResource()
    {
        //startCore‚æ‚è‰º‚©‚Â‹——£4‚ÌêŠ‚É“S‚Æ‰”‚ð‰Šú¶¬‚·‚é
        Vector3Int[] initialPos = { new Vector3Int(-1, 4, 0) , new Vector3Int(-2, 4, 0) , new Vector3Int(-3, 3, 0),new Vector3Int(-3,2,0),new Vector3Int(-4,1,0),
            new Vector3Int(-4,0,0),new Vector3Int(-4,-1,0),new Vector3Int(-3,-2,0),new Vector3Int(-3,-3,0),new Vector3Int(-2,-4,0),new Vector3Int(-1,-4,0)};
        int ironNumber = Random.Range(0, 11);
        int leadNumber = Random.Range(0,11);
        if(ironNumber==leadNumber||ironNumber+1==leadNumber||ironNumber-1==leadNumber)
        {
            while(ironNumber == leadNumber || ironNumber + 1 == leadNumber || ironNumber - 1 == leadNumber)
            {
                
                leadNumber = Random.Range(0, 11);
            }
            
        }
        mineMap.SetTile(initialPos[ironNumber], mines[0]);
        mineMap.SetTile(initialPos[leadNumber], mines[1]);
        
    }

    private void SurfaceMineGene()
    {
        //‚“x-5‚Ü‚Å‚ÌzÎ¶¬
        for (int y =6; y <= rightMax; y += boxWidth_Sur)
        {
            int tilePosNum_iron = Random.Range(1, 5 * boxWidth_Sur + 1);
            int tilePosNum_lead = Random.Range(1, 5 * boxWidth_Sur + 1);
            if (tilePosNum_iron == tilePosNum_lead)
            {
                while (tilePosNum_iron == tilePosNum_lead)
                {
                    tilePosNum_lead = Random.Range(1, 5 * boxWidth_Sur + 1);
                }
            }
            int x_Offset_iron = tilePosNum_iron / boxWidth_Sur;
            int y_Offset_iron = tilePosNum_iron % boxWidth_Sur;
            int x_Offset_lead = tilePosNum_lead / boxWidth_Sur;
            int y_Offset_lead = tilePosNum_lead % boxWidth_Sur;

            mineMap.SetTile(new Vector3Int( - x_Offset_iron, y + y_Offset_iron - 1, 0), mines[0]);
            mineMap.SetTile(new Vector3Int(-x_Offset_lead, y + y_Offset_lead - 1, 0), mines[1]);
        }
        for (int y = -6; y >= leftMax; y -= boxWidth_Sur)
        {
            int tilePosNum_iron = Random.Range(1, 5 * boxWidth_Sur + 1);
            int tilePosNum_lead = Random.Range(1, 5 * boxWidth_Sur + 1);
            if (tilePosNum_iron == tilePosNum_lead)
            {
                while (tilePosNum_iron == tilePosNum_lead)
                {
                    tilePosNum_lead = Random.Range(1, 5 * boxWidth_Sur + 1);
                }
            }
            int x_Offset_iron = tilePosNum_iron / boxWidth_Sur;
            int y_Offset_iron = tilePosNum_iron % boxWidth_Sur;
            int x_Offset_lead = tilePosNum_lead / boxWidth_Sur;
            int y_Offset_lead = tilePosNum_lead % boxWidth_Sur;

            mineMap.SetTile(new Vector3Int(-x_Offset_iron, y - y_Offset_iron - 1, 0), mines[0]);
            mineMap.SetTile(new Vector3Int(-x_Offset_lead, y - y_Offset_lead - 1, 0), mines[1]);
        }
    }

    private void DeepMineGene_iron_lead()
    {
        //‚“x-6‚æ‚è[‚¢zÎ‚Ì¶¬
        for(int x=-6;x>=downMax;x-=boxHeight)
        {
            for (int y = 0; y <= rightMax; y += boxWidth)
            {
                int tilePosNum_iron = Random.Range(1, boxHeight * boxWidth + 1);
                int tilePosNum_lead = Random.Range(1, boxHeight* boxWidth+ 1);
                if (tilePosNum_iron == tilePosNum_lead)
                {
                    while (tilePosNum_iron == tilePosNum_lead)
                    {
                        tilePosNum_lead = Random.Range(1, boxHeight* boxWidth + 1);
                    }
                }
                int x_Offset_iron = tilePosNum_iron / boxWidth;
                int y_Offset_iron = tilePosNum_iron % boxWidth;
                int x_Offset_lead = tilePosNum_lead / boxWidth;
                int y_Offset_lead = tilePosNum_lead % boxWidth;

                mineMap.SetTile(new Vector3Int(x-x_Offset_iron, y + y_Offset_iron - 1, 0), mines[0]);
                mineMap.SetTile(new Vector3Int(x-x_Offset_lead, y + y_Offset_lead - 1, 0), mines[1]);
            }
        }
        for (int x = -6; x >= downMax; x -= boxHeight)
        {
            for (int y = -1; y >= leftMax;y-=boxWidth)
            {
                int tilePosNum_iron = Random.Range(1, boxHeight * boxWidth + 1);
                int tilePosNum_lead = Random.Range(1, boxHeight * boxWidth + 1);
                if (tilePosNum_iron == tilePosNum_lead)
                {
                    while (tilePosNum_iron == tilePosNum_lead)
                    {
                        tilePosNum_lead = Random.Range(1, boxHeight * boxWidth + 1);
                    }
                }
                int x_Offset_iron = tilePosNum_iron / boxWidth;
                int y_Offset_iron = tilePosNum_iron % boxWidth;
                int x_Offset_lead = tilePosNum_lead / boxWidth;
                int y_Offset_lead = tilePosNum_lead % boxWidth;

                mineMap.SetTile(new Vector3Int(x-x_Offset_iron, y + y_Offset_iron - 1, 0), mines[0]);
                mineMap.SetTile(new Vector3Int(x-x_Offset_lead, y - y_Offset_lead - 1, 0), mines[1]);
            }
        }
    }

    private void RareMinesGene()
    {
        
        for(int x=goldTopPos;x>=downMax;x=-rareBoxHeight)
        {
            for (int y = 0; y <= rightMax; y  += rareBoxWidth)
            {
                int tilePos_Gold_Sur = Random.Range(1, (rareBoxHeight * rareBoxWidth + 1));
                int x_Offset_gold_Sur = tilePos_Gold_Sur / (rareBoxWidth);
                int y_Offset_gold_Sur = tilePos_Gold_Sur % (rareBoxWidth);
                if (mineMap.HasTile(new Vector3Int(goldTopPos - x_Offset_gold_Sur, y + y_Offset_gold_Sur, 0)))
                {
                    while (mineMap.HasTile(new Vector3Int(goldTopPos - x_Offset_gold_Sur, y + y_Offset_gold_Sur, 0)))
                    {
                        tilePos_Gold_Sur = Random.Range(1, (rareBoxHeight) * (rareBoxWidth) + 1);
                        x_Offset_gold_Sur = tilePos_Gold_Sur / (rareBoxWidth);
                        y_Offset_gold_Sur = tilePos_Gold_Sur % (rareBoxWidth);
                    }
                }
                mineMap.SetTile(new Vector3Int(goldTopPos - x_Offset_gold_Sur, y + y_Offset_gold_Sur, 0), mines[2]);

            }
            for (int y = -1; y >= leftMax; y  -= rareBoxWidth)
            {
                int tilePos_Gold_Sur = Random.Range(1, (rareBoxHeight * rareBoxWidth + 1));
                int x_Offset_gold_Sur = tilePos_Gold_Sur / (rareBoxWidth);
                int y_Offset_gold_Sur = tilePos_Gold_Sur % (rareBoxWidth);
                if (mineMap.HasTile(new Vector3Int(goldTopPos - x_Offset_gold_Sur, y - y_Offset_gold_Sur, 0)))
                {
                    while (mineMap.HasTile(new Vector3Int(goldTopPos - x_Offset_gold_Sur, y -y_Offset_gold_Sur, 0)))
                    {
                        tilePos_Gold_Sur = Random.Range(1, (rareBoxHeight) * (rareBoxWidth) + 1);
                        x_Offset_gold_Sur = tilePos_Gold_Sur / (rareBoxWidth);
                        y_Offset_gold_Sur = tilePos_Gold_Sur % (rareBoxWidth);
                    }
                }
                mineMap.SetTile(new Vector3Int(goldTopPos - x_Offset_gold_Sur, y - y_Offset_gold_Sur, 0), mines[2]);

            }
        }
        
        
        
    }

    //A,BŠÔ‚Ì‹——£‚ð‚¾‚·
    //private int GetDistance( Vector3Int A, Vector3Int B)
    //{
        
    //    if (Mathf.Abs((A.y%2))==Mathf.Abs((B.y%2)))
    //    {
    //        if(Mathf.Abs(A.y-B.y)<=2*Mathf.Abs(A.x-B.x))
    //        {
    //            Debug.Log("1");
    //            return (Mathf.Abs(A.y - B.y))/2 +  Mathf.Abs(A.x - B.x); ;
    //        }
    //        else
    //        {
    //            Debug.Log("2");
    //            return Mathf.Abs(A.y - B.y);
                
    //        }
    //    }
    //    else
    //    {
    //        if(A.x==B.x)
    //        {
    //            Debug.Log("3");
    //            return Mathf.Abs(A.y - B.y);
    //        }
    //        else if(A.x>=B.x)
    //        {
    //            if(A.y % 2==0)
    //            {
    //                if((Mathf.Abs(A.y - B.y)+1)<=2*(Mathf.Abs(A.x - B.x)))
    //                {
    //                    Debug.Log("4");
    //                    return (Mathf.Abs(A.y - B.y) + Mathf.Abs(A.x - B.x) - (Mathf.Abs(A.y - B.y) + 1) / 2);
    //                }
    //                else
    //                {
    //                    Debug.Log("5");
    //                    return Mathf.Abs(A.y - B.y);
    //                }
    //            }
    //            else
    //            {
    //                if ((Mathf.Abs(A.y - B.y) -1) <= 2 * (Mathf.Abs(A.x - B.x)))
    //                {
    //                    Debug.Log("6");
    //                    return (Mathf.Abs(A.y - B.y) + Mathf.Abs(A.x - B.x) - (Mathf.Abs(A.y - B.y) - 1) / 2);
    //                }
    //                else
    //                {
    //                    Debug.Log("7");
    //                    return Mathf.Abs(A.y - B.y);
    //                }
    //            }
    //        }
    //        else 
    //        {
    //            if (B.y % 2 == 0)
    //            {
    //                if ((Mathf.Abs(A.y - B.y) + 1) <= 2 * (Mathf.Abs(A.x - B.x)))
    //                {
    //                    Debug.Log("8");
    //                    return (Mathf.Abs(A.y - B.y)  + Mathf.Abs(A.x - B.x)- (Mathf.Abs(A.y - B.y) + 1) / 2);
    //                }
    //                else
    //                {
    //                    Debug.Log("9");
    //                    return Mathf.Abs(A.y - B.y);
    //                }
    //            }
    //            else
    //            {
    //                if ((Mathf.Abs(A.y - B.y) - 1) <= 2 * (Mathf.Abs(A.x - B.x)))
    //                {
    //                    Debug.Log("10");
    //                    return (Mathf.Abs(A.y - B.y) + Mathf.Abs(A.x - B.x) - (Mathf.Abs(A.y - B.y) - 1) / 2);
    //                }
    //                else
    //                {
    //                    Debug.Log("11");
    //                    return Mathf.Abs(A.y - B.y);
    //                }
    //            }
    //        }
    //    }
        
    //}
}
