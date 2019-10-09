﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class Rylie : MonoBehaviour
{
    public Tilemap mainGrid;
    private TileBase currentTile;
    Vector3Int currVect = Vector3Int.zero;
    Vector3Int prevVect = Vector3Int.zero; 

    
    private Vector3 movementDirection;
    [SerializeField]
    private float playerSpeed;
    private Sprite backSprite;
    private Sprite frontSprite; 
    private SpriteRenderer rylieSprite; 
    private Rigidbody2D rylieRB;
    private bool facingBack; 
    /*
    [SerializeField]
    private float moveSpeed = 3f;
    private float gridSize = 1f;
    private enum Orientation
    {
        Horizontal,
        Vertical
    };
    private Orientation gridOrientation = Orientation.Vertical;
    [SerializeField]
    private bool allowDiagonals = false;
    private bool correctDiagonalSpeed = true;
    private Vector2 input;
    private bool isMoving = false;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private float t;
    private float factor;
    */

    // Start is called before the first frame update
    void Start()
    {
        
        rylieSprite = this.gameObject.GetComponent<SpriteRenderer>();
        rylieRB = this.gameObject.GetComponent<Rigidbody2D>();
        backSprite = Resources.Load<Sprite>("Kid_SpriteBack");
        frontSprite = Resources.Load<Sprite>("Kid_SpriteFront");
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (currVect == Vector3Int.zero)
        {
            currVect = Vector3Int.FloorToInt(transform.position);
            currentTile = mainGrid.GetTile(currVect);
        }
        else
        {
            prevVect = currVect;
            currVect = Vector3Int.FloorToInt(transform.position);
            if (prevVect != currVect)
            {
                currentTile.name = "not in use";
            }
            currentTile = mainGrid.GetTile(currVect);

        }

        currentTile.name = "tile in use";
        if (!isMoving)
        {
            input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            if (!allowDiagonals)
            {
                if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
                {
                    input.y = 0;
                }
                else
                {
                    input.x = 0;
                }
            }

            if (input != Vector2.zero)
            {
                StartCoroutine(move(transform));
            }
            else
            {
                Debug.Log("YOLO");
            }
        }
        */

        if (!facingBack)
        {
            if (movementDirection.x < 0)
            {
                rylieSprite.flipX = false;
            }
            else if (movementDirection.x > 0)
            {
                rylieSprite.flipX = true;
            }
        }
        else
        {
            if (movementDirection.x < 0)
            {
                rylieSprite.flipX = true;
            }
            else if (movementDirection.x > 0)
            {
                rylieSprite.flipX = false;
            }
        }
        if(movementDirection.y > 0)
        {
            rylieSprite.sprite = backSprite;
            facingBack = true; 
        }
        else if(movementDirection.y < 0)
        {
            rylieSprite.sprite = frontSprite;
            rylieSprite.flipX = false; 
            facingBack = false; 
        }
        movementDirection = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        movementDirection.Normalize(); 

        rylieRB.MovePosition(transform.position + movementDirection * Time.deltaTime * playerSpeed);
        
        //transform.Translate(movementDirection*Time.deltaTime*playerSpeed);
    }

    /*
    public IEnumerator move(Transform transform)
    {
        isMoving = true;
        startPosition = transform.position;
        t = 0;

        if (gridOrientation == Orientation.Horizontal)
        {
            endPosition = new Vector3(startPosition.x + System.Math.Sign(input.x) * gridSize,
                startPosition.y, startPosition.z + System.Math.Sign(input.y) * gridSize);
        }
        else
        {
            endPosition = new Vector3(startPosition.x + System.Math.Sign(input.x) * gridSize,
                startPosition.y + System.Math.Sign(input.y) * gridSize, startPosition.z);
        }

        if (allowDiagonals && correctDiagonalSpeed && input.x != 0 && input.y != 0)
        {
            factor = 0.7071f;
        }
        else
        {
            factor = 1f;
        }

        while (t < 1f)
        {
            t += Time.deltaTime * (moveSpeed / gridSize) * factor;
            transform.position = Vector3.Lerp(startPosition, endPosition, t);
            yield return null;
        }

        isMoving = false;
        yield return 0;
    }
    */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("COLLIDED");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("COLLIDED");
    }
}
