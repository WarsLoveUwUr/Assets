using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Joystick : MonoBehaviour
{
    //variables para el movimiento del joystick
    public GameObject joystick;
    public GameObject joystickBG;
    public Vector2 joystickVec;
    private Vector2 joystickTouchPos;
    private Vector2 joystickOriginalPos;
    private float joystickRadius;
    //prueba de texto
    public Text texto;
    //script de weapon
    public weapon weapon;   
    
    // Start is called before the first frame update
    void Start()
    {
        //valores iniciales del joystick
        joystickOriginalPos = joystickBG.transform.position;
        joystickRadius = joystickBG.GetComponent<RectTransform>().sizeDelta.y / 5;        
    }
    public void PointerDown()
    {   
        //muestra en caja de texto izquierda que dedo esta tocando el joystick
        texto.GetComponent<Text>().text = Input.touchCount.ToString();
        //condicion para saber si la pantalla a sido tocada
        if (Input.touchCount > 0)
        {
            
            //for se usa para hacer un bucle con respecto a las dedos que tienes en la pantalla

           for(int i=0 ;i<Input.touchCount;i++){
            //condicion para saber que dedo esta tocando el joystick
            if(i < 2){
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
        //codigo para el seguimiento del joystick con respecto al dedo
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
        //el joystick regresa a su posicion original
        joystickVec = Vector2.zero;
        joystick.transform.position = joystickOriginalPos;
        joystickBG.transform.position = joystickOriginalPos;
        //acutaliza caja de texto derecha  
        texto.GetComponent<Text>().text = Input.touchCount.ToString();
        weapon.Fire();
    }

}