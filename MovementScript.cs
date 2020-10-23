using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    //This calls the joystick function that was just made
    public Joystick joystick;
    //This sets a float for the speed value. Set it to whatever you want, but its going to be 1 here
    public float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //use the normalized vector from the inner joystick script to get direction of movement, multiply by speed to actually move
        transform.Translate(joystick.movementVector * speed * Time.deltaTime);
    }
}
