using UnityEngine;
using System.Collections;


public class BallMoving : MonoBehaviour {
    public Sprite[] Sprites;
    private Sprite currentSprite;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = transform.FindChild("Ball").GetComponent<SpriteRenderer>();
        currentSprite = transform.FindChild("Ball").GetComponent<SpriteRenderer>().sprite;
        Debug.Log("생성시 스프라이트 상태 " + currentSprite.name);
        //spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
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

        if(Sprites.Length>num)
        {
            currentSprite = Sprites[num];
            Debug.Log(currentSprite.name + "로 색 바뀜");
            //spriteRenderer.sprite = Sprites[num];
        }
        else
        {
            Debug.Log("Invaild Request : color");
        }
        
    }

    public void changeSprite_viaNum(int num)
    {
        if (Sprites.Length > num)
        {
            spriteRenderer.sprite = Sprites[num];
        }
        else
        {
            Debug.Log("Invalid color Num, (over the SpritesNum)");
        }
    }


}
