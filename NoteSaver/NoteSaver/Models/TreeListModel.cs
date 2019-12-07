using DataBaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteSaver.Models
{
    public class TreeListModel : ParagraphTreeList
    {
        public virtual List<TreeListModel> TreeList { get; set; }
    }
}
