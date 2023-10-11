using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOrganization
{
    internal abstract class Organization
    {
        private Position root;

        public Organization()
        {
            root = CreateOrganization();
        }

        protected abstract Position CreateOrganization();

        /**
         * hire the given person as an employee in the position that has that title
         * 
         * @param person
         * @param title
         * @return the newly filled position or empty if no position has that title
         */
        public Position? Hire(Name person, string title)
        {
            Position? newPostion = GetPosition(title, root);
            if (newPostion != null)
            {
                newPostion.SetEmployee(new Employee(Counter.NextNumber, person));
            }
            //else
            //{
            //    Console.WriteLine($"{title} Postion is not available for hiring");
            //}
            return null;
        }


        public Position? GetPosition(string title, Position position)
        {
            if (title.Equals(position.GetTitle(), StringComparison.OrdinalIgnoreCase) && !position.IsFilled())
            {
                return position;
            }

            if (position.GetDirectReports().Count > 0)
            {
                foreach (Position p in position.GetDirectReports())
                {
                    Position? np = GetPosition(title, p);
                    if (np != null)
                    {
                        return np;
                    }
                }
            }

            return null;
        }
        override public string ToString()
        {
            return PrintOrganization(root, "");
        }

        private string PrintOrganization(Position pos, string prefix)
        {
            StringBuilder sb = new StringBuilder(prefix + "+-" + pos.ToString() + "\n");
            foreach (Position p in pos.GetDirectReports())
            {
                sb.Append(PrintOrganization(p, prefix + "  "));
            }
            return sb.ToString();
        }

    }
}
