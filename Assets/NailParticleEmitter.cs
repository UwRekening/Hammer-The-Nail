using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NailParticleEmitter : MonoBehaviour, IInteractable {
    private ParticleSystem particle;
    public void OnHit() {
        Debug.Log("Hit");
        EmitParticle();
    }

    public void OnSpawn() {
    }

    public void MoveUp() {
    }

    private void EmitParticle() {
        particle = GetComponent<ParticleSystem>();
        particle.Play();
    }
}
