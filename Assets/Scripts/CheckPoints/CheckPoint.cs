using UnityEngine;
using System.Collections;

public class CheckPoint: MonoBehaviour {

	public bool startPoint = false;
	public bool refillPoint = true;
	public bool goalPoint = false;

	public int refillSeconds = 20;

	public TimeManager tm;
	public GameManager gm;

	void OnTriggerEnter(Collider col){
		if (col.name == "PathCollider") {

			//Debug.Log (col.gameObject.transform.position);

			gm.SetRespawn (col.gameObject.transform);

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
