using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineControl : MonoBehaviour {
	public GameObject linePrefab;
	public float lineWidth  = 1.0f;
	public int count = 0;
    float lineLength = 0.0f;

	public GameObject player;

	private Vector3 touchpos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		DrawLine ();


	}
	void DrawLine(){
		

		if (Input.GetMouseButtonDown (0)) {
			touchpos = Camera.main. ScreenToWorldPoint (Input.mousePosition);
			touchpos.z =-1;
	
		}
		if (Input.GetMouseButtonUp (0)) {
			Vector3 startPos = touchpos;
			Vector3 endPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			endPos.z=-1;

		//if ((endPos - startPos).magnitude > lineLength) {
			lineLength = (endPos- startPos).magnitude;
			GameObject obj = Instantiate (linePrefab, transform.position, transform.rotation)as GameObject;
			obj.transform.position = (startPos + endPos) / 2;
			obj.transform.right = (endPos - startPos).normalized;
			obj.transform.localScale = new Vector3 ((endPos - startPos).magnitude, lineWidth, lineWidth);

			obj.transform.parent = this.transform;

			PlayerScript d1 = player.GetComponent<PlayerScript> ();
			d1.UseEnegy (-lineLength);
			     
				//touchpos = endPos;
			//}
		}
	}
}
