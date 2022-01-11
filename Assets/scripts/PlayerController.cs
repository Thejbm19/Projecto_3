using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    private Animator playerAnimator;
    [SerializeField] private float jumpForce = 400f;
    public float gravityModifier = 1;
    private bool isOnTheGround = true;
    public bool gameOver;
   
    void Start()
    {
        gameOver = false; // per si reiniciam joc
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();//Accedim al component de animator des player
        

        Physics.gravity *= gravityModifier;
    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnTheGround && gameOver == false)
        {
           
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnTheGround = false;
            playerAnimator.SetTrigger("Jump_trig"); //accedeix a sa animacio de saltar cuando esta corriendo,  es sa condicio per donarse sa animacio

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
            gameOver = true;
            int randomDeath = Random.Range(1, 3);
            playerAnimator.SetBool("Death_b", true);         // Condicio 1 per morir booleana
            playerAnimator.SetInteger("DeathType_int", randomDeath);   // Condicio 2 per triar quina mort si 1 o 2
         } 

       




    }
}
