using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {

	private int selectedZombiePosistion = 0;
	private int maxZombiePosition;
	public Text scoreText;
	private int score = 0;
	public GameObject selectedZombie;
	public List<GameObject> zombies;
	public Vector3 selectedSize;
	public Vector3 defaultSize;

	// Use this for initialization
	void Start () {
		SelectZombie (selectedZombie);
		scoreText.text = "Score :" + score;
	}
	
	// Update is called once per frame
	void Update () {

		CheckZombiePosition ();

		if (Input.GetKeyDown ("left")){
			GetZombieLeft ();
		}

		if(Input.GetKeyDown ("right")){
			GetZombieRight ();
		}

		if(Input.GetKeyDown ("up") || Input.GetKeyDown("w")){
			PushUp ();
		}

	}

	void GetZombieLeft () {

		maxZombiePosition = zombies.Count - 1;

		if (selectedZombiePosistion == 0) {
			selectedZombiePosistion = maxZombiePosition;
			SelectZombie (zombies [maxZombiePosition]);
		} else {
			selectedZombiePosistion = selectedZombiePosistion - 1;
			GameObject newZombie = zombies [selectedZombiePosistion];
			SelectZombie (newZombie);

		}
	}

	void GetZombieRight () {

		maxZombiePosition = zombies.Count - 1;

		if (selectedZombiePosistion == maxZombiePosition) {
			selectedZombiePosistion = 0;
			SelectZombie (zombies [0]);
		} else {
			selectedZombiePosistion = selectedZombiePosistion + 1;
			GameObject newZombie = zombies [selectedZombiePosistion];
			SelectZombie (newZombie);

		}
	}

	void SelectZombie(GameObject newZombie) {
		
		selectedZombie.transform.localScale = defaultSize;
		selectedZombie = newZombie;
		newZombie.transform.localScale = selectedSize;  // I selected the component ( Transform ) localScale (View inspector)
	}

	void PushUp() {

		Rigidbody rb = selectedZombie.GetComponent<Rigidbody> ();
		rb.AddForce (0, 0, 10, ForceMode.Impulse);  // Verctor force in 3d
	}

	void CheckZombiePosition() {
		for(int i = 0; i < zombies.Count; i++){
			if(zombies[i].transform.position.y < 0.1f) {
				zombies.RemoveAt (i);
			}
		}
	}

	public void AddPoint() {
		score = score + 10;
		scoreText.text = "Score: " + score;
	}
}
