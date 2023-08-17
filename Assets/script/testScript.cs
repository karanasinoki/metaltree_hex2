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
            // 60�x�̉�]�p�x�����W�A���ɕϊ�
            float angleRad = 60f * Mathf.Deg2Rad;

            // ��]�s����쐬
            Matrix4x4 rotationMatrix = Matrix4x4.Rotate(Quaternion.Euler(0f, 0f, angleRad));

            // �^�C���̍s��ϊ���K�p
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
