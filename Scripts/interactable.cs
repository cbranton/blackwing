using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactable : MonoBehaviour
{
    public GameObject popup;
    public bool opened = false;
    public Collider2D newCollider;
    public string aquiredItem;

    void Start(){
        popup.GetComponent<Renderer>().enabled = false;
    }
    void Update(){
        OnTriggerEnter2D(newCollider);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(Input.GetKeyDown(KeyCode.Return) && !opened){
            Debug.Log("Got " + aquiredItem+"!");
            Pause();
            opened = true;
        }
        else if(Input.GetKeyDown(KeyCode.Return)){
            Debug.Log("Interactable Test - Close");
            Resume();
        }
        else if(Input.GetKeyDown(KeyCode.Return) && opened){
            Debug.Log("Empty");
            Pause();
            if(Input.GetKeyDown(KeyCode.Return)){
                Debug.Log("Interactable Test - Close");
                Resume();
            }
        }
        
    

    }
    public void Pause(){
        Time.timeScale = 0f;
        popup.GetComponent<Renderer>().enabled = true;
    }
    public void Resume(){
        Time.timeScale = 1;
        popup.GetComponent<Renderer>().enabled = false;
    }
}
