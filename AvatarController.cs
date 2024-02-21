using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarController : MonoBehaviour
{
    public float moveSpeed = 5f; // speed at which the avatar moves

    void Update()
    {
        // get the horizontal and vertical input axis
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // calculate the movement direction based on the input axis
        Vector3 movementDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // calculate the movement vector based on the movement direction and move speed
        Vector3 movementVector = movementDirection * moveSpeed * Time.deltaTime;

        // apply the movement vector to the avatar's position
        transform.position += movementVector;
    }
}
