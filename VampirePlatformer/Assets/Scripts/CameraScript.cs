using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject player;
    public float horizontalDistance=0, verticalDistance=0;
    private Vector2 playerDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerDistance = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
        if(playerDistance.x > horizontalDistance)
        {
            transform.Translate(new Vector2(playerDistance.x-horizontalDistance,0));
        }
        else if (playerDistance.x < -horizontalDistance)
        {
            transform.Translate(new Vector2(playerDistance.x + horizontalDistance, 0));

        }
        if (playerDistance.y > verticalDistance)
        {
            transform.Translate(new Vector2(0,playerDistance.y - verticalDistance));
        }
        else if (playerDistance.y < -verticalDistance)
        {
            transform.Translate(new Vector2(0,playerDistance.y + verticalDistance));
        }

    }
}
