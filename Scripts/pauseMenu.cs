using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour
{
    public GameObject equipMenu;
    public float counter = 0f;
    public bool isPaused = false;
    
    void Start(){
        equipMenu.GetComponent<Renderer>().enabled = false;
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Tab) && !isPaused){
            Pause();
            isPaused = true;
            Debug.Log("ack1");
        }
        else if(Input.GetKeyDown(KeyCode.Tab) && isPaused){
            Resume();
            isPaused = false;
            Debug.Log("ack2");
        }

    }

    public void Pause(){
        Time.timeScale = 0f;
        equipMenu.GetComponent<Renderer>().enabled = true;
    }
    public void Resume(){
        Time.timeScale = 1;
        equipMenu.GetComponent<Renderer>().enabled = false;
    }

}
