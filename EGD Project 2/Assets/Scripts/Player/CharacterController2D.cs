﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void MoveCharacter(Rigidbody2D obj, Vector3 origin, Vector3 movementVect){
        obj.MovePosition(origin + movementVect);

    }
}
