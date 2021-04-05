using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn1ngay.DAO
{
    class KhoHangToByte
    {
        public ushort[] a = new ushort[10];
        

        public void MaHoa(string[] so)
        {
            for(int i=0;i<so.Length;i++)
            {
                switch (so[i])
                {
                    case "01":
                        a[8] |= (1 << 2);
                        break;
                    case "02":
                        a[8] |= (1 << 1);
                        break;
                    case "03":
                        a[8] |= (1 << 0);
                        break;
                    case "04":
                        a[5] |= (1 << 7);
                        break;
                    case "05":
                        a[5] |= (1 << 6);
                        break;
                    case "06":
                        a[5] |= (1 << 5);
                        break;
                    case "07":
                        a[5] |= (1 << 4);
                        break;
                    case "08":
                        a[5] |= (1 << 3);
                        break;
                    case "09":
                        a[5] |= (1 << 2);
                        break;
                    case "10":
                        a[5] |= (1 << 1);
                        break;
                    case "11":
                        a[5] |= (1 << 0);
                        break;
                    case "12":
                        a[4] |= (1 << 3);
                        break;
                    case "13":
                        a[4] |= (1 << 4);
                        break;
                    case "14":
                        a[4] |= (1 << 5);
                        break;
                    case "15":
                        a[8] |= (1 << 3);
                        break;
                    case "16":
                        a[8] |= (1 << 4);
                        break;
                    case "17":
                        a[8] |= (1 << 5);
                        break;
                    case "18":
                        a[8] |= (1 << 6);
                        break;
                    case "19":
                        a[8] |= (1 << 7);
                        break;
                    case "20":
                        a[0] |= (1 << 0);
                        break;
                    case "21":
                        a[0] |= (1 << 1);
                        break;
                    case "22":
                        a[0] |= (1 << 2);
                        break;
                    case "23":
                        a[0] |= (1 << 3);
                        break;
                    case "24":
                        a[0] |= (1 << 4);
                        break;
                    case "25":
                        a[0] |= (1 << 5);
                        break;
                    case "26":
                        a[0] |= (1 << 6);
                        break;
                    case "27":
                        a[0] |= (1 << 7);
                        break;
                    case "28":
                        a[6] |= (1 << 2);
                        break;
                    case "29":
                        a[7] |= (1 << 3);
                        break;
                    case "30":
                        a[7] |= (1 << 4);
                        break;
                    case "31":
                        a[7] |= (1 << 5);
                        break;
                    case "32":
                        a[7] |= (1 << 6);
                        break;
                    case "33":
                        a[1] |= (1 << 4);
                        break;
                    case "34":
                        a[1] |= (1 << 5);
                        break;
                    case "35":
                        a[1] |= (1 << 6);
                        break;
                    case "36":
                        a[9] |= (1 << 0);
                        break;
                    case "37":
                        a[9] |= (1 << 1);
                        break;
                    case "38":
                        a[9] |= (1 << 2);
                        break;
                    case "39":
                        a[9] |= (1 << 3);
                        break;
                    case "40":
                        a[9] |= (1 << 4);
                        break;
                    case "41":
                        a[9] |= (1 << 5);
                        break;
                    case "42":
                        a[9] |= (1 << 6);
                        break;
                    case "43":
                        a[9] |= (1 << 7);
                        break;
                    case "44":
                        a[3] |= (1 << 7);
                        break;
                    case "45":
                        a[6] |= (1 << 0);
                        break;
                    case "46":
                        a[6] |= (1 << 1);
                        break;
                    case "47":
                        a[2] |= (1 << 0);
                        break;
                    case "48":
                        a[2] |= (1 << 1);
                        break;
                }
            }
        }

    }
}
