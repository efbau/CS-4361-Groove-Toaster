using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{

    void Awake() {
        EventManager.StartListening("despawn", Despawn);
    }

    void Despawn()
    {
        Destroy(gameObject, 2f);
    }

    
}
