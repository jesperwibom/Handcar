using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	Transform currentRespawn;
	public Transform playerPrefab;

	public void SetRespawn(Transform tf){
		currentRespawn = tf;
	}

	public void Respawn(){
		//GameObject go = (GameObject)Instantiate(playerPrefab, currentRespawn.position, Quaternion.identity);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

}
