using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;


public class DB_Loader{

	private int x, y;
	private string text;
	private string[] parse;
	private string[] tile_list = { "Spawn", "Red","Yellow","Green","Blue","Purple"};
	string[, ] Tile;
	int board_Height, board_Width;


	public DB_Loader(){
		this.loadTileDB();
	}

	public string[,] get_tile(){
		return Tile;
	}

	private void loadTileDB(){
		XmlDocument xmldoc = new XmlDocument ();
		xmldoc.Load ("DB.xml");
		XmlElement root = xmldoc.DocumentElement;
		XmlNodeList nodes = root.GetElementsByTagName("Tile");

		board_Height = XmlConvert.ToInt32(root.SelectSingleNode ("Size").SelectSingleNode ("Height").InnerText);
		board_Width = XmlConvert.ToInt32(root.SelectSingleNode ("Size").SelectSingleNode ("Width").InnerText);
		Tile = new string[board_Height, board_Width];

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
