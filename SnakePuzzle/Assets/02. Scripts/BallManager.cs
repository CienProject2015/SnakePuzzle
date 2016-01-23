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
        Debug.Log(tilePosX + "  " + tilePosY);
        myBalls.Add(new Ball(Instantiate(Ball, pos, Quaternion.identity) as GameObject, tilePosX, tilePosY));
        myBalls[myBalls.Count - 1].setColor(getRndColor(numOfColors));
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
                color = "Greed";
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


    void MergeBallAandB(Ball A, Ball B)
    {
        
        A.changeSize(A.showSize() + B.showSize());
        Destroy(B.showBall());
        B = null;
    }

    void Update()
    {
        tempTime = tempTime + Time.deltaTime;
        moveDist += tileSize * Time.deltaTime;

        float y = -ballJumpPower * (moveDist) * (moveDist - tileSize);

        if (moveDist > tileSize / 2)
        {
            isOktoMoveBlock = false;
        }
        else
        {
            isOktoMoveBlock = true;
        }


        
        if (moveDist > tileSize)
        {
            List<int> temp = new List<int>();
            for (int i = 0; i < myBalls.Count; i++)
            {
                
                for(int j= i+1; j< myBalls.Count; j++)
                {
                    if (myBalls[i].compareDest(myBalls[j])) {
                        Debug.Log("공 겹침 발생?");
                        temp.Add(j);
                    }
                }
                for(int j = 0; j<temp.Count; j++)
                {
                    MergeBallAandB(myBalls[i], myBalls[temp[temp.Count - 1]]);
                    myBalls.RemoveAt(temp[temp.Count - 1]);
                    temp.RemoveAt(temp.Count - 1);
                    //공 i 와 j를 머지한다.
                }

                temp.Clear();
            }


            for (int i = 0; i < myBalls.Count; i++)
            {
                myBalls[i]._2Dmove(tileSize, y);
                myBalls[i].changeDirection();
            }
            isOktoMoveBlock = true;
            moveDist = 0;

        }
        else
        {
            for (int i = 0; i < myBalls.Count; i++)
            {
                myBalls[i]._2Dmove(moveDist, y);
            }
        }


    }
}
