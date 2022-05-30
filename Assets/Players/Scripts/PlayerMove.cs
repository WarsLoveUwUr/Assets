using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //variables para el manejo del player
    //joystick izquierdo
    public JoystickIzquierdo movementJoystick;
    //joystick derecho
    public Joystick movementJoystick2;
    //velocidad en que se mueve el jugador
    public float playerSpeed;
    //comopoente rigibody del player
    private Rigidbody2D rb;
    //propiedad transform del player
    public Transform tr;
    //dif para rotacion del player
    public float dif;
    //aura de velocidad "AuraVelocidad" en carpeta
    public GameObject auraVelo;
    //crear lista de aura veloz
    List<GameObject> veloci;

    //contador del buff de velocidad
    public int buffveloCon;
    //vairbale para hacer rotar la aura
    public int rotarBuff;
    //variable para iundicar a este y otros scripts que se ah tocado el icono del buff de velocidad
    public bool buffvelocidad;
    //variable para saber si hay un aura creada
    public bool destruido;
    

    

    


    // Start is called before the first frame update
    void Start()
    {
        //valores iniciales de variables
        veloci = new List<GameObject>();       

        //rotar aura inicial
        rotarBuff = 0;      
        //al inicia el player no tiene buf por eso es falso  
        buffvelocidad = false;
        destruido = true;
        //incicia contador de buff de velocidad
        buffveloCon = 0;
        //velocidad incial del player
        playerSpeed = 7;
        //se inicia rigibody
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //compara si se a tocado  el buff de velocidad
        if(buffvelocidad)
        {
        //condicion que funciona como seguro para solo crear una aurade velocidad sobre el jugador  
          if(destruido == true){
              //como se creo un objeto esto regresa a false
            destruido = false;
        //se crea el aura de velocidad 
          veloci.Add(Instantiate(auraVelo,tr.position,tr.rotation));
          }
          
          //se iguala la posicion del aura con la del jugador
          veloci[buffveloCon].transform.position = tr.position;
          //la rotacion actualiza su valor con respecto a un contador
          veloci[buffveloCon].transform.rotation =  Quaternion.Euler(0,0,rotarBuff);
          // se indica que ya se ah generado una aura
          
          //contador que hara rotar el aura
          rotarBuff = rotarBuff - 1;
          //si el contador llega e -500 significa que el buff a acbado
          if(rotarBuff == -250)
          {
              rotarBuff = 0;
              //desturye el aura
              Destroy(veloci[buffveloCon]);
              //la variable para este y otros scripts cambia a falso
              buffvelocidad = false;
              //el contador del aura regresa aumenta uno
              buffveloCon =  buffveloCon +1;
              //indica que el objeto se destruyo
              destruido = true;

          }

        }
        if (movementJoystick.joystickVec.y != 0)
        {
            //codigo para mover al player a otro lugar en dado caso que llegue al limite
            rb.velocity = new Vector2(movementJoystick.joystickVec.x * playerSpeed, movementJoystick.joystickVec.y * playerSpeed);
            //izquierda
            if(tr.position.x < -8.5)
            {
                rb.position = rb.position + new Vector2(17f,0); 
            }
            //derecha
             if(tr.position.x > 8.5)
            {
                rb.position = rb.position + new Vector2(-17f,0); 
            }
            //abajo
              if(tr.position.y < -5.5)
            {
                rb.position = rb.position + new Vector2(0,11f); 
            }
            //arriba
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
    void OnTriggerEnter2D(Collider2D other) 
    {
    //codigo para saber si el player a tocado el buff de velocidad
        switch(other.gameObject.tag)
        {
        case "VelocidadBuff":
        Debug.Log("ddd");
        buffvelocidad = true;
        break;
        }
    }
   

}
