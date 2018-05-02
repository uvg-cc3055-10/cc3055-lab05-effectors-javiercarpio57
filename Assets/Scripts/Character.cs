using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour {

    public GameObject feet;
    public LayerMask layerMask;
    private Vector2 startingPosition;

    public GameObject gem;

    Rigidbody2D rb2d;
    SpriteRenderer sr;
    Animator anim;
    private float speed = 5f;
    private float jumpForce = 250f;
    private bool facingRight = true;
 


	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        startingPosition = new Vector2(rb2d.position.x, rb2d.position.y);
    }
	

	void Update () {
        float move = Input.GetAxis("Horizontal");
        if (move != 0) {
            rb2d.transform.Translate(new Vector3(1, 0, 0) * move * speed * Time.deltaTime);
            facingRight = move > 0;
        }

        anim.SetFloat("Speed", Mathf.Abs(move));

        sr.flipX = !facingRight;

        if (Input.GetButtonDown("Jump")) {
            RaycastHit2D raycast = Physics2D.Raycast(feet.transform.position, Vector2.down, 0.1f, layerMask);

            if(raycast.collider != null)
            {
                rb2d.AddForce(Vector2.up * jumpForce);
            }
        }
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Door1"))
        {
            Debug.Log("Puertaaaa");
            SceneManager.LoadScene("Dungeon2");
        }
        if (collision.tag.Equals("Door2"))
        {
            Debug.Log("Puertaaaa");
            SceneManager.LoadScene("Dungeon3");
        }
        if (collision.tag.Equals("gem"))
        {
            GameObject.Destroy(gem);
        }
        if (collision.tag.Equals("Enemy"))
        {
            Debug.Log("Enemigooo");
            rb2d.position = startingPosition;
        }
    }
}
