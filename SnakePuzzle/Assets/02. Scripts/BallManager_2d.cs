using UnityEngine;
using System.Collections;
using System.Collections.Generic; //리스트 쓸려고 추가함



public class BallManager_2d : MonoBehaviour {

    public float ballJumpPower;
    public float ballSpeed;
    private float tempTime;
    public GameObject BallPrefab;

    private float moveDist;
    private float tileSize;

    private List<GameObject> balls;
    private int numOfColors;
    private bool isOktoMoveBlock;

    private List<Pos> tempPosToChange;


    private Board inGameBoard;
    private string[,] Block;






    // Use this for initialization
    void Start () {
        balls = new List<GameObject>();
        tempPosToChange = new List<Pos>();
    }
	
	void Update (){


        tempTime = tempTime + Time.deltaTime;
        moveDist += tileSize * Time.deltaTime;

        float y = -ballJumpPower * (moveDist) * (moveDist - tileSize);

        if (moveDist > tileSize / 2)// 처음부터 1/2 거리까지 진행했을때
        {
            isOktoMoveBlock = false; // 블록 변경 불가
        }
        else // 1/2 부터 끝까지 진행했을때
        {
            isOktoMoveBlock = true; // 블록 변경 가능
        }



        if (moveDist > tileSize) // 공이 방향을 바꿔야 할 때 바꿔말하면 공이 튕길때
        {
            
            BallMergeFound();
            AllballBounce();
            List<GameObject> additionalBallList = new List<GameObject>();
            for (int i = 0; i < balls.Count; i++) // 공 방향 변경시킴
            {
                /////////// 밟은
                int tempCounter = 0;
                for (int k = 0; k < tempPosToChange.Count; k++)
                {
                    if (tempPosToChange[i].x_int == balls[i].GetComponent<_2dBall>().getFromPos().x_int)
                    {
                        if (tempPosToChange[i].y_int == balls[i].GetComponent<_2dBall>().getFromPos().y_int)
                        {
                            tempCounter++;
                            break;
                        }
                    }
                }
                if (tempCounter == 0)
                {
                    tempPosToChange.Add(balls[i].GetComponent<_2dBall>().getFromPos());
                }
                ///////////
                

                List<int> ttemp = new List<int>();

                ttemp = getAvailableDirection(balls[i]);

                if (ttemp.Count > 0)
                {
                    
                    string clr = balls[i].GetComponent<_2dBall>().getColor();
                    float tempSize = balls[i].GetComponent<_2dBall>().getBallSize();
                    switch (ttemp.Count)
                    {
                        case 2:
                            tempSize *= 0.79f;
                            break;
                        case 3:
                            tempSize *= 0.69f;
                            break;
                        case 4:
                            tempSize *= 0.63f;
                            break;
                        case 1:
                        default:
                            break;
                    }
                    
                    int num = Random.Range(0, ttemp.Count);

                    balls[i].GetComponent<_2dBall>().setDirection(ttemp[num]);
                    balls[i].GetComponent<_2dBall>().setBallSize(tempSize);
                    ttemp.RemoveAt(num);

                    if (ttemp.Count != 0) {
                        for (int j = 0; j < ttemp.Count; j++){
                            Pos alpha = balls[i].GetComponent<_2dBall>().getFromPos();
                            GameObject a = SpawnBallwithDir(alpha.vectorPos, alpha.x_int, alpha.y_int, ttemp[ttemp.Count - 1], clr, tempSize);
                            //addBallList.Add(SpawnBallwithDir(alpha.vectorPos, alpha.x_int, alpha.y_int, ttemp[ttemp.Count - 1], clr, tempSize));
                            additionalBallList.Add(a);
                        }
                    }
                    
                }
                else // 갈 곳이 없으면 공을 지움
                {
                    Debug.Log("갈 길 없음.");
                    Destroy(balls[i]);
                    balls.RemoveAt(i);
                    i--;
                }

                //myBalls[i].changeDirection();
                ttemp.Clear();
            }
            balls.AddRange(additionalBallList);
            additionalBallList.Clear();
            //myBalls.AddRange(addBallList);
            //addBallList.Clear();
            moveDist = 0;

            BoardManager aaaaa = GameObject.Find("BoardManager").GetComponent<BoardManager>();
            
            for (int i = 0; i < tempPosToChange.Count; i++)
            {
                aaaaa.changeBlock(tempPosToChange[i]);
            }
            tempPosToChange.Clear();
        }
        else // 공 움직이게 함
        {
            for (int i = 0; i < balls.Count; i++)
            {
                balls[i].GetComponent<_2dBall>()._2Dmove(moveDist, y);
            }
        }
        
    }



    public void setNumOfUsedColor(int num)
    {
        numOfColors = num;
    }

    public bool checkIsOkToMoveBlock()
    {
        return isOktoMoveBlock;
    }

    public void setTIleSize(float tileSize)
    {
        this.tileSize = tileSize;
    }
    private void setNumofUsedColor(int want)
    {
        numOfColors = want;
    }

    private int setStartDir(GameObject GA)
    {
        _2dBall a = GA.GetComponent<_2dBall>();
        int tilePosx = a.getFromPos().x_int;
        int tilePosy = a.getFromPos().y_int;

        int BoardHeight = inGameBoard.getBoardHeight();
        int BoardWidth = inGameBoard.getBoardWidth();

        if (tilePosx == 0){
            return 1;
        }else if(tilePosx == BoardWidth-1){
            return 3;
        }else if (tilePosy == 0)
        {
            return 0;
        }else if (tilePosy == BoardHeight - 1)
        {
            return 2;
        }
        else
        {
            Debug.Log("분명히 문제가 있다.");
            return 0;
        }
    }
    public void setTile(ref string[,] Tile)
    {
        Block = Tile;
    }

    public void SetBoard(ref Board a)
    {
        inGameBoard = a;
    }

    private void merge2Ball()
    {

    }
    public void SpawnBall(Vector3 pos, int tilePosX, int tilePosY)
    {
        GameObject Ball = Instantiate(BallPrefab, pos, Quaternion.identity) as GameObject;
        Ball.GetComponent<_2dBall>().init();
        Ball.GetComponent<_2dBall>().setFromPos(tilePosX, tilePosY, pos);
        Ball.GetComponent<_2dBall>().setDirection(setStartDir(Ball));
        Ball.GetComponent<_2dBall>().setColor(getRndColor());
        balls.Add(Ball);
    }

    public GameObject SpawnBallwithDir(Vector3 pos, int tilePosX, int tilePosY, int Dir, string clr, float size)
    {
        GameObject Ball = Instantiate(BallPrefab, pos, Quaternion.identity) as GameObject;
        Ball.GetComponent<_2dBall>().init();
        Ball.GetComponent<_2dBall>().setFromPos(tilePosX, tilePosY, pos);
        Ball.GetComponent<_2dBall>().setDirection(Dir);
        Ball.GetComponent<_2dBall>().setBallSize(size);
        Ball.GetComponent<_2dBall>().setColor(clr);
        return Ball;
        //balls.Add(Ball);
    }

    


    private string getRndColor()
    {
        string color;
        switch (Random.Range(0, numOfColors))
        {
            case 0:
                color = "Red";
                break;
            case 1:
                color = "Blue";
                break;
            case 2:
                color = "Green";
                break;
            case 3:
                color = "Yellow";
                break;
            case 4:
                color = "Purple";
                break;
            default:
                color = "Red";
                break;
        }
        return color;
    }

    private void BallMergeFound()
    {
        List<int> temp = new List<int>();
        for (int i = 0; i < balls.Count; i++) // // 모든공에 대해서 겹침이 발생하는지 찾음 
        {

            for (int j = i + 1; j < balls.Count; j++)
            {
                if (balls[i].GetComponent<_2dBall>().compareDest(balls[j]))
                { // 머지한다
                    Debug.Log("공 겹침 발생?");
                    temp.Add(j); //발생한 공을 임시저장한다.
                }
            }
            
            for (int j = 0; j < temp.Count; j++) // 발생한 공들을 머지한다.
            {
                //balls[i].GetComponent<_2dBall>().setBallSize(balls[i].GetComponent<_2dBall>().getBallSize() + balls[temp[temp.Count - 1]].GetComponent<_2dBall>().getBallSize());
                float tempSize1 = balls[i].GetComponent<_2dBall>().getBallSize();
                float tempSize2 = balls[temp[temp.Count - 1]].GetComponent<_2dBall>().getBallSize();
                balls[i].GetComponent<_2dBall>().setBallSize(Mathf.Pow(Mathf.Pow(tempSize1, 3) + Mathf.Pow(tempSize2, 3), 0.33f));
                Destroy(balls[temp[temp.Count - 1]]);
                balls.RemoveAt(temp[temp.Count - 1]);
                temp.RemoveAt(temp.Count - 1);
                //공 i 와 j를 머지한다.
            }

            temp.Clear();
        }
    }

    private void AllballBounce()
    {
        _2dBall temp2dBallScript;
        for(int i = 0; i < balls.Count; i++)
        {
            Debug.Log("i를 출력합니다. i = " + i);
            temp2dBallScript = balls[i].GetComponent<_2dBall>();

            temp2dBallScript.TotoFrom_Pos();
        }
    }

    private List<int> getAvailableDirection(GameObject a)
    {
        List<int> list = new List<int>();

        string color = a.GetComponent<_2dBall>().getColor();
        int x = a.GetComponent<_2dBall>().getFromPos().x_int;
        int y = a.GetComponent<_2dBall>().getFromPos().y_int;
        Debug.Log(x + " + " + y);

        if (x > 0)
        {
            if (Block[x - 1, y].Equals(color)) // 왼쪽방향 3
            {
                list.Add(3);
            }
        }
        if (x < inGameBoard.getBoardWidth() - 1)
        {
            if (Block[x + 1, y].Equals(color)) // 오른쪽방향 1
            {
                list.Add(1);
            }
        }
        if (y > 0)
        {
            if (Block[x, y - 1].Equals(color)) // 아래쪽방향방향 3
            {
                list.Add(2);
            }
        }

        if (y < inGameBoard.getBoardHeight() - 1)
        {
            if (Block[x, y + 1].Equals(color)) // 위쪽방향 0
            {
                list.Add(0);
            }
        }

        return list;
    }
}
