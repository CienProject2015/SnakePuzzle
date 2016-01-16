using UnityEngine;
using System.Collections;

public class BallMoving : MonoBehaviour {

    public float ballJumpPower;

    private Vector3 myPos = new Vector3();

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
	void Update () {
        if (direction == 3)//방향이 왼쪽일때
        {
            //speed = ;
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, transform.position.y, ballJumpPower * (transform.position.x - myPos.x) * (transform.position.x - myPos.x + 1) - 0.5f);
            if (transform.position.x <=myPos.x - 1)
            {
                myPos = new Vector3(myPos.x - 1, myPos.y,myPos.z);
                direction = Random.Range(0, 4);
            }
        }
        else if(direction == 1)//오른쪽일때
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, transform.position.y, ballJumpPower * (transform.position.x - myPos.x) * (transform.position.x - myPos.x - 1) - 0.5f);
            if (transform.position.x >= 1 +  myPos.x)
            {
                myPos = new Vector3(myPos.x + 1, myPos.y, myPos.z);
                direction = direction = Random.Range(0, 4);
            }
        }else if (direction == 2)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, transform.position.y, ballJumpPower * (transform.position.y - myPos.y) * (transform.position.y - myPos.y + 1) - 0.5f);
            if (transform.position.y <= myPos.y - 1)
            {
                myPos = new Vector3(myPos.x, myPos.y - 1, myPos.z);
                direction = direction = Random.Range(0, 4);
            }
        }
        else
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, transform.position.y, ballJumpPower * (transform.position.y - myPos.y) * (transform.position.y - myPos.y - 1) - 0.5f);
            if (transform.position.y >= 1 + myPos.y)
            {
                myPos = new Vector3(myPos.x, myPos.y + 1, myPos.z);
                direction = direction = Random.Range(0, 4);
            }
        }
        checkLoc();

    }
}
