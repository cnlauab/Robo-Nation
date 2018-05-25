using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject boxObj;
	public bool stopSpawning = false;
	public float spawnTime;
	private float spawnDelay;

	void Start(){
		Invoke ("SpawnObject", spawnTime);
	}

	void SpawnObject(){
		float rn = Random.Range (0.5f, 1f);
		spawnDelay = (rn / GameStatus.game_speed);
		//Debug.Log (GameStatus.game_speed + " / " + rn + " = " + spawnDelay);
		GameObject spawn_box = Instantiate (boxObj, transform.position, transform.rotation);
		spawn_box.GetComponent<LowerBoxBehaviour>().boxOnScreen = true;
		Invoke ("SpawnObject", spawnDelay);

		if (stopSpawning) {
			CancelInvoke ("SpawnObject");
		}
	}


}
