using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using TMPro;

public class MineCounter : MonoBehaviour
{
    public TileBase miner;
    public Tilemap mineMap;

    public TextMeshProUGUI scoreText; // �X�R�A��\������UI�e�L�X�g
    public float scoreIncreaseInterval = 1.0f; // �X�R�A����������Ԋu�i�b�j
    public int minerPower ; // �X�R�A�̑�����

    private float timer = 0.0f;
    private int currentScore = 0;

    void Start()
    {
        UpdateScoreText();
    }
    
    int CountTiles(TileBase tile)
    {
        int count = 0;
        BoundsInt bounds = mineMap.cellBounds;

        foreach (Vector3Int pos in bounds.allPositionsWithin)
        {
            if (mineMap.GetTile(pos) == tile)
            {
                count++;
            }
        }

        return count;
    }

   
    private void Update()
    {
        // ���Ԍo�߂ŃX�R�A�𑝉�������
        timer += Time.deltaTime;
        if (timer >= scoreIncreaseInterval)
        {
            int minerAmount = CountTiles(miner);
            currentScore += minerAmount*minerPower;
            timer = 0.0f;
            UpdateScoreText();
        }
    }

    void UpdateScoreText()
    {
        // �X�R�A��UI�ɕ\��
        if (scoreText != null)
        {
            scoreText.text = "�~ " + currentScore.ToString();
        }
    }
}
