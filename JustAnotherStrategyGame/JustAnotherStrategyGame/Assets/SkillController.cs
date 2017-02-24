using UnityEngine;
using System.Collections;

public class SkillController : MonoBehaviour {
	public void LumberAttack()
	{
		GameObject tempPlayer = CharacterController.ActivePlayer (), 
		tempEnemy = EnemyController.ActiveEnemy ();
		Debug.Log (tempPlayer.name + "has attacked " + tempEnemy.name);
		if (Random.value < tempPlayer.GetComponent<LuberMan> ().CritRate) {
			tempEnemy.GetComponent<EnemyController> ().Health -= tempPlayer.GetComponent<LuberMan> ().Damage * 2;
		} else {
			tempEnemy.GetComponent<EnemyController> ().Health -= tempPlayer.GetComponent<LuberMan> ().Damage;
		}
		tempPlayer.GetComponent<LuberMan> ().formatPlayer ();
	}
	public void WizardAttack()
	{
		GameObject tempPlayer = CharacterController.ActivePlayer (), 
				   tempEnemy = EnemyController.ActiveEnemy ();
		Debug.Log (tempPlayer.name + "has attacked " + tempEnemy.name);
		if (Random.value < tempPlayer.GetComponent<Wizard> ().CritRate) {
			tempEnemy.GetComponent<EnemyController> ().Health -= tempPlayer.GetComponent<Wizard> ().Damage * 2;
		} else {
			tempEnemy.GetComponent<EnemyController> ().Health -= tempPlayer.GetComponent<Wizard> ().Damage;
		}
		tempPlayer.GetComponent<Wizard> ().formatPlayer ();
	}
	public void LSkill1 (){
		CharacterController.ActivePlayer ().GetComponent<LuberMan> ().hitWithAxe ();
		Debug.Log ("LSkill activated");
		LumberAttack ();}
	public void LSkill2 (){
		Debug.Log ("LSkill2 activated");
		CharacterController.ActivePlayer ().GetComponent<LuberMan> ().throwAxe ();
		LumberAttack ();

	}
	public void LSkill3 (){
		Debug.Log ("LSkill3 activated");

		CharacterController.ActivePlayer ().GetComponent<LuberMan> ().makeRoar ();
		CharacterController.ActivePlayer ().GetComponent<LuberMan> ().formatPlayer ();

	}
	public void LSkill4 (){
		Debug.Log ("LSkill4 activated");
		CharacterController.ActivePlayer ().GetComponent<LuberMan> ().healYourself ();
		CharacterController.ActivePlayer ().GetComponent<LuberMan> ().formatPlayer ();
	}
	public void WSkill1 (){
		Debug.Log ("wSkill1 activated");
		CharacterController.ActivePlayer ().GetComponent<Wizard> ().fuckingMeteor ();
		CharacterController.ActivePlayer ().GetComponent<Wizard> ().formatPlayer ();
		CharacterController.ActivePlayer ().GetComponent<Animation> ().Play ("Attack", PlayMode.StopSameLayer);
		CharacterController.ActivePlayer ().GetComponent<Animation> ().PlayQueued ("Idle1");
	}
	public void WSkill2 (){
		Debug.Log ("wSkill2 activated");
		CharacterController.ActivePlayer ().GetComponent<Wizard> ().throwFire ();
		WizardAttack ();
		CharacterController.ActivePlayer ().GetComponent<Animation> ().Play ("Magic Attack", PlayMode.StopSameLayer);
		CharacterController.ActivePlayer ().GetComponent<Animation> ().PlayQueued ("Idle1");
	}
	public void WSkill3 (){
		Debug.Log ("wSkill3 activated");
		CharacterController.ActivePlayer ().GetComponent<Wizard> ().healEverybody ();
		CharacterController.ActivePlayer ().GetComponent<Wizard> ().formatPlayer ();
		CharacterController.ActivePlayer ().GetComponent<Animation> ().Play ("Magic Attack2", PlayMode.StopSameLayer);
		CharacterController.ActivePlayer ().GetComponent<Animation> ().PlayQueued ("Idle1");

	}
	public void WSkill4 (){
		Debug.Log ("wSkill4 activated");
		CharacterController.ActivePlayer ().GetComponent<Wizard> ().curseIdiots ();
		CharacterController.ActivePlayer ().GetComponent<Wizard> ().formatPlayer ();
		CharacterController.ActivePlayer ().GetComponent<Animation> ().Play ("Magic Attack3", PlayMode.StopSameLayer);
		CharacterController.ActivePlayer ().GetComponent<Animation> ().PlayQueued ("Idle1");
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
