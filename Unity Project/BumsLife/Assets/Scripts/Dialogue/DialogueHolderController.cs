using UnityEngine;
using System.Collections;

public class DialogueHolderController : MonoBehaviour {

    private string dialogue;

    private DialogueManagerController dMan;
    private DialogueGetterController dGet;

	// Use this for initialization
	void Start () {
        dMan = FindObjectOfType<DialogueManagerController>();
        dGet = FindObjectOfType<DialogueGetterController>();
        
	}

    void OnTriggerStay2D(Collider2D player)
    {
        if(player.gameObject.name == "Hobo")
        {
            if(Input.GetKeyUp(KeyCode.E))
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
    }
}
