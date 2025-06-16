using System;
using UnityEngine;

public class Nail : MonoBehaviour, IInteractable {
    private float moveStep = 0.2f;

    private Rigidbody rb;
    private PrefabsSpawner prefabSpawner;
    private SoundManager soundManager;

    public float lifeTime = 60f;

    private void Start() {
        rb = GetComponent<Rigidbody>();
        prefabSpawner = FindObjectOfType<PrefabsSpawner>();
        soundManager = FindObjectOfType<SoundManager>();
    }

    public void OnHit() {
        soundManager.PlaySound(SoundType.NailHit);
        
        Vector3 down = Vector3.down * moveStep;
        Vector3 target = rb.position + down;
        
        rb.MovePosition(target);
    }

    private void Update() {
        if (lifeTime < 0) {
            Destroy(gameObject);
            prefabSpawner.SpawnRandomAmount(1);
        }
        else {
            lifeTime -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Plank")) {
            BoxCollider boxCollider = GetComponent<BoxCollider>();
            boxCollider.enabled = false;
            prefabSpawner.SpawnRandomAmount(1);
        }
    }
}
