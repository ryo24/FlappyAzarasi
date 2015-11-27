using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {
	public float maxHeight;
	public float minHeight;
	public GameObject pivot;

	// Use this for initialization
	void Start () {
		ChangeHeight ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void ChangeHeight(){
		float height = Random.Range (minHeight, maxHeight);
		pivot.transform.localPosition = new Vector3 (0.0f, height, 0.0f);
	}

	void OnScrollEnd(){
		ChangeHeight ();
		Debug.Log ("OnScrollEnd()");
	}

}
