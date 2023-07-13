using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Joystick joystick;
    [SerializeField] float maxHorizontalSpeed = 5f;
    [SerializeField] float maxJumpSpeed = 5f;
    [SerializeField] float jumpThreshold = 0.3f;
    [SerializeField] float enterExitBuildingThreshold = 0.1f;
    [SerializeField] float timeBetweenShots = 0.25f;
    [SerializeField] AmmoTracker ammoCountText;
    [SerializeField] AmmoTracker grenadeCountText;
    [SerializeField] AudioSource outOfAmmoSound;
    //[SerializeField] Vector2 hazardForce;

    private Animator playerAnimator;
    private Rigidbody2D playerRigidbody;
    private BoxCollider2D feetCollider;
    private LayerMask jumpableSurface;
    private OrientationTracker orientationTracker;
    private Shooter shooter;
    private PowerupShooter powerupShooter;
    private MeleeAttacker meleeAttacker;
    private PlayerHealth playerHealth;

    private bool readyToShoot;
    private bool allowInvoke;
    private bool dialogueMode = false;
    private bool jumpReset = true;
    public bool hasKey = false;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerHealth = GetComponent<PlayerHealth>();
        feetCollider = GetComponentInChildren<BoxCollider2D>();
        jumpableSurface = LayerMask.GetMask("Ground") | LayerMask.GetMask("Hazards") | LayerMask.GetMask("Breakables"); // ...
        readyToShoot = true;
        allowInvoke = true;
        orientationTracker = GetComponent<OrientationTracker>();
        shooter = GetComponent<Shooter>();
        powerupShooter = GetComponent<PowerupShooter>();
        meleeAttacker = GetComponent<MeleeAttacker>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth.IsDead()) return;

        Run();
        Jump();
        FlipSprite();

        // for debugging only
        meleeAttacker.InMeleeRange();

        
        
    }

    private void Run()
    {
        if (dialogueMode)
        {
            playerRigidbody.velocity = new Vector2(0f, playerRigidbody.velocity.y);
            playerAnimator.SetFloat("horizontalSpeed", 0f);
            return;
        }

        // get player speed from joystick input
        float horizontalSpeed = joystick.Horizontal * maxHorizontalSpeed;
        
        // move player according to speed
        Vector2 playerVelocity = new Vector2(horizontalSpeed, playerRigidbody.velocity.y);
        playerRigidbody.velocity = playerVelocity;

        // adjust player animation according to absolute value of speed
        playerAnimator.SetFloat("horizontalSpeed", Mathf.Abs(horizontalSpeed));
    }

    
    public void SetDialogueMode(bool status)
    {
        dialogueMode = status;
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
        if (joystick.Vertical < jumpThreshold)
        {
            jumpReset = true;
        }

        if (dialogueMode) return;

        bool onJumpableSurface = (feetCollider.IsTouchingLayers(jumpableSurface));

        if (!onJumpableSurface) return;

        if (!jumpReset) return;
       
        if (joystick.Vertical >= jumpThreshold)
        {
            Vector2 playerVelocity = new Vector2(playerRigidbody.velocity.x, maxJumpSpeed);
            playerRigidbody.velocity = playerVelocity;
            jumpReset = false;
        }
    }

    

    public void ShootButton()
    {
        // check if you are able to shoot
        if (!readyToShoot) return;

        // check if you have ammo
        if (!HasAmmo())
        {
            playerAnimator.SetTrigger("shoot");
            outOfAmmoSound.Play();
            return;
        }

        readyToShoot = false;

        // actual shooting happens here
        playerAnimator.SetTrigger("shoot");
        shooter.Shoot();
        ammoCountText.DecrementAmmo();


        // reset
        if (allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShots);
            allowInvoke = false;
        }
    }
    
    public void PowerupShootButton(int powerupIdx)
    {
        // check if you are able to shoot
        if (!readyToShoot) return;

        readyToShoot = false;
        
        // actual shooting happens here
        playerAnimator.SetTrigger("shoot");
        powerupShooter.ShootPowerupBlast(powerupIdx);

        //reset
        if (allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShots);
            allowInvoke = false;
        }
    }

    public void GrenadeButton()
    {
        // check if you have grenades
        if (!HasGrenades()) return;

        // actual grenade throwing happens in animation event
        playerAnimator.SetTrigger("throwGrenade");
        grenadeCountText.DecrementAmmo();
    }

    private bool HasAmmo()
    {
        return ammoCountText.GetAmmoCount() > 0;
    }

    private bool HasGrenades()
    {
        return grenadeCountText.GetAmmoCount() > 0;
    }

    

    public void MeleeButton()
    {
        playerAnimator.SetTrigger("stab");
    }


    private void ResetShot()
    {
        readyToShoot = true;
        allowInvoke = true;
    }

    public void ReactToHazard(float hazardDamage)
    {
        //playerRigidbody.AddForce(hazardForce);
        playerHealth.TakeDamage(hazardDamage);
    }

    public bool AttemptingToEnter()
    {
        return joystick.Vertical > enterExitBuildingThreshold;
    }

    public bool AttemptingToExit()
    {
        return joystick.Vertical < -enterExitBuildingThreshold;
    }

    public void UseKey()
    {
        hasKey = false;
    }

    public void PickupKey()
    {
        hasKey = true;
    }
}
