using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class BoomerangController : MonoBehaviour {

    public float fSpeed;             //Floating point variable to store the player's movement speed.
    private short sPoints;            // Short variable to store the number of points the player has.
    private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.        
    private Vector2 force;
    private Transform trans;
    private Quaternion qRotation;
    private Vector3 ZAxis;
    private GameObject[] GameObjects;
    public Image ScreenOverlay;
    public Button PlayAgain;
    public Button ExitGame;

    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.       
        rb2d = GetComponent<Rigidbody2D>();
        trans = GetComponent<Transform>();       
        force = new Vector2(0, 0);
        ZAxis = new Vector3(0, 0, 1);
        GameObjects = GameObject.FindGameObjectsWithTag("Pickup");
        sPoints = 0;
        ScreenOverlay.gameObject.SetActive(false);
        PlayAgain.gameObject.SetActive(false);
        ExitGame.gameObject.SetActive(false);        
    }

    // Update is called every frame
    void Update()
    {
        // Win Check
        if (ScreenOverlay.isActiveAndEnabled == false)
        {
            if (sPoints == GameObjects.Length)
            {
                Debug.Log("You've saved all those ugly babies!");
                rb2d.velocity = new Vector2(0, 0);
                ScreenOverlay.gameObject.SetActive(true);
                PlayAgain.gameObject.SetActive(true);
                ExitGame.gameObject.SetActive(true);                
            }
        }       
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        if (ScreenOverlay.isActiveAndEnabled == false)
        {
            // Controls
            if (Input.GetKey(KeyCode.A))
            {
                if (Input.GetKey(KeyCode.W))
                {
                    force.x = (-fSpeed * 0.7071f);
                    force.y = (fSpeed * 0.7071f);
                    trans.rotation = Quaternion.AngleAxis(45, ZAxis);
                    rb2d.velocity = force;
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    force.x = (-fSpeed * 0.7071f);
                    force.y = (-fSpeed * 0.7071f);
                    trans.rotation = Quaternion.AngleAxis(135, ZAxis);
                    rb2d.velocity = force;
                }
                else
                {
                    force.x = -fSpeed;
                    force.y = 0;
                    trans.rotation = Quaternion.AngleAxis(90, ZAxis);
                    rb2d.velocity = force;
                }
            }
            else if (Input.GetKey(KeyCode.D))
            {
                if (Input.GetKey(KeyCode.W))
                {
                    force.x = (fSpeed * 0.7071f);
                    force.y = (fSpeed * 0.7071f);
                    trans.rotation = Quaternion.AngleAxis(-45, ZAxis);
                    rb2d.velocity = force;
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    trans.rotation = Quaternion.AngleAxis(-135, ZAxis);
                    force.x = (fSpeed * 0.7071f);
                    force.y = (-fSpeed * 0.7071f);
                    rb2d.velocity = force;
                }
                else
                {
                    force.x = fSpeed;
                    force.y = 0;
                    trans.rotation = Quaternion.AngleAxis(-90, ZAxis);
                    rb2d.velocity = force;
                }
            }
            else if (Input.GetKey(KeyCode.S))
            {
                force.x = 0;
                force.y = -fSpeed;
                trans.rotation = Quaternion.AngleAxis(180, ZAxis);
                rb2d.velocity = force;
            }
            else if (Input.GetKey(KeyCode.W))
            {
                force.x = 0;
                force.y = fSpeed;
                trans.rotation = Quaternion.AngleAxis(0, ZAxis);
                rb2d.velocity = force;
            }            
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Pickup")
        {            
            AddToPoints(1);
            AddToSpeed(0.3f);
            Debug.Log("Points:" + sPoints);
            Debug.Log("Speed:" + fSpeed);
        }
        else
        {
            Debug.Log("Boomerange had a collision.");
            rb2d.velocity = new Vector2(0, 0);
            ScreenOverlay.gameObject.SetActive(true);
            PlayAgain.gameObject.SetActive(true);
            ExitGame.gameObject.SetActive(true);
        }
    }

    public void AddToPoints(short _s)
    {
        sPoints += _s;
    }

    public void AddToSpeed(float _f)
    {
        fSpeed += _f;
    }

    public short GetPoints()
    {
        return sPoints;
    }

    public float GetSpeed()
    {
        return fSpeed;
    }
}
