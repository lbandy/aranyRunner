using UnityEngine;
using System.Collections;

public class Gold : MonoBehaviour {
    public float fallSpeed = 2f;

    public Transform goldPrefab;
    
    System.Random random = new System.Random();

    Vector3[] shinies = new Vector3[20];
    Transform[] golds = new Transform[20];

    [System.NonSerialized]
    public float score = 0;
    float rnd;

    void Awake()
    {
        for (int i = 0; i < 15; i++)
        {
            Transform gold = Instantiate(goldPrefab, Vector3.zero, Quaternion.identity) as Transform;
            gold.name = "Gold_" + i;
            golds[i] = gold;
            ResetPosition(i);
        }
        GetComponent<Gold>().enabled = true;

    }

    public void ResetPosition(int name)
    {
        shinies[name] = new Vector3(random.Next(-600, 600) / 100f, random.Next(700, 1900) / 100f, random.Next(-900, 300) / 100f);
        golds[name].transform.position = new Vector3(shinies[name].x, shinies[name].y, -1f);
        rnd = random.Next(50, 200) / 100f;
        golds[name].transform.localScale = new Vector3(rnd,rnd, 0);
    }

	void Start () {
	}
	
	void Update () {
        for (int i = 0; i < 15; i++)
        {
            if (golds[i].transform.position.y > -4)
            {
                golds[i].rigidbody.MovePosition(golds[i].transform.position + (Vector3.down * Time.deltaTime * ((10 - shinies[i].z) / 10)));
            }
            else
            {
                ResetPosition(i);
            }
        }
	
	}
}
