using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 6;
    private float timer = 0;
    public float heightOffset = 10;
    public LogicScript logicScript;

    void Start()
    {
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    void Update()
    {
        if (logicScript != null && logicScript.gameStarted) // Only spawn pipes if the game has started
        {
            timer += Time.deltaTime;

            if (timer < spawnRate)
            {
                timer += Time.deltaTime;
            } else {
                spawnPipe();
                timer = 0;
            }
        } 
    }

    void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset - 2;
        float highestPoint = transform.position.y + heightOffset - 4;

        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}
