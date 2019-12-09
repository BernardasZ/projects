using DataBaseModel;
using NoteSaver.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteSaver.Services.Concrete
{
    public class ConstructTreeList : IConstructTreeList
    {
        private readonly NoteSaverEntities _context;
        private readonly ILogger _log;
        public ConstructTreeList(NoteSaverEntities noteSaverEntities)
        {
            this._log = Log.ForContext<ConstructTreeList>();
            this._context = noteSaverEntities;
        }

        public List<TreeListModel> Construct()
        {
            var treeList = _context.ParagraphTreeList.Select(x => x).ToList();

            return null;
        }

        public bool SaveTreeList(List<TreeListModel> list)
        {
            try
            {
                //CheckTreeForChanges(list);
            }
            catch (Exception ex)
            {
                _log.Error(ex, "");
                return false;
            }

            return true;
        }
    }
}
