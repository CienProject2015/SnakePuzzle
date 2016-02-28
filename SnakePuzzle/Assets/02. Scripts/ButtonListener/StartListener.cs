using UnityEngine;
using System.Collections;

public class StartListener : MonoBehaviour {

	public void buttonClicked(){
		int level = 0;
			level++;	
		Application.LoadLevel (level);
	}

}
