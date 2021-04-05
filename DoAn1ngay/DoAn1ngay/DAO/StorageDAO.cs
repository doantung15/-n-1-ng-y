using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAn1ngay.DAO;
using DoAn1ngay.DTO;
namespace DoAn1ngay.DAO
{
    public class StorageDAO
    {
        private static StorageDAO instance;

        public static StorageDAO Instance
        {
            get { if (instance == null) instance = new StorageDAO(); return StorageDAO.instance; }
            private set { StorageDAO.instance = value; }
        }

        public static int TableWidth = 90;
        public static int TableHeight = 90;

        private StorageDAO() { }

        public void SwitchTable(int id1, int id2)
        {
            Dataprovider.Instance.ExecuteQuery("USP_SwitchTabel @idTable1 , @idTabel2", new object[] { id1, id2 });
        }

        public List<Storage> LoadTableList()
        {
            List<Storage> StorageList = new List<Storage>();

            DataTable data = Dataprovider.Instance.ExecuteQuery("USP_GetTableList");

            foreach (DataRow item in data.Rows)
            {
                Storage storage = new Storage(item);
                StorageList.Add(storage);
            }

            return StorageList;
        }
    }
}
