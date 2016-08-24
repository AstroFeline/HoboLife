using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour{
    public float moveSpeed;
    private bool facingRight;
    private bool isMoving=true;
    private Animator anim;

    void Start() {
        facingRight = true;
        anim = this.gameObject.GetComponent<Animator>();
    }


    

    void FixedUpdate(){
        float xMove = Input.GetAxisRaw("Horizontal");
        if (IsMoving1) {
            Move();
            Flip(xMove);
        } 

    }

    void Move(){
        this.moveSpeed = 1;
        float xMove = Input.GetAxisRaw("Horizontal");
        float yMove = Input.GetAxisRaw("Vertical");


        if (xMove > 0f ){
            moveSpeed = 1;
            transform.Translate(new Vector3(xMove * moveSpeed*Time.deltaTime,0f,0f));
            
        }else if(xMove < 0f){
            moveSpeed = 1;
            transform.Translate(new Vector3(-(xMove * moveSpeed * Time.deltaTime), 0f, 0f));
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (yMove > 0f || yMove < 0f){
            moveSpeed = 1;
            transform.Translate(new Vector3(0f, yMove*moveSpeed * Time.deltaTime, 0f));
        }
        else
        {
            moveSpeed = 0;
        }

        anim.SetFloat("Speed", moveSpeed);

    }
    
    public bool IsMoving1
    {
        get
        {
            return isMoving;
        }

        set
        {
            isMoving = value;
        }
    }

    public void Flip(float xMove)
    {
        if (xMove > 0 && !facingRight || xMove < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}

