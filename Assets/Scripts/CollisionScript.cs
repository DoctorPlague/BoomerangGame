using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionScript : MonoBehaviour {    
    void OnTriggerEnter2D(Collider2D col)
    {        
        if (col.gameObject.name == "Boomerang")
        {
            Debug.Log("Collision with obstacle");
            //col.gameObject.transform.rotation = Quaternion.AngleAxis(0, new Vector3(0, 0, 1));
            //col.gameObject.transform.position = new Vector3((float)0.213, (float)-3.347, 0);            
            //col.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            //Debug.Log("Reloading scene..");
            //SceneManager.LoadScene("Main");
        }
    }
}
