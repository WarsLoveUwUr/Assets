using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JoystickIzquierdo : MonoBehaviour
{
    //variables para el movimiento del joystick

    public GameObject joystick;
    public GameObject joystickBG;
    public Vector2 joystickVec;
    private Vector2 joystickTouchPos;
    private Vector2 joystickOriginalPos;
    private float joystickRadius;

    //caja de texto para pruebas
    public Text texto;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        //valores iniciales del joystick
        joystickOriginalPos = joystickBG.transform.position;
        joystickRadius = joystickBG.GetComponent<RectTransform>().sizeDelta.y / 5;
        


    }

    public void PointerDown()
    {
        //imprime valores en caja de texto derecha
         texto.GetComponent<Text>().text = Input.touchCount.ToString();
         //if para saber si se esta tocando la pantalla

        if (Input.touchCount > 0)
        {
            //for generado con respecto a la cantidad de dedos en pantalla
            for(int i=0 ;i<Input.touchCount;i++){
                //conocer que dedo esta tocando el joystick
           if(i < 2){
               //tomar posicion del joystick con respecto al dedo
            Touch toch = Input.GetTouch(i);
            joystick.transform.position =toch.position;
            joystickBG.transform.position =toch.position;
            joystickTouchPos = toch.position;
        }

        }
        }
        //joystick para pc
        else
        {
        joystick.transform.position = Input.mousePosition;
        joystick.transform.position =  Input.mousePosition;
        joystickBG.transform.position = Input.mousePosition;
        joystickTouchPos = Input.mousePosition;
    }
        

        
        
        
    }

    public void Drag(BaseEventData baseEventData)
    {
        //seguimiento del joystick con respecto al dedo
        PointerEventData pointerEventData = baseEventData as PointerEventData;
        Vector2 dragPos = pointerEventData.position;
        joystickVec = (dragPos - joystickTouchPos).normalized;

        float joystickDist = Vector2.Distance(dragPos, joystickTouchPos);

        if (joystickDist < joystickRadius)
        {
            joystick.transform.position = joystickTouchPos + joystickVec * joystickDist;
        }

        else
        {
            joystick.transform.position = joystickTouchPos + joystickVec * joystickRadius;
        }
    }

    public void PointerUp()
    {
        //joystcik regresa a posicion original
        joystickVec = Vector2.zero;
        joystick.transform.position = joystickOriginalPos;
        joystickBG.transform.position = joystickOriginalPos;
        //actualiza valores de caja de texto izquierda
        texto.GetComponent<Text>().text = "ssss"+Input.touchCount.ToString();
       
             

       
                  



        
    }

}