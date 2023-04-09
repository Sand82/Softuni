using System.Text;

namespace MyArray
{
    public class MyArray<T>
    {
        private int index;

        private T[] array;

        private T emptyTElement;

        public MyArray(int arrayCount = 4)
        {
            array = new T[arrayCount];
            emptyTElement = array[0];
            index = 0;
        }

        public int Count { get { return index; }  }

        public void Add(T emptyTElement)
        {
            if (index == array.Length)
            {
                Grow();
            }

            array[index] = emptyTElement;
            index++;
        }

        public void Remove()
        {
            if (index > 0)
            {
                array[index - 1] = emptyTElement;                
                index --;                  
            }            
        }

        public bool RemoveAt(int value)
        {
            if (value > index)
            {
                return false;
            }
            
            for (int i = value; i < index - 1; i++)
            {
                array[i] = array[i + 1];
                array[index] = emptyTElement;               
            }

            index--;
            return true;
        }

        public bool Contains(T value)
        {
            if (index <= 0)
            {
                return false;
            }          

           return FindemptyTElement(value);           
        }

        public int IndexOf(T value)
        {
            for (int i = 0; i < index; i++)
            {
                if (array[i].Equals(value))
                {
                    return i;
                }
            }

            return -1;
        }

        public string Print()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < index; i++)
            {
                if (i < index - 1)
                {
                    sb.Append(array[i] + " ");
                }else
                {
                    sb.Append(array[i]);
                }
            }

            return sb.ToString();
        }

        private bool FindemptyTElement(T? value)
        {
            for (int i = 0; i < index; i++)
            {
                if (array[i].Equals(value))
                {
                    return true;
                }
            }

            return false;
        }

        private void Grow()
        {
            T[] newArray = new T[array.Length * 2];

            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i];
            }

            array = newArray;
        }
    }
}
