using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    public float boostMultiplier = 1.5f; // how much to boost the speed
    public float boostDuration = 5.0f; // how long the boost lasts
    private float boostTimeLeft = 0.0f;
    private float baseMaxSpeed;
    private float baseAcceleration;
    public ArcadeBikeController Controller; 
    private bool playerContact=false;

    void Start()
    {
        Controller = GameObject.Find("Player").GetComponent<ArcadeBikeController>();
        Debug.Log("Found player controller: " + Controller);
        Debug.Log("SpeedBoost script attached to object: " + gameObject.name);

        baseMaxSpeed = Controller.MaxSpeed;
        baseAcceleration = Controller.accelaration;
        Debug.Log("Base Speed Found: "+baseMaxSpeed);
        Debug.Log("Base Acceleration Found: "+baseAcceleration);
    }

    void FixedUpdate()
    {
        if(playerContact)
        {
            Debug.Log("Boost time left: " + boostTimeLeft);

            Controller.MaxSpeed = baseMaxSpeed*boostMultiplier;
            Controller.accelaration = baseAcceleration*boostMultiplier;
            Debug.Log("SPEED increase: "+Controller.MaxSpeed);
            Debug.Log("ACCEL increase: "+Controller.accelaration);
            boostTimeLeft -= Time.deltaTime;
            // 1.1:
            if(boostTimeLeft<=0){
                playerContact=false;
                Controller.MaxSpeed = baseMaxSpeed;
                Controller.accelaration = baseAcceleration;
            }
        }
        /*
        else
        {
            // This statement is running on ALL other instances of the object that have duration set to 0.0, constantly resetting the speed and accel!
            Controller.MaxSpeed = baseMaxSpeed;
            Controller.accelaration = baseAcceleration;
        }
        */
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerContact=true;
            boostTimeLeft = boostDuration;
            Debug.Log("boostTimeLeft set to: "+boostTimeLeft);
            // Destroy
            foreach (Transform child in transform){
                foreach (Transform child1 in child){
                    foreach (MeshRenderer renderer in child1.GetComponentsInChildren<MeshRenderer>()){
                        renderer.enabled = false;
                        Debug.Log("Disabled MeshRenderer: " + renderer);
                        }
                    }
                }
            
            Collider myCol = GetComponent<SphereCollider>();
            myCol.enabled=false;
            Destroy(gameObject,boostDuration+0.5f);
            
        }
    }
}
