using System;
using System.Collections.Generic;
using System.Text;

namespace implementList
{
    public class CoolList<T>
    {
        private T[] array;

        private int counter = 0;

        public CoolList(int arrayLength = 4)
        {
            array = new T[arrayLength];
        }

        public T this[int i]
        {
            get
            {
                return array[i];
            }
            set
            {
                array[i] = value;
            }
        }

        public int Count { get { return counter; } }

        public int InturnalArrayCount { get { return array.Length; } }

        private T[] DobuleArray(T[] array)
        {
            T[] newArray = new T[array.Length * 2];

            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i];
            }

            return newArray;
        }

        public void add(T element)
        {
            if (counter == array.Length)
            {
                array = DobuleArray(array);
            }

            array[counter] = element;
            counter++;
        }

        public void IncertElement(int index, T element)
        {

            if (counter == array.Length)
            {
                array = DobuleArray(array);
            }

            T[] newArray = new T[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                if (i < index)
                {
                    newArray[i] = array[i];
                }
                else if (i == index)
                {
                    newArray[i] = element;
                }
                else
                {
                    newArray[i] = array[i - 1];
                }
            }

            array = newArray;
        }

        public T ContainsElement(T element)
        {
            bool isEqual = false;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Equals(element))
                {
                    isEqual = true;
                }
            }

            if (!isEqual)
            {
                throw new Exception("Element dont exist!");
            }
            return element;
        }

        public T IndexElement(int index)
        {
            T element = default;

            for (int i = 0; i < array.Length; i++)
            {
                if (i == index)
                {
                    element = array[i];
                }
            }

            return element;
        }

        public void Remove()
        {
            array[counter - 1] = default;
        }

        public void RemoveAtt(int index)
        {
            T[] newArray = new T[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                if (i < index)
                {
                    newArray[i] = array[i];
                }                
                else
                {
                    newArray[i - 1] = array[i];
                }
            }

            array = newArray;
        }

        public T[] toArray()
        {
            return array;
        }
    }
}
