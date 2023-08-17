using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class testScript : MonoBehaviour
{
    public Tilemap stageMap
        ;
    public TileBase testTile;

     
    public void RotateHexagonTile(Vector3Int position)
    {
        TileBase tile = stageMap.GetTile(position);

        if (tile != null)
        {
            // 60度の回転角度をラジアンに変換
            float angleRad = 60f * Mathf.Deg2Rad;

            // 回転行列を作成
            Matrix4x4 rotationMatrix = Matrix4x4.Rotate(Quaternion.Euler(0f, 0f, angleRad));

            // タイルの行列変換を適用
            stageMap.SetTransformMatrix(position, rotationMatrix);
        }
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(
                Input.mousePosition);
            Vector3Int grid = stageMap.WorldToCell(mousePos);
            RotateHexagonTile(grid);
            stageMap.SetTile(new Vector3Int(grid.x,grid.y,0),testTile);
        }   
    }
}
