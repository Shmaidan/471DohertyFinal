using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UICoolidge : MonoBehaviour
{
    public GameObject ui;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ui.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ui.SetActive(false);
        }
    }
}
