using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerBoxBehaviour : MonoBehaviour {

	public float speed = 5;
	public bool boxOnScreen = false;
	private Rigidbody2D rb2d;

	void Start(){
		rb2d = GetComponent<Rigidbody2D> ();
		if (boxOnScreen) {
			Vector2 movement = new Vector2 (5 * GameStatus.game_speed, 0);
			rb2d.velocity = movement;
		}
	}

	private void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "floor") {
			GameStatus.combo = 0;
			GameStatus.hp -= 200f;
			DestroyObject (gameObject);
		}
	}

	void Update(){
		if (GameStatus.fever == true && boxOnScreen) {
			Vector2 movement = new Vector2 (5 * GameStatus.game_speed, 0);
			rb2d.velocity = movement;
		}	
	}
}
