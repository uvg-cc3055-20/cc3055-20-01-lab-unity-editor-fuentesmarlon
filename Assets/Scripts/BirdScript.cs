using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour {
    //fuerza del salto 
    public float jumpForce=10f;
    Rigidbody2D rb;
    //velocidad de movimiento
    public float forwardSpeed = 2f;
    //Acceso a la camara 
    public GameObject cam;
    //Colision 
    public bool dead = false;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (dead == false)
        {
            //afuera porque se tiene que hacer siempre
            rb.transform.Translate(new Vector3(1, 0, 0) * forwardSpeed * Time.deltaTime);
        //camara lo siga 
        cam.transform.Translate(new Vector3(1, 0, 0) * forwardSpeed * Time.deltaTime);
        
            if (Input.GetButtonDown("Jump"))
            {
                rb.velocity = Vector2.zero;
                rb.AddForce(new Vector2(0, 1) * jumpForce);
            }
        }
        if (rb.transform.position.x>45)
        {
            dead = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Enviroment")
        {
            dead = true;
        }
        
        
    }
}
