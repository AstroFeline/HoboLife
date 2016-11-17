using UnityEngine;
using System.Collections;

public class PlayerZoneController : MonoBehaviour {
    private string dialogue;

    private DialogueManagerController dMan;
    private DialogueGetterController dGet;
    private StealthManagerController sCon;
    // Use this for initialization
    void Start()
    {
        dMan = FindObjectOfType<DialogueManagerController>();
        dGet = FindObjectOfType<DialogueGetterController>();

    }

    void OnTriggerStay2D(Collider2D player)
    {
        if (player.gameObject.name == "Hobo")
        {
            //Comprobamos si se hará un dialogo.
            DialogueZone();
            //Comprobamos que sea zona de stealth.
            StealthZone();
        }
    }

    void DialogueZone()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            if (!dMan.dialogueActive)
            {
                dialogue = dGet.ReadText();
                dMan.ShowBox(dialogue);
            }

            if (transform.parent.GetComponent<NPCController>() != null)
            {
                transform.parent.GetComponent<NPCController>().canMove = false;
            }

        }
    }

    void StealthZone()
    {
        if (Input.GetKeyUp(KeyCode.S))
        {
            if (!sCon.stealthActive)
            {
                //Se hacen cosas
            }
            Debug.Log("Stealth Zone");
        }
    }
}
