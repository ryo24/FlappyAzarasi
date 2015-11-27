using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	enum State{
		Ready,
		Play,
		GameOver
	}

	State state;

	public AzarashiContoller azarashi;
	public GameObject blocks;

	// Use this for initialization
	void Start () {
		Ready ();
	
	}

	// Update is called once per frame
	void Update () {
	
	}

	void LateUpdate(){
		switch (state){
		case State.Ready:
			if(Input.GetButtonDown("Fire1")){
				GameStart();
			}
			break;
		case State.Play:
			if(azarashi.IsDead()){
				GameOver();
			}
			break;
		case State.GameOver:
			if (Input.GetButtonDown ("Fire1")){
				Reload();
			}
			break;
		}
	}

	void Ready() {
		state = State.Ready;

		azarashi.SetSteerActive(false);
		blocks.SetActive(false);
	}

	void GameStart(){
		state = State.Play;

		azarashi.SetSteerActive(true);
		blocks.SetActive(true);

		azarashi.Flap();
	}

	void GameOver(){
		state = State.GameOver;

		ScrollScript[] scrollObjects = GameObject.FindObjectsOfType<ScrollScript>();

		foreach (ScrollScript ss in scrollObjects){
			ss.enabled = false;
		}
	}

	void Reload(){
		Application.LoadLevel(Application.loadedLevel);
	}
}
