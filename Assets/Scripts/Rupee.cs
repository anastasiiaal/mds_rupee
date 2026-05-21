using System;
using UnityEngine;

public class Rupee : MonoBehaviour
{
    [SerializeField] private AudioClip pickupSound;
    public event Action<Rupee> OnCollected;
    
    private void OnTriggerEnter2D(Collider2D other)
    {   
        if (!other.CompareTag("Player")) return;
        
        // Debug.Log($"Rupee collected at {transform.position}");
        PlayPickupSound();
        OnCollected?.Invoke(this);
        Destroy(gameObject);
    }

    private void PlayPickupSound()
    {
        var audioGo = new GameObject("PickupSfx");
        audioGo.transform.position = transform.position;
        var source = audioGo.AddComponent<AudioSource>();
        source.clip = pickupSound;
        source.spatialBlend = 0f;
        source.Play();
        Destroy(audioGo, source.clip.length);
    }
}
