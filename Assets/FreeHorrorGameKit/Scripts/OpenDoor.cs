using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{

    public Animator _animator;

    private bool _colidindo;
    private bool _portaAbera = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _colidindo)
        {
            _portaAbera = true;
            this.gameObject.SetActive(false);
            this.gameObject.GetComponent<PlayerBehaviour>().pickUpUI.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider _col)
    {
        if (_col.gameObject.CompareTag("Player"))
        {
            _colidindo = true;
            _col.gameObject.GetComponent<PlayerBehaviour>().pickUpUI.SetActive(true);
        }
    }

    void OnTriggerExit(Collider _col)
    {
        if (_col.gameObject.CompareTag("Player"))
        {
            if (_portaAbera)
            {
                this.gameObject.SetActive(true);
            }

            _colidindo = false;
        }
    }
}