using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Sam Fields
//
// This script will be attached to an empty object and will hold the 'databases' of words and verses
// for the game.
//
// The dictionary 'words' can be queried by score (an integer), and will return a list of words.

public class WordStore : MonoBehaviour {
	
	public List<string> nounsSane;
	public List<string> nounsAmbig;
	public List<string> nounsInsane;
	public List<string> verbsSane;
	public List<string> verbsAmbig;
	public List<string> verbsInsane;
	public List<string> verses;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public List<string> getAssortmentNouns() {
		List<string> result = new List<string>();

		result.Add (nounsSane[Random.Range (0,nounsSane.Count-1)]);
		result.Add (nounsAmbig[Random.Range (0,nounsAmbig.Count-1)]);
		result.Add (nounsInsane[Random.Range (0,nounsInsane.Count-1)]);

		return result;

	}

	public List<string> getAssortmentVerbs() {
		List<string> result = new List<string>();
		
		result.Add (verbsSane[Random.Range (0,verbsSane.Count-1)]);
		result.Add (verbsAmbig[Random.Range (0,verbsAmbig.Count-1)]);
		result.Add (verbsInsane[Random.Range (0,verbsInsane.Count-1)]);
		
		return result;
		
	}

}
