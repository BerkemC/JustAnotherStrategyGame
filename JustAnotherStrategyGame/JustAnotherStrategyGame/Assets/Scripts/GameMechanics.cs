using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class GameMechanics : MonoBehaviour {
	public List<GameObject> playerChars;
	// Use this for initialization



	void Start () {
		for (int i = 0; i < 3; i++) {
			GameObject temp = Instantiate (playerChars [i],new Vector3 (GameObject.Find("Players").gameObject.transform.position.x+5.5f-(5.5f*i),GameObject.Find("Players").gameObject.transform.position.y,GameObject.Find("Players").gameObject.transform.position.z), Quaternion.identity) as GameObject;
			temp.transform.parent = GameObject.Find ("Players").transform;
		
		}
		foreach (Transform child in  GameObject.Find ("Players").transform) {
			if (child.tag != "MainCamera") {
				/*child.GetComponent<Animator> ().SetInteger ("battle", 0);
				child.GetComponent<Animator> ().SetInteger ("moving", 1);*/
			}
		}




		}
	
	// Update is called once per frame
	void Update () {
	//	GameObject.Find ("Players").transform.position += Vector3.forward * Time.deltaTime * 3f;

	}
}
