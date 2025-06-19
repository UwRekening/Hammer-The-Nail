using System.Collections;
using System.Collections.Generic;
using Axis.Solvers;
using UnityEngine;

public class SetPositionOnStart : MonoBehaviour {
    [SerializeField] private GameObject character;
    [SerializeField] private AxisHubPositionSolver positionSolver;
    void Start() {
        StartCoroutine(wait());
    }

    IEnumerator wait() {
        yield return new WaitForSeconds(0.1f);
        positionSolver = GetComponent<AxisHubPositionSolver>();
        character.transform.rotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);
        positionSolver.hubZeroPosition = new Vector3(8.82999992f, 5.05000019f, -8.02000046f);
    }
}
