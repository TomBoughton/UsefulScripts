using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick : MonoBehaviour
{

    
    
    //This sets the movement vector to the origin (0,0)
    public Vector2 movementVector = Vector2.zero;
    
    
    
    //This sets the maximum distance that the joystick can move
    public float maxDistance = 0.1f;
    

    // Update is called once per frame
    void Update()
    {



        //check to see if there are any touches on the screen
        if (Input.GetKey(KeyCode.Mouse0))
        {
            //get the position in world space of the touch position
            //Sets innerJoystickPos as a 2D vector
            Vector2 innerJoystickPos;
            //Sets the Joystick position at a position on the screen
            innerJoystickPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            //move the joystick button to the touch position
            transform.position = innerJoystickPos;
        }


        //If the screen is not being touched, do this
        else if (Input.touchCount < 1)
        {
            //if the screen isn't being touched, revert to initial position
            transform.localPosition = Vector2.zero;
        }
        

        //If the screen is being touched, do this
        if (Input.touchCount > 0)
        {
            //get the position in world space of the touch position
            Touch newTouch = Input.GetTouch(0);
            //Sets innerJoystickPos to be a 2D vector
            Vector2 innerJoystickPos;
            //Sets the Joystick position at a position on the screen
            innerJoystickPos = new Vector2(Camera.main.ScreenToWorldPoint(newTouch.position).x, Camera.main.ScreenToWorldPoint(newTouch.position).y);
            //move the joystick button to the touch position
            transform.position = innerJoystickPos;
        }



        //If there is no input, do this
        else if (!Input.GetKey(KeyCode.Mouse0))
        {
            //if the screen isn't being touched, revert to initial position
            transform.localPosition = Vector2.zero;
        }


        //This keeps the joystick in its circle
        transform.localPosition = Vector2.ClampMagnitude(transform.localPosition, maxDistance);
        //normalize local vector by keeping it pointing in one direction
        movementVector = new Vector2(transform.localPosition.x * (1/maxDistance), transform.localPosition.y * (1/maxDistance));
        //This keeps the joystick always on the top layer, so it is always visable
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, -0.1f);
    }
}
