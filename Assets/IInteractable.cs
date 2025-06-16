using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable {
    public void OnHit() { }

    public void OnSpawn() {}
    
    public void MoveUp() { }
}
