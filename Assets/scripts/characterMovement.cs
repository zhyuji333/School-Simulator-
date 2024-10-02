using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class characterMovement : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public float playerspeed;
    public Vector2 direction;
    public Vector2 direction1;
    private Animator animator;
    private bool isMoving;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        {
            float directionY = Input.GetAxisRaw("Vertical");
            float directionX = Input.GetAxisRaw("Horizontal");

            direction = new Vector2(directionX, directionY).normalized;
            if (direction.x != 0 || direction.y != 0)
            {
                isMoving = true;
            }
            else if (direction.x==0 && direction.y==0) 
            {
                isMoving=false;
            }
        }
        animator.SetBool("isMoving", isMoving);
    }
    void FixedUpdate()
    {
        {

            rigidbody.velocity = new Vector2(direction.x * playerspeed, direction.y * (playerspeed*Time.deltaTime));
            animator.SetFloat("moveX", direction.x);
            animator.SetFloat("moveY", direction.y);

        }
    }
}
//need to make it so body turns to the last direction it was facing 
