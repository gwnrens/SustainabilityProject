using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    public GameObject[] weapons;                // The array that holds all the weapons that the player has
    public int startingWeaponIndex = 0;         // The weapon index that the player will start with
    private int weaponIndex;                    // The current index of the active weapon

    void Start()
    {
        // Make sure the starting active weapon is the one selected by the user in startingWeaponIndex
        weaponIndex = startingWeaponIndex;
        SetActiveWeapon(weaponIndex);
    }

    void Update()
    {
        // Allow the user to instantly switch to any weapon
        if (Input.GetKeyDown(KeyCode.Alpha1))
            SetActiveWeapon(0);
        if (Input.GetKeyDown(KeyCode.Alpha2) && weapons.Length > 1)
            SetActiveWeapon(1);
        if (Input.GetKeyDown(KeyCode.Alpha3) && weapons.Length > 2)
            SetActiveWeapon(2);
        if (Input.GetKeyDown(KeyCode.Alpha4) && weapons.Length > 3)
            SetActiveWeapon(3);

        // Allow the user to scroll through the weapons
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
            NextWeapon();
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
            PreviousWeapon();
    }

    public void SetActiveWeapon(int index)
    {
        // Make sure this weapon exists before trying to switch to it
        if (index >= weapons.Length || index < 0)
        {
            Debug.LogWarning("Tried to switch to a weapon that does not exist. Make sure you have all the correct weapons in your weapons array.");
            return;
        }

        // Make sure the weaponIndex references the correct weapon
        weaponIndex = index;

        // Start by deactivating all weapons
        foreach (var weapon in weapons)
        {
            weapon.SetActive(false);
        }

        // Activate the one weapon that we want
        weapons[index].SetActive(true);
    }

    public void NextWeapon()
    {
        weaponIndex = (weaponIndex + 1) % weapons.Length;
        SetActiveWeapon(weaponIndex);
    }

    public void PreviousWeapon()
    {
        weaponIndex--;
        if (weaponIndex < 0)
            weaponIndex = weapons.Length - 1;
        SetActiveWeapon(weaponIndex);
    }
}
