using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasUp : MonoBehaviour
{

    private FuelManager mngr;
    // Start is called before the first frame update
    void Start()
    {
        mngr = GameObject.Find("FuelManager").GetComponent<FuelManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                if(mngr.fuel<=75f){
                    mngr.fuel+=25f;
                }
                else{
                    mngr.fuel+=(100f-mngr.fuel);
                }
                
                Destroy(gameObject);
            }
        }   
}
