using UnityEngine;
using System.Collections;

public class woodenWall : MonoBehaviour {

    //this is almost exactly the same script as the script cobwebWall, so I comment only this one.

	private GameObject woodWall;   //your wooden wall object
	private GameObject Particle;   //your particle effect
	private GameObject activate;   //Your gameobject which is the position of the particle effect.
	private Vector3 ParticlePos;   //the position of this specific wooden wall

	void Awake (){
        //setting the references
		woodWall = GameObject.FindGameObjectWithTag("wood");
		Particle = GameObject.FindGameObjectWithTag ("particle");
	}

	void OnTriggerEnter( Collider other){                     //if something enters the collider of the wooden wall...
		if (other.gameObject.tag =="crucifix"){               //...and the someting is a crucifix projectile...

			ParticlePos = this.transform.position;            //...store the position of the wooden wall

			Destroy(this.gameObject);                         //Destroy the wooden wall 
			activate = Instantiate(Particle) as GameObject;   //Instantiate the particle effect...
			activate.transform.position = ParticlePos;        //...at the position o the now destroyed wooden wall.
		}
	}
}
