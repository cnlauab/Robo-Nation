using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void PlayGame(string sceneIndex){
		//SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
		SceneManager.LoadScene (sceneIndex);
	}

	public void Sayhello(){
		Debug.Log ("Hello world");
	}

	public void Exit(){
		Application.Quit ();
	}
}
