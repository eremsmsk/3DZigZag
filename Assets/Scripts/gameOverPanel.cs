using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameOverPanel : MonoBehaviour
{
    public Text txtScore;
    public Text txtBest;
    public int score { get; private set; }
    public int best { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        LoadHighScore();

        score = PlayerPrefs.GetInt("cry");
        txtScore.text = score.ToString();


        if (score > best)
        {
            //Debug.Log("İf içerisine girdi score " + score);
            best = score;
            //Debug.Log("best score : " + best);

            txtBest.text = best.ToString();
            PlayerPrefs.SetInt("best", best);
        }
        else
        {
            //Debug.Log("else içerisine girdi best : " + best);

            best = PlayerPrefs.GetInt("best");
            txtBest.text = best.ToString();
        }
        //Debug.Log("dışarı best " + best);
        //Debug.Log("dışarı score " + score);
        score = 0;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LoadHighScore()
    {
        best = PlayerPrefs.GetInt("best");   
        txtBest.text = best.ToString();
    }


}
