using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TriggerChinelo : MonoBehaviour
{
    public Rigidbody2D ChineloVoadorRB;

    // Update is called once per frame
    void Start()
    {
        ChineloVoadorRB = this.GetComponent<Rigidbody2D>();
        ChineloVoadorRB.velocity = new Vector2 (Random.Range(-10, -5), Random.Range(-3, 3));
        ChineloVoadorRB.angularVelocity = (Random.Range(-360, 360));
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.CompareTag("GG") || other.gameObject.CompareTag("Parede"))
        {
            Destroy(this.gameObject);
            StartCoroutine (SeguraChinelo());
            SpawnaChinelos.ChineloTela = false;
        }
    }

    IEnumerator SeguraChinelo ()
    {
        yield return new WaitForSeconds(2);
    }
}
