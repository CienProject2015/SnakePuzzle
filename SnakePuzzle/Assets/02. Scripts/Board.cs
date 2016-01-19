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

    public Board(){
        board_Height = 12;
        board_Width = 12;
        Tile = new string[board_Height, board_Width];
		loadTileDB ();
    }

    public Board(int a, int b){
        board_Height = a;
        board_Width = b;
        Tile = new string[board_Height, board_Width];
		loadTileDB ();

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


	private void loadTileDB(){
		XmlDocument xmldoc = new XmlDocument ();
		xmldoc.Load ("DB.xml");
		XmlElement root = xmldoc.DocumentElement;
		XmlNodeList nodes = root.ChildNodes;

		int x, y;
		string text;
		string[] parse;
		string[] tile_list = { "Spawn", "Red","Yellow","Green","Blue","Purple"};

		foreach (XmlNode node in nodes) {
			for(int i = 0 ; i < tile_list.Length; i++){
				text = node.SelectSingleNode(tile_list[i]).InnerText;
				if (text != "null"){
					parse = node.SelectSingleNode (tile_list[i]).InnerText.Split (',');
					x = XmlConvert.ToInt32 (parse [1]);
					y = XmlConvert.ToInt32 (parse [2]);
					switch(parse[0]){
					case "U":
						Tile [x, y] = "SpawnUp";
						break;
					case "D":
						Tile [x, y] = "SpawnDown";
						break;
					case "R":
						Tile [x, y] = "SpawnRight";
						break;
					case "L":
						Tile [x, y] = "SpawnLeft";
						break;
					case "0":
						Tile [x, y] = tile_list[i];
						break;
					default :
						break;
					}
				}
			}// end for 
		}// end foreach
		Tile[0, 0] = Tile[0, board_Height-1] = Tile[board_Width-1, 0] = Tile[board_Width-1, board_Height-1] = "NULL";
	}
}


