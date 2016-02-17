using UnityEngine;
using System.Collections;

struct integerXandY
{
    public int x;
    public int y;
}

public struct Pos
{
    public int x_int;
    public int y_int;

    public Vector3 vectorPos;
}

public class _2dBall : MonoBehaviour {
    private static int ballNum = 0; //공 카운터
    private int myNum;//이 공의 번호
    private Transform myTransform;
    private Transform myChild_Ball_transform;
    private Pos toPos;
    private Pos fromPos;

    /*private integerXandY fromTilePos; //공이 출발하는 장소
    private integerXandY toTilePos;   //공이 도착하는 장소*/

    public Sprite[] Sprites;
    private Sprite currentSprite;

    private float ballSize;
    private int direction;
    private string color;
    
    
    public void init()
    {
        myNum = ++ballNum;


        myTransform = GetComponent<Transform>();
        myTransform.parent = GameObject.Find("BallManager").transform;
        myChild_Ball_transform = myTransform.FindChild("Ball");

        currentSprite = myTransform.FindChild("Ball").GetComponent<SpriteRenderer>().sprite;
        ballSize = 1;

        //setColor("Red");
    }

    public void TotoFrom_Pos()
    {
        fromPos = toPos;
    }
    public void setFromPos(int x, int y, Vector3 a)
    {
        fromPos.x_int = x;
        fromPos.y_int = y;
        fromPos.vectorPos = a;
    }
    public void setToPos(int x, int y, Vector3 a)
    {
        toPos.x_int = x;
        toPos.y_int = y;
        toPos.vectorPos = a;
    }
    public Pos getFromPos()
    {
        return fromPos;
    }
    public Pos getToPos()
    {
        return toPos;
    }


    public void setDirection(int dir)
    {
        direction = dir;
    }

    public void setBallSize(float size)
    {
        ballSize = size;
        if (ballSize > 2)
        {
            ballSize = 1;
        }
        if (ballSize < 0.66f)
        {
            ballSize = 0.66f;
        }
        myTransform.localScale = new Vector3(ballSize, ballSize, ballSize);
    }
    public float getBallSize()
    {
        return ballSize;
    }

    public Vector3 getballTranformPosition()
    {
        return GetComponent<Transform>().position;
    }

    public string getColor()
    {
        return color;
    }
    public void setColor(string wantcolor)
    {
        color = wantcolor;
        changeSprite(color);
    }
    public void changeSprite(string color)
    {
        Debug.Log(color);
        int num = 99;
        switch (color)
        {
            case "Red":
                num = 0;
                break;
            case "Blue":
                num = 1;
                break;
            case "Yellow":
                num = 2;
                break;
            case "Green":
                num = 3;
                break;
            case "Purple":
                num = 4;
                break;
            default:
                num = 99;
                break;
        }
        Debug.Log(num + "  " + Sprites.Length);

        if (Sprites.Length > num)
        {
            Debug.Log(currentSprite.name + "에서");
            currentSprite = Sprites[num];
            Debug.Log(currentSprite.name + "로 색 바뀜");
        }
        else
        {
            Debug.Log("Invaild Request : color");
        }

    }

    public void _2Dmove(float moveDist, float y)
    {
        Vector3 tempVec = fromPos.vectorPos;
        if (direction == 3)//방향이 왼쪽일때
        {
            myTransform.position = new Vector3(tempVec.x - moveDist, tempVec.y, -0.5f);
            //ballTransform.position = new Vector3(myBoundStartPos.x - moveDist, myBoundStartPos.y, -0.5f);
        }
        else if (direction == 1)//오른쪽일때
        {
            myTransform.position = new Vector3(tempVec.x + moveDist, tempVec.y, -0.5f);
            //ballTransform.position = new Vector3(myBoundStartPos.x + moveDist, myBoundStartPos.y, -0.5f);
        }
        else if (direction == 2)//아래일때
        {
            myTransform.position = new Vector3(tempVec.x, tempVec.y - moveDist, -0.5f);
            //ballTransform.position = new Vector3(myBoundStartPos.x, myBoundStartPos.y - moveDist, -0.5f);
        }
        else//위일때
        {
            myTransform.position = new Vector3(tempVec.x, tempVec.y + moveDist, -0.5f);
            //ballTransform.position = new Vector3(myBoundStartPos.x, myBoundStartPos.y + moveDist, -0.5f);
        }
        //Debug.Log(myTransform.position);
        myChild_Ball_transform.position = new Vector3(myChild_Ball_transform.position.x, myTransform.position.y + y + 0.2f * BallManager.tileSize, -0.5f);
    }
}
