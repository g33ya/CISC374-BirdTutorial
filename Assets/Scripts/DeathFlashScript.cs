using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DeathFlashScript : MonoBehaviour
{
    public Image flashImage;  
    public float flashDuration = 0.5f;  

    private void Start()
    {
        flashImage.gameObject.SetActive(false); // Hide red flash image
    }

    public void TriggerFlash()
    {
        Debug.Log("Flash Triggered!");
        flashImage.gameObject.SetActive(true); // show flash screen
        StartCoroutine(FlashEffectCoroutine());
    }

    // Allow the flash to be visible for flashDuration while game still runs (coroutine)
    private IEnumerator FlashEffectCoroutine() 
    {
        yield return new WaitForSeconds(flashDuration);
        flashImage.gameObject.SetActive(false); // Hide after flashDuration
    }
}
