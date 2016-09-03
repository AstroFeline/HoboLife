using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public bool isZoom=false;
    public GameObject target;
    public float distance;
    private bool isTarget;
	private float camOrthographic;
	private Vector3 camInitPosition;
	
	void Start(){
		camOrthographic = Camera.main.orthographicSize;
		camInitPosition = transform.position;
	}
	void Update () {

        if (IsTarget)
            transform.position = target.transform.position- new Vector3 (0,0, distance);

        //PRUEBA, SE ELIMINARA
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
			isZoom = !isZoom;
			print ("isZoom=" + isZoom);
        }
        //
		if (isZoom) {
			if (Camera.main.orthographicSize > 1) {
				ZoomIn ();
			}
		} else {
			if (Camera.main.orthographicSize < camOrthographic) {
				ZoomOut ();
			} else {
				transform.position = camInitPosition + new Vector3 (0, 0, camOrthographic);

			}
		}
	}

    private void ZoomIn(){
        Camera.main.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, Camera.main.orthographicSize - 500, Time.deltaTime * 0.7f);
        transform.position = target.transform.position - new Vector3(0, 0, Camera.main.orthographicSize);
    }

	private void ZoomOut(){
		Camera.main.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, camOrthographic + 500, Time.deltaTime * 0.7f);
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
