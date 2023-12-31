﻿#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace uk.novavoidhowl.dev.meshbonerebind
{
  [ExecuteInEditMode]
  public class MeshBoneRebind : MonoBehaviour
  {
    public Transform newArmature;
    public string rootBoneName = "hips";

    void Update() { }

    [ContextMenu("Reassign Bones")]
    public void Reassign()
    {
      if (newArmature == null)
      {
        Debug.Log("No new armature assigned");
        return;
      }

      if (newArmature.Find(rootBoneName) == null)
      {
        Debug.Log("Root bone not found");
        return;
      }

      Debug.Log("Reassigning bones");
      SkinnedMeshRenderer rend = gameObject.GetComponent<SkinnedMeshRenderer>();
      Transform[] bones = rend.bones;

      rend.rootBone = newArmature.Find(rootBoneName);

      Transform[] children = newArmature.GetComponentsInChildren<Transform>();

      for (int i = 0; i < bones.Length; i++)
      {
        for (int a = 0; a < children.Length; a++)
        {
          if (bones[i].name == children[a].name)
          {
            bones[i] = children[a];
            break;
          }
        }
      }
      rend.bones = bones;
    }
  }
}
#endif
