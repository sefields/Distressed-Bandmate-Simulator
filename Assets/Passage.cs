using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// True = noun
// False = verb

public class Passage : MonoBehaviour {

	public List<bool> nounOrVerb ;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public int howMany(){
		return nounOrVerb.Count;
	}
}
