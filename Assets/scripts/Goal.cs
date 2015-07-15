using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Goal: MonoBehaviour {

	//static field accessable from everywhere
	public static bool goalMet;
	private GameObject Goaltext;
	private Text GarlicText;

	private GameObject ParticleBlood;
	private GameObject activate;
	private Vector3 ParticlePos;

	private GameObject GoalSound;
	private GameObject GameSound;
	int x = 0;


	void Start(){
		//print ("started");
		Goaltext = GameObject.FindGameObjectWithTag ("goalText");
		Goaltext.SetActive (false);

		GoalSound = GameObject.FindGameObjectWithTag ("goalSound");
		GoalSound.SetActive (false);

		GameSound = GameObject.FindGameObjectWithTag ("gamesound");

		ParticleBlood = GameObject.FindGameObjectWithTag ("particleBlood");
		Debug.Log ("particleblood found");

	
	}
	void Update(){

		if (x == 0) {
		}

		else {
			x = x - 1;
			if (x == 1){
				 GarlicText.text = "";
			}
		}
	}
	void OnTriggerEnter(Collider other) {

		if (other.gameObject.tag == "peg") {
			//print ("collision");
			goalMet = true;

			ParticlePos = this.transform.position;
			activate = Instantiate(ParticleBlood) as GameObject; 
			activate.transform.position = ParticlePos;

			GameSound.SetActive(false);

			//play = Instantiate (play1) as AudioSource;
			GoalSound.SetActive(true);

			//print ("dracula is dead");
			Goaltext.SetActive(true);
			//print ("dracula is dead");
		}

		if (other.gameObject.tag == "garlic") {
			//print ("You cannot kill dracula with garlic!");

			GameObject GarlicTextGO = GameObject.FindGameObjectWithTag ("kill");
			GarlicText = GarlicTextGO.GetComponent<Text>();
			GarlicText.text = "You can only kill dracula with the peg!";
			x=300;
		}

		if (other.gameObject.tag == "crucifix") {
			//print ("You cannot kill dracula with garlic!");
			
			GameObject GarlicTextGO = GameObject.FindGameObjectWithTag ("kill");
			GarlicText = GarlicTextGO.GetComponent<Text>();
			GarlicText.text = "You can only kill dracula with the peg!";
			x=300;
		}

		if (other.gameObject.tag == "holyWater") {
			//print ("You cannot kill dracula with garlic!");
			
			GameObject GarlicTextGO = GameObject.FindGameObjectWithTag ("kill");
			GarlicText = GarlicTextGO.GetComponent<Text>();
			GarlicText.text = "You can only kill dracula with the peg!";
			x=300;
		}
		//check if the object is a projectile
		//if so set goal met = true, also set the goals alpha to a higher opacity
		//use renderer component material,color,transparency
	}
}
