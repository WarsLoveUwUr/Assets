using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;
    private int balascon;
    List<GameObject> balas;
    public Sprite enemy;
    
    
     

    public float fireForce;
    public void Start()
    {
        balascon = 0;
        balas = new List<GameObject>();       
    }

        public void Fire(){
          balas.Add(Instantiate(bullet,firePoint.position,firePoint.rotation));
          balas[balascon].GetComponent<Rigidbody2D>().AddForce(firePoint.right*fireForce,ForceMode2D.Impulse);
          balascon = balascon + 1;
        }
        public void Update()
        {
           
            for(int i = 0; i <balas.Count;i++)
            {
                if(balas[i]){
               if(balas[i].transform.position.x > 11 )
                {
                balas[i].transform.position = balas[i].transform.position + new Vector3(-21.5f,0,0);
               balas[i].GetComponent<SpriteRenderer>().sprite = enemy;
               balas[i].tag = "ballenemy";
               

                

                }
                 if(balas[i].transform.position.x < -11 )
                {
                balas[i].transform.position = balas[i].transform.position + new Vector3(+21.5f,0,0); 
                               balas[i].GetComponent<SpriteRenderer>().sprite = enemy;
                                              balas[i].tag = "ballenemy";



                }
                 if(balas[i].transform.position.y < -5 )
                {
                balas[i].transform.position = balas[i].transform.position + new Vector3(0,+9.7f,0); 
                               balas[i].GetComponent<SpriteRenderer>().sprite = enemy;
                                              balas[i].tag = "ballenemy";



                }
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
