using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleMusic : MonoBehaviour
{
    private bool toggle = false;
    public List<Sprite> sprites = new List<Sprite>();
    public GameObject audioSource;

    public void toggleMusic()
    {
        print("toggle" + toggle);
        if (toggle)
        {
            audioSource.GetComponent<AudioSource>().Play();
            GetComponent<Image>().sprite = sprites[0];
        }
        else
        {
            audioSource.GetComponent<AudioSource>().Stop();
            GetComponent<Image>().sprite = sprites[1];
        }
        toggle = !toggle;
    }
}
