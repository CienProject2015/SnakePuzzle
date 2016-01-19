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
    private int board_Height;
    private int board_Width;
    private string tempColor;
	private DB_Loader db_loader= new DB_Loader();

    public Board(){
		Tile = db_loader.get_tile();
    }

    public Board(int a, int b){
		Tile = db_loader.get_tile();
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


