using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	//public variables
	public float speed;
	private int count;
	public GUIText countText;

	void Start()
	{
		count = 0;
		SetCountText();
	}
	void SetCountText()
	{
		countText.text = "Count: " + count.ToString ();
	}
	void FixedUpdate()
	{

		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		GetComponent<Rigidbody>().AddForce(movement * speed *Time.deltaTime);

	}

	void OnTriggerEnter(Collider other) 
	{

		if(other.gameObject.tag == "Pickup")
		{
			other.gameObject.SetActive(false);
			count++;
			SetCountText();

		}

		//Destroy(other.gameObject);
	}

}


