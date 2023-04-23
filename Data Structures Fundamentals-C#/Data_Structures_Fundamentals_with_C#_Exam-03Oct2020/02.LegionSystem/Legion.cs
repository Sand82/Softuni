namespace _02.LegionSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using _02.LegionSystem.Interfaces;

    public class Legion : IArmy
    {
        private List<IEnemy> enemiesList = new List<IEnemy>();

        private Dictionary<int, IEnemy> enemiesDictionary = new Dictionary<int, IEnemy>();

        public int Size => enemiesList.Count;

        public void Create(IEnemy enemy)
        {
            if (!enemiesDictionary.ContainsKey(enemy.AttackSpeed))
            {
                enemiesList.Add(enemy);
                enemiesDictionary.Add(enemy.AttackSpeed, enemy);
            }
        }

        public IEnemy GetByAttackSpeed(int speed)
        {
            return enemiesDictionary[speed];
        }

        public bool Contains(IEnemy enemy)
        {
            return enemiesDictionary.ContainsKey(enemy.AttackSpeed);
        }

        public IEnemy GetFastest()
        {
            CheckForEmpty();

            enemiesList.Sort((a, b) => b.AttackSpeed - a.AttackSpeed);

            return enemiesList[0];
        }

        public IEnemy GetSlowest()
        {
            CheckForEmpty();

            enemiesList.Sort((a, b) => a.AttackSpeed - b.AttackSpeed);

            return enemiesList[0];
        }
        public void ShootFastest()
        {
            CheckForEmpty();

            enemiesList.Sort((a, b) => b.AttackSpeed - a.AttackSpeed);

            var enemy = enemiesList[0];

            enemiesList.Remove(enemy);
            enemiesDictionary.Remove(enemy.AttackSpeed);
        }

        public void ShootSlowest()
        {
            CheckForEmpty();

            enemiesList.Sort((a, b) => a.AttackSpeed - b.AttackSpeed);

            var enemy = enemiesList[0];

            enemiesList.Remove(enemy);
            enemiesDictionary.Remove(enemy.AttackSpeed);
        }

        public IEnemy[] GetOrderedByHealth()
        {           
            if (enemiesList.Count == 0)
            {
                return new IEnemy [0];
            }

            enemiesList.Sort((a, b) => b.Health - a.Health);

            return enemiesList.ToArray();
        }

        public List<IEnemy> GetFaster(int speed)
        {
            var result = new List<IEnemy>();

            for (int i = 0; i < enemiesList.Count; i++)
            {
                if (speed < enemiesList[i].AttackSpeed)
                {
                    result.Add(enemiesList[i]);
                }
            }

            return result;
        }
       

        public List<IEnemy> GetSlower(int speed)
        {
            var result = new List<IEnemy>();

            for (int i = 0; i < enemiesList.Count; i++)
            {
                if (speed > enemiesList[i].AttackSpeed)
                {
                    result.Add(enemiesList[i]);
                }
            }

            return result; ;
        }        
       
        private void CheckForEmpty()
        {
            if (Size == 0)
            {
                throw new InvalidOperationException("Legion has no enemies!");
            }
        }

    }
}
