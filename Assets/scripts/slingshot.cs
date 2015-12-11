using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class slingshot : MonoBehaviour {

	//inspector variables
	GameObject prefabProjectile;           //the projectile gameObject
	public float velocityMult = 10.0f;     //this indicates with how much wumms you can shoot
	
	public GameObject projectile1;         //The projectile you start with per default

	//Internal state variable
	private GameObject launchPoint;        // This is the gameobject, from which the launchPos its transform position fetches... is that correct english? i doubt it. but you know what i mean.
                                           // it is the gameobject with the white glow on it.
    private bool aimingMode;               // Are you in aimingmode?
	GameObject Projectiletype;             // the type of projectile you start with. Can change in the game
	int numberOfProjectiles = 2;

	Text ShotsTaken;                       // This is the text that shows how many times you have shooted
	static int shots;                      // counts your shots

	private GameObject projectile;         // the projectile you instantiate
	private Vector3 launchPos;             // launch position of the projectile stored



	void Awake(){
		Transform launchpointTrans = transform.Find("launchpoint"); //return a transform, transform only searches in the children
		launchPoint = launchpointTrans.gameObject;                  //the launchPoint is the gameobject which belongs to the launchointTrans
		launchPoint.SetActive(false);                               //deactivate launchPoint, so you only have the transform left. Thats all you need
		launchPos = launchpointTrans.position;                      
		prefabProjectile = projectile1;                             //sets the default projectile type

		GameObject shotText = GameObject.Find ("shots");            //find te right text
		ShotsTaken= shotText.GetComponent<Text>();                 
		shots = 0;                                                  //set number of taken shots to 0
	}



	void OnMouseEnter(){                           //if the cursor enters the area of the launchpoint, ...
		launchPoint.SetActive (true);              //...show the white glow
		//print ("slingshot mouse enter");
	
	}


	void OnMouseExit() {                           //if the cursor exits the area of the launchpoint,...
		if(!aimingMode){                           //...and (!) you are NOT in aimingmode...
			launchPoint.SetActive (false);         //...hide the white glow
		}
	}


	public void OnButtonClick(GameObject newBullet){   //this is for the projectile selection buttons on the left side of the screen
		prefabProjectile = newBullet;                  //if you click on a bullet, this will be your bullet for the next shots.
		//print (prefabProjectile.name);
	}

	void OnMouseDown() {
		//set the game to aiming mode, when mouse is pressed.
		aimingMode = true;

		//Instantiate a projectile AT THE LAUNCHPOINT
		projectile = Instantiate (prefabProjectile) as GameObject; //typecasting, spawning of objects;

		projectile.transform.position = launchPos;

		//switch off physics for now (in gaming mode)
		projectile.GetComponent<Rigidbody>().isKinematic = true; //new. gives back whatever type you type in between the <> braces
	}

	void Update() {

		updateShots (); //update the shotsText, which counts your shots

		//check for aiming mode
		if (!aimingMode) return;

		//Get our mouse position and convert to 3D
		Vector3 mousePos2D = Input.mousePosition;
		mousePos2D.z = -Camera.main.transform.position.z;  //to 2D space
		Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);//to world space


		//Calculate the difference()delta) between launch position and mouse position
		Vector3 mouseDelta = mousePos3D - launchPos; //delta is the differenceVector

		//constrain the delta to the maximum/the radius of the sphere collider
		float maxMagnitude = this.GetComponent<SphereCollider> ().radius; //radius - 0.5f macht projectile kleiner, je näher man am launchpoint ist
		mouseDelta = Vector3.ClampMagnitude (mouseDelta, maxMagnitude);

		//set projectile position to new positon and fire it!
		projectile.transform.position = launchPos + mouseDelta;
	    
		//fire it
		if (Input.GetMouseButtonUp (0)) { // if you release te mouse button
			aimingMode = false;           // leave the aimingmode
			//print ("aimingmode left");
			projectile.GetComponent<Rigidbody>().isKinematic=false;   //...shoot.
			projectile.GetComponent<Rigidbody>().velocity = -mouseDelta*velocityMult; //...shoot.

			followCam.S.poi = projectile;                // sets the poi of the camera to the current projectile
			shots = shots + 1;                           // counts the shots you do
		}


	}

	void updateShots(){
		ShotsTaken.text = "Shots Taken:" + shots;        // Updates the shotsTaken-text
	}
}