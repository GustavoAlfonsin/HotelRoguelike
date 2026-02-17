using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponManager : MonoBehaviour
{
    public List<Weapon> weapons = new List<Weapon>();
    private int currentWeaponIndex = 0;

    private PlayerInput _playerInputs;
    void Start()
    {
        _playerInputs = GetComponent<PlayerInput>();
        _playerInputs.actions["SelectWeapon1"].performed += ctx => selectWeapon(0);
        _playerInputs.actions["SelectWeapon2"].performed += ctx => selectWeapon(1);
        _playerInputs.actions["SelectWeapon3"].performed += ctx => selectWeapon(2);
        _playerInputs.actions["SelectWeapon4"].performed += ctx => selectWeapon(3);
        foreach (Weapon weapon in weapons)
            weapon.Unequip();

        if (weapons.Count > 0)
            weapons[0].Equip();
    }

    // Update is called once per frame
    void Update()
    {
        // Disparar / usar arma
        if (_playerInputs.actions["Atacar"].IsPressed() && weapons.Count > 0)
        {
            weapons[currentWeaponIndex].Shoot();
        }
    }
    public void addWeapon()
    {
        //Agrega el arma nueva encontrada
    }

    private void selectWeapon(int index)
    {
        if (index < 0 || index >= weapons.Count)
            return;
        if (!weapons[index].isActive())
            return;
        weapons[currentWeaponIndex].Unequip();
        currentWeaponIndex = index;
        weapons[currentWeaponIndex].Equip();
    }
}
