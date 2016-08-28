using UnityEngine;
using System.Collections;

public class NPCController : MonoBehaviour {

    public float moveSpeed;
    public bool isWalking;
    public float walkTime;
    public float waitTime;

    private float walkCounter;
    private float waitCounter;
    private int walkDirection;
    private bool isMovingL = true, isMovingR = true, isMovingU = true, isMovingD = true;
    private Animator anim;
    private bool facingRight;

    // Use this for initialization
    void Start () {
        moveSpeed = 0;
        waitCounter = waitTime;
        walkCounter = walkTime;
        anim = this.gameObject.GetComponent<Animator>();
        chooseDirection();
	}
	
	// Update is called once per frame
	void Update () {
	    if (isWalking)
        {
            walkCounter -= Time.deltaTime;


            switch (walkDirection)
            {
                case 0:
                    if (isMovingR)
                    {
                        transform.Translate(new Vector3(moveSpeed * Time.deltaTime, 0f, 0f));
                    }
                    else
                        chooseDirection();
                    break;
                case 1:
                    if (isMovingL)
                    {
                        transform.Translate(new Vector3(-(moveSpeed * Time.deltaTime), 0f, 0f));
                    }
                    else
                        chooseDirection();
                    break;
                case 2:
                    if (isMovingU)
                    {
                        transform.Translate(new Vector3(0f, moveSpeed * Time.deltaTime, 0f));
                    }
                        
                    else
                        chooseDirection();
                    break;
                case 3:
                    if (isMovingD)
                    {
                        transform.Translate(new Vector3(0f, -(moveSpeed * Time.deltaTime), 0f));
                    }
                        
                    else
                        chooseDirection();
                    break;
                case 5:
                    if (isMovingL && isMovingD)
                        transform.Translate(new Vector3(-(moveSpeed * Time.deltaTime), -(moveSpeed * Time.deltaTime), 0f));
                    else
                        chooseDirection();
                    break;
                case 6:
                    if (isMovingR && isMovingD)
                        transform.Translate(new Vector3((moveSpeed * Time.deltaTime), -(moveSpeed * Time.deltaTime), 0f));
                    else
                        chooseDirection();
                    break;
                case 7:
                    if (isMovingR && isMovingU)
                        transform.Translate(new Vector3((moveSpeed * Time.deltaTime), (moveSpeed * Time.deltaTime), 0f));
                    else
                        chooseDirection();
                    break;
                case 8:
                    if (isMovingL && isMovingU)
                        transform.Translate(new Vector3(-(moveSpeed * Time.deltaTime), (moveSpeed * Time.deltaTime), 0f));
                    else
                        chooseDirection();
                    break;

            }
            if (walkCounter < 0)
            {
                isWalking = false;
                waitCounter = waitTime;
            }
        }
        else
        {
            waitCounter -= Time.deltaTime;
            moveSpeed = 0;
            if (waitCounter < 0)
            {
                chooseDirection();
            }
        }
        anim.SetFloat("Speed", moveSpeed);
    }

    public void chooseDirection()
    {
        walkDirection = Random.Range(0, 9);
        isWalking = true;
        moveSpeed = 1;
        walkCounter = walkTime;
    }

    public bool IsMovingR
    {
        get
        {
            return isMovingR;
        }

        set
        {
            isMovingR = value;
        }
    }

    public bool IsMovingL
    {
        get
        {
            return isMovingL;
        }

        set
        {
            isMovingL = value;
        }
    }

    public bool IsMovingU
    {
        get
        {
            return isMovingU;
        }

        set
        {
            isMovingU = value;
        }
    }

    public bool IsMovingD
    {
        get
        {
            return isMovingD;
        }

        set
        {
            isMovingD = value;
        }
    }
}
