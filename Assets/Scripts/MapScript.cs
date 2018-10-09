using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
            if (hit)
            {
                if (hit.collider.gameObject.name == "Cuarto")
                {
                    SceneManager.LoadScene("Cuarto1");
                }
                if (hit.collider.gameObject.name == "Jugueteria")
                {
                    SceneManager.LoadScene("Jugueteria1");
                }
                if (hit.collider.gameObject.name == "Plaza")
                {
                    SceneManager.LoadScene("Plaza1");
                }
            }
        }
    }
}
