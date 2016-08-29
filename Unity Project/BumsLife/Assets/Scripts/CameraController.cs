using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public bool isZoom=false;
    public GameObject target;
    public float distance;
    private bool isTarget;
    
	
	// Update is called once per frame
	void Update () {

        if (IsTarget)
            transform.position = target.transform.position- new Vector3 (0,0, distance);

        //PRUEBA, SE ELIMINARA
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            isZoom = true;
        }
        //
        if (isZoom)
        {
            if (Camera.main.orthographicSize > 1)
            {
                Zoom();
            }
        }
	}

    private void Zoom(){
        Camera.main.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, Camera.main.orthographicSize - 500, Time.deltaTime * 0.7f);
        transform.position = target.transform.position - new Vector3(0, 0, Camera.main.orthographicSize);
    }

    public bool IsTarget
    {
        get
        {
            return isTarget;
        }

        set
        {
            isTarget = value;
        }
    }
}
