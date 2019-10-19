using DataModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DapperAdapter
{
    public interface IDapperService
    {
        void Update<T, U>(string procedureName, U param) where T : class;
        IEnumerable<T> SelectList<T, U>(string procedureName, U regPozId) where T : class;
        void UpdateList<T>(List<T> listEntities) where T : class;
    }
}
