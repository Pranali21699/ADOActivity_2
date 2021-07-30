using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADOActivity_2DAL;

namespace ADOActivity_2UI
{
    class Program
    {
        static void Main(string[] args)
        {
            act2 obj = new act2();
            obj.StudentInfoDetails();

            int result = obj.updateName(1, "Panda", out int rowaf);
            int result1 = obj.InsertName(4, "Ridhhi", "Finzly", "Pune", out int rowaf);
        }
    }
}
