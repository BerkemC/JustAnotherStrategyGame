using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class CharacterController : MonoBehaviour {
	public int Health;
	public int Mana;
	public bool isHalo;
	public bool isActive;
	public bool isRoar;
	public bool critReduce;
	private int levelNum;
	private bool isActiveMove;
	private float distance = 35f;
	public Vector3 startPos;
	public bool levelCompleted;


	public bool levelComp(int level){
		if (level == -1)
			level = 0;
		foreach (Transform child in GameObject.Find("Enemy").transform.GetChild(level).transform) {
			if (child.gameObject.GetComponent<Goblin> ().isDead == false)
				return false;
			}
		levelNum++;
		return true;
	}
	public void destroySkills()
	{
		for (int i = 0; i < 4; i++) {
			foreach (Transform child in GameObject.Find("Canvas").transform.FindChild("Skills").transform) {
				if (child != null)
					Destroy (child.gameObject);
			}
		}

	}
	public static GameObject ActivePlayer()
	{
		foreach (Transform child in GameObject.Find("Players").transform) {
			if (child.tag != "MainCamera")
			if (child.GetComponent<CharacterController> ().isHalo)
				return child.gameObject;
		}
		return null;
	}

	public void  OnMouseDown()
	{
		foreach (Transform child in GameObject.Find("Players").transform) {
			if( child.tag != "MainCamera")
			if (child.GetComponent<CharacterController> ().isHalo ) {
				child.GetComponent<CharacterController> ().isHalo = false;
			}	
		}
		isHalo =true;
	
	}


	// Use this for initialization
	void Start () {
		startPos = GameObject.Find ("Players").transform.position;
		isActiveMove = false;
		levelNum = 0;
		isHalo = false;
		(transform.FindChild ("Halo").gameObject.GetComponent("Halo") as Behaviour).enabled = false;
		Health = 200;
		Mana = 100;
		isRoar = false;
		levelCompleted = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (isActiveMove) {
			if (Mathf.Abs (Vector3.Distance (startPos, GameObject.Find ("Players").transform.position)) <= distance) {
				GameObject.Find ("Players").transform.position += Vector3.forward * 2f * Time.deltaTime;
				if (Mathf.Abs (Vector3.Distance (startPos, GameObject.Find ("Players").transform.position)) > distance) {
					GameObject.Find ("Enemy").transform.GetChild (levelNum - 1).gameObject.SetActive (false);
					isActiveMove = false;
				}
			}
		} else {
			startPos = gameObject.transform.position;
		}
		if (levelComp (levelNum)) {
			Debug.Log ("Hello ");
			isActiveMove = true;
			GameObject.Find ("Enemy").transform.GetChild (levelNum).gameObject.SetActive (true);

		}
		if (!isHalo)
			(transform.FindChild ("Halo").gameObject.GetComponent ("Halo") as Behaviour).enabled = false;
		else
			(transform.FindChild ("Halo").gameObject.GetComponent ("Halo") as Behaviour).enabled = true;
	}
}
