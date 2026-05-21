using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Rupee : MonoBehaviour
{
    // [SerializeField] private AudioClip pickupSound;
    public event Action<Rupee> OnCollected;
    
    private RupeeData _data;
    private SpriteRenderer _spriteRenderer;
    
    public RupeeData Data => _data;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Init(RupeeData data)
    {
        _data = data;
        _spriteRenderer.color = _data.color;
    }
    
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
        source.clip = _data.pickupSound;
        source.spatialBlend = 0f;
        source.Play();
        Destroy(audioGo, _data.pickupSound.length);
    }
}
