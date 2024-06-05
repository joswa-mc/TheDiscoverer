using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_Horiz : MonoBehaviour
{
    [SerializeField]
    public float movSpeed;

    private float moveHorizontal;
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal") * movSpeed;

        // Set the vertical movement to zero to restrict movement to horizontal only
        rb.velocity = new Vector2(moveHorizontal, 0);

        Vector2 direction = new Vector2(moveHorizontal, 0);
        FindObjectOfType<PlayerAnimation>().SetDirection(direction);
    }
}
