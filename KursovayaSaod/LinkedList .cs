using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace KursovayaSaod
{
    unsafe public class LinkedList<T> : IEnumerable<Node>  // односвязный список
    {
        private Node head; // головной/первый элемент
        private Node tail; // последний/хвостовой элемент
        private int count;  // количество элементов в списке

        // добавление элемента
        public void Add(Node node)
        {
            if (head == null)
            {
                head = node;
            }
            else
            {
                tail.Next = node;
            }
            tail = node;

            count++;
        }

        // удаление элемента
        public bool RemoveF(Node data)
        {
            Node current = head;
            Node previous = null;

            while (current != null)
            {
                if (current.Equals(data))
                {


                    
                    
                        // если удаляется первый элемент
                        // переустанавливаем значение head
                        head = head.Next;

                        // если после удаления список пуст, сбрасываем tail
                        if (head == null)
                            tail = null;
                    
                    count--;
                    return true;
                }

                previous = current;
                current = current.Next;
            }
            return false;
        }
        public bool Remove(Node data)
        {
            Node current = head;
            Node previous = null;

            while (current != null)
            {
                if (current.Equals(data))
                {


                    // Если узел в середине или в конце
                    if (previous != null)
                    {
                        // убираем узел current, теперь previous ссылается не на current, а на current.Next
                        previous.Next = current.Next;

                        // Если current.Next не установлен, значит узел последний,
                        // изменяем переменную tail
                        if (current.Next == null)
                            tail = previous;
                    }
                    else
                    {
                        // если удаляется первый элемент
                        // переустанавливаем значение head
                        head = head.Next;

                        // если после удаления список пуст, сбрасываем tail
                        if (head == null)
                            tail = null;
                    }
                    count--;
                    return true;
                }

                previous = current;
                current = current.Next;
            }
            return false;
        }
        public bool RemoveFirst(Node data)
        {
            Node current = head;
            Node previous = null;

            while (current != null)
            {
                if (current.Equals(data))
                {


                    // Если узел в середине или в конце
                   
                        // убираем узел current, теперь previous ссылается не на current, а на current.Next
                        previous.Next = current.Next;

                        // Если current.Next не установлен, значит узел последний,
                        // изменяем переменную tail
                        if (current.Next == null)
                            tail = previous;

                        // если после удаления список пуст, сбрасываем tail
                        if (head == null)
                            tail = null;
                    
                    count--;
                    return true;
                }

                previous = current;
                current = current.Next;
            }
            return false;
        }

        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }
        // очистка списка
        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }
        // содержит ли список элемент


        public bool Contains(Node data)
        {
            Node current = head;
            while (current != null)
            {
                if (current.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }


        public string PrintAll(LinkedList<Node> list)
        {

            string textBox = "";
            foreach (var item in list)
            {
                textBox += ($"{item.Surname}  {item.Name}  {item.Patronimyc}  {item.Group}\r\n");
            }
            return textBox;

        }

        public string PrintByGroup(LinkedList<Node> list, string str)
        {
            string textBox = "";
            foreach (var item in list)
            {
                if (str == item.Group)
                {
                    Node eee = item;
                    Node r = eee;
                    Node k = eee;
                    var ad = r.Next?.GetHashCode() ?? 0;
          
                    textBox += ($"{item.Surname}  {item.Name}  {item.Patronimyc}   указатель на адрес след элемента: {ad}   собственный адрес:{k.GetHashCode()} \r\n");
                }
            }
            return textBox;
        }



        // реализация интерфейса IEnumerable
        IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<Node> IEnumerable<Node>.GetEnumerator()
        {
            Node current = head;
            while (current != null)
            {
                yield return current;
                current = current.Next;
            }
        }
    }
}


