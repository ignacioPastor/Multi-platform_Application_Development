using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_12_2_4
{
    class item
    {
        string aItem;
        int x;
        int y;

        public item()
        {
            
        }
        public item(string aItem, int x, int y)
        {
            this.aItem = aItem;
            this.x = x;
            this.y = y;
        }

        public void setX(int x)
        {
            this.x = x;
        }
        
        public void setY(int y)
        {
            this.y = y;
        }

        public int GetX()
        {
            return x;
        }

        public int GetY()
        {
            return y;
        }

        public void SetAItem(string aItem)
        {
            this.aItem = aItem;
        }

        public string GetAItem()
        {
            return aItem;
        }

        public void Dibujar()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(aItem);
        }
    }
}
