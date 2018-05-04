using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour {

    /*GameObject para detectar cuando toca el suelo.*/
    public GameObject feet;
    /*Determina si esta en contacto con tierra.*/
    public LayerMask layerMask;
    /*Posicion inicial de personaje*/
    private Vector2 startingPosition;

    /*Objeto Gema*/
    public GameObject gem;

    /*Cuerpo rigido de presonaje*/
    Rigidbody2D rb2d;
    /*Sprite renderer de personaje*/
    SpriteRenderer sr;
    /*Animaciones del personaje*/
    Animator anim;
    /*Velocidad de movimiento*/
    private float speed = 5f;
    /*Fuerza de salto*/
    private float jumpForce = 350f;
    /*Posicion de giro*/
    private bool facingRight = true;
 


	void Start () {
        /*Se obtienen los componentes del RigidBody, SpriteRenderer y Animator*/
        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        /*Se inicializa la posicion de inicio*/
        startingPosition = new Vector2(rb2d.position.x, rb2d.position.y);
    }
	

	void Update () {
        /*Determina hacia donde se mueve: Derecha o izquierda*/
        float move = Input.GetAxis("Horizontal");

        if (move != 0) {
            /*Desplaza al personaje horizontalmente*/
            rb2d.transform.Translate(new Vector3(1, 0, 0) * move * speed * Time.deltaTime);
            /*Determina hacia donde mira el personaje*/
            facingRight = move > 0;
        }

        /*Asinga la velocida para animacion*/
        anim.SetFloat("Speed", Mathf.Abs(move));

        /*Gira al personaje en X*/
        sr.flipX = !facingRight;

        if (Input.GetButtonDown("Jump")) {
            /*Salta unicamente si esta tocando el suelo*/
            RaycastHit2D raycast = Physics2D.Raycast(feet.transform.position, Vector2.down, 0.1f, layerMask);

            if(raycast.collider != null)
            {
                /*Salta si tiene contacto con el suelo*/
                rb2d.AddForce(Vector2.up * jumpForce);
            }
        }
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Door1"))
        {
            /*Dirige a escena Dungeon2 al tocar la puerta*/
            Debug.Log("Puertaaaa");
            SceneManager.LoadScene("Dungeon2");
        }
        if (collision.tag.Equals("Door2"))
        {
            /*Dirige a escena Dungeon3 al tocar la puerta*/
            Debug.Log("Puertaaaa");
            SceneManager.LoadScene("Dungeon3");
        }
        if (collision.tag.Equals("gem"))
        {
            /*Toma la gema al tocarla*/
            GameObject.Destroy(gem);
        }
        if (collision.tag.Equals("Enemy"))
        {
            /*Regresa a la posicion de inicio al tocar al enemigo.*/
            Debug.Log("Enemigooo");
            rb2d.position = startingPosition;
        }
    }
}
