using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT_Lab2
{
    internal sealed class Singleton
    {
        private static StartForm? startForm;
        private Singleton() { }

        public static StartForm StartForm
        {

            get
            {
                if (startForm == null)
                {
                    startForm = new StartForm();
                }
                return startForm;
            }
        }
    }
}
