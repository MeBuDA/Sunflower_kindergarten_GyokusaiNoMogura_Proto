using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackScene : MonoBehaviour
{
    public string backSceneName;
    // Start is called before the first frame update
    void Start()
    {
        
    }
#if !UNITY_EDITOR
    void Update()
    {
       if(OVRInput.GetDown(OVRInput.Button.Back))
       {
           SceneManager.LoadScene(backSceneName);
       } 
    }
#endif
#if UNITY_EDITOR
void Update()
    {
       if(Input.GetKeyDown(KeyCode.Space))
       {
           SceneManager.LoadScene(backSceneName);
       } 
    }
#endif
}
