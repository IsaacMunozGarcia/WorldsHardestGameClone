using UnityEngine;

public class OnOff : MonoBehaviour
{
    [SerializeField] private bool blockOn = false;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Onoff();
        }
    }

    private void Onoff()
    {
        blockOn = !blockOn;
        gameObject.GetComponent<BoxCollider2D>().enabled = blockOn;
        Transform child = transform.GetChild(0);
        SpriteRenderer sr = child.GetComponent<SpriteRenderer>();
        sr.enabled = blockOn;
    }
}
