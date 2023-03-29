using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopCarpisma : MonoBehaviour
{
    public GameObject top;
    public float xdegeri;
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        xdegeri = top.transform.position.x;
    }
  private void OnTriggerEnter(Collider collision)
  {
    
     top.transform.position = new Vector3(-xdegeri ,top.transform.position.y,top.transform.position.z);
  }
   /* IEnumerator ExampleCoroutine()
    {
       

      yield return new WaitForSeconds(1);

    }*/

    }

