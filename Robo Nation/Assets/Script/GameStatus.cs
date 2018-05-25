using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStatus : MonoBehaviour {

	public GameObject boxObj;
	public GameObject buttonUI;
	public GameObject gameOverUI;

	public bool paused = false;

	public static float score = 0;
	private float prev_score = score;
	public static float game_speed = 1;
	public static float hp = 500;
	private float prev_hp = hp;
	public static float combo = 0;
	private float prev_combo = combo;
	public static bool fever = false;
	public Text ScoreText;
	public Text HealthText;
	public Text ComboText;

	void Start(){
		buttonUI.SetActive (false);
		gameOverUI.SetActive (false);
		Time.timeScale = 1;
		hp = 500;
		score = 0;
		game_speed = 1;
		combo = 0;
		updateScoreText ();
		updateHealthText ();
		updateComboText ();
		StartCoroutine ("spawnUpper");

	}

	void Update(){
		if (prev_score != score) {
			updateScoreText ();
		}
		if (prev_hp != hp) {
			updateHealthText ();
		}
		if (prev_combo != combo) {
			updateComboText ();
		}
		if (!fever && (combo == 20 || combo%40 == 0) && combo != 0) {
			StartCoroutine ("goFever");
		}

		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			StartCoroutine ("spawnUpper");
		}

		if (hp <= 0) {
			gameOverUI.SetActive (true);
			Time.timeScale = 0;
		}
	}

	void updateScoreText(){
		ScoreText.text = "Score: " + score.ToString ();
		prev_score = score;
		//Debug.Log (ScoreText.text);
	}

	void updateHealthText(){
		HealthText.text = "HP: " + hp.ToString ();
		prev_hp = hp;
		//Debug.Log (HealthText.text);
	}

	void updateComboText(){
		ComboText.text = "Combo: " + combo.ToString ();
		prev_combo = combo;
		//Debug.Log (ComboText.text);
	}

	IEnumerator goFever(){
		Debug.Log ("Go Fever");
		fever = true;
		game_speed = game_speed * 1.5f;
		yield return new WaitForSeconds(10);
		game_speed = game_speed / 1.5f;
		Debug.Log ("Exit Fever");
		fever = false;
	}

	IEnumerator spawnUpper(){
		GameObject spawn_box = Instantiate (boxObj, new Vector2 (0, 3), Quaternion.identity);
		spawn_box.GetComponent<BoxBehaviour> ().boxOnScreen = true;
		Collider2D spawn_collider = spawn_box.GetComponent<Collider2D>();
		spawn_collider.enabled = !spawn_collider.enabled;
		yield return new WaitForSeconds (0.1f);
		spawn_collider.enabled = !spawn_collider.enabled;
	}

	public void Pause(){
		if (Time.timeScale == 1) {
			buttonUI.SetActive (true);
			Time.timeScale = 0;

		} else if (Time.timeScale == 0) {
			buttonUI.SetActive (false);
			Time.timeScale = 1;
		}
	}

	public void Play(){
		SceneManager.LoadScene("game");
	}

	public void Menu(){
		SceneManager.LoadScene ("menu");
	}

	public void Exit(){
		Application.Quit ();
	}
}
