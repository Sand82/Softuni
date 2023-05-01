using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.DeliveriesManager
{
    public class DeliveriesManager : IDeliveriesManager
    {
        private List<Deliverer> delivererList = new List<Deliverer>();

        private Dictionary<string, Deliverer> delivererDictionary = new Dictionary<string, Deliverer>();

        private List<Package> packagesList = new List<Package>();

        private Dictionary<string, Package> packageDictionary = new Dictionary<string, Package>();

        private Dictionary<string, Package> unasignedPackages = new Dictionary<string, Package>();
        

        public void AddDeliverer(Deliverer deliverer)
        {
            if (!delivererDictionary.ContainsKey(deliverer.Id))
            {
                delivererDictionary.Add(deliverer.Id, deliverer);
                delivererList.Add(deliverer);
            }
        }

        public void AddPackage(Package package)
        {
            if (!packageDictionary.ContainsKey(package.Id))
            {
                packageDictionary.Add(package.Id, package);
                packagesList.Add(package);
                unasignedPackages.Add(package.Id, package);
            }
        }

        public bool Contains(Deliverer deliverer)
        {
            return delivererDictionary.ContainsKey(deliverer.Id);
        }

        public bool Contains(Package package)
        {
            return packageDictionary.ContainsKey(package.Id);
        }

        public IEnumerable<Deliverer> GetDeliverers()
        {
            return delivererList;
        }
        public IEnumerable<Package> GetPackages()
        {
            return packagesList;
        }

        public void AssignPackage(Deliverer deliverer, Package package)
        {
            ChekForDeliverer(deliverer.Id);
            ChekForPackages(package.Id);

            deliverer.Packages.Add(package);
            unasignedPackages.Remove(package.Id);
        }

        public IEnumerable<Package> GetUnassignedPackages()
        {
            return unasignedPackages.Values;
        }

        public IEnumerable<Package> GetPackagesOrderedByWeightThenByReceiver()
        {
            if (packageDictionary.Count == 0)
            {
                return new List<Package>();
            }

            //var result = packageDictionary.Values.OrderByDescending(x=> x.Weight).ThenBy(x=> x.Receiver).ToList();

            return packagesList;
        }

        public IEnumerable<Deliverer> GetDeliverersOrderedByCountOfPackagesThenByName()
        {
            if (delivererDictionary.Count == 0)
            {
                return new List<Deliverer>();
            }

            //var result = delivererDictionary.Values.OrderByDescending(x => x.Packages.Count).ThenBy(x => x.Name).ToList();

            return delivererList;
        } 

        private void ChekForDeliverer(string id)
        {
            if (!delivererDictionary.ContainsKey(id))
            {
                throw new ArgumentException();
            }
        }

        private void ChekForPackages(string id)
        {
            if (!packageDictionary.ContainsKey(id))
            {
                throw new ArgumentException();
            }
        }
    }
}
