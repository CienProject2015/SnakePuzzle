using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;


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

	private DB_Loader db_loader= new DB_Loader();

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
  
    public string[,] getTile(){
        return Tile;
    }
		
	/*public string getRndColor(){
        string retString = "";
        int num = Random.Range(0,3);
        switch (num){
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
    }*/
}


