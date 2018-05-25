using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBehaviour : MonoBehaviour {

	public float gravity = 50;
	private bool boxOnAir = false;
	public bool boxOnScreen = false;
	private Rigidbody2D rb2d;


	void Start(){
		rb2d = GetComponent<Rigidbody2D> ();
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.Mouse0) && !boxOnAir && boxOnScreen){
			boxOnAir = true;
		}
	}

	void FixedUpdate(){
		if (boxOnAir) {
			Vector2 movement = new Vector2 (0, -gravity * GameStatus.game_speed);
			rb2d.velocity = movement;
		}

	}

	private void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "boxLower") {
			Vector2 movement = new Vector2 (0, 0);
			rb2d.velocity = (movement);
			boxOnAir = false;
			//Debug.Log ("X Position Difference: " + compareXposition (other.gameObject));
			updateScore (compareXposition (other.gameObject));
			DestroyObject(gameObject);
			DestroyObject(other.gameObject);
		} else if (other.tag == "floor") {
			
			DestroyObject(gameObject);
		}
	}

	private float compareXposition(GameObject obj){
		return Mathf.Abs(obj.transform.position.x - this.transform.position.x);
	}

	private void updateScore(float positionDiff){
		if (positionDiff <= 0.05) {
			Debug.Log ("Perfect");
			GameStatus.combo += 1;
			GameStatus.score += 1000f * (1f + 0.25f * GameStatus.combo);
		} else if (positionDiff <= 0.5) {
			Debug.Log ("OK");
			GameStatus.combo += 1;
			GameStatus.score += 500f * (1f + 0.12f * GameStatus.combo);
		} else {
			Debug.Log ("Bad");
			GameStatus.combo = 0;
			//GameStatus.score -= 200f;
			GameStatus.hp -= 200f;
		}
	}
}
