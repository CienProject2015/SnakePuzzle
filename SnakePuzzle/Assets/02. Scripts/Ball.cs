using UnityEngine;
using System.Collections;


struct integerXandY {
    public int x;
    public int y;
}

public class Ball{

    private static int ballNum = 0;
    private int myNum;
    private GameObject ball;
    private int dir;
    private integerXandY fromTilePos;
    private integerXandY toTilePos;

    private string color;//"Red", Green Blue Purple Yellow

    private float ballSize;

    private Vector3 myBoundStartPos;//공이 튀어오르는 위치를 말하는 것
    private Transform childTrans;
    private Transform ballTransform;

    public GameObject showBall()
    {
        return ball;
    }

    public Ball(GameObject theBall, int tilePosX, int tilePosY)
    {
        ballSize = 1;
        myNum = ballNum++;
        fromTilePos.x = tilePosX;
        fromTilePos.y = tilePosY;

        ball = theBall;
        ball.transform.parent = GameObject.Find("BallManager").transform;
        ballTransform = ball.GetComponent<Transform>();

        myBoundStartPos = ballTransform.position;
        childTrans = ballTransform.FindChild("Ball").transform; ;
        checkLoc();

        setDestPos();
        Debug.Log(dir);
        showInfo();
        setColor("Red");
    }

    public float showSize()
    {
        return ballSize;
    }
    public void changeSize(float a)
    {
        ballSize = a;

        ballTransform.localScale = new Vector3(ballSize, ballSize, ballSize);
    }

    public void showInfo()
    {
        Debug.Log("my num = " + myNum + "startingPos = " + fromTilePos.x + ", " + fromTilePos.y + "endingPos = " + toTilePos.x + ", " + toTilePos.y);
    }

    public void setDestPos()
    {
        toTilePos.x = fromTilePos.x;
        toTilePos.y = fromTilePos.y;
        if (dir == 3)//방향이 왼쪽일때
        {
            toTilePos.x = fromTilePos.x - 1;
        }
        else if (dir == 1)//오른쪽일때
        {
            Debug.Log("1");
            toTilePos.x = fromTilePos.x + 1;
        }
        else if (dir == 2)//아래일때
        {
            Debug.Log("2");
            toTilePos.y = fromTilePos.y - 1;
        }
        else//위일때
        {
            Debug.Log("0");
            toTilePos.y = fromTilePos.y + 1;
        }
    }

    public void Merge() {
        
    }

    public void Branch()
    {

    }
    
    public void setColor(string a)
    {
        color = a;
    }

    private void changeObjectColor()
    {

    }

    /*~Ball()
    {
        //Destroy(ball);
    }*/

    public bool compareDest(Ball a)
    {
        
        if((a.getToX() == toTilePos.x)&&(a.getToY() == toTilePos.y))
        {
            return true;
        }        
        return false;
    }
    
    public int getToX()
    {
        return toTilePos.x;
    }
    public int getToY()
    {
        return toTilePos.y;
    }
    public void _2Dmove(float moveDist, float y)
    {

        if (dir == 3)//방향이 왼쪽일때
        {
            ballTransform.position = new Vector3(myBoundStartPos.x - moveDist, myBoundStartPos.y, -0.5f);
        }
        else if (dir == 1)//오른쪽일때
        {
            ballTransform.position = new Vector3(myBoundStartPos.x + moveDist, myBoundStartPos.y, -0.5f);
        }
        else if (dir == 2)//아래일때
        {
            ballTransform.position = new Vector3(myBoundStartPos.x, myBoundStartPos.y - moveDist, -0.5f);
        }
        else//위일때
        {
            ballTransform.position = new Vector3(myBoundStartPos.x, myBoundStartPos.y + moveDist, -0.5f);
        }
        childTrans.position = new Vector3(childTrans.position.x, ballTransform.position.y + y + 0.2f * BallManager.tileSize, -0.5f);
    }

    public void changeDirection()
    {
        float tileSize = BallManager.tileSize;

        if (ballTransform.position.x <= myBoundStartPos.x - tileSize)
        {
            myBoundStartPos = new Vector3(myBoundStartPos.x - tileSize, myBoundStartPos.y, -0.5f);
        }
        if (ballTransform.position.x >= tileSize + myBoundStartPos.x)
        {
            myBoundStartPos = new Vector3(myBoundStartPos.x + tileSize, myBoundStartPos.y, -0.5f);
        }
        if (ballTransform.position.y <= myBoundStartPos.y - tileSize)
        {
            myBoundStartPos = new Vector3(myBoundStartPos.x, myBoundStartPos.y - tileSize, -0.5f);
        }
        if (ballTransform.position.y >= tileSize + myBoundStartPos.y)
        {
            myBoundStartPos = new Vector3(myBoundStartPos.x, myBoundStartPos.y + tileSize, -0.5f);
        }

        //Debug.Log(myNum + "  " + myBoundStartPos.x + "  +  " + myBoundStartPos.y + "  +  " + myTransformPos.z);
        //if()

        dir = Random.Range(0, 4);
        
        checkLoc();
        fromTilePos.x = toTilePos.x;
        fromTilePos.y = toTilePos.y;

        setDestPos();
        showInfo();
    }

    private void checkLoc(int xSize = 11, int ySize = 11)
    {
        if (ballTransform.position.x > xSize - 2)
        {
            dir = 3;
        }
        if (ballTransform.position.x < 2)
        {
            dir = 1;
        }
        if (ballTransform.position.y < 2)
        {
            dir = 0;
        }
        if (ballTransform.position.y > ySize - 2)
        {
            dir = 2;
        }
    }

}
