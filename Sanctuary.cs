using UnityEngine;

public class Sanctuary : MonoBehaviour
{
    [SerializeField] private GameObject activatedButton;
    [SerializeField] private ParticleSystem particles;
    void OnTriggerEnter2D(Collider2D other)
    {
        if( other.gameObject.CompareTag("Player") )
        {
            if( activatedButton != null )
            {
                activatedButton.SetActive(true);
            }
            particles.Play();
        }
    }
}
