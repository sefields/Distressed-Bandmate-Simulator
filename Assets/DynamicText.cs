using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DynamicText : MonoBehaviour {

	public int index;
	List<string> listOfWords = new List<string>();
	public GameObject wordStoreObject;
	WordStore wordStore;

	// Use this for initialization
	void Start () {

		index = 0;

		wordStoreObject = GameObject.Find ("WordStore");
		wordStore = wordStoreObject.GetComponent<WordStore> ();
		//Note: listOfWords[0] returns a sane word, [1] returns ambig, [2] returns insane

	}

	public void init(){
		index = 0;
		
		wordStoreObject = GameObject.Find ("WordStore");
		wordStore = wordStoreObject.GetComponent<WordStore> ();
		//Note: listOfWords[0] returns a sane word, [1] returns ambig, [2] returns insane
	}

	public void getWords(bool noun){
		if (noun) {//noun get nouns, not noun get verbs
			listOfWords = wordStore.getAssortmentNouns ();
		} else {
			listOfWords = wordStore.getAssortmentVerbs ();
		}
		setInitialText ();
	}

	// Update is called once per frame
	void Update () {
	
	}

	public void setInitialText(){
		float roll = Random.Range (0, 100);
		if (Score.score < 0) { //sane
			GetComponent<TextMesh> ().text = listOfWords [0];
		} else if (Score.score == 0) { //ambiguous
			cycle ();
		} else { //insane
			cycle();
			cycle();
		}

	}

	public void switchIndex(int i) {
		index = i;
		GetComponent <TextMesh>().text = listOfWords[index];
	}

	public void cycle() {
		index ++;
		if (index >= listOfWords.Count)
			index = 0; 
		Debug.Log ("count " + listOfWords.Count + " index " + index);
		GetComponent <TextMesh>().text = listOfWords[index];
	}
}
