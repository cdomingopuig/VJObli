using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public Vector2 speed = new Vector2(300f, 0f);
    private Rigidbody2D rb;
    private bool moving = false;
    private Vector2 startPosition;

    private Animator anim;


    //The position you clicked
    public Vector2 targetPosition;
    //That position relative to the players current position (what direction and how far did you click?)
    public Vector2 relativePosition;

    // 2 - Store the movement
    private Vector2 movement;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        startPosition = new Vector2(transform.position.x, transform.position.y);
    }

    void Start()
    {
        anim.SetInteger("state", 0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log("Click: " + targetPosition);
            anim.SetInteger("state", 1);
            if (targetPosition.x > transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                rb.velocity = new Vector2(speed.x * Time.deltaTime, 0f);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 180f, 0);
                rb.velocity = new Vector2(-speed.x * Time.deltaTime, 0f);
            }
            moving = true;
        }
        if (moving)
        {
            if (Mathf.Abs(targetPosition.x - transform.position.x) < speed.x * Time.deltaTime)
            {
                rb.velocity = new Vector2((targetPosition.x - transform.position.x), 0);
            }
            if (Mathf.Abs(targetPosition.x - transform.position.x) < 1.5)
            {
                rb.velocity = new Vector2(0, 0);
                anim.SetInteger("state", 0);
                moving = false;
            }
        }
    }

    /*public float speed;
        //The position you clicked
        public Vector2 targetPosition;
        //That position relative to the players current position (what direction and how far did you click?)
        public Vector2 relativePosition;

        // 2 - Store the movement
        private Vector2 movement;

        void Update()
        {
            // 3 - Retrieve the mouse position
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }

            //4 - Find the relative poistion of the target based upon the current position
            // Update each frame to account for any movement
            relativePosition = new Vector2(
                targetPosition.x - gameObject.transform.position.x,
                targetPosition.y - gameObject.transform.position.y);
        }

        void FixedUpdate()
        {
            // 5 - If you are about to overshoot the target, reduce velocity to that distance
            //      Else cap the Movement by a maximum speed per direction (x then y)
            if (speed * Time.deltaTime >= Mathf.Abs(relativePosition.x))
            {
                movement.x = relativePosition.x;
            }
            else
            {
                movement.x = speed * Mathf.Sign(relativePosition.x);
            }

            // 6 - Move the game object using the physics engine
            rigidbody2D.velocity = movement;

        }

        // Use this for initialization
        void Start()
        {
            //speed = speed * Time.deltaTime;

        }

        //Update is called once per frame
        /*void Update()
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                Vector3 playerPosition = transform.position;
                playerPosition.x -= 0.1f;
                transform.position = playerPosition;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                Vector3 playerPosition = transform.position;
                playerPosition.x += 0.1f;
                transform.position = playerPosition;
            }
            if (Input.GetMouseButtonDown(0))
            {
                targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Debug.Log(targetPosition.x);
                targetPosition.y = transform.position.y;
                targetPosition.z = transform.position.z;
                if (move == false)
                    move = true;
                if (move == true)
                    transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                Debug.Log(transform.position.x);
            }

        }*/
    }
