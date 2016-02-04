using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Board_Maker : MonoBehaviour {

	private Board mainBoard;
	private int board_Height;
	private int board_Width;

	private float tileSize = 30f;
	private string[,] tile;

	private GameObject[,] TileObject;

	public GameObject RedTile;
	public GameObject YellowTile;
	public GameObject GreenTile;
	public GameObject BlueTile;
	public GameObject PurpleTile;
	public GameObject SpawnTile;

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
				TileObject[i, j] = Instantiate(RedTile, new Vector3(i * tileSize+(145-(board_Height-3)*15), j * tileSize+(161-(board_Height-3)*15), 0), Quaternion.identity) as GameObject;
				TileObject[i, j].transform.parent = GameObject.Find("Board").transform;
				Debug.Log("보드 생성 : "+i);
				}
			}
		
	
		/*
		for (int i = 0; i < board_Height; i++)
		{
			for (int j = 0; j < board_Width; j++)
			{
				switch (tile[i, j])
				{
				case "Red":
					TileObject[i, j] = Instantiate(RedTile, new Vector3(i * tileSize, j * tileSize, 0), Quaternion.identity) as GameObject;
					TileObject[i, j].transform.parent = GameObject.Find("Board").transform;
					//GOlist.Add(Instantiate(RedTile, new Vector3(i * tileSize, j * tileSize, 0), Quaternion.identity));
					//Instantiate(RedTile, new Vector3(i * tileSize, j * tileSize, 0), Quaternion.identity);
					break;
				case "Blue":
					TileObject[i,j] = Instantiate(BlueTile, new Vector3(i * tileSize, j * tileSize, 0), Quaternion.identity) as GameObject;
					TileObject[i, j].transform.parent = GameObject.Find("Board").transform;
					break;
				case "Yellow":
					TileObject[i, j] = Instantiate(YellowTile, new Vector3(i * tileSize, j * tileSize, 0), Quaternion.identity) as GameObject;
					TileObject[i, j].transform.parent = GameObject.Find("Board").transform;
					break;
				case "Green":
					TileObject[i, j] = Instantiate(GreenTile, new Vector3(i * tileSize, j * tileSize, 0), Quaternion.identity) as GameObject;
					TileObject[i, j].transform.parent = GameObject.Find("Board").transform;
					break;
				case "Purple":
					TileObject[i, j] = Instantiate(PurpleTile, new Vector3(i * tileSize, j * tileSize, 0), Quaternion.identity) as GameObject;
					TileObject[i, j].transform.parent = GameObject.Find("Board").transform;
					break;
				case "SpawnLeft":
				case "SpawnRight":
				case "SpawnUp":
				case "SpawnDown":
					TileObject[i, j] = Instantiate(SpawnTile, new Vector3(i * tileSize, j * tileSize, 0), Quaternion.identity) as GameObject;
					TileObject[i, j].transform.parent = GameObject.Find("Board").transform;
					break;
				default:
					Debug.Log("None");
					break;
				}
			}
		}
	*/
	
	
	
	}




}




