using UnityEngine;
using System.Collections;

public class cursorscript : MonoBehaviour {

		public Texture2D cursorImage;
		
		private int cursorWidth = 40;
		private int cursorHeight = 40;
		
		void Awake()
		{
			Cursor.visible = false;
		}
		
		
		void OnGUI()
		{
			GUI.DrawTexture(new Rect(Input.mousePosition.x, Screen.height - Input.mousePosition.y, cursorWidth, cursorHeight), cursorImage);
		}
}
