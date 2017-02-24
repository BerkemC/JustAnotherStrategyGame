using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	public int Health;
	public int Mana;
	public bool isCursed;
	public bool isHalo;
	public bool isActive;
	/*	bool checkHighlight()
	{
		foreach (Transform child in GameObject.Find("Players").transform) {
			if (child.GetComponent<CharacterController>().isHalo)
				return true;
			else
				return false;
				
		}
	
	}*/
	public static GameObject ActiveEnemy()
	{
		foreach (Transform child in GameObject.Find("Enemy/Enemies").transform) {
			if (child.GetComponent<EnemyController> ().isHalo)
				return child.gameObject;
		}
		return null;

	}
	public void  OnMouseDown()
	{
		foreach (Transform child in GameObject.Find("Enemy/Enemies").transform) {
			if (child.GetComponent<EnemyController> ().isHalo ) {
				child.GetComponent<EnemyController> ().isHalo = false;

			}	

		}
		isHalo = !isHalo;

	}


	// Use this for initialization
	void Start () {
		isHalo = false;
		(transform.FindChild ("Halo").gameObject.GetComponent("Halo") as Behaviour).enabled = false;
		Health = 100;
		Mana = 100;
		isCursed = false;

	}

	// Update is called once per frame
	void Update () {
		if (!isHalo)
			(transform.FindChild ("Halo").gameObject.GetComponent ("Halo") as Behaviour).enabled = false;
		else
			(transform.FindChild ("Halo").gameObject.GetComponent ("Halo") as Behaviour).enabled = true;

	}

}
