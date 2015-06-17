using UnityEngine;
using System.Collections;

public class MapElement : MonoBehaviour {

	public Transform target;
	Map map;
	RectTransform myRect;
	
	// Use this for initialization
	void Awake () {
		map = GameObject.FindGameObjectWithTag("MiniMap").GetComponent<Map>();
		transform.SetParent (map.transform, false);
		myRect = GetComponent<RectTransform> ();
	}
	
	// Update is called once per frame
	void LateUpdate () {
		Vector2 myPos = map.Position (target.position); 
		myRect.localPosition = myPos;
		myRect.localScale = new Vector2 (map.zoomLevel, map.zoomLevel);
		Quaternion myRotation = map.Rotation (target.rotation);
		myRect.localRotation = myRotation;
	}
}
