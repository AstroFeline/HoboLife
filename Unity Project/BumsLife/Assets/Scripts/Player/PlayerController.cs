using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour{

    public float moveSpeed;
    private bool facingRight;
    public bool canMove;

    private bool isMovingL=true, isMovingR = true, isMovingU = true, isMovingD = true;
    private Animator anim;

    void Start() {
        facingRight = true;
        anim = this.gameObject.GetComponent<Animator>();
        canMove = true;
    }

    void FixedUpdate(){
        float xMove = Input.GetAxisRaw("Horizontal");

        if (!canMove)
        {
            moveSpeed = 0;
            return;
        }
        Move();
        Flip(xMove);
        

    }

    void Move() {
        this.moveSpeed = 1;
        float xMove = Input.GetAxisRaw("Horizontal");
        float yMove = Input.GetAxisRaw("Vertical");

        if ((xMove > 0f || xMove < 0f) || (yMove > 0f || yMove < 0f)) { 
            if (isMovingR)
            {
                if (xMove > 0f)
                {
                    moveSpeed = 1;
                    transform.Translate(new Vector3(xMove * moveSpeed * Time.deltaTime, 0f, 0f));

                }
            }
            if (isMovingL)
            {
                if (xMove < 0f)
                {
                    moveSpeed = 1;
                    transform.Translate(new Vector3(-(xMove * moveSpeed * Time.deltaTime), 0f, 0f));
                }
            }
            if (isMovingU)
            {
                if (yMove > 0f)
                {
                    moveSpeed = 1;
                    transform.Translate(new Vector3(0f, yMove * moveSpeed * Time.deltaTime, 0f));

                }
            }
            if (isMovingD)
            {
                if (yMove < 0f)
                {
                    moveSpeed = 1;
                    transform.Translate(new Vector3(0f, yMove * moveSpeed * Time.deltaTime, 0f));
                }

            }
        }else{
            moveSpeed = 0;
        }
		print ("movespeed=" + moveSpeed);
        anim.SetFloat("Speed", moveSpeed);

    }
    
    public void Flip(float xMove)
    {
		if (isMovingL || isMovingR) {
			if (xMove > 0 && !facingRight || xMove < 0 && facingRight) {
				facingRight = !facingRight;
				Vector3 theScale = transform.localScale;
				theScale.x *= -1;
				transform.localScale = theScale;
			}
		}
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

