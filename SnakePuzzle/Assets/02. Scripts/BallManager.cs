using UnityEngine;
using System.Collections;
using System.Collections.Generic; //리스트 쓸려고 추가함

public class BallManager : MonoBehaviour
{
    public float ballJumpPower;
    public float ballSpeed;
    public GameObject Ball;
    private float moveDist;
    private float tileSize;

    private List<GameObject> balls = new List<GameObject>();

    public void SpawnBall(Vector3 pos)
    {
        balls.Add(Instantiate(Ball, pos, Quaternion.identity) as GameObject);
        balls[balls.Count - 1].GetComponent<BallMoving>().SetPos(pos);
        balls[balls.Count - 1].transform.parent = GameObject.Find("BoardManager").transform;
    }
    public void init(float tilesize)
    {
        tileSize = tilesize;
    }
    void Update(){

        float z = 0.0f;
        if (balls.Count != 0)
        {
            Vector3 tempVec = balls[0].GetComponent<BallMoving>().getMyPos();
        }
        
        
        moveDist += ballSpeed * Time.deltaTime;
        z = ballJumpPower * (moveDist) * (moveDist - tileSize) - 0.5f;
        /*if (z > -0.5f)
        {
            z = -0.5f;
        }*/
        


        for (int i = 0; i < balls.Count; i++)
        {
            balls[i].GetComponent<BallMoving>().move(Time.deltaTime, z);
        }
        if (moveDist > tileSize)
        {
            moveDist = 0;
        }
    }
}
