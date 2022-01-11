using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 30f;

    private PlayerController playerControllerScript;


    private void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }


    // Update is called once per frame
    void Update()
    {
        if (!playerControllerScript.gameOver) // ! es per dir si aixo es false
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
       
    }
}
