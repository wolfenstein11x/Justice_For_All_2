using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Joystick joystick;
    [SerializeField] float maxHorizontalSpeed = 5f;
    [SerializeField] float maxJumpSpeed = 5f;
    [SerializeField] float timeBetweenShots = 0.25f;
    [SerializeField] Bullet bullet;
    [SerializeField] Transform shootPoint;
    [SerializeField] float meleeRange = 0.25f;
    [SerializeField] Transform meleePos;
    [SerializeField] float meleeDamage = 5f;

    private Animator playerAnimator;
    private Rigidbody2D playerRigidbody;
    private BoxCollider2D feetCollider;
    private LayerMask jumpableSurface;
    private MuzzleFlash muzzleFlash;
    private OrientationTracker orientationTracker;
    private LayerMask meleeRaycastLayers;

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
        orientationTracker = GetComponent<OrientationTracker>();
        meleeRaycastLayers = LayerMask.GetMask("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        Jump();
        FlipSprite();
        InMeleeRange();

        
        
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
        Bullet firedBullet = Instantiate(bullet, shootPoint.position, bullet.transform.rotation);
        firedBullet.transform.parent = gameObject.transform;

        if (allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShots);
            allowInvoke = false;
        }
    }

    // InMeleeRange not needed for Player, other than for debugging
    public bool InMeleeRange()
    {
        float orientation = orientationTracker.GetOrientation();

        RaycastHit2D hitMelee = Physics2D.Raycast(meleePos.position, Vector2.right * new Vector2(orientation, 0f), meleeRange, meleeRaycastLayers);


        if (hitMelee.collider != null)
        {
            Debug.DrawRay(meleePos.position, Vector2.right * hitMelee.distance * new Vector2(orientation, 0f), Color.red);
            return true;
        }
        else
        {
            Debug.DrawRay(meleePos.position, Vector2.right * meleeRange * new Vector2(orientation, 0f), Color.blue);
            return false;
        }

    }

    public void Stab()
    {
        playerAnimator.SetTrigger("stab");
    }

    public void DealMeleeDamage()
    {
        float orientation = orientationTracker.GetOrientation();
        RaycastHit2D hitMelee = Physics2D.Raycast(meleePos.position, Vector2.right * new Vector2(orientation, 0f), meleeRange, meleeRaycastLayers);

        if (hitMelee.collider != null)
        {
            Health enemyHealth = hitMelee.collider.gameObject.GetComponent<Health>();
            enemyHealth.TakeDamage(meleeDamage);
        }
    }

    private void ResetShot()
    {
        readyToShoot = true;
        allowInvoke = true;
    }
}
