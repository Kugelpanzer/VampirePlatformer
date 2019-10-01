using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour
{
    public List<Text> Score = new List<Text>();
    public List<Text> Name = new List<Text>();
    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i < 5; i++)
        {
           Score[i].text= PlayerPrefs.GetInt("Score" + i.ToString(),0 ).ToString();
           Name[i].text= PlayerPrefs.GetString("Name" + i.ToString(),"" );
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
