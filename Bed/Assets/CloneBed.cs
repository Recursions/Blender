using UnityEngine;
using System.Collections;

public class CloneBed : MonoBehaviour {

	public GameObject bed;
	// Use this for initialization
	void Start () {
		Instantiate (bed);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
