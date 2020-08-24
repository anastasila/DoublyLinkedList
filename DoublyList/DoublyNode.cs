using System;

namespace DoublyList
{
    public class DoublyNode
    {
        public DoublyNode(int Value)
        {
            this.Value = Value;
        }

        public int Value { get; set; }
        public DoublyNode Prev { get; set; }
        public DoublyNode Next { get; set; }
    }    

}

