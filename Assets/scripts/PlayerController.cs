using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    [SerializeField] private float jumpForce = 400f;
    public float gravityModifier = 1;
    private bool isOnTheGround = true;
   
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
       
        Physics.gravity *= gravityModifier;
    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnTheGround)
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce);
            isOnTheGround = false;
        }
    }

    private void OnCollisionEnter(Collision otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("ground"))
        {
             isOnTheGround = true;
        }

         if (otherCollider.gameObject.CompareTag("obstaculo"))
         {
            Destroy(gameObject);
         }
        
           
        
        
    }
}
