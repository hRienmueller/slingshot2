using UnityEngine;
using System.Collections;

public class cursorscript : MonoBehaviour {

		public Texture2D cursorImage;   //the cursor you want to have
		//the width and height of the shown image
		private int cursorWidth = 40;   
		private int cursorHeight = 40;
		
		void Awake()
		{
			Cursor.visible = false; //make he default cursor invisible
		}
		
		
		void OnGUI()    //draw the new cursor at the ame position as the mouse position. EVERY FRAMEEE!!
		{
			GUI.DrawTexture(new Rect(Input.mousePosition.x, Screen.height - Input.mousePosition.y, cursorWidth, cursorHeight), cursorImage);
		}
}
