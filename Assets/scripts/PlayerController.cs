using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    [SerializeField] private float jumpForce = 400f;
    public float gravityModifier = 1;
   
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
       
        Physics.gravity *= gravityModifier;
    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce);
        }
    }
}
