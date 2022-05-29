using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    //bala aliada "bals"
    public GameObject bullet;
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
    public void Start()
    {
        
        balascon = 0;  
        balas = new List<GameObject>();       
    }

        public void Fire(){
            //codigo para crar bala el objeto creado se guarda em una lista"balas" para ser manipulado
         balas.Add(Instantiate(bullet,firePoint.position,firePoint.rotation));
          balas[balascon].GetComponent<Rigidbody2D>().AddForce(firePoint.right*fireForce,ForceMode2D.Impulse);
          balascon = balascon + 1;
        }

         public void VelBuff()
         {//codigo para generar un icono "velBuff" dentro del juego se guarda en una variable para poder manipularla
          velBuffIco =  Instantiate(velBuff,new Vector3(-5,3,0),firePoint.rotation);
         buffcon = buffcon + 1;
        }
        public void Update()
        {
            //para conocer si se a generado un icono den pantalla
            if(buffcon>0)
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
                //izquierda    
               if(balas[i].transform.position.x > 11 )
                {
                    //tp de la bala
                balas[i].transform.position = balas[i].transform.position + new Vector3(-21.5f,0,0);
                //cambio de sprite de la bala
               balas[i].GetComponent<SpriteRenderer>().sprite = enemy;
               //etiqueta para enemigo generado
               balas[i].tag = "ballenemy";
               

                

                }
                //derecha
                 if(balas[i].transform.position.x < -11 )
                {
                balas[i].transform.position = balas[i].transform.position + new Vector3(+21.5f,0,0); 
                               balas[i].GetComponent<SpriteRenderer>().sprite = enemy;
                                              balas[i].tag = "ballenemy";



                }
                //abajo
                 if(balas[i].transform.position.y < -5 )
                {
                balas[i].transform.position = balas[i].transform.position + new Vector3(0,+9.7f,0); 
                               balas[i].GetComponent<SpriteRenderer>().sprite = enemy;
                                              balas[i].tag = "ballenemy";



                }
                //arriba
                 if(balas[i].transform.position.y > 5 )
                {
                balas[i].transform.position = balas[i].transform.position + new Vector3(0,-9.7f,0); 
                               balas[i].GetComponent<SpriteRenderer>().sprite = enemy;
                                              balas[i].tag = "ballenemy";



                }
            }
            }
        
        }
    

}
