using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

public class Board{
    private float tileSize = 30f;
    private string[, ] Tile;

    private int board_Height;
    private int board_Width;
    private string tempColor;

	public Board(){
		Tile = new string[board_Height,board_Width];
	}

	public Board(int board_Height, int  board_Width){
		Tile = new string[board_Height, board_Width];
		for (int i = 0; i < board_Height; i++) {
			for (int j = 0; j < board_Width; j++) {
				Tile [i, j] = "NULL";
			}
		}
    }

    public string[,] getTile(){
        return Tile;
    }
}


