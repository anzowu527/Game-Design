using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaBoxControllerLV2 : MonoBehaviour
{
    public float floatHeight = 218.5f; // height at which the object should float
    public float rotationSpeed = 10f; // speed at which the object should rotate
    public float tiltAngle = 15f; // angle at which the object should be tilted

    private bool isColliding = false; // flag to keep track of collisions

    void Update()
    {
        // rotate the object around its center
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.Self);

        // tilt the object along the x-axis
        transform.rotation = Quaternion.Euler(tiltAngle, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
    }

    void OnCollisionEnter(Collision collision)
    {
        // destroy the object if it collides with something
        if (!isColliding)
        {
            isColliding = true;
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        // calculate the position of the object based on the float height
        Vector3 floatPosition = new Vector3(transform.position.x, floatHeight, transform.position.z);

        // apply the calculated position to the object
        transform.position = floatPosition;
    }
}