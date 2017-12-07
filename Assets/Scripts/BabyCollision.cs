using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyCollision : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Boomerang")
        {
            Debug.Log("Collision with baby");
            DestroyObject(gameObject);            
        }
    }
}
