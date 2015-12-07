using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Score : MonoBehaviour {

	public static int score = 0;
    public List<GameObject> passages;
    public List<GameObject> endingPassages;
	public GameObject currPassage;
	public GameObject dynaTextPrefab;
	public GameObject dynaTextWhere;
	public int index = 0;

	public float answersLeftSide;
	public float answersRightSide;


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
            Debug.Log(Score.score);

			//Cycle to the next passage and destroy the old one
            if(++index >= passages.Count) { // ending passage case, spawn ending passage based on insanity score
                GameObject destroy = currPassage;
                if (Score.score > 3)
                { //insane ending
                    currPassage = (GameObject)Instantiate(endingPassages[2], transform.position, Quaternion.identity);
                }
                else if (Score.score <= 3 && Score.score >= -3)
                { //ambiguous ending
                    currPassage = (GameObject)Instantiate(endingPassages[1], transform.position, Quaternion.identity);
                }
                else if (Score.score < -3)
                { //sane ending
                    currPassage = (GameObject)Instantiate(endingPassages[0], transform.position, Quaternion.identity);
                } else
                {
                    Debug.Log("somethings wrong");
                }
                Destroy(destroy);
            } else { //default case to add next passage 
                GameObject destroy = currPassage;
                currPassage = (GameObject)Instantiate(passages[index], transform.position, Quaternion.identity);
                Destroy(destroy);              
            }

            //Destroy any dynamic texts that are lying around
            GameObject[] dynamicTexts = GameObject.FindGameObjectsWithTag("dynamic");
            foreach (GameObject word in dynamicTexts)
            {
                Destroy(word);
            }

            //Spawn words
            if (index < passages.Count) {
                spawnWords();
            }
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


}
