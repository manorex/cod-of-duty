using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Barrel : MonoBehaviour {
	
	public GameObject m_fishPrefab;
	public int m_numFishToGenerate;
	public Vector3 m_genMin;
	public Vector3 m_genMax;
	public List<GameObject> m_fish;
	
	void Start() {
		m_fish = new List<GameObject>();
		for(var i = 0; i < m_numFishToGenerate; i++) {
			GenerateFish();
		}
	}
	
	void GenerateFish() {
		var go = (GameObject)GameObject.Instantiate(m_fishPrefab);
		go.transform.parent = transform;
		go.transform.localPosition = new Vector3(0, Random.Range (m_genMin.y, m_genMax.y), 0);
		go.transform.localRotation = Quaternion.identity;
		m_fish.Add (go);
	}
	
	public void Explode(Player p) {
		for(var i = m_fish.Count - 1; i >= 0; i--) {
			var fishGO = m_fish[i];
			var shootable = fishGO.GetComponentInChildren<Shootable>();
			shootable.ShotBy (p);
			m_fish.Remove(fishGO);
		}
		Destroy (gameObject, 0.3f);
	}
}
