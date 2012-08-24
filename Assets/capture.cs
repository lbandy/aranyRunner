using UnityEngine;
using System.Collections;
using System;

public class capture : MonoBehaviour {

    TextMesh score;
    Gold gold;

	// Use this for initialization
	void Start () {
        score = GameObject.Find("score").GetComponent<TextMesh>();
        gold = GameObject.Find("bg").GetComponentInChildren<Gold>();
	}
	
	// Update is called once per frame

    string[] explode;

    void OnTriggerEnter(Collider coll)
    {
        if (coll.transform.name == "player")
        {
            gold.score++;
            score.text = "Score: " + gold.score;
            explode = transform.name.Split('_');
            gold.ResetPosition(Int32.Parse(explode[1]));
        }

    }

}
