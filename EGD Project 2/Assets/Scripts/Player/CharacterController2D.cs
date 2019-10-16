using System.Collections;
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

    public static void MoveCharacter(Rigidbody2D obj, Vector3 origin, Vector3 movementVect)
    {
        obj.MovePosition(origin + movementVect);

    }


    public static Vector3 MoveCharacterTowards(Vector3 origin, Vector3 target, float speed)
    {
        //public static void MoveCharacter(Rigidbody2D obj, Vector3 origin, )
        return Vector3.MoveTowards(origin, target, speed*Time.deltaTime);
    }
}
