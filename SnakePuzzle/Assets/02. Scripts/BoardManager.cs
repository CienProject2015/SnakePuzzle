using UnityEngine;
using System.Collections;
using System.Collections.Generic; //리스트 쓸려고 추가함

public class BoardManager : MonoBehaviour {
    private Board mainBoard;
    public int board_Height;
    public int board_Width;

    
    int BallSpawnTime = 5;
    float timer = 0.0f;

    private float tileSize = 1.0f;
    private string[,] tile;

    private List<Vector3> ballSpawnPos = new List<Vector3>();
    private List<GameObject> balls = new List<GameObject>();

    private GameObject[,] TileObject;

    public GameObject Ball;
    public GameObject RedTile;
    public GameObject YellowTile;
    public GameObject GreenTile;
    public GameObject BlueTile;
    public GameObject PurpleTile;
    public GameObject SpawnTile;

	// Use this for initialization
	void Start () {
        initialize();
        
	}
    void initialize()
    {
        timer = 4;

        mainBoard = new Board(board_Height, board_Width);
        //tile = loadMapFile(stage, level);
        tile = mainBoard.getTile();
        TileObject = new GameObject[board_Height, board_Width];
        /*for (int i = 0; i < board_Height; i++)
        {
            for (int j = 0; j < board_Width; j++)
            {
                TileObject[i, j] = new GameObject();
            }
        }*/

        getAllSpawnPos_of_Ball();
        DrawBoard();
    }


    private void getAllSpawnPos_of_Ball(){
        for (int i = 0; i < board_Width; i++)
        {
            for (int j = 0; j < board_Height; j++)
            {
                if (tile[i, j].Contains("Spawn"))
                {
                    ballSpawnPos.Add(new Vector3(i, j, 0));
                }
            }
        }
    }

	// Update is called once per frame
	void Update () {
        timer = timer + Time.deltaTime;
        if (timer > BallSpawnTime)
        {
            timer = 0;
            SpawnBall_in_RandPos();
            SpawnBall_in_RandPos();
            SpawnBall_in_RandPos();
            ballSpawnPos.Clear();
            getAllSpawnPos_of_Ball();
        }
	    
	}

    public void DrawBoard()
    {
        Debug.Log("보드 생성중");
        Debug.Log(board_Height);
        Debug.Log(board_Width);

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
        //Instantiate(brick, Vector3(x, y, 0), Quaternion.identity);
    }

    public void SpawnBall_in_RandPos()
    {
        int temp = Random.Range(0,ballSpawnPos.Count);
        SpawnBall(ballSpawnPos[temp]);
        ballSpawnPos.RemoveAt(temp);
    }
    public void SpawnBall(Vector3 pos){
        
        balls.Add(Instantiate(Ball, pos, Quaternion.identity)as GameObject);

        balls[balls.Count-1].GetComponent<BallMoving>().SetPos(pos);
    }
    public void Swap()
    {

    }
    
}
