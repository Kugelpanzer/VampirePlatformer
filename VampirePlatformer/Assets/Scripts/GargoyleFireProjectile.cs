using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GargoyleFireProjectile : MonoBehaviour
{


    public float attackCooldown = 3;
    public GameObject projectile;
    public float projetileSpeed = 10;

    float elapsedTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        elapsedTime+= Time.deltaTime;
        if (elapsedTime >= attackCooldown)
        {
            elapsedTime = 0;
            GameObject clone;
            clone = Instantiate(projectile, transform.position, transform.rotation);
            clone.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(Vector3.left * projetileSpeed);
        }
    }
}
