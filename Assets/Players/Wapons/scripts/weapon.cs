using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    //bala aliada "bals"
    public GameObject bullet;
    //bala aliada "ShVeloBuff"
    public GameObject ShVeloBuff;
    //icono buff de velocidad
    public GameObject velBuff;
    //variable para almacenar icono de buff creado
    private GameObject velBuffIco;
    //posicion del "arma" en la nave
    public Transform firePoint;
    //contadores de objetos creado
    private int balascon,buffcon;
    //lista de los objetos creados
    List<GameObject> balas;
    //variable para enemigo
    public Sprite enemy;
    //fuerza de la bala
    public float fireForce;
    //variable que se usa para saber si el estado del player 
    public PlayerMove buffdVelocidad;
    //variable para saber si el disparo deve ser normal
    public bool normal;

    public void Start()
    {
        //se indica que se usara tiro normal
        normal = true;
        //contador de balas
        balascon = 0;  
        //inicia genera lista balas
        balas = new List<GameObject>();       
    }

        public void Fire(){
            //comparar si la variable "buffvelocidad" 
            if(buffdVelocidad.buffvelocidad)
            {
                normal = false;
            }
            else
            //si el buff de velocidad se acaba "normal" regresara a true
            {
                normal = true;
            }
            //codigo para crar bala el objeto creado se guarda em una lista"balas" para ser manipulado
            //se compara si el tiro que se quiere generar es normal
            if(normal)
            {
                //se genera la bala con respecto a "bullet" la bala amarilla
             balas.Add(Instantiate(bullet,firePoint.position,firePoint.rotation));
             //se añade una fuerza a la bala
            balas[balascon].GetComponent<Rigidbody2D>().AddForce(firePoint.right*fireForce,ForceMode2D.Impulse);


            }
            //se compara si el tiro que se va a generar es de un buff de velocidad
             if(buffdVelocidad.buffvelocidad)
            {
            balas.Add(Instantiate(ShVeloBuff,firePoint.position,firePoint.rotation));
            balas[balascon].GetComponent<Rigidbody2D>().AddForce(firePoint.right*50,ForceMode2D.Impulse);


            }
            //se crea una bala y se cuenta
         balascon = balascon + 1;
        }

         public void VelBuff()
         {//codigo para generar un icono "velBuff" dentro del juego se guarda en una variable para poder manipularla
          velBuffIco =  Instantiate(velBuff,new Vector3(-5,3,0),Quaternion.Euler(0,0,0));
         buffcon = buffcon + 1;
        }
        public void Update()
        {
            
            //if para saber si el icono que se genero no se ah destruido
            if(!velBuffIco)
            {
                buffcon = 0;
            }
            //para conocer si se a generado un icono den pantalla
            if(buffcon>0 && velBuff )
            {
                //mover icono
                velBuffIco.transform.position = velBuffIco.transform.position + new Vector3(.001f,0,0);

            }
            
           //bucle generaro con respecto a la cantidad de balas generadas
            for(int i = 0; i <balas.Count;i++)
            {
                //condicion para saber si la bala no esta destruidad
                if(balas[i]){
               //codigo para que las balas cambien de lugar llegando al limite
               //las balas de buffs se destruiran cuando lleguen al limite
                //derecha    
               if(balas[i].transform.position.x > 11 )
                {
                //tp de la bala
                balas[i].transform.position = balas[i].transform.position + new Vector3(-21.5f,0,0);
                //se compara si la bala que supero el limite es una bala rosa si es asi se destruira
                if( balas[i].tag == "ShVeloBuffo")
                    {
                         Destroy(balas[i]);
                    }
                //compara si la balla que llega al limite es una bala aliada o enemiga estas no se destruyen    
                if(balas[i].tag =="ball")
                    {
                        //codigo para cambiar etiqueta de la bala y su sprite
                        balas[i].GetComponent<SpriteRenderer>().sprite = enemy;
                        balas[i].tag = "ballenemy";
                    }
                    //codigo para lateral derecho de la pantalla se aplica lo mismo para los demas limites  x,y 
               

                

                }
                //izquierda
                 if(balas[i].transform.position.x < -11 )
                {
                    
                    balas[i].transform.position = balas[i].transform.position + new Vector3(+21.5f,0,0); 
                    if( balas[i].tag == "ShVeloBuffo")
                    {
                         Destroy(balas[i]);
                    }
                    
                    if(balas[i].tag =="ball")
                    {
                        balas[i].GetComponent<SpriteRenderer>().sprite = enemy;
                        balas[i].tag = "ballenemy";
                    }
               



                }
                //abajo
                 if(balas[i].transform.position.y < -5 )
                {
                balas[i].transform.position = balas[i].transform.position + new Vector3(0,+9.7f,0); 
                if( balas[i].tag == "ShVeloBuffo")
                {
                         Destroy(balas[i]);
                }
                    
                if(balas[i].tag =="ball")
                {
                        balas[i].GetComponent<SpriteRenderer>().sprite = enemy;
                        balas[i].tag = "ballenemy";
                }
                }
                //arriba
                 if(balas[i].transform.position.y > 5 )
                {
                balas[i].transform.position = balas[i].transform.position + new Vector3(0,-9.7f,0); 
                 if( balas[i].tag == "ShVeloBuffo")
                    {
                         Destroy(balas[i]);
                    }
                    
                    if(balas[i].tag =="ball")
                    {
                        balas[i].GetComponent<SpriteRenderer>().sprite = enemy;
                        balas[i].tag = "ballenemy";
                    }
               
                }
            }
            }
        
        }
    

}
//ulises se la come xD
