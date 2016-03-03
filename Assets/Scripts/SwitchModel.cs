using UnityEngine;
using System.Collections;

public class SwitchModel : MonoBehaviour {

	public Material activeMaterial;
	public Material inactiveMaterial;

	public GameObject cl;
	public GameObject cc;
	public GameObject cr;

	//call it like this: UpdateModel("SwitchColliderC",-1);
	public void UpdateModel(string section, int state){

		if(section == "SwitchColliderL" || section == "l" || section == "L"){
			switch (state){
			case -1:
				Debug.Log ("L to L");
				break;
			case 0:
				Debug.Log ("L to C");
				break;
			case 1:
				Debug.Log ("L to R");
				break;
			default:
				Debug.Log("PROBLEM : cannot find proper state for rail model");
				break;
			}
		}
		if(section == "SwitchColliderC" || section == "c" || section == "C"){
			switch (state){
			case -1:
				if (cl != null) {cl.GetComponent<Renderer> ().material = activeMaterial;}
				if (cc != null) {cc.GetComponent<Renderer> ().material = inactiveMaterial;}
				if (cr != null) {cr.GetComponent<Renderer> ().material = inactiveMaterial;}
				Debug.Log ("C to L");
				break;
			case 0:
				if (cl != null) {cl.GetComponent<Renderer> ().material = inactiveMaterial;}
				if (cc != null) {cc.GetComponent<Renderer> ().material = activeMaterial;}
				if (cr != null) {cr.GetComponent<Renderer> ().material = inactiveMaterial;}
				Debug.Log ("C to C");
				break;
			case 1:
				if (cl != null) {cl.GetComponent<Renderer> ().material = inactiveMaterial;}
				if (cc != null) {cc.GetComponent<Renderer> ().material = inactiveMaterial;}
				if (cr != null) {cr.GetComponent<Renderer> ().material = activeMaterial;}
				Debug.Log ("C to R");
				break;
			default:
				Debug.Log("PROBLEM : cannot find proper state for rail model");
				break;
			}
		}
		if(section == "SwitchColliderR" || section == "r" || section == "R"){
			switch (state){
			case -1:
				Debug.Log ("R to L");
				break;
			case 0:
				Debug.Log ("R to C");
				break;
			case 1:
				Debug.Log ("R to R");
				break;
			default:
				Debug.Log("PROBLEM : cannot find proper state for rail model");
				break;
			}
		}

	}
}
