using DoAn1ngay.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn1ngay.DAO
{
    public class StorageInfoDAO
    {
        private static StorageInfoDAO instance;

        public static StorageInfoDAO Instance
        {
            get { if (instance == null) instance = new StorageInfoDAO(); return StorageInfoDAO.instance; }
            private set { StorageInfoDAO.instance = value; }
        }

        private StorageInfoDAO() { }

        public List<StorageInfo> GetListStorageInfoById(int id)
        {
            List<StorageInfo> listStorageInfo = new List<StorageInfo>();

            string query = "SELECT tt.id,tt.StackName,t.StorageName FROM dbo.TENKHO AS t,dbo.THONGTINKHO AS tt WHERE tt.idKho = t.id AND t.id = " + id;
            DataTable data = Dataprovider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                StorageInfo StorageInfo = new StorageInfo(item);
                listStorageInfo.Add(StorageInfo);
            }

            return listStorageInfo;
        }
    }
}
