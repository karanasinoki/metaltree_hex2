using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using TMPro;

public class MineCounter : MonoBehaviour
{
    
   
    
    public float scoreIncreaseInterval = 1.0f; // スコアが増加する間隔（秒）
    public int[] minerPower ; // スコアの増加量

    public TextMeshProUGUI[] minesScoreText;
    
   
    public int newMinesCount_iron;
    public int newMinesCount_lead;
    public int newMinesCount_gold;
    public int newMinesCount_ruby;
    public int newMinesCount_sapphire;

    private int currentMinesCount_iron;
    private int currentMinesCount_lead;
    private int currentMinesCount_gold;
    private int currentMinesCount_ruby;
    private int currentMinesCount_sapphire;


    public int newMinerCount;
    private int[] curentScore=new int[5];
    private int[] increaseScore = new int[5];
    private int currentMinerCount;
    private int updateCount;
    private int oldUpdateCount;

    private bool isRunning = true;

    void Start()
    {
      
         
    }

   

    IEnumerator IncreaseMinesCoroutine_iron()
    {
        while(isRunning)
        {
            curentScore[0] += newMinesCount_iron*minerPower[0];
            minesScoreText[0].text = curentScore[0].ToString();
            yield return new WaitForSeconds(scoreIncreaseInterval);
        }
       
    }
    IEnumerator IncreaseMinesCoroutine_lead()
    {
        while (isRunning)
        {
            curentScore[1] += newMinesCount_lead * minerPower[1];
            minesScoreText[1].text = curentScore[1].ToString();
            yield return new WaitForSeconds(scoreIncreaseInterval);
        }

    }
    IEnumerator IncreaseMinesCoroutine_gold()
    {
        while (isRunning)
        {
            curentScore[2] += newMinesCount_gold * minerPower[2];
            minesScoreText[2].text = curentScore[2].ToString();
            yield return new WaitForSeconds(scoreIncreaseInterval);
        }

    }
    IEnumerator IncreaseMinesCoroutine_ruby()
    {
        while (isRunning)
        {
            curentScore[3] += newMinesCount_ruby * minerPower[3];
            minesScoreText[3].text = curentScore[3].ToString();
            yield return new WaitForSeconds(scoreIncreaseInterval);
        }

    }
    IEnumerator IncreaseMinesCoroutine_sapphire()
    {
        while (isRunning)
        {
            curentScore[4] += newMinesCount_sapphire * minerPower[4];
            minesScoreText[4].text = curentScore[4].ToString();
            yield return new WaitForSeconds(scoreIncreaseInterval);
        }

    }


    private void Update()
    {
        if(newMinesCount_iron!=currentMinesCount_iron)
        {
            StartCoroutine(IncreaseMinesCoroutine_iron());
            currentMinesCount_iron = newMinesCount_iron;
        }
        if (newMinesCount_lead != currentMinesCount_lead)
        {
            StartCoroutine(IncreaseMinesCoroutine_lead());
            currentMinesCount_lead = newMinesCount_lead;
        }
        if (newMinesCount_gold != currentMinesCount_gold)
        {
            StartCoroutine(IncreaseMinesCoroutine_gold());
            currentMinesCount_gold = newMinesCount_gold;
        }
        if (newMinesCount_ruby != currentMinesCount_ruby)
        {
            StartCoroutine(IncreaseMinesCoroutine_ruby());
            currentMinesCount_ruby = newMinesCount_ruby;
        }
        if (newMinesCount_sapphire != currentMinesCount_sapphire)
        {
            StartCoroutine(IncreaseMinesCoroutine_sapphire());
            currentMinesCount_sapphire = newMinesCount_sapphire;
        }
    }

    
}
