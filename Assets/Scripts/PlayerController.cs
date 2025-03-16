using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpY;

    public int playerHealth;

    bool isJumping;

    private float moveX;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(speed * moveX, rb.velocity.y);

        if ( Input.GetButtonDown("Jump") && !isJumping )
        {
            rb.AddForce(new Vector2(rb.velocity.x, jumpY));
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }

        if (other.gameObject.CompareTag("End"))
        {
            FindAnyObjectByType<AudioManager>().PlaySound("GameOver");
            UIManager.Instance.GameOver();
        }

        if (other.gameObject.CompareTag("Finish") && UIManager.Instance.score == 90)
        {
            FindAnyObjectByType<AudioManager>().PlaySound("GameOver");
            UIManager.Instance.GameWon();
        }

    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }

    public void TakeDamage(int damage)
    {
        playerHealth -= damage;
        UIManager.Instance.UpdateHealth(playerHealth);

        if (playerHealth <= 0)
        {
            FindAnyObjectByType<AudioManager>().PlaySound("GameOver");
            UIManager.Instance.GameOver();
        }
    }

}
