using UnityEngine;
using System.Collections;

public class Tile_Info : MonoBehaviour{

	Camera _mainCam = null; 
	GameObject target = null;
	GameObject clicked = null;

	void OnMouseDown(){
		clicked = this.gameObject;
		Debug.Log ("clicked : "+clicked+" / pos : "+clicked.transform.position);
	}
	void OnMouseDrag(){
		dragObject ();
	}

	void OnMouseUp(){
		swap (target);
	}

	void Awake() {
		_mainCam = Camera.main;

	}

	private void dragObject(){
		RaycastHit hit;
		Ray ray = _mainCam.ScreenPointToRay (Input.mousePosition);
		int flag = 0;

		float distance;



		if (true == (Physics.Raycast (ray.origin, ray.direction * 1, out hit))) {
			
			distance = Vector3.Distance (clicked.transform.position, hit.collider.gameObject.transform.position);

			if (distance < 1.3 && distance >= 0.9) {
				target = hit.collider.gameObject;
				Debug.Log ("target : " + target + " / pos : " + target.transform.position);
			}
		}
	}

	private void swap(GameObject target){
		if (target != null) {
			Vector3 temp = new Vector3 (target.transform.position.x, target.transform.position.y, target.transform.position.z);
			target.transform.position = clicked.transform.position;
			clicked.transform.position = temp;
		}
	}
}