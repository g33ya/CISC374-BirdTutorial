using UnityEngine;
using UnityEngine.InputSystem;

public class BirdScript : MonoBehaviour
{
    public LogicScript logic;
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public bool birdIsAlive = true;
    public AudioSource flapSound;
    public DeathFlashScript deathFlashScript; 

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        myRigidbody.gravityScale = 0;  // Stops bird from falling before game starts!
        GetComponent<SpriteRenderer>().enabled = false; // Make bird invisible before game starts
    }

    void Update()
    {
        if (!logic.gameStarted) 
        {
            return;  // Don't move bird until the game starts
        } 
        else 
        {
            myRigidbody.gravityScale = 1;  
            GetComponent<SpriteRenderer>().enabled = true; // make bird visible
        }
        
        if (Input.GetKeyDown(KeyCode.Space) == true && birdIsAlive)
        {
            myRigidbody.linearVelocity = Vector2.up * flapStrength;
            if (flapSound != null && birdIsAlive) 
            {
                flapSound.Play();
            }
        }   
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        logic.gameOver();
        birdIsAlive = false;

        if (deathFlashScript != null) {
            deathFlashScript.TriggerFlash(); // Trigger death flash when bird hits pipe
        } else {
            Debug.LogError("DeathFlashScript reference is missing!");
        }
    }

    // "Game Over" condition occurs when the bird goes off screen
    void OnBecameInvisible()
    {   
        Debug.Log("Bird went off screen!");
        logic.gameOver();
    }
}
