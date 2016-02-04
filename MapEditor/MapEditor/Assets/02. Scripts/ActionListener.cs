using UnityEngine;
using UnityEngine.UI;
using System;


public class ActionListener : MonoBehaviour {
	private static int row = 0, col = 0;
	private static int level = 0;
	private Board_Maker board_maker = new Board_Maker();

	public static int[] get_size(){
		int[] size = new int[2];
		size [0] = row;
		size [1] = col;
		return size;
	}


	public void buttonClicked(){

		switch (level) {
			case 0:
				level++;	
				Application.LoadLevel (level);
			break;

		case 1:
			level++;
			GameObject input = GameObject.Find ("Row");
			row = Convert.ToInt32 (input.GetComponent<InputField> ().text);
			input = GameObject.Find ("Col");
			col = Convert.ToInt32 (input.GetComponent<InputField> ().text);
			Application.LoadLevel (level);

			board_maker.put_size (row, col);
			break;

		case 2:
			level = 1 ;
			Application.LoadLevel (level);
			break;
		}
	}

}
