using UnityEngine;
using System.Collections;

public class PlayerTrackSwitch : MonoBehaviour {

	public TrackSwitch trackSwitch;

	public void SwitchLeft(){
		trackSwitch.Switch (-1);
	}

	public void SwitchRight(){
		trackSwitch.Switch (1);
	}

}
