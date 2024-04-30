using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerViewer : MonoBehaviour
{
    public AudioClip SomViewer;

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.CompareTag("BolaPrincipal"))
        {
            SpawnaViewer.ViewerTela = false;
            other.gameObject.GetComponent<ComportBola>().NovoViewer();
            AudioSource.PlayClipAtPoint (SomViewer, transform.position);
            Destroy(this.gameObject);
        }
    }
}
