using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other){
        Destroy(gameObject,1);
    }
    public void OnTriggerStay(Collider other){
        if(other.gameObject.CompareTag("piano") && gameObject != null){
            Destroy(gameObject);
        }
    }
}
