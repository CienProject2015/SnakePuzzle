using UnityEngine;
using System.Collections;


public struct MyTilePos
{
    private int x;
    private int y;

    public void setPos(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    public int getX()
    {
        return x;
    }
    public int getY()
    {
        return y;
    }
}

public class BallMoving : MonoBehaviour {
    public static int BallNum = 0;
    public float ballJumpPower;
    private int myNum;


    private MyTilePos mytilePos;

    //private float tileSize; //타일 개개의 사이즈를 의미함

    private Vector3 myTransformPos = new Vector3();
    private Transform childTrans;
    public static bool ChangeDir = false;

    private float speed;
    public int direction;
    // 0 = 위
    // 1 = 오른쪽
    // 2 = 아래
    // 3 = 왼쪽
	// Use this for initialization

    

	void Start () {

        childTrans = transform.FindChild("Ball").transform;
        speed = GameObject.Find("BallManager").GetComponent<BallManager>().ballSpeed;
        
        myNum = BallNum++;
        myTransformPos = transform.position;
        direction = 1;
	}

    public void setMyTilepos(int x, int y)
    {
        mytilePos.setPos(x, y); ;
    }
    public int getMyTilePosX()
    {
        return mytilePos.getX();
    }
    public int getMyTilePosY()
    {
        return mytilePos.getY();
    }

    public void _2Dmove(float moveDist, float y)
    {
        if (direction == 3)//방향이 왼쪽일때
        {
            transform.position = new Vector3(myTransformPos.x-moveDist, myTransformPos.y, -0.5f);
        }
        else if (direction == 1)//오른쪽일때
        {
            transform.position = new Vector3(myTransformPos.x + moveDist, myTransformPos.y, -0.5f);
        }
        else if (direction == 2)//아래일때
        {
            transform.position = new Vector3(myTransformPos.x, myTransformPos.y - moveDist, -0.5f);
        }
        else//위일때
        {
            transform.position = new Vector3(myTransformPos.x, myTransformPos.y + moveDist, -0.5f);
        }
        childTrans.position = new Vector3(childTrans.position.x, transform.position.y + y + 0.2f*BallManager.tileSize,  -0.5f);
    }

    public void SetPos(Vector3 a)
    {
        myTransformPos = a;
    }

    public void move(float deltaTime, float z)
    {
        if (direction == 3)//방향이 왼쪽일때
        {
            //speed = ;
            transform.Translate(Vector3.left * speed * deltaTime);
            //transform.position = new Vector3(transform.position.x, transform.position.y, ballJumpPower * (transform.position.x - myTransformPos.x) * (transform.position.x - myTransformPos.x + tileSize) - 0.5f);
        }
        else if (direction == 1)//오른쪽일때
        {
            transform.Translate(Vector3.right * speed * deltaTime);
            //transform.position = new Vector3(transform.position.x, transform.position.y, ballJumpPower * (transform.position.x - myTransformPos.x) * (transform.position.x - myTransformPos.x - tileSize) - 0.5f);
        }
        else if (direction == 2)
        {
            transform.Translate(Vector3.down * speed * deltaTime);
            //transform.position = new Vector3(transform.position.x, transform.position.y, ballJumpPower * (transform.position.y - myTransformPos.y) * (transform.position.y - myTransformPos.y + tileSize) - 0.5f);
        }
        else
        {
            transform.Translate(Vector3.up * speed * deltaTime);
            //transform.position = new Vector3(transform.position.x, transform.position.y, ballJumpPower * (transform.position.y - myTransformPos.y) * (transform.position.y - myTransformPos.y - tileSize) - 0.5f);
        }

        transform.position = new Vector3(transform.position.x, transform.position.y, z);
        
        //Debug.Log("z = " + transform.position.z);
        //Debug.Log(myNum + " ++ " + direction+ " + " + speed * deltaTime + " +++ " + transform.position.z);
        if (transform.position.z >= -0.5f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -0.5f);
            //changeDirection();
            //ChangeDir = true;
        }

    }

    public Vector3 getmyTransformPos()
    {
        return myTransformPos;
    }

    /*public void changeDirection()
    {
        if (transform.position.x <= myTransformPos.x - tileSize)
        {
            myTransformPos = new Vector3(myTransformPos.x - tileSize, myTransformPos.y, -0.5f);
        }
        if (transform.position.x >= tileSize + myTransformPos.x)
        {
            myTransformPos = new Vector3(myTransformPos.x + tileSize, myTransformPos.y, -0.5f);
        }
        if (transform.position.y <= myTransformPos.y - tileSize)
        {
            myTransformPos = new Vector3(myTransformPos.x, myTransformPos.y - tileSize, -0.5f); 
        }
        if (transform.position.y >= tileSize + myTransformPos.y)
        {
            myTransformPos = new Vector3(myTransformPos.x, myTransformPos.y + tileSize, -0.5f);
        }

        Debug.Log(tileSize);
        //Debug.Log(myNum + "  " + myTransformPos.x + "  +  " + myTransformPos.y + "  +  " + myTransformPos.z);
        //if()
        
        direction = Random.Range(0, 4);
        checkLoc();
        ChangeDir = false;
        
    }*/

    public void changeDirection()
    {
        float tileSize = BallManager.tileSize;

        if (transform.position.x <= myTransformPos.x - tileSize)
        {
            myTransformPos = new Vector3(myTransformPos.x - tileSize, myTransformPos.y, -0.5f);
        }
        if (transform.position.x >= tileSize + myTransformPos.x)
        {
            myTransformPos = new Vector3(myTransformPos.x + tileSize, myTransformPos.y, -0.5f);
        }
        if (transform.position.y <= myTransformPos.y - tileSize)
        {
            myTransformPos = new Vector3(myTransformPos.x, myTransformPos.y - tileSize, -0.5f);
        }
        if (transform.position.y >= tileSize + myTransformPos.y)
        {
            myTransformPos = new Vector3(myTransformPos.x, myTransformPos.y + tileSize, -0.5f);
        }

        //Debug.Log(myNum + "  " + myTransformPos.x + "  +  " + myTransformPos.y + "  +  " + myTransformPos.z);
        //if()

        direction = Random.Range(0, 4);
        checkLoc();
        ChangeDir = false;


    }

    private void checkLoc(int xSize = 11, int ySize = 11)
    {
        if (transform.position.x > xSize - 1)
        {
            direction = 3;
        }
        if(transform.position.x < 1)
        {
            direction = 1;
        }
        if(transform.position.y < 1)
        {
            direction = 0;
        }
        if (transform.position.y > ySize - 1)
        {
            direction = 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
     
        

    }
}
