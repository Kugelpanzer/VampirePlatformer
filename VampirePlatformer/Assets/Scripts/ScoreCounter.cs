using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public int Score = 300;
    private TextMesh text;
    public GameObject player;
    private PlayerMovment playerMovement;
    // Start is called before the first frame update    

    void Start()    
    {
        playerMovement = player.GetComponent<PlayerMovment>();
        text = GetComponent<TextMesh>();
    }
        
    // Update is called once per frame
    void Update()
    {

        bool isFlying = playerMovement.getFlyFlag();
        if (isFlying)
        {
            Score--; 
        }
        text.text = Score.ToString();
    }
}
