using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField]
    public GameObject Right, Left, Restart,Bucket;
    // Start is called before the first frame update
    void Start()
    {
        Restart.SetActive(false);
    }
    public void DisableObjects()
    {
        Right.SetActive(false);
        Left.SetActive(false);
        Restart.SetActive(true);
        Bucket.SetActive(false);
    }
    public void EnableObjects()
    {
        Right.SetActive(true);
        Left.SetActive(true);
        Restart.SetActive(false);
        Bucket.SetActive(true);

    }

}
