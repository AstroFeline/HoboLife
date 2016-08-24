using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            print("pause");
            if (Time.timeScale == 0) Time.timeScale = 1;
                else Time.timeScale = 0;
        }
        
	}
}
