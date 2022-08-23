using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour

{
    public AudioClip firearm;
    AudioSource asource;
    int hp = 100;
    Image healthbar_border;


    // Start is called before the first frame update
    void Start()
    {
        asource = GetComponent<AudioSource>();
        healthbar_border = gameObject.Find("healthbar_bg").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            asource.PlayOneShot(firearm);
        }

        healthbar_border.fillAmount = hp / 100;
    }

    void OntriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Zombie"))
        {
            hp -= 20;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Zombie"))
        {
            hp -= 0.01f;
        }
    }
}
