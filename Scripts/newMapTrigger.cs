using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class newMapTrigger : MonoBehaviour
{
    public Transform playerMapReloc;
    public Transform newMapPosition;
    public Collider2D mapCollider;

    void Update(){
        OnTriggerEnter2D(mapCollider);
    }

    void OnTriggerEnter2D(Collider2D newMap){
        if(newMap.CompareTag("Player")){
            playerMapReloc.position = newMapPosition.position;
        }
    }
}
