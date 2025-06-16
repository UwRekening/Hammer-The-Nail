using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NailParticleEmitter : MonoBehaviour, IInteractable {
    private ParticleSystem particle;
    public void OnHit() {
        EmitParticle();
    }

    public void MoveUp() {
    }

    private void EmitParticle() {
        particle = FindObjectOfType<ParticleSystem>();
        
        particle.Play();
    }
}
