using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Goal: MonoBehaviour {

	//static field accessable from everywhere
	public static bool goalMet;        //have you reached your goal?
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

		else {                                 //if x > 1
			x = x - 1;                         //decrease x by 1 every frame
			if (x == 1){                       //if x = 1
				 GarlicText.text = "";         //set the garlicText to empty, so you can´t see it anymore.
			}
		}
	}
	void OnTriggerEnter(Collider other) {

		if (other.gameObject.tag == "peg") {  //if you hit the goal with a peg projectie
			//print ("collision");
			goalMet = true;    //you win
            //instantiate the particle effect
			ParticlePos = this.transform.position;
			activate = Instantiate(ParticleBlood) as GameObject; 
			activate.transform.position = ParticlePos;

			GameSound.SetActive(false);    //deactivae the gamesound

			//play = Instantiate (play1) as AudioSource;
			GoalSound.SetActive(true);     //activate the goalSound

			//print ("dracula is dead");
			Goaltext.SetActive(true);     //activate the goalText
			//print ("dracula is dead");
		}

		if (other.gameObject.tag == "garlic") {                                 //if the goal is hit with some other projectile than the peg...
			//print ("You cannot kill dracula with garlic!");

			GameObject GarlicTextGO = GameObject.FindGameObjectWithTag ("kill");//find the garlicText gameObject
			GarlicText = GarlicTextGO.GetComponent<Text>();                     //get its text component
			GarlicText.text = "You can only kill dracula with the peg!";        //show this text
			x=300;                                                              //set the x to 300, for it is some kind of timer, see the update function. as long as x > 0, the text is shown.
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
	}
}
