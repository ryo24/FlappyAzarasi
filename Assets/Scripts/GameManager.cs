using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	enum State{
		Ready,
		Play,
		GameOver
	}

	State state;
	int score;

	public AzarashiContoller azarashi;
	public GameObject blocks;
	public Text scoreLabel;
	public Text stateLabel;

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

		scoreLabel.text = "Score : " + 0;

		stateLabel.gameObject.SetActive(true);
		stateLabel.text = "Ready";
	}

	void GameStart(){
		state = State.Play;

		azarashi.SetSteerActive(true);
		blocks.SetActive(true);

		azarashi.Flap();

		stateLabel.gameObject.SetActive(false);
		stateLabel.text = "";
	}

	void GameOver(){
		state = State.GameOver;

		ScrollScript[] scrollObjects = GameObject.FindObjectsOfType<ScrollScript>();

		foreach (ScrollScript ss in scrollObjects){
			ss.enabled = false;
		}

		stateLabel.gameObject.SetActive(true);
		stateLabel.text = "GameOver";
	}

	void Reload(){
		Application.LoadLevel(Application.loadedLevel);
	}

	public void IncreaseScore(){
		score++;
		scoreLabel.text = "Score : " + score;
	}
}
