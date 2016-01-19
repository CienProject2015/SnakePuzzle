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

    public static float tileSize;
    private List<GameObject> balls = new List<GameObject>();

    public void SpawnBall(Vector3 pos)
    {
        balls.Add(Instantiate(Ball, pos, Quaternion.identity) as GameObject);
        balls[balls.Count - 1].GetComponent<BallMoving>().SetPos(pos);
        balls[balls.Count - 1].transform.parent = GameObject.Find("BallManager").transform;
    }
    public void init(float tilesize)
    {
        atime = 0;
        tempTime = 0;
        tileSize = tilesize;
    }
    void Update(){

        if (balls.Count != 0)
        {
            Vector3 tempVec = balls[0].GetComponent<BallMoving>().getMyPos();
        }
        tempTime = tempTime + Time.deltaTime;
        //Debug.Log("시간 = " + tempTime);
        //moveDist += ballSpeed * Time.deltaTime;
        moveDist += tileSize * Time.deltaTime;
        float y = -ballJumpPower * (moveDist) * (moveDist - tileSize);

        
        
        if (moveDist > tileSize)
        {
            for (int i = 0; i < balls.Count; i++)
            {
                balls[i].GetComponent<BallMoving>()._2Dmove(tileSize, y);
                balls[i].GetComponent<BallMoving>().changeDirection();
            }
            
            Debug.Log("경로변경!" + (tempTime-atime));
            atime = tempTime;
            moveDist = 0;
            
        }else{
            for (int i = 0; i < balls.Count; i++)
            {
                balls[i].GetComponent<BallMoving>()._2Dmove(moveDist, y);
            }
        }


    }
}
