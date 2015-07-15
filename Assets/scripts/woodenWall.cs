using UnityEngine;
using System.Collections;

public class woodenWall : MonoBehaviour {

	private GameObject woodWall;
	private GameObject Particle;
	private GameObject activate;
	private Vector3 ParticlePos;


	void Awake (){
		woodWall = GameObject.FindGameObjectWithTag("wood");
		Particle = GameObject.FindGameObjectWithTag ("particle");
	}

	void OnTriggerEnter( Collider other){
		if (other.gameObject.tag =="crucifix"){

			ParticlePos = this.transform.position;

			Destroy(this.gameObject);
			activate = Instantiate(Particle) as GameObject; 
			activate.transform.position = ParticlePos;
		}
	}
}
