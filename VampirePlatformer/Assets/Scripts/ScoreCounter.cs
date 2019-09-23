using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public float Score = 100;
    public float FlyDrainPerSecond = 30;
    public float RegenPerSecond = 20;
    public float DrainPerSecond = 1;
    private TextMesh text;
    public GameObject player;
    public Text ScoreDisplay;
    private PlayerMovment playerMovement;
    // Start is called before the first frame update    

    void Start()    
    {
        playerMovement = player.GetComponent<PlayerMovment>();
        //text = GetComponent<TextMesh>();
    }
        
    // Update is called once per frame
    void Update()
    {
        


        bool isFlying = playerMovement.getFlyFlag();
        if (isFlying)
        {
            Score-= Time.deltaTime * FlyDrainPerSecond; 
        }

        if(Score <= 50)
        {
            Score += Time.deltaTime * RegenPerSecond;
        }
        else
        {
            Score -= Time.deltaTime * DrainPerSecond;
        }

        ScoreDisplay.text = Math.Floor(Score).ToString();
    }
}
