using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private CharacterController controller;
    public float speed = 10f;
    public float gravity = -9.81f;
    public int PlayerHealth = 100;

    private Vector3 gravityVector;

    //GroundCheck
    public Transform groundCheckPoint;
    public float groundCheckRadius = 0.35f;
    public LayerMask groundLayer;

    public bool isGrounded = false;

    public float jumpHeight = 7f;

    //UI
    public Slider healthSlider;
    public Text healthText;
    public CanvasGroup damageScreen;

    private GameManager gameManager;
    public AudioSource playerHurtSound;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        gameManager = FindObjectOfType<GameManager>();
        damageScreen.alpha = 0f; 
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        GroundCheck();
        JumpAndGravity();
        DamageScreenCleaner();
        
        
    }

     void MovePlayer()
    {
        Vector3 moveVector = Input.GetAxis("Horizontal") * transform.right + Input.GetAxis("Vertical") * transform.forward;
        controller.Move(moveVector * speed * Time.deltaTime);
    }

    void GroundCheck()
    {
        isGrounded = Physics.CheckSphere(groundCheckPoint.position, groundCheckRadius, groundLayer);
    }

    void JumpAndGravity()
    {
        gravityVector.y += gravity * Time.deltaTime;
        controller.Move(gravityVector * Time.deltaTime);


        if (isGrounded && gravityVector.y < 0)
        {
            gravityVector.y = -3f;
        }
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            gravityVector.y = jumpHeight;
        }
    }
    public void PlayerTakeDamage(int DamageAmount)
    {
        PlayerHealth -= DamageAmount;
        healthSlider.value -= DamageAmount;
        HealthTextUpdate();
        damageScreen.alpha = 1f;
        playerHurtSound.Play();

        if (PlayerHealth <= 0)
        {
            PlayerDeath();
            healthSlider.value = 0;
            HealthTextUpdate();
        }
    }

    void DamageScreenCleaner()
    {
        if(damageScreen.alpha > 0)
        {
            damageScreen.alpha -= Time.deltaTime;
        }
    }
    void PlayerDeath()
    {
        gameManager.Restart();
    }

    void HealthTextUpdate()
    {
        healthText.text = PlayerHealth.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("EndTrigger"))
        {
            gameManager.WinLevel();
        }
        
    }
}
