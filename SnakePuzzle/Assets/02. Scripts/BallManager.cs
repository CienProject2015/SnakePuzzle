using UnityEngine;
using System.Collections;
using System.Collections.Generic; //리스트 쓸려고 추가함



public class BallManager : MonoBehaviour
{
    
    public float ballJumpPower;
    public float ballSpeed;
    public GameObject Ball;
    private float moveDist;
    //private float tileSize;
    private float tempTime;
    private float atime;

    private float scale;

    public static float tileSize;
    private List<GameObject> balls;
    private List<Ball> myBalls;
    private int numOfColors;

    private Board inGameBoard;

    private string[,] Block;
    

    private bool isOktoMoveBlock;

    public bool checkIsOkToMoveBlock()
    {
        return isOktoMoveBlock;
    }


    public void setTile(ref string[,] Tile)
    {
        Block = Tile;
    }
    




    public void SpawnBall(Vector3 pos, int tilePosX, int tilePosY)
    {
        GameObject abc = Instantiate(Ball, pos, Quaternion.identity) as GameObject;
        myBalls.Add(new Ball(ref abc, tilePosX, tilePosY));
        myBalls[myBalls.Count - 1].setColor(getRndColor(numOfColors));
    }

    public void SpawnBall_To_SpecificList(Vector3 pos, int tilePosX, int tilePosY, ref List<Ball> a)
    {
        GameObject abc = Instantiate(Ball, pos, Quaternion.identity) as GameObject;
        a.Add(new Ball(ref abc, tilePosX, tilePosY));
        a[a.Count - 1].setColor(getRndColor(numOfColors));
    }

    private string getRndColor(int numofcolor)
    {
        string color;
        switch (Random.Range(0, numofcolor))
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
        Debug.Log("결정된 색은 " + color);
        return color;
    }

    public void init(float tilesize)
    {
        atime = 0;
        tempTime = 0;
        tileSize = tilesize;
        numOfColors = 3;
        balls = new List<GameObject>();
        myBalls = new List<Ball>();
        
    }

    public int checkDestColor()
    {
        return 0;
    }

    public void SetBoard(ref Board a)
    {
        inGameBoard = a;
    }

    void MergeBallAandB(Ball A, Ball B)
    {
        A.changeSize(A.getBallSize() + B.getBallSize());
        Destroy(B.getBallObject());
        B = null;
    }

    void Update()
    {
       

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
            GameObject Text;
            Text = GameObject.Find("Text");
            

            /*for (int i = 0; i < myBalls.Count; i++)
            {
                myBalls[i].DisplayInfo();
            }*/

            List<int> temp = new List<int>();
            for (int i = 0; i < myBalls.Count; i++) // // 모든공에 대해서 겹침이 발생하는지 찾음 
            {
                
                for(int j= i+1; j< myBalls.Count; j++)
                {
                    if (myBalls[i].compareDest(myBalls[j])) { // 머지한다
                        Debug.Log("공 겹침 발생?");
                        temp.Add(j); //공을 머지한다.
                    }
                }
                for(int j = 0; j<temp.Count; j++) // 발생한 공들을 머지한다.
                {
                    MergeBallAandB(myBalls[i], myBalls[temp[temp.Count - 1]]);
                    myBalls.RemoveAt(temp[temp.Count - 1]);
                    temp.RemoveAt(temp.Count - 1);
                    //공 i 와 j를 머지한다.
                }

                temp.Clear();
            }

            List<Ball> addBallList = new List<Ball>();

            for (int i = 0; i < myBalls.Count; i++) // 공 위치 변경시킴
            {
                List<int> ttemp = new List<int>();
                myBalls[i]._2Dmove(tileSize, y);
                string color = myBalls[i].getColor();

                //myBalls[i].setBoundStartPos();
                myBalls[i].setBoundStartPos();

                ttemp = changeDir_AndGenBall(myBalls[i]);

                if (ttemp.Count > 0)
                {

                    float tempSize = myBalls[i].getBallSize() / ttemp.Count;
                    //사이즈를 변동하려면 주석을 지운다.
                    myBalls[i].setDirection(ttemp[ttemp.Count - 1]);
                    myBalls[i].changeSize(tempSize);
                    ttemp.RemoveAt(ttemp.Count - 1);

                    for (int j = 0; j < ttemp.Count; j++)
                    {

                        SpawnBall_To_SpecificList(myBalls[i].getVectorPos(), myBalls[i].getToX(), myBalls[i].getToY(), ref addBallList);

                        addBallList[addBallList.Count - 1].setColor(color);
                        addBallList[addBallList.Count - 1].setDirection(ttemp[ttemp.Count - 1]);
                        ttemp.RemoveAt(ttemp.Count - 1);
                        addBallList[addBallList.Count - 1].changeSize(tempSize);
                    }

                }
                else
                {
                    Destroy(myBalls[i].getBallObject());
                    myBalls.RemoveAt(i);
                    i--;
                }
                
                //myBalls[i].changeDirection();
                ttemp.Clear();
            }
            myBalls.AddRange(addBallList);
            addBallList.Clear();
            moveDist = 0;

        }
        else // 공 움직이게 함
        {
            for (int i = 0; i < myBalls.Count; i++)
            {
                myBalls[i]._2Dmove(moveDist, y);
            }
        }
    }

    private List<int> changeDir_AndGenBall(Ball a)
    {
        List<int> list = new List<int>();

        string color = a.getColor();
        int x = a.getToX();
        int y = a.getToY();
        
        if (x > 0)
        {
            if (Block[x - 1,y].Equals(color)) // 왼쪽방향 3
            {
                list.Add(3);
            }
        }
        if(x<inGameBoard.getBoardWidth() - 1)
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
