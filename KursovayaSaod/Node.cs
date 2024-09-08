using System;
using System.Collections.Generic;
using System.Text;

namespace KursovayaSaod
{
#pragma warning disable CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
    unsafe public class Node
#pragma warning restore CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
    {

        public override bool Equals(object obj)
        {
            var node = (Node)obj;
            if (this.Surname == node.Surname && this.Name == node.Name && this.Patronimyc == node.Patronimyc)
            {
                return true;
            }
            else { return false; }
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronimyc { get; set; }
        public string Group { get; set; }
        public Node Next { get; set; }
    }

}
