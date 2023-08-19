#if UNITY_EDITOR
using System.IO;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;
using uk.novavoidhowl.dev.meshbonerebind;

namespace uk.novavoidhowl.dev.meshbonerebind
{
  [CustomEditor(typeof(MeshBoneRebind))]
  public class MeshBoneRebindEditor : Editor
  {
    private string GetPackageVersion()
    {
      string packagePath = "Packages/uk.novavoidhowl.dev.meshbonerebind/package.json";
      string packageJson = File.ReadAllText(packagePath);
      Match match = Regex.Match(packageJson, @"""version""\s*:\s*""([^""]+)""");
      if (match.Success)
      {
        return match.Groups[1].Value;
      }
      return "Unknown";
    }

    private void OnEnable() { }

    public override void OnInspectorGUI()
    {
      GUILayout.Label("Mesh Bone Rebind v" + GetPackageVersion(), EditorStyles.boldLabel);
      renderHorizontalSeparator();

      GUILayout.Space(10);

      MeshBoneRebind MeshBoneRebind = (MeshBoneRebind)target;
      // Check if there is a SkinnedMeshRenderer component with a valid mesh attached.
      bool hasValidSkinnedMeshRenderer =
        MeshBoneRebind.GetComponent<SkinnedMeshRenderer>() != null
        && MeshBoneRebind.GetComponent<SkinnedMeshRenderer>().sharedMesh != null;

      if (hasValidSkinnedMeshRenderer)
      {
        EditorGUILayout.HelpBox(
          "To rebind the mesh of this game object, please drag the new armature into the field below and, after confirming the root bone name matches, press the 'Rebind Bones' Button.",
          MessageType.Info
        );
        MeshBoneRebind.newArmature = (Transform)
          EditorGUILayout.ObjectField("New Armature", MeshBoneRebind.newArmature, typeof(Transform), true);
        MeshBoneRebind.rootBoneName = EditorGUILayout.TextField("Root Bone Name", MeshBoneRebind.rootBoneName);

        if (GUILayout.Button("Rebind Bones"))
        {
          MeshBoneRebind.Reassign();
        }
      }
      else
      {
        EditorGUILayout.HelpBox(
          "SkinnedMeshRenderer with a valid mesh not found on this GameObject.",
          MessageType.Error
        );
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
}
#endif
