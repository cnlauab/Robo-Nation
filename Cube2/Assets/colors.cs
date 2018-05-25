using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class colors : MonoBehaviour {

	public Text SolutionText;
	public static string solution;

	string[] allMoves = { "T0", "T1", "T2", "F0", "F1", "F2"};
	List<string[]> moveList = new List<string[]> ();
		
	public class Cube{
		public Face[] faces = new Face[6];
		public int dimension;

		//3 x 3 Cube Construction
		public Cube(){
			this.dimension = 3;
			string[] colors = {"w","y","r","b","g","o"};
			for(int i = 0; i < colors.Length; i++){
				this.faces[i] = new Face(colors[i], colors[i]);
			}
		}

		public Cube(Cube cube){
			this.dimension = cube.dimension;
			for(int i = 0; i < this.faces.Length; i++){
				this.faces[i] = new Face(this.faces[i]);
			}
		}

		public void printCube(){
			Debug.Log ("Cube now is:");
			for (int i = 0; i < faces.Length; i++) {
				Debug.Log (faces [i].name);
				Debug.Log (faces [i].squares [0].name + "," +
				faces [i].squares [1].name + "," +
				faces [i].squares [2].name + "," +
				faces [i].squares [3].name + "," +
				faces [i].squares [4].name + "," +
				faces [i].squares [5].name + "," +
				faces [i].squares [6].name + "," +
				faces [i].squares [7].name + "," +
				faces [i].squares [8].name + ",");
			}
		}

		//layers(integers from 0 to 2) 
		public void T(int layers){
			Face[] tempfaces = new Face[6];
			for (int i = 0; i < 6; i++) {
				tempfaces [i] = new Face (this.faces [i]);
			}
				
			//Rotate top face
			if(layers == 0){
				this.faces[0].squares[0] = tempfaces[0].squares[2];
				this.faces[0].squares[1] = tempfaces[0].squares[5];
				this.faces[0].squares[2] = tempfaces[0].squares[8];
				this.faces[0].squares[3] = tempfaces[0].squares[1];
				this.faces[0].squares[5] = tempfaces[0].squares[7];
				this.faces[0].squares[6] = tempfaces[0].squares[0];
				this.faces[0].squares[7] = tempfaces[0].squares[3];
				this.faces[0].squares[8] = tempfaces[0].squares[6];
			}
			//Rotate side faces
			this.faces[1].squares[0+layers*3] = tempfaces[4].squares[0+layers*3];
			this.faces[1].squares[1+layers*3] = tempfaces[4].squares[1+layers*3];
			this.faces[1].squares[2+layers*3] = tempfaces[4].squares[2+layers*3];
			this.faces[2].squares[0+layers*3] = tempfaces[1].squares[0+layers*3];
			this.faces[2].squares[1+layers*3] = tempfaces[1].squares[1+layers*3];
			this.faces[2].squares[2+layers*3] = tempfaces[1].squares[2+layers*3];
			this.faces[3].squares[0+layers*3] = tempfaces[2].squares[0+layers*3];
			this.faces[3].squares[1+layers*3] = tempfaces[2].squares[1+layers*3];
			this.faces[3].squares[2+layers*3] = tempfaces[2].squares[2+layers*3];
			this.faces[4].squares[0+layers*3] = tempfaces[3].squares[0+layers*3];
			this.faces[4].squares[1+layers*3] = tempfaces[3].squares[1+layers*3];
			this.faces[4].squares[2+layers*3] = tempfaces[3].squares[2+layers*3];


			//Rotate bottom face
			if(layers == this.dimension){
				this.faces[this.faces.Length-1].squares[0] = tempfaces[this.faces.Length-1].squares[2];
				this.faces[this.faces.Length-1].squares[1] = tempfaces[this.faces.Length-1].squares[5];
				this.faces[this.faces.Length-1].squares[2] = tempfaces[this.faces.Length-1].squares[8];
				this.faces[this.faces.Length-1].squares[3] = tempfaces[this.faces.Length-1].squares[1];
				this.faces[this.faces.Length-1].squares[5] = tempfaces[this.faces.Length-1].squares[7];
				this.faces[this.faces.Length-1].squares[6] = tempfaces[this.faces.Length-1].squares[0];
				this.faces[this.faces.Length-1].squares[7] = tempfaces[this.faces.Length-1].squares[3];
				this.faces[this.faces.Length-1].squares[8] = tempfaces[this.faces.Length-1].squares[6];
			}

		}

		public void RT(int layers){
			for(int i = 0; i < 3; i++){
				this.T (layers);
			}
		}

		public void F(int layers){
			Face[] tempfaces = new Face[6];
			for (int i = 0; i < 6; i++) {
				tempfaces [i] = new Face (this.faces [i]);
			}
			//Rotate front face
			if(layers == 0){
				this.faces[2].squares[0] = tempfaces[2].squares[2];
				this.faces[2].squares[1] = tempfaces[2].squares[5];
				this.faces[2].squares[2] = tempfaces[2].squares[8];
				this.faces[2].squares[3] = tempfaces[2].squares[1];
				this.faces[2].squares[5] = tempfaces[2].squares[7];
				this.faces[2].squares[6] = tempfaces[2].squares[0];
				this.faces[2].squares[7] = tempfaces[2].squares[3];
				this.faces[2].squares[8] = tempfaces[2].squares[6];
			}
			//Rotate side face
			this.faces[0].squares[6-layers*3] = tempfaces[3].squares[0+layers];
			this.faces[0].squares[7-layers*3] = tempfaces[3].squares[3+layers];
			this.faces[0].squares[8-layers*3] = tempfaces[3].squares[6+layers];
			this.faces[3].squares[0+layers] = tempfaces[5].squares[2+layers*3];
			this.faces[3].squares[3+layers] = tempfaces[5].squares[1+layers*3];
			this.faces[3].squares[6+layers] = tempfaces[5].squares[0+layers*3];
			this.faces[5].squares[2+layers*3] = tempfaces[1].squares[2-layers];
			this.faces[5].squares[1+layers*3] = tempfaces[1].squares[5-layers];
			this.faces[5].squares[0+layers*3] = tempfaces[1].squares[8-layers];
			this.faces[1].squares[2-layers] = tempfaces[0].squares[8-layers*3];
			this.faces[1].squares[5-layers] = tempfaces[0].squares[7-layers*3];
			this.faces[1].squares[8-layers] = tempfaces[0].squares[6-layers*3];
			//Rotate back face
			if(layers == this.dimension){
				this.faces[4].squares[0] = tempfaces[4].squares[6];
				this.faces[4].squares[1] = tempfaces[4].squares[3];
				this.faces[4].squares[2] = tempfaces[4].squares[0];
				this.faces[4].squares[3] = tempfaces[4].squares[7];
				this.faces[4].squares[5] = tempfaces[4].squares[1];
				this.faces[4].squares[6] = tempfaces[4].squares[8];
				this.faces[4].squares[7] = tempfaces[4].squares[5];
				this.faces[4].squares[8] = tempfaces[4].squares[2];
			}
		}

		public void RF(int layers){
			for(int i = 0; i < 3; i++){
				F (layers);
			}
		}

		public void L(int layers){
			T(0);
			T(1);
			T(2);
			F(layers);
			RT(0);
			RT(1);
			RT(2);
		}

		public void R(int layers){
			RT(0);
			RT(1);
			RT(2);
			F(layers);
			T(0);
			T(1);
			T(2);
		}

		public void B(int layers){
			T(0);
			T(1);
			T(2);
			T(0);
			T(1);
			T(2);
			F(layers);
			T(0);
			T(1);
			T(2);
			T(0);
			T(1);
			T(2);
		}

		public void RL(int layers){
			T(0);
			T(1);
			T(2);
			RF(layers);
			RT(0);
			RT(1);
			RT(2);
		}

		public void RR(int layers){
			RT(0);
			RT(1);
			RT(2);
			RF(layers);
			T(0);
			T(1);
			T(2);
		}

		public void RB(int layers){
			T(0);
			T(1);
			T(2);
			T(0);
			T(1);
			T(2);
			RF(layers);
			T(0);
			T(1);
			T(2);
			T(0);
			T(1);
			T(2);
		}



		public string suffle(){
			string result = "Move-Sequence used: ";
			for (int i = 0; i < 1000; i++) {
				int state = Random.Range (0, 10);
				int layer = Random.Range (0, 3);
				//state = i % 10;
				//int layer = 1;
				if (0 <= state && state < 1) {
					T (layer);
					//Debug.Log ("T"+layer);
					result = string.Concat (result, "T" + layer + ", ");
				}else if (1 <= state && state < 2) {
					RT (layer);
					//Debug.Log ("RT"+layer);
					result = string.Concat (result, "RT" + layer + ", ");
				}else if (2 <= state && state < 3) {
					F (layer);
					//Debug.Log ("F"+layer);
					result = string.Concat (result, "F" + layer + ", ");
				}else if (3 <= state && state < 4) {
					RF (layer);
					//Debug.Log ("RF"+layer);
					result = string.Concat (result, "RF" + layer + ", ");
				}else if (4 <= state && state < 5) {
					R (layer);
					//Debug.Log ("R"+layer);
					result = string.Concat (result, "R" + layer + ", ");
				}else if (5 <= state && state < 6) {
					RR (layer);
					//Debug.Log ("RR"+layer);
					result = string.Concat (result, "RR" + layer + ", ");
				}else if (6 <= state && state < 7) {
					L (layer);
					//Debug.Log ("L"+layer);
					result = string.Concat (result, "L" + layer + ", ");
				}else if (7 <= state && state < 8) {
					RL (layer);
					//Debug.Log ("RL"+layer);
					result = string.Concat (result, "RL" + layer + ", ");
				}else if (8 <= state && state < 9) {
					B (layer);
					//Debug.Log ("B"+layer);
					result = string.Concat (result, "B" + layer + ", ");
				}else if (9 <= state && state <= 10) {
					RB (layer);
					//Debug.Log ("RB"+layer);
					result = string.Concat (result, "RB" + layer + ", ");
				}
			}
			solution = result;
			Debug.Log (result);
			return result;
		}
	}

	public class Face{
		public string name;
		public Square[] squares = new Square[9];

		public Face(string name, string color){
			this.name = name;
			for(int i = 0; i < 9; i++){
				this.squares[i] = new Square(color);
			}
		}

		public Face(Face face){
			this.name = face.name;
			for(int i = 0; i < face.squares.Length; i++){
				this.squares[i] = new Square(face.squares[i]);
			}
		}

	}

	public class Square{
		public string name;
		public Square(string color){
			this.name = color;
		}
		public Square(Square square){
			this.name = square.name;
		}
	}

	public bool checkFinished(Cube cube){
		for (int i = 0; i < cube.faces.Length; i++) {
			if(cube.faces[i].squares[0].name != cube.faces[i].squares[1].name || 
				cube.faces[i].squares[0].name != cube.faces[i].squares[2].name || 
				cube.faces[i].squares[0].name != cube.faces[i].squares[3].name || 
				cube.faces[i].squares[0].name != cube.faces[i].squares[4].name || 
				cube.faces[i].squares[0].name != cube.faces[i].squares[5].name || 
				cube.faces[i].squares[0].name != cube.faces[i].squares[6].name || 
				cube.faces[i].squares[0].name != cube.faces[i].squares[7].name ||
				cube.faces[i].squares[0].name != cube.faces[i].squares[8].name)
			{
				return false;
			}
		}
		return true;
	}
	/*
	public string[] solve(List<Cube> cubeList){
		int numNode = cubeList.Count;
		Debug.Log (numNode);

		for (int x = 0; x < numNode; x++) {
			cubeList [x].printCube();
		}
		for (int i = 0; i < numNode; i++) {
			Cube tempCube;
			string[] newMoveSeq;
			if (moveList.Count == 0) {
				
				for (int j = 0; j < allMoves.Length; j++) {
					string move = allMoves [j];
					newMoveSeq = new string[1];
					newMoveSeq[0] = move;

					switch (move) {
					case "T0":
						tempCube = new Cube (cubeList [i]);
						T (tempCube, 0);
						break;
					case "T1":
						tempCube = new Cube (cubeList [i]);
						T (tempCube, 1);
						break;
					case "T2":
						tempCube = new Cube (cubeList [i]);
						T (tempCube, 2);
						break;
					case "F0":
						tempCube = new Cube (cubeList [i]);
						F (tempCube, 0);
						break;
					case "F1":
						tempCube = new Cube (cubeList [i]);
						F (tempCube, 1);
						break;
					case "F2":
						tempCube = new Cube (cubeList [i]);
						F (tempCube, 2);
						break;
					default:
						tempCube = new Cube ();
						Debug.Log ("Error");
						break;
					}

					if (checkFinished (tempCube) == true) {
						return newMoveSeq;
					} else {
						cubeList.Add (tempCube);
						moveList.Add (newMoveSeq);
					}
				}


			} else {
				
				string[] result = new string[1];
				result [0] = "Error";
				return result;
				string[] prevMove = moveList [0];

				for (int p = 0; p < allMoves.Length; p++) {
					newMoveSeq = new string[prevMove.Length + 1];
					for (int k = 0; k < newMoveSeq.Length - 1; k++) {
						newMoveSeq [k] = prevMove [k];
					}
					newMoveSeq [newMoveSeq.Length - 1] = allMoves [p];
					for (int x = 0; x < newMoveSeq.Length; x++) {
						Debug.Log (newMoveSeq [x]);
					}
					switch (allMoves [p]) {
					case "T0":
						tempCube = new Cube (cubeList [i]);
						T (tempCube, 0);
						break;
					case "T1":
						tempCube = new Cube (cubeList [i]);
						T (tempCube, 1);
						break;
					case "T2":
						tempCube = new Cube (cubeList [i]);
						T (tempCube, 2);
						break;
					case "F0":
						tempCube = new Cube (cubeList [i]);
						F (tempCube, 0);
						break;
					case "F1":
						tempCube = new Cube (cubeList [i]);
						F (tempCube, 1);
						break;
					case "F2":
						tempCube = new Cube (cubeList [i]);
						F (tempCube, 2);
						break;
					default:
						tempCube = new Cube ();
						Debug.Log ("Error");
						break;
					}

					if (checkFinished (tempCube) == true) {
						//tempCube.printCube ();
						return newMoveSeq;
					} else {
						cubeList.Add (tempCube);
						moveList.Add (newMoveSeq);
						//tempCube.printCube ();
						//Debug.Log (moveList.Count);
					}
				}
				moveList.Remove (moveList [0]);
			}
		}
		for (int l = 0; l < numNode; l++) {
			cubeList.Remove (cubeList [0]);
		}
		return solve(cubeList);

	}*/

	void Start(){
		Debug.Log ("Start");
		/*Cube cube = new Cube();
		cube.printCube ();
		Debug.Log ("Solved?: " + checkFinished (cube));
		cube.suffle ();
		//RT(cube,0);
		//RF(cube,0);
		cube.printCube ();
		Debug.Log ("Solved?: " + checkFinished (cube));*/

		/*
		List<Cube> solvingCube = new List<Cube> ();
		solvingCube.Add(cube);
		string[] solution = solve (solvingCube);
		Debug.Log ("Now printing Solution");
		for (int i = 0; i < solution.Length; i++) {
			Debug.Log (solution[i]);
		}*/
	}

	public void Exit(){
		Application.Quit ();
	}


}
