using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class slingshot : MonoBehaviour {

	//inspector variables
	GameObject prefabProjectile;
	public float velocityMult = 10.0f;
	
	public GameObject projectile1;

	//Internal state variable
	private GameObject launchPoint;
	private bool aimingMode;
	GameObject Projectiletype;
	int numberOfProjectiles = 2;

	Text ShotsTaken;
	static int shots;

	private GameObject projectile;
	private Vector3 launchPos;     //launch position stored



	void Awake(){
		Transform launchpointTrans = transform.Find("launchpoint"); //return a transform, tranform nly searches in the children
		launchPoint = launchpointTrans.gameObject;
		launchPoint.SetActive(false);
		launchPos = launchpointTrans.position;
		prefabProjectile = projectile1;

		GameObject shotText = GameObject.Find ("shots");
		ShotsTaken= shotText.GetComponent<Text>();
		shots = 0;
	}



	void OnMouseEnter(){
		launchPoint.SetActive (true);
		//print ("slingshot mouse enter");
	
	}


	void OnMouseExit() {
		if(!aimingMode){
			launchPoint.SetActive (false);
		}
	}


	public void OnButtonClick(GameObject newBullet){
		prefabProjectile = newBullet;
		//print (prefabProjectile.name);
	}

	void OnMouseDown() {
		//set the game to aiming mode, when mouse is pressed.
		aimingMode = true;

		//Instantiate a projectile AT THE LAUNCHPOINT(erschaffen! WICHTIG!!)
		projectile = Instantiate (prefabProjectile) as GameObject; //typecasting, spawning of objects;

		projectile.transform.position = launchPos;

		//switch off physics for now (in gaming mode)
		projectile.GetComponent<Rigidbody>().isKinematic = true; //new. gives back whatever type you type in between the <> braces
	}

	void Update() {

		updateShots ();

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
		if (Input.GetMouseButtonUp (0)) {
			aimingMode = false;
			//print ("aimingmode left");
			projectile.GetComponent<Rigidbody>().isKinematic=false;
			projectile.GetComponent<Rigidbody>().velocity = -mouseDelta*velocityMult;

			followCam.S.poi = projectile;
			shots = shots + 1;
		}


	}

	void updateShots(){
		ShotsTaken.text = "Shots Taken:" + shots; 
	}
	// zooming the level try it! camera tab zoom, you can acces it in the script,  one line of code
}