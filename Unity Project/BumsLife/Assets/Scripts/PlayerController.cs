using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour{
    public float moveSpeed;
    private bool isMoving=true;
    private Animator anim;

    void Start() {
        anim = this.gameObject.GetComponent<Animator>();
    }


    

    void FixedUpdate(){

        if (IsMoving1) Move();

    }

    void Move(){
        this.moveSpeed = 1;
        float xMove = Input.GetAxisRaw("Horizontal");
        float yMove = Input.GetAxisRaw("Vertical");
        if (xMove > 0.5f || xMove < -0.5f){
            moveSpeed = 1;
            transform.Translate(new Vector3(xMove * moveSpeed*Time.deltaTime,0f,0f));
        }
        else if (yMove > 0.5f || yMove < -0.5f){
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
}

