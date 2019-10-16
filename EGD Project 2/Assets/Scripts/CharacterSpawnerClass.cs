using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawnerClass : MonoBehaviour
{
    public GameObject playerPrefab;
    public Transform[] spawnLocations;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Instantiate(playerPrefab);
        player.transform.position = spawnLocations[SceneTransitionClass.spawnPoint].position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
