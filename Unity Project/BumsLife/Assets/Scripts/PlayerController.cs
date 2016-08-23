using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour{
    public float moveSpeed;
    void Start() { }

    void FixedUpdate(){
        Move();
    }

    void Move(){
        float xMove = Input.GetAxisRaw("Horizontal");
        float yMove = Input.GetAxisRaw("Vertical");
        if (xMove > 0.5f || xMove < -0.5f){
            transform.Translate(new Vector3(xMove * moveSpeed*Time.deltaTime,0f,0f));
        }
        if (yMove > 0.5f || yMove < -0.5f){
            transform.Translate(new Vector3(0f, yMove*moveSpeed * Time.deltaTime, 0f));
        }

    }
}

