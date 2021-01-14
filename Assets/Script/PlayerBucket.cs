using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBucket : MonoBehaviour
{
    [SerializeField]
    public int _fruiteCount;

    AudioPlayer _audioPlayer;
    Rigidbody2D _bucketBody;
    private float speed=3f;
    Text _txtScore;
    float _maxLeft = -1.8f, maxRight = 1.8f;
    void Start()
    {
        _bucketBody = gameObject.GetComponent<Rigidbody2D>();
        _txtScore = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        _audioPlayer = GameObject.Find("AudioManager").GetComponent<AudioPlayer>();
            
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _txtScore.text = _fruiteCount.ToString();     
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fruite")
        {          
            _audioPlayer._audioSource.clip = _audioPlayer._Collect;
            _audioPlayer._audioSource.Play();
            collision.gameObject.SetActive(false);
            _fruiteCount++;
        }
    }

    public void OnRightClick()
    {
        if (transform.position.x < maxRight)
        {
            print("Roght gong");
            _bucketBody.velocity = Vector2.right * speed;
        }

    }
    public void OnLeftClick()
    {
        if (transform.position.x > _maxLeft)
        {
            _bucketBody.velocity = Vector2.left * speed;
        }

    }

    
}
