# NVH's Mesh Bone Rebind

## Script Overview

This script set is to allow rebinding of meshes to other armatures, note it does not and can not make incompatible armatures and meshes work with each other.

The primary use case for this is to allow you to add extra items that are made for a given avatar base to it without having to constraint or stack armatures together.

Note: For it to work the armatures of both the main avatar and the addon (cloths, armor etc.) must sufficiently match one and other, though the addon need not fully have all bones the avatar does.

Note: This does not work for addons which have extra bones (that the base avatar does not have)

## How to install this package

1> In unity open the `Package Manager` window  
2> Click the plus button in the top left of that window and choose the `Add packages from git URL` option  
![image](https://github.com/NovaVoidHowl/Mesh-Bone-Rebind/assets/31048789/66eaec96-322e-46ac-811d-353f8209198c)  
3> Paste in the git url of this repo `https://github.com/NovaVoidHowl/Mesh-Bone-Rebind.git`  
![image](https://github.com/NovaVoidHowl/Mesh-Bone-Rebind/assets/31048789/de07970b-7649-4789-aa7b-fc2a00622551)  
4> Click the add button  

The script should then be ready to use.

## How to use
1> Select the mesh you want to re-bind in the `Hierarchy` and go to the `Inspector` window, then click the `Add Component` button  
2> Select the Mesh Bone Rebind option form the list  
![image](https://github.com/NovaVoidHowl/Mesh-Bone-Rebind/assets/31048789/91a39c53-32d2-4675-b7c1-3cb559183442)  
3> Drag the target armature in to the `New Armature` box and press the Rebind Bones button  
![image](https://github.com/NovaVoidHowl/Mesh-Bone-Rebind/assets/31048789/2ab36a47-8ede-4d87-b71d-fe883f2e2146)  

The mesh should now be bound to the avatar's armature and you should be able to safely dispose of the one that came with the addon.

