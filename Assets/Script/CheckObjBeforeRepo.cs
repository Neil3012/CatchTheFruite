using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckObjBeforeRepo : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isRepo = true;
    CheckObjBeforeRepo current;

    void Start()
    {
        if (current != null)
        {
            current = this;
        }
        isRepo = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fruit")
        {
            isRepo = false;
        }
       
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
