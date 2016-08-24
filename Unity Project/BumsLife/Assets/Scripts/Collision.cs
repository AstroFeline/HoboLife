using UnityEngine;
using System.Collections;

public class Collision : MonoBehaviour {

    public float rightDistance = 0.04f, leftDistance = 0.16f, downDistance = 0.05f, upDistance = 0.02f;

    void FixedUpdate()
    {
        RaycastHit hit;

        //Calcula el raycast hacia la derecha
        if (Physics.Raycast(new Vector3(transform.position.x + 0.07f, transform.position.y - 0.25f, 0), Vector3.right, out hit, rightDistance)) { 
            if (hit.collider.tag == "limit")
            {
                GameObject.Find("Hobo").GetComponent<PlayerController>().IsMovingR = false;
            }
        }else{
            GameObject.Find("Hobo").GetComponent<PlayerController>().IsMovingR = true;
        }

        //Calcula el raycast hacia la izquierda
        if (Physics.Raycast(new Vector3(transform.position.x + 0.07f, transform.position.y - 0.25f, 0), Vector3.left, out hit, leftDistance)){
            if (hit.collider.tag == "limit")
            {
                GameObject.Find("Hobo").GetComponent<PlayerController>().IsMovingL = false;
            }
        }
        else
        {
            GameObject.Find("Hobo").GetComponent<PlayerController>().IsMovingL = true;
        }

        //Calcula el raycast hacia arriba
        if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y - 0.25f, 0), Vector3.up, out hit, upDistance))
        {
            
            if (hit.collider.tag == "limit")
            {
               GameObject.Find("Hobo").GetComponent<PlayerController>().IsMovingU = false;
            }
        }
        else
        {
            GameObject.Find("Hobo").GetComponent<PlayerController>().IsMovingU = true;
        }

        //Calcula el raycast hacia abajo
        if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y - 0.25f, 0), Vector3.down, out hit, downDistance))
        {

            if (hit.collider.tag == "limit")
            {
                GameObject.Find("Hobo").GetComponent<PlayerController>().IsMovingD = false;
            }
        }
        else
        {
            GameObject.Find("Hobo").GetComponent<PlayerController>().IsMovingD = true;
        }

    }
}

