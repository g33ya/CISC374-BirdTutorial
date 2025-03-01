using UnityEngine;

public class CeilingCollisionScript : MonoBehaviour
{
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Bird hit the ceiling!");
            other.GetComponent<BirdScript>().logic.gameOver();
        }
    }
}
   

