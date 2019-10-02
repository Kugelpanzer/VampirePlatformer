using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    Animator anim;
    public GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        anim = button.GetComponent<Animator>();
    }
    public void Off()
    {
        anim.SetBool("ButtonSwitch", true);
    }
    public void On()
    {
        anim.SetBool("ButtonSwitch", false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
