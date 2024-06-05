using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    public float movSpeed;

    private float moveHorizontal, moveVertical;
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal") * movSpeed;
        moveVertical = Input.GetAxisRaw("Vertical") * movSpeed;
        rb.velocity = new Vector2(moveHorizontal, moveVertical);

        Vector2 direction = new Vector2 (moveHorizontal, moveVertical);
        FindObjectOfType<PlayerAnimation>().SetDirection(direction);
    }
}
