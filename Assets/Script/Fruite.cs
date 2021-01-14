using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruite : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D froot;
 
    // Start is called before the first frame update
    void Start()
    {
        froot = gameObject.GetComponent<Rigidbody2D>();
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fruite")
        {
            collision.gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (froot != null)
            froot.velocity = new Vector2(froot.velocity.x, -1f);
    }
    private void OnDisable()
    {
       // print(gameObject.name);
    }
    
}
