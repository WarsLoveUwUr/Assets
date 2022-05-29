using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buffs : MonoBehaviour
{
    
    public bool BuffoVelocidad;
    // Start is called before the first frame update
    void Start()
    {
        
        BuffoVelocidad = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //colider del icono
     void OnTriggerEnter2D(Collider2D other) {
        
        switch(other.gameObject.tag)
        {
            // player toca el icono y se destruye
            case "player":Destroy(gameObject);
            BuffoVelocidad = true;
            break;
            //
            
           

        } 

    }

}
