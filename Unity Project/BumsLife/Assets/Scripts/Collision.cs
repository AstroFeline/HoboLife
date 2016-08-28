using UnityEngine;
using System.Collections;

public class Collision : MonoBehaviour {

    public float rightDistance = 0.04f, leftDistance = 0.16f, downDistance = 0.05f, upDistance = 0.02f;
    public GameObject target;

    void FixedUpdate()
    {
        RaycastHit hit;

        //Calcula el raycast hacia la derecha
        if (Physics.Raycast(new Vector3(transform.position.x + 0.07f, transform.position.y - 0.25f, 0), Vector3.right, out hit, rightDistance)) { 
            if (hit.collider.tag == "limit")
            {
                if (target.GetComponent<PlayerController>() != null)
                    target.GetComponent<PlayerController>().IsMovingR = false;
                else if (target.GetComponent<NPCController>() != null)
                    target.GetComponent<NPCController>().IsMovingR = false;
            }
        }else{
            if (target.GetComponent<PlayerController>() != null)
                target.GetComponent<PlayerController>().IsMovingR = true;
            else if (target.GetComponent<NPCController>() != null)
                target.GetComponent<NPCController>().IsMovingR = true;
        }

        //Calcula el raycast hacia la izquierda
        if (Physics.Raycast(new Vector3(transform.position.x + 0.07f, transform.position.y - 0.25f, 0), Vector3.left, out hit, leftDistance)){
            if (hit.collider.tag == "limit")
            {
                if (target.GetComponent<PlayerController>() != null)
                    target.GetComponent<PlayerController>().IsMovingL = false;
                else if (target.GetComponent<NPCController>() != null)
                    target.GetComponent<NPCController>().IsMovingL = false;
            }
        }
        else
        {
            if (target.GetComponent<PlayerController>() != null)
                target.GetComponent<PlayerController>().IsMovingL = true;
            else if (target.GetComponent<NPCController>() != null)
                target.GetComponent<NPCController>().IsMovingL = true;
        }

        //Calcula el raycast hacia arriba
        if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y - 0.25f, 0), Vector3.up, out hit, upDistance))
        {
            
            if (hit.collider.tag == "limit")
            {
                if (target.GetComponent<PlayerController>() != null)
                    target.GetComponent<PlayerController>().IsMovingU = false;
                else if (target.GetComponent<NPCController>() != null)
                    target.GetComponent<NPCController>().IsMovingU = false;
            }

        }
        else
        {
            if (target.GetComponent<PlayerController>() != null)
                target.GetComponent<PlayerController>().IsMovingU = true;
            else if (target.GetComponent<NPCController>() != null)
                target.GetComponent<NPCController>().IsMovingU = true;

        }

        //Calcula el raycast hacia abajo
        if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y - 0.25f, 0), Vector3.down, out hit, downDistance))
        {

            if (hit.collider.tag == "limit")
            {
                if (target.GetComponent<PlayerController>() != null)
                    target.GetComponent<PlayerController>().IsMovingD = false;
                else if (target.GetComponent<NPCController>() != null)
                    target.GetComponent<NPCController>().IsMovingD = false;
            }
        }
        else
        {
            if (target.GetComponent<PlayerController>() != null)
                target.GetComponent<PlayerController>().IsMovingD = true;
            else if (target.GetComponent<NPCController>() != null)
                target.GetComponent<NPCController>().IsMovingD = true;
        }

    }
}

