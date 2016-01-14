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
        speed = 1f;
        direction = 1;
	}

    public void SetPos(Vector3 a)
    {
        myPos = a;
    }
	// Update is called once per frame
	void Update () {
        if (direction == 3)//방향이 왼쪽일때
        {
            //speed = ;
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, transform.position.y, ballJumpPower * (transform.position.x - myPos.x) * (transform.position.x - myPos.x - 1) - 0.5f);
            if (transform.position.x <=myPos.x)
            {
                direction = 1;
            }
        }
        else if(direction == 1)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, transform.position.y, ballJumpPower * (transform.position.x - myPos.x) * (transform.position.x - myPos.x - 1) - 0.5f);
            if (transform.position.x >= 1+myPos.x)
            {
                direction = 3;
            }
        }else if (direction == 2)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, transform.position.y, ballJumpPower * (transform.position.x - myPos.x) * (transform.position.x - myPos.x - 1) - 0.5f);
            if (transform.position.x >= 1 + myPos.x)
            {
                direction = 0;
            }
        }
        else
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, transform.position.y, ballJumpPower * (transform.position.x - myPos.x) * (transform.position.x - myPos.x - 1) - 0.5f);
            if (transform.position.x >= 1 + myPos.x)
            {
                direction = 2;
            }
        }
        
	}
}
