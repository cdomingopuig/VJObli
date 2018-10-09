using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

    void OnMouseClick()
    {

    }

    void GoToBedroom1()
    {
        SceneManager.LoadScene("Cuarto1");
    }
    void GoToBedroom2()
    {
        SceneManager.LoadScene("Cuarto2");
    }
    void GoToStore1()
    {
        SceneManager.LoadScene("Jugueteria1");
    }
    void GoToStore2()
    {
        SceneManager.LoadScene("Jugueteria2");
    }
    void GoToSquare1()
    {
        SceneManager.LoadScene("Plaza1");
    }
    void GoToSquare2()
    {
        SceneManager.LoadScene("Plaza2");
    }
    void GoToMap()
    {
        SceneManager.LoadScene("Mapa");
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
            if (hit)
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                    interactable.selected = true;
                if (hit.collider.gameObject.name == "Next")
                {
                    if (SceneManager.GetActiveScene().name == "Cuarto1")
                        GoToBedroom2();
                    else if (SceneManager.GetActiveScene().name == "Cuarto2")
                        GoToStore1();
                    else if (SceneManager.GetActiveScene().name == "Jugueteria1")
                        GoToStore2();
                    else if (SceneManager.GetActiveScene().name == "Jugueteria2")
                        GoToSquare1();
                    else if (SceneManager.GetActiveScene().name == "Plaza1")
                        GoToSquare2();
                }
                if (hit.collider.gameObject.name == "Prev")
                {
                    if (SceneManager.GetActiveScene().name == "Cuarto2")
                        GoToBedroom1();
                    else if (SceneManager.GetActiveScene().name == "Jugueteria1")
                        GoToBedroom2();
                    else if (SceneManager.GetActiveScene().name == "Jugueteria2")
                        GoToStore1();
                    else if (SceneManager.GetActiveScene().name == "Plaza1")
                        GoToStore2();
                    else if (SceneManager.GetActiveScene().name == "Plaza2")
                        GoToSquare1();
                }
                if (hit.collider.gameObject.name == "map icon")
                {
                    GoToMap();
                }
            }

        }
    }
}
