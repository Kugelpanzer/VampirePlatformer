using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreList : MonoBehaviour
{

    List<string> Names = new List<string>();

    List<int> Scores = new List<int>();
    public Text currScore;
    // Start is called before the first frame update
    void Start()
    {
        currScore.text = PlayerPrefs.GetInt("CurrentScore", 0).ToString();
    }
    public void AddScore(InputField nameTxt)
    {
        string name;
        if (nameTxt.text != "")
            name = nameTxt.text;
        else
            name = "Player";
        int score = PlayerPrefs.GetInt("CurrentScore", 0);
        for (int i = 0; i < 5; i++)
        {
            Scores.Add( PlayerPrefs.GetInt("Score" + i.ToString(),0) );
            Names.Add(PlayerPrefs.GetString("Name" + i.ToString(),""));
        }
        for (int i = 0; i < 5; i++)
        {
            if (score > Scores[i])
            {
                Scores.Insert(i, score);
                Names.Insert(i, name);
            }
        }
        for (int i = 0; i < 5; i++)
        {
            PlayerPrefs.SetInt("Score" + i.ToString(), Scores[i]);
            PlayerPrefs.SetString("Name" + i.ToString(), Names[i]);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
