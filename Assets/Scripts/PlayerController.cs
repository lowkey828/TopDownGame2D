using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float bulletSpeed = 10f;
    public GameObject attackArea;
    public GameObject bulletPrefab;
    public Transform pulletArea;

    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector2 shootDirection;
    private Animator animator;
    private bool isAttacking;

    void Start()
    {
        attackArea.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        handleMovement();
        handleAttack();
        handleBullet();
    }

    void FixedUpdate()
    {
        if (isAttacking == false)
        {
            rb.linearVelocity = movement * moveSpeed;
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
    }

    void handleMovement()
    {
        if (isAttacking == false)
        {
            movement.x = Input.GetAxis("Horizontal");
            movement.y = Input.GetAxis("Vertical");

            movement.Normalize();

            if (movement.x > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (movement.x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }

            if (movement != Vector2.zero)
            {
                animator.SetBool("isRunning", true);
            }
            else
            {
                animator.SetBool("isRunning", false);
            }
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }

    void handleAttack()
    {
        if (Input.GetKeyDown(KeyCode.E) && isAttacking == false)
        {
            animator.SetTrigger("Attack1");
            isAttacking = true;
        }
    }

    void handleBullet()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(banDan());
        }
    }

    void StartAttack()
    {
        attackArea.SetActive(true);
    }

    void EndAttack()
    {
        isAttacking = false;
        attackArea.SetActive(false);
    }

    IEnumerator banDan()
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, pulletArea.position, Quaternion.identity);
            Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();

            if (movement.x > 0)
            {
                shootDirection = Vector2.right;
            }
            else if (movement.x < 0)
            {
                shootDirection = Vector2.left;
            }
            else if (movement.y > 0)
            {
                shootDirection = Vector2.up;
            }
            else if (movement.y < 0)
            {
                shootDirection = Vector2.down;
            }
            else
            {
                shootDirection = Vector2.right;
            }

            rbBullet.linearVelocity = shootDirection * bulletSpeed;

            Destroy(bullet, 0.5f);

            yield return new WaitForSeconds(0.2f);
        }
    }
}
