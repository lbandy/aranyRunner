using UnityEngine;
using System.Collections;
using System;

public class capture : MonoBehaviour {

    TextMesh score;
    Gold gold;
    Coal coal;

    bool coaling = false;

	// Use this for initialization
	void Start () {
        score = GameObject.Find("score").GetComponent<TextMesh>();
        gold = GameObject.Find("bg").GetComponentInChildren<Gold>();
        coal = GameObject.Find("bg").GetComponentInChildren<Coal>();
	}
	
	// Update is called once per frame

    string[] explode;

    void OnTriggerEnter(Collider coll)
    {
        if (coll.transform.name == "player")
        {
            gold.score = Mathf.Round((gold.score + transform.localScale.x) * 100) / 100;
            score.text = "Score: " + gold.score;
            explode = transform.name.Split('_');
            gold.ResetPosition(Int32.Parse(explode[1]));

            if (!coaling && gold.score > 10)
            {
                coal.enabled = true;
            }
        }

    }

}
