using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManager.Log;
using WarehouseManager.Model;
using WarehouseManager.Model.ModelExtended;
using WarehouseManager.Utility;

namespace WarehouseManager.Proccess
{
    public class UnitService
    {
        /// <summary>
        /// Condition for AddCommand or Editmand
        /// </summary>
        /// <param name="displayName"></param>
        /// <param name="selectedItem"></param>
        /// <param name="isEdit"></param>
        /// <returns></returns>
        public bool CanAddOrEdit(string displayName, UserModel selectedItem = null, bool isEdit = false)
        {
            
            if (isEdit)
            {
                if (string.IsNullOrEmpty(displayName) || selectedItem == null)
                    return false;
            }
            else
            {
                if (string.IsNullOrEmpty(displayName))
                    return false;
            }
            var displayList = DataProvider.Instance.Context.Units.Where(x => x.DisplayName.Equals(displayName));
            if (displayList == null || displayList.Count() != 0)
                return false;
            return true;
        }

        public Unit Add(string displayName)
        {
            Unit newUnit = new Unit() { DisplayName = displayName };
            DataProvider.Instance.Context.Units.Add(newUnit);
            DataProvider.Instance.Context.Entry(newUnit).State = EntityState.Added;
            DataProvider.Instance.Context.SaveChanges();
            return newUnit;
        }

        /// <summary>
        /// edit unit
        /// </summary>
        /// <param name="id"></param>
        /// <param name="displayName"></param>
        public int Edit(int id, string displayName)
        {
            int result = 0;
            using (var dbContextTransaction = DataProvider.Instance.Context.Database.BeginTransaction())
            {
                try
                {
                    var unit = DataProvider.Instance.Context.Units.FirstOrDefault(x => x.Id == id);
                    unit.DisplayName = displayName;
                    DataProvider.Instance.Context.Entry(unit).State = EntityState.Modified;
                    result = DataProvider.Instance.Context.SaveChanges();
                    dbContextTransaction.Commit();
                }
                catch(Exception ex)
                {
                    dbContextTransaction.Rollback();
                    LoggerManager.LogError(nameof(UnitService), nameof(Edit), ex);
                    result = Constant.ErrorCode;
                }
                return result;
            }     
        }
    }
}
