using NoteSaver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteSaver.Helpers
{
    public class ConstructTreeList
    {
        public ConstructTreeList()
        {

        }

        public List<TreeListModel> Construct()
        {
            var treeList = new DataBaseModel.NoteSaverEntities().ParagraphTreeList;

            return null;
        }
    }
}
