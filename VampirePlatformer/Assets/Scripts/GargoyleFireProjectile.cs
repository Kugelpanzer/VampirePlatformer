using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GargoyleFireProjectile : MonoBehaviour
{


    public float attackCooldown = 3;
    public GameObject projectile;
    public float projetileSpeed = 10;
    public bool facingLeft = true;

    float elapsedTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        int sign = 1;
        float offsetX = 0.6F;
        if(!facingLeft)
        {
            sign = -1;
        }
        Vector3 offset = new Vector3(-1* offsetX* sign, 0, 0);
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= attackCooldown)
        {
            elapsedTime = 0;
            GameObject clone;
            clone = Instantiate(projectile, transform.position + offset, transform.rotation);
            clone.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(Vector3.left * sign *  projetileSpeed);
        }
    }
}
