using UnityEngine;
using System.Collections;
using System.IO;

public class DialogueGetterController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public string ReadText()
    {
        StreamReader reader = new StreamReader(Application.dataPath + "/StreamingAssets" + "/Dialogues/" + "Dialogues.txt");
        ArrayList line = new ArrayList();
        Random rnd = new Random();
        while (!reader.EndOfStream)
        {
            line.Add(reader.ReadLine());
        }
        int lineNumber = Random.Range(0, line.Count);
        return (string) line[lineNumber];
    }
}
