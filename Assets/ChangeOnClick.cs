using UnityEngine;
using System.Collections;

public class ChangeOnClick : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetMouseButtonDown (0)) {
			Ray newRay = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit newHit = new RaycastHit();
			Debug.DrawRay (newRay.origin, newRay.direction *10, Color.yellow);
			if (Physics.Raycast(newRay.origin, newRay.direction, out newHit, 100f)) {
				Debug.Log("Hit something");
				if (newHit.collider.GetComponent<DynamicText>() != null) {
					Debug.Log ("Dynamic Text found.");
					newHit.collider.GetComponent<DynamicText>().cycle();
				}
				else Debug.Log ("Dynamic Text not found.");
			}
		}
		
	}
}
