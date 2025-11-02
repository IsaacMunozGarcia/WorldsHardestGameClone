using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private float speed;
    [SerializeField] private int scene;
    [SerializeField] private int goalScene;
    [SerializeField] private int requiredCoins;

    private int coins = 0;
    private Vector3 initialPosition;
    public bool onIce = false;

    private void Start()
    {
        initialPosition = transform.position;
    }
    
    void Update()
    {
        Movement();
    }
    
    private void Movement()
    {
        movementDirection();
        void movementDirection()
        {
            
            float hInput = Input.GetAxisRaw("Horizontal");//-1, 0, 1 DEPENDING ON THE AXIS
            float vInput = Input.GetAxisRaw("Vertical");

            Vector3 movementDirection = new Vector3(hInput, vInput, 0f).normalized;
        
            //this.gameObject.transform.Translate(movementDirection * speed * Time.deltaTime);
        
            transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);

        }
        
    }
    //YOU NEED both of the objects to have a collider MANDATORY
    //AT LEAST one of them should be checked as trigger (ghost)
    //AT LEAST one of them should have a rigidbody (the moving Object)
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            UpdateCoins(other);
        }
        
        //I want to take into consideration the interaction with the traps
        //If you're interacting with a trap go to the initial position.
        
        else if (other.gameObject.CompareTag("Trap"))
        {
            transform.position = initialPosition;
            SceneManager.LoadScene(scene);
        }
        
        else if (other.gameObject.CompareTag("Goal"))
        {
            if (coins == requiredCoins)
            {
                SceneManager.LoadScene(goalScene);
            }
        }
        
    }
    
    private void UpdateCoins(Collider2D other)
    {
        Destroy(other.gameObject);
        coins++; //+1 coin
        scoreText.text = "Score: " + coins;
    }
}
