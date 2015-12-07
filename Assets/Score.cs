using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public static int score = 0;
	public List<GameObject> passages = new List<GameObject>();
	public GameObject currPassage;
	public GameObject dynaTextPrefab;
	public GameObject dynaTextWhere;
	public int index = 0;

	public float answersLeftSide;
	public float answersRightSide;

	public Color saneColor;
	public Color neutralColor;
	public Color insaneColor;


	// Use this for initialization
	void Start () {
		currPassage = (GameObject) Instantiate (passages [index], transform.position, Quaternion.identity);
		//spawnWords ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyUp(KeyCode.Return)) {

			//Count up the score
			getVerseScore ();

			//Cycle to the next passage and destroy the old one
			GameObject destroy = currPassage;
			currPassage =  (GameObject) Instantiate (passages [++index], transform.position, Quaternion.identity);
			Destroy (destroy);

			//Destroy any dynamic texts that are lying around
			GameObject[] dynamicTexts = GameObject.FindGameObjectsWithTag ("dynamic");
			foreach(GameObject word in dynamicTexts){
				Destroy (word);
			}

			//Spawn words
			spawnWords();

			//Update background color
			updateColor ();

			//GameObject dText = (GameObject) Instantiate(dynaTextPrefab, dynaTextWhere.transform.position, Quaternion.identity);
			//dText.GetComponent<DynamicText>().setInitialText(score); //MARKKKEDDDDD
		}
	
	}

	void spawnWords(){
		//Instantiate some dynamic text objects in some specific spots
		int howMany = currPassage.GetComponent<Passage> ().howMany ();
		float span = answersRightSide - answersLeftSide;
		float interval = span / howMany;
		List<GameObject> dTexts = new List<GameObject> ();
		for (int i = 0; i < howMany; i ++) {
			GameObject newDText = (GameObject)Instantiate (dynaTextPrefab, new Vector3 (answersLeftSide + (interval * i), dynaTextWhere.transform.position.y, dynaTextWhere.transform.position.z), Quaternion.identity);
			newDText.GetComponent<DynamicText> ().init ();
			newDText.GetComponent<DynamicText> ().getWords (currPassage.GetComponent<Passage> ().nounOrVerb [i]);
			dTexts.Add (newDText);

		}
	}

	public void getVerseScore(){
		int sanityChange = 0; //how much sanity has changed from this verse
		GameObject[] dynamicTexts = GameObject.FindGameObjectsWithTag ("dynamic");
		foreach(GameObject word in dynamicTexts){
			int index = word.GetComponent<DynamicText>().index;
			if(index == 0){
				score--;
			} else if (index == 1){
				//score stays the same
			} else if (index == 2) {
				score++;
			} else {
				Debug.Log ("bad index");
			}
		}
	}

	public void updateColor(){
		GameObject bg = GameObject.Find ("RawImage");
		Color currColor = bg.GetComponent<RawImage> ().color;
		//Debug.Log (score + "    " + currColor);

		if (score <= -3) bg.GetComponent<RawImage> ().color = saneColor;
		else if (score >=3) bg.GetComponent<RawImage> ().color = insaneColor;
		else bg.GetComponent<RawImage> ().color = neutralColor;
	}


}
