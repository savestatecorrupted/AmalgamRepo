using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class oneWayPlatform : MonoBehaviour

    //This code will allow the player to fall through one-way platforms by double tapping the Down Arrow Key
{

    private PlatformEffector2D effector;
    private const float doubleTapTime = 0.3f;
    private float firstButtonTap;
    private float timeSinceLastTap;
    private float rotateBackTime;
    

    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    void Update()
    {
        //code to down jump by hitting Down Key twice
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            timeSinceLastTap = Time.time - firstButtonTap;
            if(timeSinceLastTap <= doubleTapTime) //double tap
            {
                effector.rotationalOffset = 180f;
                Invoke("FlipBack", 0.3f);
            }
            firstButtonTap = Time.time;
        }

        if (Input.GetKey(KeyCode.Space))    //If the player jumps, make sure the platform is one-way up
        {                                   //that way they won't bonk their head
            effector.rotationalOffset = 0f;
        }

    }

    void FlipBack() //flips the platforms back from fall-though to solid after 0.3 seconds.
    {
        effector.rotationalOffset = 0;
    }

}
