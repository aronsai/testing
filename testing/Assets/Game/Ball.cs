using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    float xInput = 0; // höger-vänster rörelse
    float yInput = 0; // upp-ner rörelse
    int moveSpeed = 3; // movespeed, denna vill man egentligen styra utifrån sen

    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
	}

    void Movement () // metoden som flyttar på bollen
    {
        xInput = Input.GetAxis("Horizontal"); // hämtar från InputManager (inbyggt i Unity), dessa är mellan -1 och 1
        yInput = Input.GetAxis("Vertical");

        if (xInput != 0 || yInput != 0)
        {
            Vector3 movement = new Vector3(xInput, yInput, 0); // gör om infon till en vektor
            transform.Translate(movement * moveSpeed * Time.deltaTime); // flyttar bollen i vektorns riktning * hastigheten * deltaTime (deltaTime gör att animationen inte påverkas av processorkraften)
        }
    }
}
