using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyOWAI : MonoBehaviour
{
    public float speed = 0.5f;
    public float aggroSpeed = 2f;
    public Transform target;//set target from inspector instead of looking in Update
    
    Vector3 oldPosition;
    Vector3 newPosition;

    public int randomNum;
 
    void Start ()
    {
        PositionChange();
    }
 
    void PositionChange()
    {
        newPosition = new Vector2(Random.Range(-5.0f, 5.0f), Random.Range(-5.0f, 5.0f));
    }
   
    void Update ()
    {
        if(Vector2.Distance(transform.position, newPosition)<1f){
            newPosition = new Vector2(Random.Range(-5.0f, 5.0f), Random.Range(-5.0f, 5.0f));
            new WaitForSeconds(randomNum);
        }
        
        if(Vector2.Distance(target.position, transform.position) > 1f) {
            transform.position += ((target.position-transform.position)*aggroSpeed*Time.deltaTime);
        }
        
        transform.position=Vector3.Lerp(transform.position,newPosition,Time.deltaTime*speed);

        LookAt2D(newPosition);
    }
 
    void LookAt2D(Vector3 lookAtPosition)
    {
        float distanceX = lookAtPosition.x - transform.position.x;
        float distanceY = lookAtPosition.y - transform.position.y;
    }
}
