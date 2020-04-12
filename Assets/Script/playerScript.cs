using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerScript : MonoBehaviour {
	public GameObject particle;

	public Text txtScore;
	int score = 0;
	private Animator player;

	public float speed = 5f;
	public float jumpHeight = 5f;
	// Start is called before the first frame update
	void Start () {
		txtScore = GameObject.Find ("txtScore").GetComponent<Text> ();
		player = GetComponent<Animator> ();
	}

	//Va chạm ăn điểm
	void OnCollisionEnter2D (Collision2D other) {
		if (other.gameObject.tag == "Coin") {
			score += 1;
			txtScore.text = "Score: " + score.ToString ();
			Destroy (other.gameObject);
			//tao hieu ung
			GameObject g1 = Instantiate (particle);

			//khoi tao particle
			Destroy (g1, 3);
			//tu huy sau 3s
		}
		//va chạm vào CNV sẽ bị trừ điểm
		if (other.gameObject.tag == "CNV") {
			score -= 1;
			txtScore.text = "Score: " + score.ToString ();
			Destroy (other.gameObject);
		}
		if (score < 0) {
			Application.LoadLevel ("Main");
		}
		// nếu va chạm vào tag có tên là "level2" thì sẽ chuyển sang level 2 
		if (other.gameObject.tag == "Level2") {
			Application.LoadLevel ("Level2");
		}

	}

	// Update is called once per frame
	void Update () {
		//nhan vật quay qua phải khi nhấn phải
		if (Input.GetKey (KeyCode.RightArrow)) {
			player.SetBool ("Run", true); //doi trang thai
			player.SetBool ("Idle", false);
			//di chuyen
			gameObject.transform.Translate (Vector3.right * speed * Time.deltaTime);
			if (gameObject.transform.localScale.x < 0) {
				gameObject.transform.localScale =
					new Vector3 (gameObject.transform.localScale.x * -1,
						gameObject.transform.localScale.y,
						gameObject.transform.localScale.z
					);
			}
		}
		// nhân vật quay qua trái khi nhấn trái 
		else if (Input.GetKey (KeyCode.LeftArrow)) {
			player.SetBool ("Run", true);
			player.SetBool ("Idle", false);
			gameObject.transform.Translate (Vector3.left * speed * Time.deltaTime);
			if (gameObject.transform.localScale.x > 0) {
				gameObject.transform.localScale =
					new Vector3 (gameObject.transform.localScale.x * -1,
						gameObject.transform.localScale.y,
						gameObject.transform.localScale.z
					);
			}
			//nhân vật sẽ di chuyển lên
		} else if (Input.GetKey (KeyCode.UpArrow)) {
			player.SetBool ("Run", false);
			player.SetBool ("Idle", true);
			gameObject.GetComponent<Rigidbody2D> ().velocity =
				new Vector2 (gameObject.GetComponent<Rigidbody2D> ().velocity.x, jumpHeight);
		} else {
			player.SetBool ("Run", false);
			player.SetBool ("Idle", true);
		}
	}
}