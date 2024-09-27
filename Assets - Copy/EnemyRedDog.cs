using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRedDog : Enemy
{
    public Transform groundCheck;
    public Transform wallCheck;
    public float speed = 1;
    public float radius;
    private int direction = -1;
    public LayerMask layerToCheck;
    private bool detectGround;
    private bool detectWall;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Flip();
        rb.velocity = new Vector2(direction * speed, rb.velocity.y);
        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
    }

    private void Flip()
    {
        detectGround = Physics2D.OverlapCircle(groundCheck.position, radius, layerToCheck);
        detectWall = Physics2D.OverlapCircle(wallCheck.position, radius, layerToCheck);

        if (!detectGround || detectWall)
        {
            direction *= -1;
            transform.localScale = new Vector3(-transform.localScale.x, 1, 1);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, radius);
        Gizmos.DrawWireSphere(wallCheck.position, radius);
    }
}
