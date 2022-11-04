using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Player : MonoBehaviour
{
    public float speed;

    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rb;

    private Vector2 movement;
    public int fruits;
    public Text fruitText;
    public Animator animator;

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Item>())
        {
            fruits++;
        }
        fruitText.text = fruits.ToString();
    }
}

