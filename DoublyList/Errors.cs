using System;
using System.Collections.Generic;
using System.Text;

namespace DoublyList
{
    public class Errors
    {
        public static void IndexIsIncorrect()
        {
            throw new Exception("Некорректный индекс.");
        }

        public static void NullHead()
        {
            throw new Exception("Пустой лист.");
        }
    }
}
