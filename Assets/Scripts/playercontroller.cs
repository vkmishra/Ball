using UnityEngine;
using System.Collections;

public class playercontroller : MonoBehaviour {
	public float speed;
	public GUIText scoreText, finish;
	private int score;
	// Use this for initialization
	void Start () {
		score = 0;
		scoreText.text = "";
		finish.text = "";
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float movehorizontal = Input.GetAxis ("Horizontal");
		float movevertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (movehorizontal, 0, movevertical);
		rigidbody.AddForce (movement * speed * Time.deltaTime);
		scoreText.text = "Score: " + score.ToString ();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "bcollectible") {
						score += 7;
						other.gameObject.SetActive (false);
				} else if (other.tag == "scollectible") {
						score += 4;
						other.gameObject.SetActive (false);
				} else if (other.tag == "door") {
						finish.text="Congrats!! You Win!! Your score: "+score.ToString();
				}
	}
}
