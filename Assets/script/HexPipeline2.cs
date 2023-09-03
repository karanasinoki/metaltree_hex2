using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HexPipeline2 : MonoBehaviour
{
    public Tilemap pipeMap;
    public Tilemap mineMap;
    public TileBase[] pipeTiles = new TileBase[12];
    int tileCount = 0;
    private bool a;
    public Vector3Int startCorePos;

    private void Start()
    {
        pipeMap.SetTile(startCorePos, pipeTiles[0]);
        if(mineMap.HasTile(startCorePos))
        {
            mineMap.SetTile(startCorePos, null);
        }
    }

    //指定された位置のタイルに[pipeTiles]がある場合trueを返す
    public bool JudgeTiles(Vector3Int position)
    {
        foreach (TileBase pipe_a in pipeTiles)
        {
            a = false;
            TileBase tile_a = pipeMap.GetTile(position);
            if (tile_a == pipe_a)
            {
                a = true;
                break;
            }
        }
        return a;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(
                Input.mousePosition);
            Vector3Int grid_pr = pipeMap.WorldToCell(mousePos);
            Vector3Int grid = new Vector3Int(grid_pr.x, grid_pr.y, 0);
            if (!mineMap.HasTile(grid))
            {

                if (pipeMap.HasTile(grid))
                {
                    pipeMap.SetTile(grid, null);
                }

                if (grid.y % 2 == 0)
                {
                    Vector3Int[] hexPosAro = new Vector3Int[]
                    {
                    new Vector3Int(1,0,0)+new Vector3Int(grid.x,grid.y,0),
                    new Vector3Int(0,1,0)+new Vector3Int(grid.x,grid.y,0),
                    new Vector3Int(-1,1,0)+new Vector3Int(grid.x,grid.y,0),
                    new Vector3Int(-1,0,0)+new Vector3Int(grid.x,grid.y,0),
                    new Vector3Int(-1,-1,0)+new Vector3Int(grid.x,grid.y,0),
                    new Vector3Int(0,-1,0)+new Vector3Int(grid.x,grid.y,0),

                    };
                    TileRenderer(hexPosAro, grid);

                    foreach (Vector3Int aroPos in hexPosAro)
                    {
                        if (JudgeTiles(aroPos))
                        {
                            if (aroPos.y % 2 == 0)
                            {
                                Vector3Int[] hexPosAro_ref1 = new Vector3Int[]
                                {

                                new Vector3Int(1,0,0)+new Vector3Int(aroPos.x,aroPos.y,0),
                                new Vector3Int(0,1,0)+new Vector3Int(aroPos.x,aroPos.y,0),
                                new Vector3Int(-1,1,0)+new Vector3Int(aroPos.x,aroPos.y,0),
                                new Vector3Int(-1,0,0)+new Vector3Int(aroPos.x,aroPos.y,0),
                                new Vector3Int(-1,-1,0)+new Vector3Int(aroPos.x,aroPos.y,0),
                                new Vector3Int(0,-1,0)+new Vector3Int(aroPos.x,aroPos.y,0),

                                };
                                TileRenderer(hexPosAro_ref1, aroPos);
                            }

                            else
                            {
                                Vector3Int[] hexPosAro_ref2 = new Vector3Int[]
                                {
                                new Vector3Int(1,0,0)+new Vector3Int(aroPos.x,aroPos.y,0),
                                new Vector3Int(1,1,0)+new Vector3Int(aroPos.x,aroPos.y,0),
                                new Vector3Int(0,1,0)+new Vector3Int(aroPos.x,aroPos.y,0),
                                new Vector3Int(-1,0,0)+new Vector3Int(aroPos.x,aroPos.y,0),
                                new Vector3Int(0,-1,0)+new Vector3Int(aroPos.x,aroPos.y,0),
                                new Vector3Int(1,-1,0)+new Vector3Int(aroPos.x,aroPos.y,0),

                                    };
                                TileRenderer(hexPosAro_ref2, aroPos);

                            }
                        }
                    }
                }
                else
                {
                    Vector3Int[] hexPosAro = new Vector3Int[]
                    {
                    new Vector3Int(1,0,0)+new Vector3Int(grid.x,grid.y,0),
                    new Vector3Int(1,1,0)+new Vector3Int(grid.x,grid.y,0),
                    new Vector3Int(0,1,0)+new Vector3Int(grid.x,grid.y,0),
                    new Vector3Int(-1,0,0)+new Vector3Int(grid.x,grid.y,0),
                    new Vector3Int(0,-1,0)+new Vector3Int(grid.x,grid.y,0),
                    new Vector3Int(1,-1,0)+new Vector3Int(grid.x,grid.y,0),

                    };
                    TileRenderer(hexPosAro, grid);

                    foreach (Vector3Int aroPos in hexPosAro)
                    {
                        if (JudgeTiles(aroPos))
                        {
                            if (aroPos.y % 2 == 0)
                            {
                                Vector3Int[] hexPosAro_ref1 = new Vector3Int[]
                                {

                                new Vector3Int(1,0,0)+new Vector3Int(aroPos.x,aroPos.y,0),
                                new Vector3Int(0,1,0)+new Vector3Int(aroPos.x,aroPos.y,0),
                                new Vector3Int(-1,1,0)+new Vector3Int(aroPos.x,aroPos.y,0),
                                new Vector3Int(-1,0,0)+new Vector3Int(aroPos.x,aroPos.y,0),
                                new Vector3Int(-1,-1,0)+new Vector3Int(aroPos.x,aroPos.y,0),
                                new Vector3Int(0,-1,0)+new Vector3Int(aroPos.x,aroPos.y,0),

                                };
                                TileRenderer(hexPosAro_ref1, aroPos);
                            }

                            else
                            {
                                Vector3Int[] hexPosAro_ref2 = new Vector3Int[]
                                {
                                new Vector3Int(1,0,0)+new Vector3Int(aroPos.x,aroPos.y,0),
                                new Vector3Int(1,1,0)+new Vector3Int(aroPos.x,aroPos.y,0),
                                new Vector3Int(0,1,0)+new Vector3Int(aroPos.x,aroPos.y,0),
                                new Vector3Int(-1,0,0)+new Vector3Int(aroPos.x,aroPos.y,0),
                                new Vector3Int(0,-1,0)+new Vector3Int(aroPos.x,aroPos.y,0),
                                new Vector3Int(1,-1,0)+new Vector3Int(aroPos.x,aroPos.y,0),

                                    };
                                TileRenderer(hexPosAro_ref2, aroPos);

                            }
                        }


                    }

                }
            }
        }
    }

    //タイルを置く関数
    public void TileRenderer(Vector3Int[] hexPos ,Vector3Int gridPos)
    {
        foreach (Vector3Int number in hexPos)
        {
            if (JudgeTiles(number))
            {
                tileCount++;
            }

        }
        Debug.Log(tileCount);
        if (pipeMap.HasTile(gridPos))
        {
            pipeMap.SetTile(gridPos, null);
        }
        if (tileCount == 0)
        {
            
        }
        else if (tileCount == 1)
        {
            
            pipeMap.SetTile(gridPos, pipeTiles[1]);

            if (JudgeTiles(hexPos[1]))
            {
                Matrix4x4 transformMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0, 0, -60), Vector3.one);
                pipeMap.SetTransformMatrix(gridPos, transformMatrix);
            }
            if (JudgeTiles(hexPos[2]))
            {
                Matrix4x4 transformMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0, 0, -120), Vector3.one);
                pipeMap.SetTransformMatrix(gridPos, transformMatrix);
            }
            if (JudgeTiles(hexPos[3]))
            {
                Matrix4x4 transformMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0, 0, -180), Vector3.one);
                pipeMap.SetTransformMatrix(gridPos, transformMatrix);
            }
            if (JudgeTiles(hexPos[4]))
            {
                Matrix4x4 transformMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0, 0, -240), Vector3.one);
                pipeMap.SetTransformMatrix(gridPos, transformMatrix);
            }
            if (JudgeTiles(hexPos[5]))
            {
                Matrix4x4 transformMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0, 0, -300), Vector3.one);
                pipeMap.SetTransformMatrix(gridPos, transformMatrix);
            }
        }
        else if (tileCount == 2)
        {
            //2-1
            if (JudgeTiles(hexPos[0]) && JudgeTiles(hexPos[1]))
            {
                pipeMap.SetTile(gridPos, pipeTiles[2]);
            }
            else if (JudgeTiles(hexPos[1]) && JudgeTiles(hexPos[2]))
            {
                pipeMap.SetTile(gridPos, pipeTiles[2]);
                Matrix4x4 transformMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0, 0, -60), Vector3.one);
                pipeMap.SetTransformMatrix(gridPos, transformMatrix);
            }
            else if (JudgeTiles(hexPos[2]) && JudgeTiles(hexPos[3]))
            {
                pipeMap.SetTile(gridPos, pipeTiles[2]);
                Matrix4x4 transformMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0, 0, -120), Vector3.one);
                pipeMap.SetTransformMatrix(gridPos, transformMatrix);
            }
            else if (JudgeTiles(hexPos[3]) && JudgeTiles(hexPos[4]))
            {
                pipeMap.SetTile(gridPos, pipeTiles[2]);
                Matrix4x4 transformMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0, 0, -180), Vector3.one);
                pipeMap.SetTransformMatrix(gridPos, transformMatrix);
            }
            else if (JudgeTiles(hexPos[4]) && JudgeTiles(hexPos[5]))
            {
                pipeMap.SetTile(gridPos, pipeTiles[2]);
                Matrix4x4 transformMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0, 0, -240), Vector3.one);
                pipeMap.SetTransformMatrix(gridPos, transformMatrix);
            }
            else if (JudgeTiles(hexPos[5]) && JudgeTiles(hexPos[0]))
            {
                pipeMap.SetTile(gridPos, pipeTiles[2]);
                Matrix4x4 transformMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0, 0, -300), Vector3.one);
                pipeMap.SetTransformMatrix(gridPos, transformMatrix);
            }

            //2-2
            if (JudgeTiles(hexPos[0]) && JudgeTiles(hexPos[2]))
            {
                pipeMap.SetTile(gridPos, pipeTiles[3]);
            }
            else if (JudgeTiles(hexPos[1]) && JudgeTiles(hexPos[3]))
            {
                pipeMap.SetTile(gridPos, pipeTiles[3]);
                Matrix4x4 transformMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0, 0, -60), Vector3.one);
                pipeMap.SetTransformMatrix(gridPos, transformMatrix);
            }
            else if (JudgeTiles(hexPos[2]) && JudgeTiles(hexPos[4]))
            {
                pipeMap.SetTile(gridPos, pipeTiles[3]);
                Matrix4x4 transformMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0, 0, -120), Vector3.one);
                pipeMap.SetTransformMatrix(gridPos, transformMatrix);
            }
            else if (JudgeTiles(hexPos[3]) && JudgeTiles(hexPos[5]))
            {
                pipeMap.SetTile(gridPos, pipeTiles[3]);
                Matrix4x4 transformMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0, 0, -180), Vector3.one);
                pipeMap.SetTransformMatrix(gridPos, transformMatrix);
            }
            else if (JudgeTiles(hexPos[4]) && JudgeTiles(hexPos[0]))
            {
                pipeMap.SetTile(gridPos, pipeTiles[3]);
                Matrix4x4 transformMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0, 0, -240), Vector3.one);
                pipeMap.SetTransformMatrix(gridPos, transformMatrix);
            }
            else if (JudgeTiles(hexPos[5]) && JudgeTiles(hexPos[1]))
            {
                pipeMap.SetTile(gridPos, pipeTiles[3]);
                Matrix4x4 transformMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0, 0, -300), Vector3.one);
                pipeMap.SetTransformMatrix(gridPos, transformMatrix);
            }

            //2-3
            if (JudgeTiles(hexPos[0]) && JudgeTiles(hexPos[3]))
            {
                pipeMap.SetTile(gridPos, pipeTiles[4]);
            }
            else if (JudgeTiles(hexPos[1]) && JudgeTiles(hexPos[4]))
            {
                pipeMap.SetTile(gridPos, pipeTiles[4]);
                Matrix4x4 transformMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0, 0, -60), Vector3.one);
                pipeMap.SetTransformMatrix(gridPos, transformMatrix);
            }
            else if (JudgeTiles(hexPos[2]) && JudgeTiles(hexPos[5]))
            {
                pipeMap.SetTile(gridPos, pipeTiles[4]);
                Matrix4x4 transformMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0, 0, -120), Vector3.one);
                pipeMap.SetTransformMatrix(gridPos, transformMatrix);
            }

        }

        else if (tileCount == 3)
        {
            //3-1
            if (JudgeTiles(hexPos[0]) && JudgeTiles(hexPos[1]) && JudgeTiles(hexPos[2]))
            {
                pipeMap.SetTile(gridPos, pipeTiles[5]);
            }
            else if (JudgeTiles(hexPos[1]) && JudgeTiles(hexPos[2]) && JudgeTiles(hexPos[3]))
            {
                pipeMap.SetTile(gridPos, pipeTiles[5]);
                Matrix4x4 transformMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0, 0, -60), Vector3.one);
                pipeMap.SetTransformMatrix(gridPos, transformMatrix);
            }
            else if (JudgeTiles(hexPos[2]) && JudgeTiles(hexPos[3]) && JudgeTiles(hexPos[4]))
            {
                pipeMap.SetTile(gridPos, pipeTiles[5]);
                Matrix4x4 transformMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0, 0, -120), Vector3.one);
                pipeMap.SetTransformMatrix(gridPos, transformMatrix);
            }
            else if (JudgeTiles(hexPos[3]) && JudgeTiles(hexPos[4]) && JudgeTiles(hexPos[5]))
            {
                pipeMap.SetTile(gridPos, pipeTiles[5]);
                Matrix4x4 transformMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0, 0, -180), Vector3.one);
                pipeMap.SetTransformMatrix(gridPos, transformMatrix);
            }
            else if (JudgeTiles(hexPos[4]) && JudgeTiles(hexPos[5]) && JudgeTiles(hexPos[0]))
            {
                pipeMap.SetTile(gridPos, pipeTiles[5]);
                Matrix4x4 transformMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0, 0, -240), Vector3.one);
                pipeMap.SetTransformMatrix(gridPos, transformMatrix);
            }
            else if (JudgeTiles(hexPos[5]) && JudgeTiles(hexPos[0]) && JudgeTiles(hexPos[1]))
            {
                pipeMap.SetTile(gridPos, pipeTiles[5]);
                Matrix4x4 transformMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0, 0, -300), Vector3.one);
                pipeMap.SetTransformMatrix(gridPos, transformMatrix);
            }

            //3-2-1
            if (JudgeTiles(hexPos[0]) && JudgeTiles(hexPos[1]) && JudgeTiles(hexPos[3]))
            {
                pipeMap.SetTile(gridPos, pipeTiles[6]);
            }
            else if (JudgeTiles(hexPos[1]) && JudgeTiles(hexPos[2]) && JudgeTiles(hexPos[4]))
            {
                pipeMap.SetTile(gridPos, pipeTiles[6]);
                Matrix4x4 transformMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0, 0, -60), Vector3.one);
                pipeMap.SetTransformMatrix(gridPos, transformMatrix);
            }
            else if (JudgeTiles(hexPos[2]) && JudgeTiles(hexPos[3]) && JudgeTiles(hexPos[5]))
            {
                pipeMap.SetTile(gridPos, pipeTiles[6]);
                Matrix4x4 transformMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0, 0, -120), Vector3.one);
                pipeMap.SetTransformMatrix(gridPos, transformMatrix);
            }
            else if (JudgeTiles(hexPos[3]) && JudgeTiles(hexPos[4]) && JudgeTiles(hexPos[0]))
            {
                pipeMap.SetTile(gridPos, pipeTiles[6]);
                Matrix4x4 transformMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0, 0, -180), Vector3.one);
                pipeMap.SetTransformMatrix(gridPos, transformMatrix);
            }
            else if (JudgeTiles(hexPos[4]) && JudgeTiles(hexPos[5]) && JudgeTiles(hexPos[1]))
            {
                pipeMap.SetTile(gridPos, pipeTiles[6]);
                Matrix4x4 transformMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0, 0, -240), Vector3.one);
                pipeMap.SetTransformMatrix(gridPos, transformMatrix);
            }
            else if (JudgeTiles(hexPos[5]) && JudgeTiles(hexPos[0]) && JudgeTiles(hexPos[2]))
            {
                pipeMap.SetTile(gridPos, pipeTiles[6]);
                Matrix4x4 transformMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0, 0, -300), Vector3.one);
                pipeMap.SetTransformMatrix(gridPos, transformMatrix);
            }

            //3-2-2
            if (JudgeTiles(hexPos[0]) && JudgeTiles(hexPos[5]) && JudgeTiles(hexPos[3]))
            {
                pipeMap.SetTile(gridPos, pipeTiles[7]);
            }
            else if (JudgeTiles(hexPos[1]) && JudgeTiles(hexPos[0]) && JudgeTiles(hexPos[4]))
            {
                pipeMap.SetTile(gridPos, pipeTiles[7]);
                Matrix4x4 transformMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0, 0, -60), Vector3.one);
                pipeMap.SetTransformMatrix(gridPos, transformMatrix);
            }
            else if (JudgeTiles(hexPos[2]) && JudgeTiles(hexPos[1]) && JudgeTiles(hexPos[5]))
            {
                pipeMap.SetTile(gridPos, pipeTiles[7]);
                Matrix4x4 transformMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0, 0, -120), Vector3.one);
                pipeMap.SetTransformMatrix(gridPos, transformMatrix);
            }
            else if (JudgeTiles(hexPos[3]) && JudgeTiles(hexPos[2]) && JudgeTiles(hexPos[0]))
            {
                pipeMap.SetTile(gridPos, pipeTiles[7]);
                Matrix4x4 transformMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0, 0, -180), Vector3.one);
                pipeMap.SetTransformMatrix(gridPos, transformMatrix);
            }
            else if (JudgeTiles(hexPos[4]) && JudgeTiles(hexPos[3]) && JudgeTiles(hexPos[1]))
            {
                pipeMap.SetTile(gridPos, pipeTiles[7]);
                Matrix4x4 transformMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0, 0, -240), Vector3.one);
                pipeMap.SetTransformMatrix(gridPos, transformMatrix);
            }
            else if (JudgeTiles(hexPos[5]) && JudgeTiles(hexPos[4]) && JudgeTiles(hexPos[2]))
            {
                pipeMap.SetTile(gridPos, pipeTiles[7]);
                Matrix4x4 transformMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0, 0, -300), Vector3.one);
                pipeMap.SetTransformMatrix(gridPos, transformMatrix);
            }

            //3-3
            if (JudgeTiles(hexPos[0]) && JudgeTiles(hexPos[2]) && JudgeTiles(hexPos[4]))
            {
                pipeMap.SetTile(gridPos, pipeTiles[8]);
            }
            else if (JudgeTiles(hexPos[1]) && JudgeTiles(hexPos[5]) && JudgeTiles(hexPos[3]))
            {
                pipeMap.SetTile(gridPos, pipeTiles[8]);
                Matrix4x4 transformMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0, 0, -60), Vector3.one);
                pipeMap.SetTransformMatrix(gridPos, transformMatrix);
            }



        }
        else if (tileCount == 4)
        {
            //4-1
            if (JudgeTiles(hexPos[0]) && JudgeTiles(hexPos[1]) && JudgeTiles(hexPos[2]) && JudgeTiles(hexPos[3]))
            {
                pipeMap.SetTile(gridPos, pipeTiles[9]);
            }
            else if (JudgeTiles(hexPos[4]) && JudgeTiles(hexPos[1]) && JudgeTiles(hexPos[2]) && JudgeTiles(hexPos[3]))
            {
                pipeMap.SetTile(gridPos, pipeTiles[9]);
                Matrix4x4 transformMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0, 0, -60), Vector3.one);
                pipeMap.SetTransformMatrix(gridPos, transformMatrix);
            }
            else if (JudgeTiles(hexPos[4]) && JudgeTiles(hexPos[5]) && JudgeTiles(hexPos[2]) && JudgeTiles(hexPos[3]))
            {
                pipeMap.SetTile(gridPos, pipeTiles[9]);
                Matrix4x4 transformMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0, 0, -120), Vector3.one);
                pipeMap.SetTransformMatrix(gridPos, transformMatrix);
            }
            else if (JudgeTiles(hexPos[0]) && JudgeTiles(hexPos[4]) && JudgeTiles(hexPos[5]) && JudgeTiles(hexPos[3]))
            {
                pipeMap.SetTile(gridPos, pipeTiles[9]);
                Matrix4x4 transformMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0, 0, -180), Vector3.one);
                pipeMap.SetTransformMatrix(gridPos, transformMatrix);
            }
            else if (JudgeTiles(hexPos[0]) && JudgeTiles(hexPos[1]) && JudgeTiles(hexPos[4]) && JudgeTiles(hexPos[5]))
            {
                pipeMap.SetTile(gridPos, pipeTiles[9]);
                Matrix4x4 transformMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0, 0, -240), Vector3.one);
                pipeMap.SetTransformMatrix(gridPos, transformMatrix);
            }
            else if (JudgeTiles(hexPos[0]) && JudgeTiles(hexPos[1]) && JudgeTiles(hexPos[2]) && JudgeTiles(hexPos[5]))
            {
                pipeMap.SetTile(gridPos, pipeTiles[9]);
                Matrix4x4 transformMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0, 0, -300), Vector3.one);
                pipeMap.SetTransformMatrix(gridPos, transformMatrix);
            }

            //4-2
            if (JudgeTiles(hexPos[0]) && JudgeTiles(hexPos[1]) && JudgeTiles(hexPos[2]) && JudgeTiles(hexPos[4]))
            {
                pipeMap.SetTile(gridPos, pipeTiles[10]);
            }
            else if (JudgeTiles(hexPos[5]) && JudgeTiles(hexPos[1]) && JudgeTiles(hexPos[2]) && JudgeTiles(hexPos[3]))
            {
                pipeMap.SetTile(gridPos, pipeTiles[10]);
                Matrix4x4 transformMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0, 0, -60), Vector3.one);
                pipeMap.SetTransformMatrix(gridPos, transformMatrix);
            }
            else if (JudgeTiles(hexPos[4]) && JudgeTiles(hexPos[0]) && JudgeTiles(hexPos[2]) && JudgeTiles(hexPos[3]))
            {
                pipeMap.SetTile(gridPos, pipeTiles[10]);
                Matrix4x4 transformMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0, 0, -120), Vector3.one);
                pipeMap.SetTransformMatrix(gridPos, transformMatrix);
            }
            else if (JudgeTiles(hexPos[1]) && JudgeTiles(hexPos[4]) && JudgeTiles(hexPos[5]) && JudgeTiles(hexPos[3]))
            {
                pipeMap.SetTile(gridPos, pipeTiles[10]);
                Matrix4x4 transformMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0, 0, -180), Vector3.one);
                pipeMap.SetTransformMatrix(gridPos, transformMatrix);
            }
            else if (JudgeTiles(hexPos[0]) && JudgeTiles(hexPos[2]) && JudgeTiles(hexPos[4]) && JudgeTiles(hexPos[5]))
            {
                pipeMap.SetTile(gridPos, pipeTiles[10]);
                Matrix4x4 transformMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0, 0, -240), Vector3.one);
                pipeMap.SetTransformMatrix(gridPos, transformMatrix);
            }
            else if (JudgeTiles(hexPos[0]) && JudgeTiles(hexPos[1]) && JudgeTiles(hexPos[3]) && JudgeTiles(hexPos[5]))
            {
                pipeMap.SetTile(gridPos, pipeTiles[10]);
                Matrix4x4 transformMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0, 0, -300), Vector3.one);
                pipeMap.SetTransformMatrix(gridPos, transformMatrix);
            }

            //4-3
            if (JudgeTiles(hexPos[0]) && JudgeTiles(hexPos[1]) && JudgeTiles(hexPos[3]) && JudgeTiles(hexPos[4]))
            {
                pipeMap.SetTile(gridPos, pipeTiles[11]);
            }
            else if (JudgeTiles(hexPos[5]) && JudgeTiles(hexPos[1]) && JudgeTiles(hexPos[2]) && JudgeTiles(hexPos[4]))
            {
                pipeMap.SetTile(gridPos, pipeTiles[11]);
                Matrix4x4 transformMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0, 0, -60), Vector3.one);
                pipeMap.SetTransformMatrix(gridPos, transformMatrix);
            }
            else if (JudgeTiles(hexPos[5]) && JudgeTiles(hexPos[0]) && JudgeTiles(hexPos[2]) && JudgeTiles(hexPos[3]))
            {
                pipeMap.SetTile(gridPos, pipeTiles[11]);
                Matrix4x4 transformMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0, 0, -120), Vector3.one);
                pipeMap.SetTransformMatrix(gridPos, transformMatrix);
            }

        }
        else if (tileCount == 5)
        {
            //5-1
            if (JudgeTiles(hexPos[0]) && JudgeTiles(hexPos[1]) && JudgeTiles(hexPos[5]) && JudgeTiles(hexPos[4]) && JudgeTiles(hexPos[3]))
            {
                pipeMap.SetTile(gridPos, pipeTiles[12]);
                Matrix4x4 transformMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0, 0, -180), Vector3.one);
                pipeMap.SetTransformMatrix(gridPos, transformMatrix);
            }
            else if (JudgeTiles(hexPos[5]) && JudgeTiles(hexPos[1]) && JudgeTiles(hexPos[2]) && JudgeTiles(hexPos[4]) && JudgeTiles(hexPos[3]))
            {
                pipeMap.SetTile(gridPos, pipeTiles[12]);
                Matrix4x4 transformMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0, 0, -60), Vector3.one);
                pipeMap.SetTransformMatrix(gridPos, transformMatrix);
            }
            else if (JudgeTiles(hexPos[5]) && JudgeTiles(hexPos[0]) && JudgeTiles(hexPos[2]) && JudgeTiles(hexPos[4]) && JudgeTiles(hexPos[3]))
            {
                pipeMap.SetTile(gridPos, pipeTiles[12]);
                Matrix4x4 transformMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0, 0, -120), Vector3.one);
                pipeMap.SetTransformMatrix(gridPos, transformMatrix);
            }
            else if (JudgeTiles(hexPos[5]) && JudgeTiles(hexPos[1]) && JudgeTiles(hexPos[0]) && JudgeTiles(hexPos[4]) && JudgeTiles(hexPos[2]))
            {
                pipeMap.SetTile(gridPos, pipeTiles[12]);
                Matrix4x4 transformMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0, 0, -240), Vector3.one);
                pipeMap.SetTransformMatrix(gridPos, transformMatrix);
            }
            else if (JudgeTiles(hexPos[5]) && JudgeTiles(hexPos[1]) && JudgeTiles(hexPos[2]) && JudgeTiles(hexPos[3]) && JudgeTiles(hexPos[0]))
            {
                pipeMap.SetTile(gridPos, pipeTiles[12]);
                Matrix4x4 transformMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0, 0, -300), Vector3.one);
                pipeMap.SetTransformMatrix(gridPos, transformMatrix);
            }
            else if (JudgeTiles(hexPos[0]) && JudgeTiles(hexPos[1]) && JudgeTiles(hexPos[2]) && JudgeTiles(hexPos[4]) && JudgeTiles(hexPos[3]))
            {
                pipeMap.SetTile(gridPos, pipeTiles[12]);

            }
        }
        else if (tileCount == 6)
        {
            pipeMap.SetTile(gridPos, pipeTiles[13]);
        }
        tileCount = 0;
    }
   
    
}
