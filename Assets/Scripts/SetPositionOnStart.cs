using System.Collections;
using UnityEngine;
using Axis.Solvers;

/// <summary>
/// Sets a fixed rotation and hub position for a character at the start of the scene.
/// </summary>
public class SetPositionOnStart : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject character;
    [SerializeField] private AxisHubPositionSolver positionSolver;

    [Header("Settings")]
    [SerializeField] private Vector3 hubZeroPosition = new Vector3(8.83f, 5.05f, -8.02f);
    [SerializeField] private Vector3 characterRotation = new Vector3(0f, 90f, 0f);
    [SerializeField] private float delayBeforeApply = 0.1f;

    private void Start()
    {
        StartCoroutine(ApplyPositionAfterDelay());
    }

    private IEnumerator ApplyPositionAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeApply);

        if (positionSolver == null)
            positionSolver = GetComponent<AxisHubPositionSolver>();

        if (character != null)
        {
            character.transform.rotation = Quaternion.Euler(characterRotation);
        }

        if (positionSolver != null)
        {
            positionSolver.hubZeroPosition = hubZeroPosition;
        }
    }
}