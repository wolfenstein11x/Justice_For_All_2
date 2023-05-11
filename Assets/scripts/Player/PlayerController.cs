using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Joystick joystick;
    [SerializeField] float maxHorizontalSpeed = 5f;
    [SerializeField] float maxJumpSpeed = 5f;
    [SerializeField] float timeBetweenShots = 0.25f;

    private Animator playerAnimator;
    private Rigidbody2D playerRigidbody;
    private BoxCollider2D feetCollider;
    private LayerMask jumpableSurface;
    private MuzzleFlash muzzleFlash;

    private bool readyToShoot;
    private bool allowInvoke;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        feetCollider = GetComponent<BoxCollider2D>();
        jumpableSurface = LayerMask.GetMask("Ground"); // | LayerMask.GetMask("Climbing") | LayerMaks.GetMask("") ...
        muzzleFlash = GetComponentInChildren<MuzzleFlash>();
        readyToShoot = true;
        allowInvoke = true;
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        Jump();
        FlipSprite();
        

        
        
    }

    private void Run()
    {
        // get player speed from joystick input
        float horizontalSpeed = joystick.Horizontal * maxHorizontalSpeed;
        
        // move player according to speed
        Vector2 playerVelocity = new Vector2(horizontalSpeed, playerRigidbody.velocity.y);
        playerRigidbody.velocity = playerVelocity;

        // adjust player animation according to absolute value of speed
        playerAnimator.SetFloat("horizontalSpeed", Mathf.Abs(horizontalSpeed));
    }

    private void FlipSprite()
    {
        if (Mathf.Abs(joystick.Horizontal) > Mathf.Epsilon)
        {
            transform.localScale = new Vector2(Mathf.Sign(playerRigidbody.velocity.x) * 1f, 1f);
        }
    }

    private void Jump()
    {
        bool onJumpableSurface = (feetCollider.IsTouchingLayers(jumpableSurface));

        if (!onJumpableSurface) return;
       
        if (joystick.Vertical >= 0.3f)
        {
            Vector2 playerVelocity = new Vector2(playerRigidbody.velocity.x, maxJumpSpeed);
            playerRigidbody.velocity = playerVelocity;
        }

    }

    public void Shoot()
    {
        if (!readyToShoot) return;

        readyToShoot = false;

        playerAnimator.SetTrigger("shoot");
        muzzleFlash.Fire();

        if (allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShots);
            allowInvoke = false;
        }
    }

    private void ResetShot()
    {
        readyToShoot = true;
        allowInvoke = true;
    }
}
