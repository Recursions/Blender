using UnityEngine;
using System.Collections;

public class GameManager: MonoBehaviour {
	
	public Camera cam;
	public AudioSource audioSource;
	//Animator anim;

	public GameObject gift;	
	public GameObject bed;
	private GameObject createdBed;
	private GameObject createdGift;

	private bool flag;
	
	// Use this for initialization
	void Start () {
		flag = false;
		createdBed = Instantiate (bed);
		//anim = GetComponent<Animator> ();
		audioSource = (AudioSource)gameObject.AddComponent<AudioSource> ();
		AudioClip myAudioClip;
		myAudioClip = (AudioClip)Resources.Load ("click");
		audioSource.clip = myAudioClip;
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		Ray ray = cam.ScreenPointToRay (Input.mousePosition);
		if (Input.GetMouseButtonUp(0)) {
			Debug.Log("Pressed left click.");
			if (Physics.Raycast(ray, out hit)) {
				Transform objectHit = hit.transform;
				if (objectHit.name.Equals("Stand")) {
					audioSource.Play();
					//anim.SetTrigger("Pressed");
					//anim.SetTrigger("notPressed");
					createdGift = Instantiate(gift);
					flag = true;
				}
			}
		}
		if (flag) {
			float disToBed = Vector3.Distance (createdGift.transform.position, createdBed.transform.position);
			if (disToBed < 50.0) {
				Debug.Log(disToBed);
				Destroy (createdBed.gameObject);
			}
		}
	}
	
}
