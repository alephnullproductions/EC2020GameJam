using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.ShaderGraph;

public class ConveyorRunner : MonoBehaviour
{
    public Material conveyorMaterial;
    public float conveyorSpeed;
    // Update is called once per frame
    void Update()
    {
        conveyorMaterial.SetFloat("position", conveyorMaterial.GetFloat("position") + 1 * conveyorSpeed * Time.deltaTime);
    }
}
