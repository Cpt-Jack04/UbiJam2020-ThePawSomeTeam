using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMusicBox : MonoBehaviour
{

    public List<AudioClip> list = new List<AudioClip>();
    public AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playSound(int audioInput)
    {
        source.clip = list[audioInput];
        source.Play();
    }
}
