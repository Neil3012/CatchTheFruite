using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitePooling : MonoBehaviour
{
    [System.Serializable]
    public class _FruitPool
    {
        public string tag;
        public GameObject _prefab;
        public int _size;
    }
    public List<_FruitPool> _Fruits_List;
    [SerializeField]
    public List<GameObject> _Fruits_Pool;

    GroundContact ground;


    public static FruitePooling current;

    public AudioSource _backgroundSong;
    AudioClip audioClip;

    private int _maxAllowedFruit=5,maxFruitBuffer=0;//not Used maxallowed fruits 
 
 
    float max_X_pos = -2.5f, max_X_pos_Left = 2.5f;
    public bool _drop,_delay;

    [SerializeField]
    private List<GameObject> _Fruits;

    float timer = 0f;


    void Start()
    {
        _backgroundSong = gameObject.GetComponent<AudioSource>();
        audioClip = Resources.Load<AudioClip>("Audio/GameBackground");
        _backgroundSong.clip = audioClip ;
        _backgroundSong.Play();
        ground = GameObject.Find("Ground").GetComponent<GroundContact>();
        current = this;
        InitializePool();
        _drop = true;
       
    }
    void InitializePool()
    {
        GameObject _parent = new GameObject();
        _parent.name = "Fruit_Pools";
        _parent.transform.position = Vector2.zero;
        _parent.transform.rotation = Quaternion.identity;
        foreach(_FruitPool pool in _Fruits_List)
        {
            for(int i=0;i< pool._size; i++)
            {              
                GameObject go = Instantiate(pool._prefab);
                go.SetActive(false);
                go.transform.parent = _parent.transform;
                _Fruits_Pool.Add(go);
            }
        }
        maxFruitBuffer = _Fruits_Pool.Count;
       
    }
    public GameObject g1, g2;
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
       DropFruits();

        //if (g1.renderer.bounds.Intersects(g2.bounds))
        //{
        //    ]
        //}
       
    }
    Vector2 vector;
    float randomrange;
    int num;
    void DropFruits()
    {
        if (_drop && ground._endGame )
        {
            randomrange = Random.Range(max_X_pos, max_X_pos_Left);
            vector = new Vector2(randomrange, 6f);
            num = Random.Range(0, maxFruitBuffer);
            if (timer >= 0.5)
            {
                if (!_Fruits_Pool[num].gameObject.activeInHierarchy)
                {
                    _Fruits_Pool[num].SetActive(true);
                    _Fruits_Pool[num].transform.position = vector;
                }
                timer -= 0.5f;

            }
        }
               
         
        
    }
   
}
