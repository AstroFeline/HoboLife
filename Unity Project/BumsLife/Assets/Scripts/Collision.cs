using UnityEngine;
using System.Collections;

public class Collision : MonoBehaviour {

    public float rightDistance = 0.13f;

    void FixedUpdate()
    {
        RaycastHit hit;
        Debug.DrawLine(new Vector3(transform.position.x + 0.07f, transform.position.y - 0.25f, 0), new Vector3(transform.position.x + rightDistance, transform.position.y - 0.25f, 0), Color.red);

        if (Physics.Raycast(new Vector3(transform.position.x + 0.07f, transform.position.y - 0.25f, 0), Vector3.right, out hit, rightDistance)) { 
            print("colision " + hit.collider.tag);
            if (hit.collider.tag == "limit")
            {

                GameObject.Find("Hobo").GetComponent<PlayerController>().IsMoving1 = false;
            }
        }

    }
}

