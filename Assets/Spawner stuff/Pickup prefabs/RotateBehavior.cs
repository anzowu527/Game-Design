using UnityEngine;

public class RotateBehavior : MonoBehaviour
{
    public float rotateSpeed = 100f; // The speed of the rotation

    void Update()
    {
        transform.Rotate(0f, rotateSpeed * Time.deltaTime, 0f); // Rotate around the Y-axis
    }
}