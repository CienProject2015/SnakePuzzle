using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Board_Maker : MonoBehaviour {

	private Board mainBoard;
	private int board_Height;
	private int board_Width;

	private float tileSize = 60f;
	private string[,] tile;

	private GameObject[,] TileObject;

	public GameObject BlackTile;


	public void put_size(int h, int w){
		this.board_Height = h;
		this.board_Width = w;
	}

	public Board_Maker(){
		this.board_Height = 5;
		this.board_Width = 5;
	}

	void Start(){
		board_Height = ActionListener.get_size ()[0];
		board_Width = ActionListener.get_size ()[1];

		mainBoard = new Board(board_Height, board_Width);
		tile = mainBoard.getTile();
		TileObject = new GameObject[board_Height, board_Width];
		DrawBoard ();
	}


	public void DrawBoard()	{
		Debug.Log("보드 생성-Draw");
		Debug.Log("보드 생성-Drawh : "+board_Height);
		Debug.Log("보드 생성-Draww : "+board_Width);
		//RedTile = Resources.Load<GameObject> ("Tile_Red");
		//Debug.Log(GameObject.Find("Board"));

		for (int i = 0; i < board_Height; i++){
			for (int j = 0; j < board_Width; j++){
				TileObject[i, j] = Instantiate(BlackTile, new Vector3(i * tileSize+((board_Height-3)*30), j * tileSize+((board_Width-3)*30), 0), Quaternion.identity) as GameObject;
				TileObject[i, j].transform.parent = GameObject.Find("Board").transform;
				Debug.Log("보드 생성 : "+i);
				}
			}	
	}




}




