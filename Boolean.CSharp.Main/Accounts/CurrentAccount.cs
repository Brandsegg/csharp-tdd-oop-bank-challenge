using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Accounts
{
    public class CurrentAccount : Account
    {
        public CurrentAccount(int _ID) : base(_ID) { }
        public CurrentAccount(int _ID, branch branch) : base(_ID, branch) { }
    }
}
