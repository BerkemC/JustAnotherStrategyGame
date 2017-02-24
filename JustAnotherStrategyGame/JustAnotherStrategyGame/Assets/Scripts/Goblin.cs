using UnityEngine;
using System.Collections;

public class Goblin : MonoBehaviour {
	public int Damage;
	public float CritRate;
	public bool isCrit;
	public int count;
	public bool isDead;
	public void formatGoblin()
	{
		if (count >1 && isCrit == true) {
			isCrit = false;
			count = 0;
		}
		GetComponent<EnemyController> ().isCursed = false;
		CritRate = 0f;
		Damage = 0;

	}
	public void hitWithKnife()
	{
		Damage =(int) Random.Range (10f, 25f);
		if(isCrit)
			CritRate = 0.3f;
		else 
			CritRate = 0.15f;
		GetComponent<EnemyController> ().Mana -= 20;
	}
	public void fuckCrit()
	{
		foreach (Transform child in GameObject.Find("Players").transform) {
			if (child.gameObject.tag != "Main Camera") {
				child.gameObject.GetComponent<CharacterController> ().critReduce = true;
			}
		}
		GetComponent<EnemyController> ().Mana -= 25;
	}
	public void stealMana()
	{
		GameObject fuckedPlayer = CharacterController.ActivePlayer ();
		int stolen = (int)(fuckedPlayer.GetComponent<CharacterController>().Mana *0.2f); 
		fuckedPlayer.GetComponent<CharacterController> ().Mana -= stolen;
		GetComponent<EnemyController> ().Mana -= 25;
		GetComponent<EnemyController> ().Mana += stolen+stolen;
	}
	public void waitForPower()
	{
		count++;
		isCrit = true;
		GetComponent<EnemyController> ().Mana -= 20;
	}
	// Use this for initialization
	void Start () {
		isCrit = false;
		isDead = false;
		GetComponent<Animator> ().SetInteger ("moving", 5);
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Animator> ().SetInteger ("moving", 5);
		if (GetComponent<EnemyController> ().isCursed) {
			Damage = (int)(Damage * 0.8);
		}
		if (GetComponent<EnemyController> ().Health <= 0 && !isDead) {
			isDead = true;
			Debug.Log ("Hello Motherfucker");
			GetComponent<Animator> ().SetInteger ("moving", 12);
			transform.GetChild (0).gameObject.SetActive (false);	
			//Destroy (gameObject);
		}

		Debug.Log (gameObject.name +" "+ gameObject.GetComponent<EnemyController> ().Health+" "+ gameObject.GetComponent<EnemyController> ().Mana);
		//Debug.Log (gameObject.name +" "+ gameObject.GetComponent<EnemyController> ().Health+" "+ gameObject.GetComponent<Ene> ().Mana);
	}
}
