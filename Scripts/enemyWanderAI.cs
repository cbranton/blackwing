using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyWanderAI : MonoBehaviour
{
    public float speed;
    public float aggroSpeed;
    public Transform target;
    public Collider2D aggroRange;
    public Collider2D combatRange;

    Vector2 newPosition;

    // Start is called before the first frame update
    void Start ()
    {
        PositionChange();
    }
 
    void Update(){
        if(OnTriggerEnter2D(aggroRange)){
            transform.position += ((target.position-transform.position)*aggroSpeed*Time.deltaTime);
        }
        else{
            PositionChange();
            transform.position=Vector2.Lerp(transform.position,newPosition,Time.deltaTime*speed);
            LookAt2D(newPosition);
        }
    }

    void PositionChange()
    {
        newPosition = new Vector2(Random.Range(-5.0f, 5.0f), Random.Range(-5.0f, 5.0f));
    }

    private bool OnTriggerEnter2D(Collider2D aggroTrig){
        return true;
    }

    void LookAt2D(Vector2 lookAtPosition)
    {
        float distanceX = lookAtPosition.x - transform.position.x;
        float distanceY = lookAtPosition.y - transform.position.y;
    }
}
