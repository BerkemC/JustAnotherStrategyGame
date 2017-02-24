using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class LuberMan : MonoBehaviour {
	public List<GameObject> skillList;
	public int Damage;
	public float CritRate;
	private bool isSkillUsed;

	void OnMouseDown(){
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
	}

	public void hitWithAxe(){
		Damage =(int) Random.Range (15f, 30f);
		GetComponent<CharacterController> ().Mana -= 20;
		CritRate = 0.15f;
		isSkillUsed = true;
		GetComponent<CharacterController> ().destroySkills ();
	}

	public void throwAxe()
	{
		Damage =(int) Random.Range (25f, 35f);
		GetComponent<CharacterController> ().Mana -= 35;
		CritRate = 0.2f;
		isSkillUsed = true;
		GetComponent<CharacterController> ().destroySkills ();
	}
	public void makeRoar(){
		foreach (Transform child in GameObject.Find("Players").transform) {
			if (child.gameObject.tag != "MainCamera") {
				child.GetComponent<CharacterController> ().isRoar = true;
			}
		}
		GetComponent<CharacterController> ().destroySkills ();
	}

	public void healYourself()
	{
		if (GetComponent<CharacterController> ().Health + GetComponent<CharacterController> ().Health * 0.2f <= 200f)
			GetComponent<CharacterController> ().Health += (int) (GetComponent<CharacterController> ().Health * 0.2f);
		GetComponent<CharacterController> ().Mana -= 20;
		isSkillUsed = true;
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
		if (GetComponent<CharacterController> ().critReduce) {
			CritRate = 0f;
		}
	}
}
