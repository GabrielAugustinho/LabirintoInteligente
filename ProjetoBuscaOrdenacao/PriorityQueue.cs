using System;
using System.Collections.Generic;

namespace ProjetoBuscaOrdenacao
{
    public class PriorityQueue<T>
    {
        private List<T> elements = new List<T>();

        private readonly Func<T, T, int> _comparer;

        public PriorityQueue(Func<T, T, int> comparer)
        {
            _comparer = comparer;
        }

        public PriorityQueue()
        {
        }

        public int Count => elements.Count;

        public void Enqueue(T item)
        {
            int index = 0;
            for (int i = 0; i < elements.Count; i++)
            {
                if (_comparer(item, elements[i]) < 0)
                {
                    index = i;
                    break;
                }
                index = i + 1;
            }
            elements.Insert(index, item);
        }

        public T Dequeue()
        {
            T item = elements[0];
            elements.RemoveAt(0);
            return item;
        }

        public T Peek()
        {
            return elements[0];
        }

        public bool Contains(T item)
        {
            return elements.Contains(item);
        }
    }

}
