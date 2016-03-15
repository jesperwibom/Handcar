using UnityEngine;
using System.Collections;

public class VehicleControl : MonoBehaviour {
	public Renderer PlayerRenderer;
	public Material[] m_materials;
	private long numberOfMaterials;
	private long currentMaterial;

	// Use this for initialization
	void Start () {
		currentMaterial = 1;
		numberOfMaterials = m_materials.Length;
		Debug.Log (numberOfMaterials);
		PlayerRenderer.material = m_materials [1];
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("up")){
			if (currentMaterial == 1) {
				currentMaterial = numberOfMaterials;
				Debug.Log ("Current material is " + currentMaterial);
			} else {
				currentMaterial = currentMaterial - 1;
				Debug.Log ("Current material is " + currentMaterial);
			}

			PlayerRenderer.material = m_materials [currentMaterial-1];
		}


		if(Input.GetKeyDown("down")){
			if (currentMaterial == numberOfMaterials) {
				currentMaterial = 1;
				Debug.Log ("Current material is " + currentMaterial);
			} else {
				currentMaterial = currentMaterial + 1;
				Debug.Log ("Current material is " + currentMaterial);
			}

			PlayerRenderer.material = m_materials [currentMaterial-1];
		}
	}
}
