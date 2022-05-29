using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public JoystickIzquierdo movementJoystick;
    public Joystick movementJoystick2;
    public float playerSpeed;
    private Rigidbody2D rb;
    public Transform tr;
    private float giro;
    public float giro2;
    public float dif;

    


    // Start is called before the first frame update
    void Start()
    {
        playerSpeed = 7;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (movementJoystick.joystickVec.y != 0)
        {
            
            giro +=giro2*playerSpeed;
            rb.velocity = new Vector2(movementJoystick.joystickVec.x * playerSpeed, movementJoystick.joystickVec.y * playerSpeed);
            if(tr.position.x < -8.5)
            {
                rb.position = rb.position + new Vector2(17f,0); 
            }
             if(tr.position.x > 8.5)
            {
                rb.position = rb.position + new Vector2(-17f,0); 
            }
              if(tr.position.y < -5.5)
            {
                rb.position = rb.position + new Vector2(0,11f); 
            }
              if(tr.position.y > 5.5)
            {
                rb.position = rb.position + new Vector2(0,-11f); 
            }
                        
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
        if (movementJoystick2.joystickVec.y != 0)
        {

               if(movementJoystick2.joystickVec.x<0){
                            dif = Mathf.Atan(movementJoystick2.joystickVec.y/-movementJoystick2.joystickVec.x)*180/3.1416f;

           tr.rotation = Quaternion.Euler(0,0,dif+(90-dif*2)+90);
          
                }
                else
                {
                     dif = Mathf.Atan(movementJoystick2.joystickVec.y/movementJoystick2.joystickVec.x)*180/3.1416f;

                     tr.rotation = Quaternion.Euler(0,0,dif);
                 }
        }
    }
   

}
