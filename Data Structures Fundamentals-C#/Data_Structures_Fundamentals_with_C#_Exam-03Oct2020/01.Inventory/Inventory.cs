namespace _01.Inventory
{
    using _01.Inventory.Interfaces;
    using _01.Inventory.Models;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Inventory : IHolder
    {
        private List<IWeapon> weaponsList = new List<IWeapon>();

        private Dictionary<int, IWeapon> weaponsDictionary = new Dictionary<int, IWeapon>();

        public int Capacity => weaponsList.Count;

        public void Add(IWeapon weapon)
        {
            weaponsList.Add(weapon);
            weaponsDictionary.Add(weapon.Id, weapon);
        }

        public IWeapon GetById(int id)
        {
            if (!weaponsDictionary.ContainsKey(id))
            {
                return null;
            }

            return weaponsDictionary[id];
        }

        public bool Contains(IWeapon weapon)
        {
            return weaponsDictionary.ContainsKey(weapon.Id);
        }

       
        public int Refill(IWeapon weapon, int ammunition)
        {
            CheckForValidId(weapon.Id);

            var currWeapon = weaponsDictionary[weapon.Id];

            currWeapon.Ammunition += ammunition;

            if (currWeapon.Ammunition > currWeapon.MaxCapacity)
            {
                currWeapon.Ammunition = currWeapon.MaxCapacity;
            }

            return currWeapon.Ammunition;
        }

        public bool Fire(IWeapon weapon, int ammunition)
        {
            CheckForValidId(weapon.Id);

            var currWeapon = weaponsDictionary[weapon.Id];

            if (currWeapon.Ammunition >= ammunition)
            {
                currWeapon.Ammunition -= ammunition;
                return true;
            }

            return false;
        }

        public IWeapon RemoveById(int id)
        {
            CheckForValidId(id);

            var removedWeapon = weaponsDictionary[id];
            weaponsDictionary.Remove(id);

            for (int i = 0; i < weaponsList.Count; i++)
            {
                if (id == weaponsList[i].Id)
                {
                    weaponsList.Remove(weaponsList[i]);
                    break;
                }
            }

            return removedWeapon;
        }

        public void Clear()
        {
            weaponsDictionary = new Dictionary<int, IWeapon>();
            weaponsList = new List<IWeapon>();
        }

        public void EmptyArsenal(Category category)
        {
            for (int i = 0; i < weaponsList.Count; i++)
            {
                var weapon = weaponsList[i];

                if (weapon.Category == category)
                {
                    weapon.Ammunition = 0;
                }
            }
        }

        public List<IWeapon> RetrieveAll()
        {
            return new List<IWeapon>(weaponsList);
        }

        public void Swap(IWeapon firstWeapon, IWeapon secondWeapon)
        {
            CheckForValidId(firstWeapon.Id);
            CheckForValidId(secondWeapon.Id);

            var firstWeponIndex = weaponsList.IndexOf(firstWeapon);
            var secondWeponIndex = weaponsList.IndexOf(secondWeapon);

            if (firstWeapon.Category.Equals(secondWeapon.Category))
            {
                weaponsList[firstWeponIndex] = secondWeapon;
                weaponsList[secondWeponIndex] = firstWeapon;
            }
        }

        public List<IWeapon> RetriveInRange(Category lower, Category upper)
        {
            var result = new List<IWeapon>();

            for (int i = 0; i < weaponsList.Count; i++)
            {
                var weapon = weaponsList[i];

                if ((int)weapon.Category >= (int)lower && (int)weapon.Category <= (int)upper)
                {
                    result.Add(weapon);
                }
            }

            return result;
        }

        public int RemoveHeavy()
        {
            var count = 0;

            for (int i = 0; i < weaponsList.Count; i++)
            {

                var weapon = weaponsList[i];

                if (weapon.Category.Equals(Category.Heavy))
                {
                    count++;
                    weaponsList.Remove(weapon);
                    i--;
                }
            }

            return count;
        }

        public IEnumerator GetEnumerator()
        {
            return weaponsList.GetEnumerator();
        }

        private void CheckForValidId(int id)
        {
            if (!weaponsDictionary.ContainsKey(id))
            {
                throw new InvalidOperationException("Weapon does not exist in inventory!");
            }
        }
    }
}
