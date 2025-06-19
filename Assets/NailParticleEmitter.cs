using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NailParticleEmitter : MonoBehaviour, IInteractable {
    private ParticleSystem particle;
    private SoundManager soundManager;
    
    public void MoveDown() {
        soundManager = FindObjectOfType<SoundManager>();
        Debug.Log("Hit");
        EmitParticle();
        soundManager.PlaySound(SoundType.NailExplosion);
    }

    public void MoveUp() {
    }

    public void DeleteObject()
    {
        
    }

    private void EmitParticle() {
        particle = GetComponent<ParticleSystem>();
        particle.Play();
    }
}
