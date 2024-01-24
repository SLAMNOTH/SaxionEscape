using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    bool crouch = false;
    public Animator animator;
    public AudioClip koffieSoundAfgelopen;
    public PowerUp powerup;
    public bool koffieSoundGespeeld;
    Rigidbody2D rigidbody2;

    private Gyroscope gyro;
    private bool gyroEnabled;
    // Power-up variables
    private float originalRunSpeed;
    private bool isSpeedBoosted = false;
    float dirX;
    float movespeed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        originalRunSpeed = runSpeed;
        rigidbody2 = gameObject.GetComponent<Rigidbody2D>();

        gyroEnabled = EnableGyro();
    }

    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            return true;
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gyroEnabled)
        {
            dirX = Input.acceleration.x * movespeed;
        }
        else
        {
            dirX = Input.acceleration.x * movespeed;
        }
        dirX = Mathf.Clamp(dirX, -1f, 1f);

        horizontalMove = dirX * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump" ))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;

        // Check if the speed boost is active
        if (isSpeedBoosted)
        {
            // You can add a timer or condition to revert the speed to the original value
            // For simplicity, let's say the boost lasts for 3 seconds
            StartCoroutine(ResetSpeedBoost(3f));
        }
    }

    IEnumerator ResetSpeedBoost(float duration)
    {
        koffieSoundGespeeld = false;
        yield return new WaitForSeconds(duration);
        runSpeed = originalRunSpeed;
        isSpeedBoosted = false;
        PlayCoffeeSound();

    }

    // Method to apply the speed boost
    public void ApplySpeedBoost(float boostAmount)
    {
        runSpeed += boostAmount;
        isSpeedBoosted = true;
    }

    public void PlayCoffeeSound()
    {
        if (koffieSoundGespeeld == false)
        {
            AudioSource.PlayClipAtPoint(koffieSoundAfgelopen, transform.position);
            koffieSoundGespeeld = true;
        }
    }
}

