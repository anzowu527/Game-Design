using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarTrigger : MonoBehaviour
{
    public GameObject Panel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            float speed = other.GetComponent<Rigidbody>().velocity.magnitude;
            if (speed > 70)
            {
                Panel.SetActive(true);
            }
        }
    }
}
