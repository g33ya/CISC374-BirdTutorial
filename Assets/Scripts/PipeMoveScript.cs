using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public float moveSpeed = 10;
    public float deadZone = -45;
    private LogicScript logic;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

    }

    void Update()
    {
        if (!logic.gameStarted) return;  // Don't move pipes until the game starts

        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        if (transform.position.x < deadZone) 
        {
            Debug.Log("Pipe Deleted");
            Destroy(gameObject);
        }
    }
}
