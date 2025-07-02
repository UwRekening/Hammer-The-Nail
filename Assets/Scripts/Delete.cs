using UnityEngine;

/// <summary>
/// Verwijdert dit object wanneer het in contact komt met de speler.
/// </summary>
public class Delete : MonoBehaviour
{
    /// <summary>
    /// Wordt aangeroepen wanneer een collider deze trigger binnenkomt (Dit word alleen gecheckt als je gebruik maakt van de AXIS PRO Motion capture suite).
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        // Controleer of het andere object een Player component heeft
        if (other.GetComponent<MoveDown>() != null)
        {
            Destroy(gameObject);
        }
    }
}
