using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroundContact : MonoBehaviour
{
    FruitePooling fruitePooling;

    [SerializeField]
    public int _errorCount;
    public bool _endGame;

    [SerializeField]
    //GameObject _restart;
    CanvasManager canvasManager;
    PlayerBucket playerScript;
    Text _txtLife;
    AudioPlayer _audioPlayer;
    GameObject go;

    // Start is called before the first frame update


    void Start()
    {
        _errorCount = 10;
        go = GameObject.FindGameObjectWithTag("Player");
        playerScript = go.GetComponent<PlayerBucket>();
        fruitePooling = GameObject.Find("PoolingManager").GetComponent<FruitePooling>();
        canvasManager = GameObject.Find("Canvas").GetComponent<CanvasManager>();
        _txtLife = GameObject.FindGameObjectWithTag("Lifeline").GetComponent<Text>();
        _audioPlayer = GameObject.Find("AudioManager").GetComponent<AudioPlayer>();

        //   _restart.SetActive(false);
        _endGame = true;
    }

    // Update is called once per frame
    void Update()
    {
        _txtLife.text =_errorCount.ToString();
        if (_errorCount <= 0)
        {
            ResetGame();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag== "Fruite")
        {
            _errorCount--;
            collision.gameObject.SetActive(false);
            fruitePooling._drop = true;
            _audioPlayer._audioSource.clip= _audioPlayer._Drop;
            _audioPlayer._audioSource.Play();
        }
    }

    private void ResetGame()
    {
        if (FruitePooling.current._backgroundSong.isPlaying)
        {
            FruitePooling.current._backgroundSong.Stop();
        }
        _endGame = false;

        playerScript._fruiteCount = 0;

        for (int i = 0; i < fruitePooling._Fruits_Pool.Count; i++)
        {

            if (fruitePooling._Fruits_Pool[i].gameObject.activeInHierarchy)
            {
                fruitePooling._Fruits_Pool[i].SetActive(false);
            }

        }
        _errorCount = 5;
    
        canvasManager.DisableObjects();
    }



    public void Restart()
    {
        _endGame = true;
        canvasManager.EnableObjects();
        go.transform.position = new Vector2(0, 4.4f);
        if (!FruitePooling.current._backgroundSong.isPlaying)
        {
            FruitePooling.current._backgroundSong.Play();
        }
    }
}
