using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    float movementSpeed;

    [SerializeField]
    Transform[] movementPoints;

    [SerializeField]
    private bool cont = true;

    [SerializeField]
    float secondsTilNextMove = 2f; 
    Vector3 currentPosition;
    bool colliding = false; 


    Rigidbody2D npcRb; 


    void Start()
    {
        npcRb = this.gameObject.GetComponent<Rigidbody2D>(); 
        int ran = Random.Range(0, movementPoints.Length);
        transform.position = movementPoints[ran].position;
        currentPosition = transform.position;
        StartCoroutine(randomMove());

    }


    public IEnumerator randomMove()
    {
        while (cont)
        {
            int newPos = Random.Range(0, movementPoints.Length);

            currentPosition = movementPoints[newPos].position;
            yield return new WaitForSeconds(secondsTilNextMove);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position != currentPosition && !colliding)
        {
            transform.position = CharacterController.MoveCharacterTowards(transform.position, currentPosition, movementSpeed);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            colliding = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            colliding = false;
        }
    }
}
