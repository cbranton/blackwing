using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleHandler : MonoBehaviour
{
    void Start()
    {
        HealthSystem healthSystem = new HealthSystem(100);

        Debug.Log("Health: "+healthSystem.getHealth());
        healthSystem.Damage(10);
        Debug.Log("Health: "+healthSystem.getHealth());
        healthSystem.Heal(10);
        Debug.Log("Health: "+healthSystem.getHealth());
    }

}
