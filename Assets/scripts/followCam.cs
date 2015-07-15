using UnityEngine;
using System.Collections;

public class followCam : MonoBehaviour {

	public GameObject poi; // point of interest, endpoint

	public static followCam S;  //Singleton followCam Instance

	private float camZ;
	public float easing = 0.05f;

	public Vector2 minXY;
	Vector3 launchPos;

	private GameObject goal;
	private GameObject slingshot;
	private GameObject empty;

	Vector3 destination;
	public float speed;

	void Awake() {

		S = this;      //this= das Objekt, das gerade erschienen ist. Nämlich das Projectil
		camZ = transform.position.z;


		
		//setEmptyToMiddle ();



	}

	void setPoi(GameObject target){
		poi = target;
	}

	private void setEmptyToMiddle(){
		Vector3 a = slingshot.transform.position;
		Vector3 b = goal.transform.position;
		Vector3 c = empty.transform.position;
		//Vector3 middle = (a + b) / 2;
		//empty.transform.position = middle;
	}




	public void OnButtonClick(GameObject NameOfPoi){
		poi = NameOfPoi;

	}

	void FixedUpdate(){


		//check if the poi is empty
		if (poi == null) {       //Set the destination to the zero vector
			destination = Vector3.zero;
		}


		else {//the poi exists
			 destination = poi.transform.position;
			//get its position
			if(poi.tag == "projectile"){

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
