using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField]
    public AudioClip _Collect, _Drop;
    public AudioSource _audioSource;
    
    // Start is called before the first frame update
   
    void Start()
    {
        _audioSource = gameObject.GetComponent<AudioSource>();
        _Collect = Resources.Load<AudioClip>("Audio/Collect");
        _Drop = Resources.Load<AudioClip>("Audio/Drop");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
