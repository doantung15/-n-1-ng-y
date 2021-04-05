using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn1ngay.DTO
{
    public class Storage
    {

        public Storage(int id, string StorageName, string status) 
        {
            this.ID = id;
            this.StorageName = StorageName;
            this.Status = status;
        }

        public Storage(DataRow row) 
        {
            this.ID = (int)row["id"];
            this.StorageName = row["StorageName"].ToString();
            this.Status = row["status"].ToString();

        }


        private string status;

        private string storageName;

        private int iD;

        public int ID { get => iD; set => iD = value; }
        
        public string Status { get => status; set => status = value; }
        public string StorageName { get => storageName; set => storageName = value; }
    }
}
