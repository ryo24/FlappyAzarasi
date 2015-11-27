using UnityEngine;
using System.Collections;

public class AzarashiContoller : MonoBehaviour {
	Rigidbody2D  rd2d;
	Animator animator;
	float angle;
	bool isDead;

	public float maxHeight;
	public float flapVelocity;
	public float relativeVelocityX;  //ditermined by Inspector 
	public  GameObject sprite ;

	void Awake(){
		rd2d = GetComponent<Rigidbody2D> ();
		animator = sprite.GetComponent<Animator> ();
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown ("Fire1") && transform.position.y < maxHeight) {
			Flap ();
		}

		ApplyAngle ();

		animator.SetBool ("isFlap", angle >= 0.0f);
	
	}

	public void Flap(){

		if (isDead) {
			return;
		}

		if (rd2d.isKinematic) {
			return;
		}
		rd2d.velocity = new Vector2 (0.0f, flapVelocity);
	}

	void ApplyAngle(){
		float targetAngle;

		if (isDead) {
			targetAngle = -80.0f;
		} else {

			targetAngle = Mathf.Atan2 (rd2d.velocity.y, relativeVelocityX) * Mathf.Rad2Deg; 
		}
			 
		angle = Mathf.Lerp (angle, targetAngle, Time.deltaTime * 10.0f);

		sprite.transform.localRotation = Quaternion.Euler (0.0f, 0.0f, angle);
	}

	public void OnCollisionEnter2D(Collision2D collision){
		if (isDead) {
			return;
		}

		isDead = true;  


	}

	public void SetSteerActive(bool active){
		rd2d.isKinematic = !active;

	}

}
