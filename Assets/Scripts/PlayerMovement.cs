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

    // Power-up variables
    private float originalRunSpeed;
    private bool isSpeedBoosted = false;

    // Start is called before the first frame update
    void Start()
    {
        originalRunSpeed = runSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
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
        yield return new WaitForSeconds(duration);
        runSpeed = originalRunSpeed;
        isSpeedBoosted = false;
    }

    // Method to apply the speed boost
    public void ApplySpeedBoost(float boostAmount)
    {
        runSpeed += boostAmount;
        isSpeedBoosted = true;
    }
}