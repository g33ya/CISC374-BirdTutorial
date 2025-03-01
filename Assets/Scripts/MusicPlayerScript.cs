using UnityEngine;

public class MusicPlayerScript : MonoBehaviour
{
    public AudioSource music;

    void Start()
    {
        if (music != null)
        {
            music.Play();
        }
    }
}
