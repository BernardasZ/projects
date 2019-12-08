using NoteSaver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteSaver.Services
{
    public interface IConstructTreeList
    {
        List<TreeListModel> Construct();
    }
}
