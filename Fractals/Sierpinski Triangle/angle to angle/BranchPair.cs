using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace angle_to_angle
{
    class BranchPair
    {
        public Branch Left;
        public Branch Right;

        public BranchPair(Branch l, Branch r)
        {
            Left = l;
            Right = r;
        }
    }
}
