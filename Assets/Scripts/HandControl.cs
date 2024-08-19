using System.Collections.Generic;
using UnityEngine;

public class HandControl : MonoBehaviour
{
    public List<Transform> fingerBones; // Use a List instead of an array
    public Vector3 grabRotation;        // Rotation to apply when grabbing

    private List<Vector3> originalRotations; // To store the original rotations

    void Start()
    {
        // Initialize the list for original rotations
        originalRotations = new List<Vector3>();

        // Store the original rotations of each bone
        foreach (Transform bone in fingerBones)
        {
            originalRotations.Add(bone.localEulerAngles);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Grab();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Release();
        }
    }

    void Grab()
    {
        // Apply the grab rotation to each finger bone
        foreach (Transform bone in fingerBones)
        {
            bone.localEulerAngles = grabRotation;
        }
    }

    void Release()
    {
        // Restore the original rotations
        for (int i = 0; i < fingerBones.Count; i++)
        {
            fingerBones[i].localEulerAngles = originalRotations[i];
        }
    }
}
