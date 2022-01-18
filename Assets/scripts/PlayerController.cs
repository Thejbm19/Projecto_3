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

    public ParticleSystem explosionParticleSystem;
    public ParticleSystem runParticleSystem;

    public AudioClip jumpClip;
    public AudioClip deathClip;

    private AudioSource playerAudioSource;
    private AudioSource cameraAudioSource;

    private int lives  = 3;  // total de vidas

    void Start()
    {
        gameOver = false; // per si reiniciam joc
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();//Accedim al component de animator des player
        playerAudioSource = GetComponent<AudioSource>();
        cameraAudioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();  // cercar audio de sa camara

        Physics.gravity *= gravityModifier;

        lives = 3;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnTheGround && gameOver == false)
        {

            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnTheGround = false;
            playerAnimator.SetTrigger("Jump_trig"); //accedeix a sa animacio de saltar cuando esta corriendo,  es sa condicio per donarse s'animacio
            runParticleSystem.Stop();
            playerAudioSource.PlayOneShot(jumpClip, 1);
        }
    }

    private void OnCollisionEnter(Collision otherCollider)
    {
        if (!gameOver)
        {
            if (otherCollider.gameObject.CompareTag("ground"))
            {
                isOnTheGround = true;
                runParticleSystem.Play();

            }

            if (otherCollider.gameObject.CompareTag("obstaculo"))
            {
                Destroy(otherCollider.gameObject);
                lives--; // lives -= 1;
                if (lives <= 0)
                {
                    Gameover();
                }
                else
                {
                    playerAnimator.SetTrigger("Crash_trig");
                }
                
            }






        }
    }

    private void Gameover()
    {           
        gameOver = true;
              int randomDeath = Random.Range(1, 3);
                playerAnimator.SetBool("Death_b", true);         // Condicio 1 per morir booleana
                playerAnimator.SetInteger("DeathType_int", randomDeath);   // Condicio 2 per triar quina mort si 1 o 2 o random


                explosionParticleSystem.Play();
                runParticleSystem.Stop();
                // ParticleSystem explosionEscena = Instantiate(explosionParticleSystem, transform.position + new vector3(0, 1.5f, 0) o --> fer una variable que agafi es valor, explosionParticleSystem.transform.rotation) ; por si le metes un prefab de particle en ves de ponerlo en escena
                // explosionEscena.Play();

                //Reproducir el SFX de la explosion
                playerAudioSource.PlayOneShot(deathClip, 1);

                //Bajar el volumen musica
                cameraAudioSource.volume = 0.01f;
    }


               
    
}
