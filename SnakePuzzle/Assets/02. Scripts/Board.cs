using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/*
 * Red
 * Blue
 * Purple
 * Green
 * Yellow
 * 
 * SpawnLeft
 * SpawnRight
 * SpawnUp
 * SpawnDown
 * 
 * NULL
 */


public class Board{
    private float tileSize = 1.0f;
    private string[, ] Tile;
    private int board_Height=12;
    private int board_Width=12;
    private string tempColor;
    private DB_Loader db_loader = new DB_Loader();


    public Board()
    {
        //board_Height = 7;
        //board_Width = 7;
        //Tile = new string[board_Height, board_Width];
        //makeRndSquare();
        Tile = db_loader.get_tile();
    }
    public Board(int a, int b)
    {
        /*board_Height = a;
        board_Width = b;
        Tile = new string[board_Height, board_Width];
        makeRndSquare();*/
        Tile = db_loader.get_tile();
    }

    public int getBoardWidth()
    {
        return board_Width;
    }

    public int getBoardHeight()
    {
        return board_Height;
    }
    public string[,] getTile()
    {
        return Tile;
    }
    public void makeRndSquare()
    {
        for (int i = 1; i < board_Height - 1; i++)
        {
            for (int j = 1; j < board_Width - 1; j++)
            {
                Tile[i, j] = getRndColor();
            }
        }
        for (int j = 1; j < board_Height-1; j++)
        {
            Tile[0, j] = "SpawnUp";
            Tile[board_Height-1, j] = "SpawnDown";
        }
        for (int i = 1; i < board_Width - 1; i++)
        {
            Tile[i, 0] = "SpawnLeft";
            Tile[i, board_Width-1] = "SpawnRight";
        }

        Tile[0, 0] = Tile[0, board_Height-1] = Tile[board_Width-1, 0] = Tile[board_Width-1, board_Height-1] = "NULL";
    }
    public string getRndColor()
    {
        string retString = "";
        int num = Random.Range(0,3);
        switch (num)
        {
            case 0:
                retString = "Red";
                break;
            case 1:
                retString = "Green";
                break;
            case 2:
                retString = "Blue";
                break;
            case 3:
                retString = "Yellow";
                break;
            case 4:
                retString = "Purple";
                break;
            default:
                break;
        }

        return retString;
    }
   /* public void DrawBoard()
    {
        for (int i = 0; i < board_Height; i++)
        {
            for (int j = 0; j < board_Width; j++)
            {
                switch (Tile[i, j])
                {
                    case "Red":
                        //toInstantiate(RedTile, new Vector3(i*tileSize, j*tileSize, 0), Quaternion.identity);
                        break;
                    case "Blue":
                        break;
                    case "Yellow":
                        break;
                    case "Green":
                        break;
                    case "Purple":
                        break;
                    case "SpawnLeft":
                        break;
                    case "SpawnRight":
                        break;
                    case "SpawnUp":
                        break;
                    case "SpawnDown":
                        break;
                    default:
                        break;
                }
            }
        }
            //Instantiate(brick, Vector3(x, y, 0), Quaternion.identity);
    }*/

}
