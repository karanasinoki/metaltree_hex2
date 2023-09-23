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

    public TextMeshProUGUI scoreText; // スコアを表示するUIテキスト
    public float scoreIncreaseInterval = 1.0f; // スコアが増加する間隔（秒）
    public int minerPower ; // スコアの増加量

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
        // 時間経過でスコアを増加させる
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
        // スコアをUIに表示
        if (scoreText != null)
        {
            scoreText.text = "× " + currentScore.ToString();
        }
    }
}
