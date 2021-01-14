using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneHandling : MonoBehaviour
{
   public void onLoadScene(string _sceneName)
    {
        SceneManager.LoadScene(_sceneName);
    }
}
