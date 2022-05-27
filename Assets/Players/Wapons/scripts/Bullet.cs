using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour

{
    public GameObject acolli;
    
  

    //public GameObject impactEffect;
    // Start is called before the first frame update
    
     public void Start(){
        // rend = GetComponent<SpriteRenderer>();
        
    }
     void OnTriggerEnter2D(Collider2D other) {
         Debug.Log("dddd");
        switch(other.gameObject.tag)
        {
            case "wall":Destroy(gameObject);
            break;
            case"enemy":Destroy(gameObject);
            break;
            case"ballenemy":
            if(other.gameObject.tag != acolli.tag)
            {
                Destroy(gameObject);
            }
            
            break;
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
