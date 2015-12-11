using UnityEngine;
using System.Collections;

public class followCam : MonoBehaviour {

	public GameObject poi;         // point of interest, endpoint

	public static followCam S;     //Singleton followCam Instance

	private float camZ;            
	public float easing = 0.05f;

	public Vector2 minXY;
	Vector3 launchPos;             //I think this is meant to be the target for the camera at the start of the game.

	private GameObject goal;       //the gameObject that is your goal
	private GameObject slingshot;  //the gameObject that is your slingshot
	private GameObject empty;      //the gameObject that is the target for the camera when you can see both the slingshot and the goal. Yeah... I cheated.

	Vector3 destination;
	public float speed;

	void Awake() {

		S = this;                      //this= the object that appeared right then. In this case the projectile
		camZ = transform.position.z;
	}

	
	void setPoi(GameObject target){   //defines the point of interest for the camera
		poi = target;                 //that is always the gameObject we define as "target"
	}

	private void setEmptyToMiddle(){    //this should set the camera in a way that it shows everything from the slingshot to the goal... i think this is a slightly modificated version of this function...
		Vector3 a = slingshot.transform.position;  // kind of the beginning of the calculation of the middle (c) between two points (a and b)
		Vector3 b = goal.transform.position;  
		Vector3 c = empty.transform.position;      
        /* i just took an empty gameobject, placed it in the middle between these two points and took
        the position directly from this gameobject. This is easier, but less flexible, for you have to 
        place the empty gameobject manually every time you change the distance between a and b.
        The better version is to do something like (b -a)/2 = c, but for some reason i did not do this...*/
	}




	public void OnButtonClick(GameObject NameOfPoi){  //this is for the buttons on top of the scene
		poi = NameOfPoi;                              // they set the camera either to the slingshot, the goal or the empty gameobject I placed in the middle

	}

	void FixedUpdate(){


		
		if (poi == null) {                        //check if the poi is empty
			destination = Vector3.zero;           //Set the destination to the zero vector
        }


		else {                                    //the poi exists
            destination = poi.transform.position; //get its position
			if(poi.tag == "projectile"){          //if the current poi is one of the projectiles

				// check if it is resting(sleeping)
				if(poi.GetComponent<Rigidbody>().IsSleeping ()){
					// set it to "null" as a default value in next update
					poi = null;
					return;
					}

				
				}
				
				destination.z = camZ;
				
				
		}

		//this part is important for smooth camera movement

		destination.x = Mathf.Max (minXY.x, destination.x);  // x and y not smaller than 0
		destination.y = Mathf.Max (minXY.y, destination.y);
		destination = Vector3.Lerp (transform.position, destination, easing);
		destination.z = camZ;

		transform.position = destination;

		this.GetComponent<Camera> ().orthographicSize = 10 + destination.y;
	}
}
