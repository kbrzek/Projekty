using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication10.model
{
    class Vertex
    {
        public String id;
        public String name;
        public int x;
        public int y;

        public Vertex(String id, String name, int x, int y)
        {
            this.id = id;
            this.name = name;
            this.x = x;
            this.y = y;
        }
    
        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;

            if (obj == null)
                return false;

            Vertex other = (Vertex) obj;

            if (id == null)
            {
                if (other.id != null)
                    return false;
            }
            else if (!id.Equals(other.id))
                return false;
            System.Console.WriteLine("true");
            return true;
        }

        public override int GetHashCode()
        {
            int result = 31;

            result = result * 23 + id.GetHashCode();
          
            return result;
        }

        public override string ToString()
        {
            return id +" "+name+" " + " "+ x +" "+ y;
        }
    }
}
