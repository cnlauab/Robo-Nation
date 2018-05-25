using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ui : MonoBehaviour {

	public Text SolutionText;
	public Text currentCube;
	public static string solution;
	colors.Cube cube = new colors.Cube();

	void Start(){
		cube.printCube ();
		updateCube ();
	}

	public void Suffle(int i){
		cube.printCube();
		SolutionText.text = cube.suffle();
		Debug.Log ("Shuffle Finished");
		cube.printCube();
		updateCube ();
	}

	public void T0(){
		cube.printCube();
		cube.T(0);
		Debug.Log ("Move Finished");
		cube.printCube();
	}
	public void T1(){
		cube.printCube();
		cube.T(1);
		Debug.Log ("Move Finished");
		cube.printCube();
		updateCube ();
	}
	public void T2(){
		cube.printCube();
		cube.T(2);
		Debug.Log ("Move Finished");
		cube.printCube();
		updateCube ();
	}
	public void F0(){
		cube.printCube();
		cube.F(0);
		Debug.Log ("Move Finished");
		cube.printCube();
		updateCube ();
	}
	public void F1(){
		cube.printCube();
		cube.F(1);
		Debug.Log ("Move Finished");
		cube.printCube();
		updateCube ();
	}
	public void F2(){
		cube.printCube();
		cube.F(2);
		Debug.Log ("Move Finished");
		cube.printCube();
		updateCube ();
	}
	public void R0(){
		cube.printCube();
		cube.R(0);
		Debug.Log ("Move Finished");
		cube.printCube();
		updateCube ();
	}
	public void R1(){
		cube.printCube();
		cube.R(1);
		Debug.Log ("Move Finished");
		cube.printCube();
		updateCube ();
	}
	public void R2(){
		cube.printCube();
		cube.R(2);
		Debug.Log ("Move Finished");
		cube.printCube();
		updateCube ();
	}
	public void L0(){
		cube.printCube();
		cube.L(0);
		Debug.Log ("Move Finished");
		cube.printCube();
		updateCube ();
	}
	public void L1(){
		cube.printCube();
		cube.L(1);
		Debug.Log ("Move Finished");
		cube.printCube();
		updateCube ();
	}
	public void L2(){
		cube.printCube();
		cube.L(2);
		Debug.Log ("Move Finished");
		cube.printCube();
		updateCube ();
	}
	public void B0(){
		cube.printCube();
		cube.B(0);
		Debug.Log ("Move Finished");
		cube.printCube();
		updateCube ();
	}
	public void B1(){
		cube.printCube();
		cube.B(1);
		Debug.Log ("Move Finished");
		cube.printCube();
		updateCube ();
	}
	public void B2(){
		cube.printCube();
		cube.B(2);
		Debug.Log ("Move Finished");
		cube.printCube();
		updateCube ();
	}

	public void updateCube(){
		string result = "";
		for (int i = 0; i < cube.faces.Length; i++) {
			result = string.Concat (result, "Face " + cube.faces[i].name + ":\n");
			Debug.Log ("Face " + cube.faces[i].name + ":\n");
			result = string.Concat (result, cube.faces [i].squares [0].name + "," + cube.faces [i].squares [1].name + "," + cube.faces [i].squares [2].name + ",\n");
			Debug.Log (cube.faces [i].squares [0].name + "," + cube.faces [i].squares [1].name + "," + cube.faces [i].squares [2].name + ",\n");
			result = string.Concat (result, cube.faces [i].squares [3].name + "," + cube.faces [i].squares [4].name + "," + cube.faces [i].squares [5].name + ",\n");
			Debug.Log (cube.faces [i].squares [3].name + "," + cube.faces [i].squares [4].name + "," + cube.faces [i].squares [5].name + ",\n");
			result = string.Concat (result, cube.faces [i].squares [6].name + "," + cube.faces [i].squares [7].name + "," + cube.faces [i].squares [8].name + ",\n");
			Debug.Log (cube.faces [i].squares [6].name + "," + cube.faces [i].squares [7].name + "," + cube.faces [i].squares [8].name + ",\n\n");
		}
		currentCube.text = result;

	}
	public void reset(){
		for (int i = 0; i < cube.faces.Length; i++) {
			for (int j = 0; j < cube.faces [i].squares.Length; j++) {
				cube.faces [i].squares [j].name = cube.faces [i].name;
			}
		}
		cube.printCube();
		updateCube ();
	}
}
