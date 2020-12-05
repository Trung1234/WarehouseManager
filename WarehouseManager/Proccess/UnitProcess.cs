using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManager.Model;
using WarehouseManager.Model.ModelExtended;

namespace WarehouseManager.Proccess
{
    public class UnitProcess
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
            var displayList = DataProvider.Instance.DB.Units.Where(x => x.DisplayName.Equals(displayName));
            if (displayList == null || displayList.Count() != 0)
                return false;

            return true;
        }

        public Unit Add(string displayName)
        {
            Unit newUnit = new Unit() { DisplayName = displayName };
            DataProvider.Instance.DB.Units.Add(newUnit);
            DataProvider.Instance.DB.SaveChanges();
            return newUnit;
        }
        public void Edit(int id, string displayName)
        {
            var unit = DataProvider.Instance.DB.Units.Where(x => x.Id == id).SingleOrDefault();
            unit.DisplayName = displayName;
            DataProvider.Instance.DB.SaveChanges();
        }
    }
}
