using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BenDialog : MonoBehaviour {

    public int status = 0;
    private GameObject danBubble;
    private GameObject benBubble;
    private GameObject player;
    private Animator playerAnim;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("player");
        playerAnim = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
            if (hit)
            {
                
                if (hit.collider.gameObject.name == "Ben")
                {
                    if (status == 0)
                    {
                        //playerAnim.SetInteger("state", 4);
                        GameObject.Find("DanBubble").GetComponentInChildren<Text>().text = "Disculpe ¿Puedo ayudarlo?";
                        Button danB = GameObject.FindGameObjectWithTag("DanBubble").GetComponent<Button>();
                        danB.image.enabled = true;
                    }
                }
                if (status == 1)
                {
                    // aparece burbuja ben con texto: ""
                    // desaparece burbuja dan

                    Button danB = GameObject.FindGameObjectWithTag("DanBubble").GetComponent<Button>();
                    danB.image.enabled = false;
                    GameObject.Find("DanBubble").GetComponentInChildren<Text>().text = "";

                    GameObject.Find("BenBubble").GetComponentInChildren<Text>().text = "Tengo un mal day man. No me molestes.";
                    Button benB = GameObject.FindGameObjectWithTag("BenBubble").GetComponent<Button>();

                    benB.image.enabled = true;
                }
                else if (status == 2)
                {
                    // desaparece burbuja ben
                    // mostrar opciones!!!!! 
                    /*
                     1 ¿Disculpe podría escuchar mi demo? 
                     2 ¿Se dio cuenta de que tiene un botón desabrochado?

                     */
                }
                status++;
            }
        } 
    }
}
