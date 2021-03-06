/*
Rag.cs
cody
09/19/2021
1.0
Rag DESCRIPTION GOES HERE
*/
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Author: cody
/// Rag CLASS DESCRIPTION GOES HERE
/// </summary>
public class Rag : MonoBehaviour
{
    public GameObject child;
    public float forwardSpeed; // current is 5f
    public float jumpForce;       // current is 300f
    public float bounceJumpForce; // current is 250f
    public float attackRange;
    //public GameObject moveableObject;
    [SerializeField]
    private GameObject changeLevel;
    //public GameObject pinHandle;
    //public GameObject Cat;
    //public GameObject dummyPin;
    //public GameObject dropPoint;
    public string levelToLoad;
    private string level;
    private Rigidbody rb;
    public Transform childRag;
    //public Transform catLocation;
    public Vector3 startPosition;
    private Scene scene;
    public bool amIHanging = false;
    public bool lookingRight = true;
    public bool isEquip = false;
    public bool isHiding = false;
    public bool disableMovement = false;
    public bool moveObject = false;


    private float attackDelay;
    //public Animator anim;
    //private string currentState;
    //private string PlayerIdle = "Idle";
    //private string PlayerRun = "Take 001";
    //private string PlayerJump;
    //private string PlayerAttack = "";
    //private string PlayerFallFlat = "";
    //private string PlayerFall;
    //private string PlayerPull = "Pull";
    //private string PlayerPush = "Push";
    //private string PlayerClimb = "Climb";
    //private string PlayerLedgeClimb = "LedgeClimb";
    //private string PlayerGotHit = "GotHit";
    //private string PlayerGrapple = "Grapple";
    //private string PlayerGrappleThrow = "GrappleThrow";
    //private string PlayerGrappleCancel = "GrappleCancel";
    private bool isAttackPressed;
    private bool isAttacking;
    public bool isGrounded;
    private bool isJumpPressed;
    private bool isClimbing;
    public bool isGrappling;
    public bool canPush = false;
    private Vector3 currentPos;
    public AudioSource jump;

    // public GameObject[] test;
    /// <summary>
    /// Author: cody
    /// Start is called before the first frame update
    /// </summary>
    void Start()
	{
        //test = GameObject.FindGameObjectsWithTag("ground");// Cat = GameObject.FindWithTag("Cat");//catLocation = Cat.transform;//anim = GetComponent<Animator>();
        scene = SceneManager.GetActiveScene();
        level = scene.name;
        PlayerPrefs.SetString("lastlevel", level);
        rb = gameObject.GetComponent<Rigidbody>();
        startPosition = transform.position;
        jump = this.gameObject.GetComponent<AudioSource>();
        //pinHandle.SetActive(false);
    }

    /// <summary>
    /// Author: cody
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        Jumping();
        //Checking for inputs
        //space jump key pressed?
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumpPressed = true;
        }

        currentPos = this.transform.position;

        if (this.transform.position.z != 0)
        {
            this.transform.position = new Vector3(currentPos.x, currentPos.y, 0);
        }

        //space Atatck key pressed?
        //if (Input.GetKeyDown(KeyCode.RightControl))
        //{
        //    isAttackPressed = true;
        //}

        //if (Input.GetKeyDown(KeyCode.R) && isEquip)
        //{
        //    pinHandle.SetActive(false);
        //    dummyPin.transform.position = dropPoint.transform.position;
        //    dummyPin.SetActive(true);
        //    isEquip = false;
        //}
        if (Input.GetKeyDown(KeyCode.D) && !isHiding)
        {
            childRag.localRotation = Quaternion.Euler(0, 275, 0);
        }
        if (Input.GetKeyDown(KeyCode.A) && !isHiding)
        {
            childRag.localRotation = Quaternion.Euler(0, 80, 0);
        }
        //childRag.localRotation = Quaternion.Euler(0, 50, 0);
        //childRag.localRotation = Quaternion.Euler(0, 180, 0);

        //if (isEquip == true && Vector3.Distance(transform.position, catLocation.position) <= attackRange)
        //{
        //    Cat.SendMessage("Spook");
        //    Cat.SendMessage("reduceAgitation", 35);
        //    //pinHandle.SetActive(false);
        //    isEquip = false;
        //}
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (canPush)
            {
                child.transform.parent = null;
                canPush = !canPush;
            }
        }
    }
    private void FixedUpdate()
    {
        if (disableMovement)
        {
        }
        else
        {
            if (Input.GetKey(KeyCode.D) && !isHiding)
            {
                transform.Translate(Vector3.right * forwardSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.A) && !isHiding)
            {
                transform.Translate(Vector3.left * forwardSpeed * Time.deltaTime);
            }
        }
        
        if (isGrounded && !isAttacking)
        {
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
            {
                //ChangeAnimationState(PlayerRun);
            }
            else if (!isClimbing && !isGrappling)
            {
                //ChangeAnimationState(PlayerIdle);
            }
        }
        //------------------------------------------ collision.collider.gameObject.layer
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
                //attackDelay = anim.GetCurrentAnimatorStateInfo(0).length;
                Invoke("AttackComplete", attackDelay);
            }
        }
    }
    public void GrappleAnim1()
    {
        //ChangeAnimationState(PlayerGrappleThrow);
       // attackDelay = anim.GetCurrentAnimatorStateInfo(0).length;
        Invoke("GrappleAnim2", attackDelay);
    }
    public void GrappleAnim2()
    {
        //ChangeAnimationState(PlayerGrapple);
    }
    public void GrappleLetGo()
    {
        //ChangeAnimationState(PlayerGrappleCancel);
        //attackDelay = anim.GetCurrentAnimatorStateInfo(0).length;
        Invoke("GrappleFalse", attackDelay);
    }
    public void GrappleFalse()
    {
        isGrappling = false;
    }
    private void Jumping()
    {
        //if hiding is true do nothing
        //if hiding is false jump
        if (isHiding || disableMovement)
        {
        }
        else
        {
            if (isGrounded && Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(0, jumpForce, 0);
                isGrounded = false;
                jump.Play();
                if (canPush)
                {
                    child.transform.parent = null;
                    canPush = !canPush;
                }
                Debug.Log("hwiefh");
               
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
        //if (currentState == newAnimation) return;

        //anim.Play(newAnimation);
        //currentState = newAnimation;
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Tag anything Rag walks on ground.
        if (collision.gameObject.tag == ("Ground") || collision.collider.gameObject.layer == LayerMask.NameToLayer("Pushable"))
        {
            //rb.velocity = new Vector3(0, 0, 0);
            isGrounded = true;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == ("Pushable"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!canPush)
                {
                    child.transform.SetParent(gameObject.transform);
                    canPush = !canPush;
                }
            }
        }
        //child.transform.SetParent(target1.transform);child.transform.parent = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        //make trigger tag it water
        if (other.gameObject.tag == ("Water"))
        {
            forwardSpeed = 1f;
        }
        if (other.gameObject.tag == ("EndLevel"))
        {
            changeLevel.GetComponent<LevelLoader>().LoadLevel(levelToLoad);
        }
        //Make trigger tag it fire
        if (other.gameObject.tag == ("Fire"))
        {
            Death();
        }

        if (other.gameObject.tag == ("CheckPoint"))
        {
            startPosition = other.transform.position;
            //Debug.Log("CheckPoint updated!");
        }

        if (other.gameObject.tag == ("JumpPad"))
        {
            jumpForce = bounceJumpForce;
        }
        if (other.gameObject.tag == ("Scarf"))
        {
            rb.velocity = new Vector3(0, 0, 0);
            rb.useGravity = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == ("Hanger"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                gameObject.transform.position = other.transform.position;
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
                amIHanging = true;
                disableMovement = true;
            }

            if (amIHanging == true)
            {
                if (Input.GetKeyDown(KeyCode.S))
                {
                    gameObject.GetComponent<Rigidbody>().isKinematic = false;
                    amIHanging = false;
                    disableMovement = false;
                }
            }
        }

        if (other.gameObject.tag == ("Scarf"))
        {
            isClimbing = true;
            //ChangeAnimationState(PlayerClimb);
            rb.velocity = new Vector3(0, 0, 0);
            if (Input.GetKey(KeyCode.E))
            {
                transform.Translate(Vector3.up * forwardSpeed * Time.deltaTime);
            }
        }

        //if (other.gameObject.tag == ("Pin"))
        //{
        //    if (Input.GetKeyDown(KeyCode.E))
        //    {
        //        dummyPin = other.gameObject;
        //        isEquip = true;
        //        pinHandle.SetActive(true);
        //        dummyPin.SetActive(false);
        //        Debug.Log("Pin equipped");
        //    }
        //}

        if (Input.GetKeyDown(KeyCode.W) && amIHanging == true)
        {

            if (other.gameObject.tag == ("Climbable"))
            {
                gameObject.transform.position = other.transform.position;
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
                amIHanging = false;
                disableMovement = false;
            }
        }
    }   
        public void InvertControls()
    { 
        transform.rotation *= Quaternion.AngleAxis(180, transform.up);
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, startPosition.z);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == ("Water"))
        {
            forwardSpeed = 5f;
        }
        if (other.gameObject.tag == ("JumpPad"))
        {
            jumpForce = 300;
        }
        if (other.gameObject.tag == ("Scarf"))
        {
            GetComponent<Rigidbody>().useGravity = true;
            isClimbing = false;
        }
    }
    //death function reset transform to start point. 
    public void Death()
    {
        gameObject.transform.position = startPosition;
    }
}