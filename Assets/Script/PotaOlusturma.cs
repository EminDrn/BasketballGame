using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotaOlusturma : MonoBehaviour
{
   float ydegeri ;
    GameObject pota;
    GameObject pota2;

    // Start is called before the first frame update
    void Start()
    {
        pota = GameObject.Find("hoop"); 
        pota2 = GameObject.Find("hoop2"); 
        
    }

    // Update is called once per frame
    void Update()
    {
      ydegeri = Random.Range(3f,7f);
        

    }
    private void OnTriggerEnter(Collider other)
    {
        
     //  transform.rotation = Quaternion.Euler(270,270,0);
        
        
        //transform.Rotate(270,0,0);
        //Instantiate(pota);
        if (pota2.activeInHierarchy == false){
            pota.SetActive(true);
        }
        if (pota.activeInHierarchy == true) {
           pota.SetActive(false);
            pota2.SetActive(true);
            pota2.transform.position = new Vector3(-0.81f,ydegeri,-4.18f);
            
        }
        else if (pota2.activeInHierarchy == true) {
            pota2.SetActive(false);
            pota.SetActive(true);
            pota.transform.position = new Vector3(0.844f,ydegeri,-4.18f);

        }
      

    }
}
