using UnityEngine;
using System.Collections;

public class CheckPoint: MonoBehaviour {

	public bool startPoint = false;
	public bool refillPoint = true;
	public bool goalPoint = false;

	public int refillSeconds = 20;

	public TimeManager tm;

	void OnTriggerEnter(Collider col){
		if (col.name == "PathCollider") {

			if (refillPoint) {
				tm.RefillTimer (refillSeconds);
			}

			if (startPoint) {
				tm.StartTimer ();
			}

			if (goalPoint) {
				tm.Win ();
			}

		}
	}
}
