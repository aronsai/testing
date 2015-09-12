using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    float moveSpeed = 1.5f; // movespeed
    GameObject player; // spelaren
    bool busy = false; // om fienden är upptagen med animation etc

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player"); // hitta objektet Player
	}
	
	// Update is called once per frame
	void Update () {
	    if (player)
        {
            MakeDecision();
        }
	}

    void MakeDecision ()
    {
        if (busy) // gör inget om den är upptagen
            return;

        var distance = Vector3.Distance(transform.position, player.transform.position) - 1; // ta reda på avståndet till spelaren
        
        if (distance > 0.1) // om det finns avstånd
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime); // Flytta mot spelaren
        }
        else
        {
            busy = true;  // ställ om till upptagen
            StartCoroutine(Attack());  // starta coroutine Attack()
        }
    }

    IEnumerator Attack() // Detta gör att man kan pausa metoden
    {
        transform.localScale += new Vector3(0.1f, 0.1f, 0); // tillfällig attackanimation
        yield return new WaitForSeconds(1); // vänta 1 sekund (längd på animationen)
        transform.localScale -= new Vector3(0.1f, 0.1f, 0);  // avsluta animation
        busy = false; // börja MakeDecision() igen
    }
}
