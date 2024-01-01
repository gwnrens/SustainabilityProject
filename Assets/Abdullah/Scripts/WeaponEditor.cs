using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Weapon))]
public class WeaponEditor : Editor
{
    private bool showAudio = false;

    public override void OnInspectorGUI()
    {
        // Get a reference to the weapon script
        Weapon weapon = (Weapon)target;

        // Weapon type
        weapon.type = (WeaponType)EditorGUILayout.EnumPopup("Weapon Type", weapon.type);

        // Rate Of Fire
        weapon.rateOfFire = EditorGUILayout.FloatField("Rate Of Fire", weapon.rateOfFire);

        // Ammo
        weapon.ammoCapacity = EditorGUILayout.IntField("Ammo Capacity", weapon.ammoCapacity);
        weapon.reloadTime = EditorGUILayout.FloatField("Reload Time", weapon.reloadTime);

        // Projectile (only show if type is Projectile)
        if (weapon.type == WeaponType.Projectile)
        {
            weapon.projectile = (GameObject)EditorGUILayout.ObjectField("Projectile", weapon.projectile, typeof(GameObject), false);
            weapon.projectileSpawnSpot = (Transform)EditorGUILayout.ObjectField("Projectile Spawn Point", weapon.projectileSpawnSpot, typeof(Transform), true);
        }

        // Audio
        showAudio = EditorGUILayout.Foldout(showAudio, "Audio");
        if (showAudio)
        {
            weapon.fireSound = (AudioClip)EditorGUILayout.ObjectField("Fire", weapon.fireSound, typeof(AudioClip), false);
            weapon.reloadSound = (AudioClip)EditorGUILayout.ObjectField("Reload", weapon.reloadSound, typeof(AudioClip), false);
            weapon.dryFireSound = (AudioClip)EditorGUILayout.ObjectField("Out of Ammo", weapon.dryFireSound, typeof(AudioClip), false);
        }

        // This makes the editor GUI re-draw the inspector if values have changed
        if (GUI.changed)
            EditorUtility.SetDirty(target);
    }
}
