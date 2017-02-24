using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Wizard : MonoBehaviour {
	public List<GameObject> skillList;
	public int Damage;
	public float CritRate;
	public bool isHeal;

	private bool isSkillUsed;

	void OnMouseDown()
	{
		for (int i = 0; i < 4; i++) {
			GameObject temp = Instantiate(skillList[i],new Vector3 (100f + (70f * i), 50f, 0f),Quaternion.identity) as GameObject;
			temp.transform.parent = GameObject.Find ("Canvas").transform.FindChild("Skills").transform;

		}


	}

	public  void formatPlayer()
	{
		Damage = 0;
		CritRate = 0;
		GetComponent<CharacterController> ().isRoar = false;
		isSkillUsed = false;
		isHeal = false;
	}
	public void fuckingMeteor()
	{

		Damage =(int) Random.Range (15f, 30f);
		GetComponent<CharacterController> ().Mana -= 40;
		CritRate = 0.10f;
		foreach (Transform child in GameObject.Find("Enemy/Enemies").transform) {
			if (Random.value < CritRate) {
				child.GetComponent<EnemyController> ().Health -= Damage * 2;
			} else {
				child.GetComponent<EnemyController> ().Health -= Damage;
			}

		}
		isSkillUsed = true;
		GetComponent<CharacterController> ().destroySkills ();
	}
	public void throwFire()
	{
		Damage =(int) Random.Range (30f, 40f);
		GetComponent<CharacterController> ().Mana -= 30;
		CritRate = 0.1f;
		isSkillUsed = true;
		GetComponent<CharacterController> ().destroySkills ();
	}
	public void healEverybody()
	{
		foreach (Transform child in GameObject.Find("Players").transform) {
			if (child.gameObject.tag != "MainCamera") {
				if ((int)(child.GetComponent<CharacterController> ().Health * 0.15f) + child.GetComponent<CharacterController> ().Health < 200)
					child.GetComponent<CharacterController> ().Health += (int)(child.GetComponent<CharacterController> ().Health * 0.15f);
				else
					child.GetComponent<CharacterController> ().Health = 200;
			}
		}
		GetComponent<CharacterController> ().Mana -= 35;
		isHeal = true;
		isSkillUsed = true;
		GetComponent<CharacterController> ().destroySkills ();
	}
	public void curseIdiots()
	{
		foreach (Transform child in GameObject.Find("Enemy/Enemies").transform) {
			child.GetComponent<EnemyController> ().isCursed = true;
		}
		GetComponent<CharacterController> ().Mana -= 30;
		GetComponent<CharacterController> ().destroySkills ();
	}
	// Use this for initialization
	void Start () {
		isSkillUsed = false;
		GetComponent<CharacterController> ().isRoar = false;
	}

	// Update is called once per frame
	void Update () {
		Debug.Log (gameObject.name +" "+ gameObject.GetComponent<CharacterController> ().Health+" "+ gameObject.GetComponent<CharacterController> ().Mana);
		if (GetComponent<CharacterController> ().isRoar) {
			Damage += (int) (Damage*0.2f);
		}
	}

}
