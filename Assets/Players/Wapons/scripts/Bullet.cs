using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour

{
    //bala alida en escena
    public GameObject acolli;
    
  

    //public GameObject impactEffect;
    // Start is called before the first frame update
    
     public void Start(){
        // rend = GetComponent<SpriteRenderer>();
        
    }
    //identifica cuando la balas son tocadas
     void OnTriggerEnter2D(Collider2D other) {
        
        switch(other.gameObject.tag)
        {
            //destruye bala
            case "player":Destroy(gameObject);
            break;
            //destruye bala
            case"enemy":Destroy(gameObject);
            break;
            //destruye el objeto si se toca la bala rosa
            case"ShVeloBuffo":Destroy(gameObject);
            break;
            case"ballenemy":
            //compara si la bala aliada es tocada por una bala enemiga
            //si las TAGs fueran iguales la balas del mismo  tipo se destruirian por ejemplo enemigo con enemigo 
            //alido con aliado
            if(other.gameObject.tag != acolli.tag)
            {
                Destroy(gameObject);
            }
            
            break;
            //compara si la bala enemiga es tocada por un bala alidada 
            case"ball":
            if(other.gameObject.tag != acolli.tag)
            {
                Destroy(gameObject);
            }
            
            break;

        } 
    }
    

    public void Impact(){
        //Instantiate(impactEffect, transform.position,Quaternion.identity);
        //Destroy(gameObject);
    }
}
