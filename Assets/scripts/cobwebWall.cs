using UnityEngine;
using System.Collections;

public class cobwebWall : MonoBehaviour {

	private GameObject cobWeb;
	private GameObject Particle;
	private GameObject activate;
	private Vector3 ParticlePos;
	
	
	void Awake (){
		cobWeb = GameObject.FindGameObjectWithTag("cobWeb");
		Particle = GameObject.FindGameObjectWithTag ("particleString");
	}
	
	void OnTriggerEnter( Collider other){
		if (other.gameObject.tag =="holyWater"){
			
			ParticlePos = this.transform.position;
			
			Destroy (this.gameObject);
			activate = Instantiate(Particle) as GameObject; 
			activate.transform.position = ParticlePos;
			other.gameObject.SetActive(false);
		}
	}
}
