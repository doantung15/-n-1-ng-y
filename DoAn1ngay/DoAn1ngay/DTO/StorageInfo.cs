using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn1ngay.DTO
{
    public class StorageInfo
    {

        public StorageInfo(int id,string stackname,string storagename) 
        {
            this.Id = id;
            this.StackName = stackname;
            this.StorageName = storagename;
        }

        public StorageInfo(DataRow row)
        {
            this.Id = (int)row["id"];
            this.StackName = row["StackName"].ToString();
            this.StorageName = row["StorageName"].ToString();
        }


        private string storageName;
        private string stackName;
        private int id;

        public int Id { get => id; set => id = value; }
       
        
        public string StackName { get => stackName; set => stackName = value; }
        public string StorageName { get => storageName; set => storageName = value; }
    }

}
