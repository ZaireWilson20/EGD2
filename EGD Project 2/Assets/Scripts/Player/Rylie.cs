using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rylie : MonoBehaviour
{

    private Vector3 movementDirection;
    [SerializeField]
    private float playerSpeed;
    private SpriteRenderer rylieSprite; 
    private Rigidbody2D rylieRB; 
    // Start is called before the first frame update
    void Start()
    {
        rylieSprite = this.gameObject.GetComponent<SpriteRenderer>();
        rylieRB = this.gameObject.GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (movementDirection.x < 0)
        {
            rylieSprite.flipX = false;
        }
        else if(movementDirection.x > 0)
        {
            rylieSprite.flipX = true; 
        }
        movementDirection = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        movementDirection.Normalize(); 

        rylieRB.MovePosition(transform.position + movementDirection * Time.deltaTime * playerSpeed);
        //transform.Translate(movementDirection*Time.deltaTime*playerSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("COLLIDED");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("COLLIDED");
    }
}
