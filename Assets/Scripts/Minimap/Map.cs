using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {

	public Transform mapTarget;
	public float zoomLevel;

//	Vector2 XRotation;
//	Vector2 YRotation;
//
//	void Awake(){
//		XRotation = Vector2.right;
//		YRotation = Vector2.up;
//	}
//
//	void LateUpdate() {
//		XRotation = new Vector2 (mapTarget.right.x, - mapTarget.right.z);
//		YRotation = new Vector2 (-mapTarget.forward.x, mapTarget.forward.z);
//	}

	/**
	 * calculate the 2D position of an gameobject with 3D position [otherPos]
	 * XRotation is the X axis of the rotated Vector2
	 * YRotation is the Y axis of the rotated Vector2
	 **/ 
	public Vector2 Position(Vector3 otherPos){

		//Vector3 offset = otherPos - mapTarget.position;
		//Vector2 mapOffset = new Vector2 (offset.x, offset.z);
		//Vector2 newPosition = mapOffset.x * XRotation + mapOffset.y * YRotation;
		var offset = (otherPos - mapTarget.position);
		offset = new Vector2(offset.x, offset.z);
		var newPosition = Quaternion.AngleAxis(mapTarget.rotation.eulerAngles.y, Vector3.forward) * offset;
		return zoomLevel * newPosition;
	}

	public Quaternion Rotation (Quaternion otherRotation){
		Quaternion newRotation = otherRotation * mapTarget.rotation;
		return Quaternion.Euler(0, 0, newRotation.eulerAngles.y);
	}
}
