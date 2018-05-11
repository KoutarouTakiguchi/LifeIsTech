using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineControl : MonoBehaviour {
	public GameObject linePrefab;
	public float lineLength = 0.2f;
	public float lineWidth  = 0.1f;

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
			touchpos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			touchpos.y = 1;
		}
		if (Input.GetMouseButton (0)) {
			Vector3 startPos = touchpos;
			Vector3 endPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			endPos.y=1;

			if ((endPos - startPos).magnitude > lineLength) {
				GameObject obj = Instantiate (linePrefab, transform.position, transform.rotation)as GameObject;
				obj.transform.position = (startPos + endPos) / 2;
				obj.transform.right = (endPos - startPos).normalized;
				obj.transform.localScale = new Vector3 ((endPos - startPos).magnitude, lineWidth, lineWidth);

				obj.transform.parent = this.transform;

				touchpos = endPos;
			}
		}
	}
}
