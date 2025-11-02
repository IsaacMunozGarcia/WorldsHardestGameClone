using UnityEngine;

public class IceMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    
    private float hInput;
    private float vInput;
    private bool onIce = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ice"))
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                hInput = Input.GetAxis("Horizontal");
                vInput = 0;
            }
            else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            {
                vInput = Input.GetAxis("Vertical");
                hInput = 0;
            }

            onIce = true;
            GetComponent<Player>().enabled = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Ice"))
        {
            Vector3 movementDirection = new Vector3(hInput, vInput, 0f).normalized;
            transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ice"))
        {
            GetComponent<Player>().enabled = true;
            onIce = false;
            
            hInput = 0;
            vInput = 0;
        }
    }
}