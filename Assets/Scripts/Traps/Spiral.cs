using UnityEngine;

public class Spiral : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Vector3 rotationDirection;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        //Rotate all the time the death fan along an axis at X unit/s
        transform.Rotate(rotationDirection * rotationSpeed * Time.deltaTime);
    }
}
