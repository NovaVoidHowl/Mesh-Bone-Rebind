#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ArmatureRebind))]
public class ArmatureRebindEditor : Editor
{
    private void OnEnable()
    {
    }

    public override void OnInspectorGUI()
    {
        GUILayout.Label("Mesh Bone Rebind v0.0.1", EditorStyles.boldLabel);
        renderHorizontalSeparator();

        GUILayout.Space(10);

        ArmatureRebind armatureRebind = (ArmatureRebind)target;
        // Check if there is a SkinnedMeshRenderer component with a valid mesh attached.
        bool hasValidSkinnedMeshRenderer = armatureRebind.GetComponent<SkinnedMeshRenderer>() != null && armatureRebind.GetComponent<SkinnedMeshRenderer>().sharedMesh != null;

        if (hasValidSkinnedMeshRenderer)
        {
            EditorGUILayout.HelpBox("To rebind the mesh of this game object, please drag the new armature into the field below and, after confirming the root bone name matches, press the 'Rebind Bones' Button.", MessageType.Info);
            armatureRebind.newArmature = (Transform)EditorGUILayout.ObjectField("New Armature", armatureRebind.newArmature, typeof(Transform), true);
            armatureRebind.rootBoneName = EditorGUILayout.TextField("Root Bone Name", armatureRebind.rootBoneName);

            if (GUILayout.Button("Rebind Bones"))
            {
                armatureRebind.Reassign();
            }
        }
        else
        {
            EditorGUILayout.HelpBox("SkinnedMeshRenderer with a valid mesh not found on this GameObject.", MessageType.Error);
        }

        // Apply any modified properties.
        serializedObject.ApplyModifiedProperties();
    }
    private void renderHorizontalSeparator()
    {
      GUILayout.Space(4);
      GUILayout.Box("", GUILayout.ExpandWidth(true), GUILayout.Height(2));
      GUILayout.Space(4);
    }
}
#endif
