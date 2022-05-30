using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScena1 : MonoBehaviour
{
    public weapon weapon;   

    // Start is called before the first frame update
    void Start()
    {
         StartCoroutine(ExampleCoroutine());
         
    }
      IEnumerator ExampleCoroutine()
    {
        //espera unos segundos para generar un icono de buff.
        yield return new WaitForSeconds(2);
        //crea el icono del buff
        weapon.VelBuff();
        yield return new WaitForSeconds(10);
        //crea el icono del buff
        weapon.VelBuff();
        yield return new WaitForSeconds(10);
        //crea el icono del buff
        weapon.VelBuff();


        
    }

    // Update is called once per frame
    void Update()
    {
           
    }
}
