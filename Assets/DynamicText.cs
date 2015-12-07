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

		//index = 0;

		//wordStoreObject = GameObject.Find ("WordStore");
		//wordStore = wordStoreObject.GetComponent<WordStore> ();
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
            if (roll < 50)
            {
                GetComponent<TextMesh>().text = listOfWords[0];
            }
            else if (roll >= 50 && roll < 75)
            {
                cycle();
            }
            else {
                cycle();
                cycle();
            }
            
		} else if (Score.score == 0) { //ambiguous
            if (roll < 50)
            {
                cycle();
            }
            else if (roll >= 50 && roll < 75)
            {
                GetComponent<TextMesh>().text = listOfWords[0];
            }
            else {
                cycle();
                cycle();
            }
		} else { //insane
            if (roll < 50)
            {
                cycle();
                cycle();
            }
            else if (roll >= 50 && roll < 75)
            {
                cycle();
            }
            else {
                GetComponent<TextMesh>().text = listOfWords[0];
            }
		}

	}

	public void switchIndex(int i) {
		index = i;
		GetComponent <TextMesh>().text = listOfWords[index];
	}

	public void cycle() {
		index++;
		if (index >= listOfWords.Count)
			index = 0; 
		GetComponent <TextMesh>().text = listOfWords[index];
	}
}
