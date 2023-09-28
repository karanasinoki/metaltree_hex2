using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Counter2 : MonoBehaviour
{
    public TextMeshProUGUI[] minesScoreText;

    
    public int[] newScore;
    public int update;
    public int oldUpdate;

    private void Start()
    {
        for (int i = 0; i < newScore.Length; i++)
        {
            minesScoreText[i].text = newScore[i].ToString();
        }
    }

    void Update()
    {
        if (update != oldUpdate)
        {
            
            for (int i = 0; i < newScore.Length; i++)
            {
                minesScoreText[i].text = newScore[i].ToString();
            }
            oldUpdate = update;
        }
    }
}
