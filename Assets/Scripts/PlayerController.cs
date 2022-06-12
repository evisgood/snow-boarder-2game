using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float backTorqueAmount = -1f;
    [SerializeField] float boostSpeed = 40f;
    [SerializeField] float baseSpeed = 20f;

    Rigidbody2D rb2d;

    SurfaceEffector2D surfaceEffector2D;

    // Start is called before the first frame update
    void Start()
    {   // mechanism called GetComponent<> 
        // for getting a reference to a component
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RotatePLayer();
        RespondToBoost();
    }

    
        void RespondToBoost()
        {
            // if we push up, then speed up
            // otherwise stay at normal speed
            // access the surfaceEffector2D and change its speed
            if(Input.GetKey(KeyCode.UpArrow))
            {
                surfaceEffector2D.speed = boostSpeed;
            }
            else
            {
                surfaceEffector2D.speed = baseSpeed;
            }
        }

    void RotatePLayer()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmount);
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(backTorqueAmount);
        }
    }
}
