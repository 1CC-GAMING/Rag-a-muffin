/*
RagAnimTest.cs
cody
09/19/2021
1.0
RagAnimTest DESCRIPTION GOES HERE
*/
using UnityEngine;

/// <summary>
/// Author: cody
/// RagAnimTest CLASS DESCRIPTION GOES HERE
/// </summary>
public class RagAnimTest : MonoBehaviour
{

	/// <summary>
	/// Author: cody
	/// Start is called before the first frame update
	/// </summary>
	void Start()
	{
		
	}

	/// <summary>
	/// Author: cody
	/// Update is called once per frame
	/// </summary>
	void Update()
	{
		
	}
    /*
     [SerializeField]
    private float attackDelay = 0.3f;
    Animator anim;
    private string currentState;
    private string PlayerIdle = "Idle";
    private string PlayerRun = "Take 001";
    //private string PlayerJump;
    //private string PlayerAttack = "";
    //private string PlayerFallFlat = "";
    //private string PlayerFall;
    private string PlayerPull = "Pull";
    private string PlayerPush = "Push";
    private string PlayerClimb = "Climb";
    private string PlayerLedgeClimb = "LedgeClimb";
    private string PlayerGotHit = "GotHit";
    private string PlayerGrapple = "Grapple";
    private string PlayerGrappleThrow = "GrappleThrow";
    private string PlayerGrappleCancel = "GrappleCancel";
    private bool isAttackPressed;
    private bool isAttacking;
    private bool isGrounded;
    private bool isJumpPressed;
    private int groundMask;
    //=====================================================
    // Start is called before the first frame update
    //=====================================================
    void Start()
    {
       // anim = GetComponent<Animator>();
        groundMask = 1 << LayerMask.NameToLayer("Ground");
    }

    //=====================================================
    // Update is called once per frame
    //=====================================================
    void Update()
    {
        //Checking for inputs
        //space jump key pressed?
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumpPressed = true;
        }

        //space Atatck key pressed?
        //if (Input.GetKeyDown(KeyCode.RightControl))
        //{
        //    isAttackPressed = true;
        //}
    }

    //=====================================================
    // Physics based time step loop
    //=====================================================
    private void FixedUpdate()
    {
        //check if player is on the ground
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f, groundMask);

        if (hit.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        if (isGrounded && !isAttacking)
        {
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
            {
                //ChangeAnimationState(PlayerJump);
            }
            else
            {
                ChangeAnimationState(PlayerIdle);
            }
        }

        //------------------------------------------

        //Check if trying to jump 
        if (isJumpPressed && isGrounded)
        {
            isJumpPressed = false;
            //ChangeAnimationState(PlayerJump);
        }
        //attack
        if (isAttackPressed)
        {
            isAttackPressed = false;

            if (!isAttacking)
            {
                isAttacking = true;

                if (isGrounded)
                {
                    //ChangeAnimationState(PlayerAttack);
                }
                Invoke("AttackComplete", attackDelay);
            }
        }
    }

    void AttackComplete()
    {
        isAttacking = false;
    }

    //=====================================================
    // mini animation manager
    //=====================================================
    void ChangeAnimationState(string newAnimation)
    {
        if (currentState == newAnimation) return;

        anim.Play(newAnimation);
        currentState = newAnimation;
    }
     */
}