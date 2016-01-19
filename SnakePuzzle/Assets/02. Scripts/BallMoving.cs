using UnityEngine;
using System.Collections;

public class BallMoving : MonoBehaviour {

    public float ballJumpPower;

    public float tileSize; //타일 개개의 사이즈를 의미함

    private Vector3 myPos = new Vector3();

    public static bool ChangeDir = false;

    public float speed;
    public int direction;
    // 0 = 위
    // 1 = 오른쪽
    // 2 = 아래
    // 3 = 왼쪽

	// Use this for initialization
	void Start () {
        myPos = transform.position;
        direction = 1;
	}

    public void SetPos(Vector3 a)
    {
        myPos = a;
    }

    public void move(float deltaTime)
    {
        if (direction == 3)//방향이 왼쪽일때
        {
            //speed = ;
            transform.Translate(Vector3.left * speed * deltaTime);
            transform.position = new Vector3(transform.position.x, transform.position.y, ballJumpPower * (transform.position.x - myPos.x) * (transform.position.x - myPos.x + tileSize) - 0.5f);
        }
        else if (direction == 1)//오른쪽일때
        {
            transform.Translate(Vector3.right * speed * deltaTime);
            transform.position = new Vector3(transform.position.x, transform.position.y, ballJumpPower * (transform.position.x - myPos.x) * (transform.position.x - myPos.x - tileSize) - 0.5f);
        }
        else if (direction == 2)
        {
            transform.Translate(Vector3.down * speed * deltaTime);
            transform.position = new Vector3(transform.position.x, transform.position.y, ballJumpPower * (transform.position.y - myPos.y) * (transform.position.y - myPos.y + tileSize) - 0.5f);
        }
        else
        {
            transform.Translate(Vector3.up * speed * deltaTime);
            transform.position = new Vector3(transform.position.x, transform.position.y, ballJumpPower * (transform.position.y - myPos.y) * (transform.position.y - myPos.y - tileSize) - 0.5f);
        }

        if (transform.position.z >= -0.5f)
        {
            changeDirection();
            //ChangeDir = true;
        }

    }

    public void changeDirection()
    {
        if (transform.position.x <= myPos.x - tileSize)
        {
            myPos = new Vector3(myPos.x - tileSize, myPos.y, -0.5f);
        }
        if (transform.position.x >= tileSize + myPos.x)
        {
            myPos = new Vector3(myPos.x + tileSize, myPos.y, -0.5f);
        }
        if (transform.position.y <= myPos.y - tileSize)
        {
            myPos = new Vector3(myPos.x, myPos.y - tileSize, -0.5f); 
        }
        if (transform.position.y >= tileSize + myPos.y)
        {
            myPos = new Vector3(myPos.x, myPos.y + tileSize, -0.5f);
        }
        Debug.Log(myPos.x + "  +  " + myPos.y + "  +  " + myPos.z);
        
        direction = Random.Range(0, 4);
        checkLoc();
        ChangeDir = false;
        
    }

    private void checkLoc(int xSize = 11, int ySize = 11)
    {
        if (myPos.x > xSize - 1)
        {
            direction = 3;
        }
        if(myPos.x < 1)
        {
            direction = 1;
        }
        if(myPos.y < 1)
        {
            direction = 0;
        }
        if (myPos.y > ySize - 1)
        {
            direction = 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*if (direction == 3)//방향이 왼쪽일때
        {
            //speed = ;
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, transform.position.y, ballJumpPower * (transform.position.x - myPos.x) * (transform.position.x - myPos.x + tileSize) - 0.5f);
        }
        else if (direction == 1)//오른쪽일때
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, transform.position.y, ballJumpPower * (transform.position.x - myPos.x) * (transform.position.x - myPos.x - tileSize) - 0.5f);
        }
        else if (direction == 2)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, transform.position.y, ballJumpPower * (transform.position.y - myPos.y) * (transform.position.y - myPos.y + tileSize) - 0.5f);
        }
        else
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, transform.position.y, ballJumpPower * (transform.position.y - myPos.y) * (transform.position.y - myPos.y - tileSize) - 0.5f);
        }

        if (transform.position.z >= 0)
        {
            ChangeDir = true;
        }*/
        

    }
}
