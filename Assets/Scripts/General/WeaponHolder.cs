using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace game
{
    public class WeaponHolder : MonoBehaviour
    {
        public Transform parentOverride;
        public WeaponItem currentWeapon;

        public bool isLeftHandSlot;
        public bool isRightHandSlot;

        public GameObject currentWeaponModel;

        public void UnloadWeapon()
        {
            if (currentWeaponModel != null)
            {
                currentWeaponModel.SetActive(false);
            }
        }

        public void UnloadAndDestroyWeapon()
        {
            if (currentWeaponModel != null)
            {
                Destroy(currentWeaponModel);
            }
        }

        public void LoadWeaponModel(WeaponItem weaponItem)
        {
            UnloadAndDestroyWeapon();

            if (weaponItem == null)
            {
                UnloadWeapon();
                return;
            }

            GameObject model = Instantiate(weaponItem.modelPrefab) as GameObject;
            if (model != null)
            {
                if (parentOverride != null)
                {
                    model.transform.parent = parentOverride;
                } else
                {
                    model.transform.parent = transform;
                }

                model.transform.localPosition = Vector3.zero;
                model.transform.localRotation = Quaternion.identity;
                
            }

            currentWeaponModel = model;
        }
        public void HideWeapon()
        {
            Renderer renderer = GetComponentInChildren<MeshRenderer>();
            renderer.enabled = false;
        }

        public void ShowWeapon()
        {
            Renderer renderer = GetComponentInChildren<MeshRenderer>();
            renderer.enabled = true;
        }
    }


}
