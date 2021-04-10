using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using NModbus;
using NModbus.Serial;
using DoAn1ngay.DAO;
using System.Threading;
using System.IO;
using DoAn1ngay.DTO;
namespace DoAn1ngay
{
    public partial class MainWindow : Form
    {
        #region register        
       
        IModbusMaster master;
        StringBuilder data = new StringBuilder();      
        
        string Reconnect;

        SerialPort serialPort1 = new SerialPort();

        private bool Isconnected = false;        


        #endregion

        #region Method

        public MainWindow()
        {
            InitializeComponent();            
            LoadStorage();
            Control.CheckForIllegalCrossThreadCalls = false;
            cbx_ID.Items.AddRange(SerialPort.GetPortNames());
        }        

        void LoadStorage() 
        {

            flpStorage.Controls.Clear();
            List<DoAn1ngay.DTO.Storage> storagesList = DoAn1ngay.DAO.StorageDAO.Instance.LoadTableList();
            foreach(Storage item in storagesList)
            {
                Button btn = new Button() { Width = StorageDAO.TableWidth, Height = StorageDAO.TableHeight };
                btn.Text = item.StorageName + Environment.NewLine + item.Status;
                btn.Click += Btn_Click;
                btn.Tag = item;

                switch (item.Status) 
                {
                    case "Đã kết nối":
                        btn.BackColor = Color.LightGreen;
                        break;
                    default:
                        btn.BackColor = Color.IndianRed;
                        break;
                }
                flpStorage.Controls.Add(btn);
            }        
        }

        void ShowStorage(int id)
        {
            progressBar1.Value = 0;
            lsvStorage.Items.Clear();
            List<StorageInfo> storagesInfo = StorageInfoDAO.Instance.GetListStorageInfoById(id);
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 45;
            foreach(StorageInfo item in storagesInfo) 
            {
                ListViewItem lsvItem = new ListViewItem(item.Id.ToString());
                lsvItem.SubItems.Add(item.StackName.ToString());
                lsvItem.SubItems.Add(item.StorageName.ToString());
                lsvStorage.Items.Add(lsvItem);
                progressBar1.Value++;
            }
        }

        public void Check_Connection()
        {            
            for (int i = 1; i <= 30; i++)
            {
                int temp = i;
                Thread t = new Thread(() =>
                 {
                     this.Invoke(new Action(() =>
                     {
                         try
                         {
                             master.WriteSingleCoil(Convert.ToByte(temp), 0, true);

                             string Status = "Đã kết nối";
                             StorageInfoDAO.Instance.Update_Storage(temp, Status);
                            
                         }
                         catch (Exception)
                         {
                             string Status = "Chưa kết nối";
                             StorageInfoDAO.Instance.Update_Storage(temp, Status);
                             
                         }
                     }));
                 });
                t.IsBackground = true;
                t.Start();
                if (i == 30)
                {                    
                    t.Abort();                    
                }     
            }
            
        }

        private void Opencomport()
        {
            
            serialPort1.PortName = cbx_ID.Text;
            serialPort1.BaudRate = 9600;
            serialPort1.DataBits = 8;
            serialPort1.Parity = Parity.None;
            serialPort1.StopBits = StopBits.One;
            serialPort1.Open();
            serialPort1.ReadTimeout = 50;
            serialPort1.WriteTimeout = 50;

            var factory = new ModbusFactory();
            master = factory.CreateRtuMaster(serialPort1);

        }

        private void OpencomportWhenDisconnect()
        {
            try
            {                
                serialPort1.PortName = Reconnect;
                serialPort1.BaudRate = 9600;
                serialPort1.DataBits = 8;
                serialPort1.Parity = Parity.None;
                serialPort1.StopBits = StopBits.One;
                serialPort1.Open();
                serialPort1.ReadTimeout = 50;
                serialPort1.WriteTimeout = 50;

                var factory = new ModbusFactory();
                master = factory.CreateRtuMaster(serialPort1);
            }
            catch
            {
                //lỗi đường truyền
            }
        }

        private void transmit(byte slaveId, ushort startAddress, ushort[] numRegister)
        {
            try
            {
                master.WriteMultipleRegisters(slaveId, startAddress, numRegister);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void receive(byte slaveId, ushort startAddress, ushort numRegisters)
        {
            try
            {
                ushort[] registers = master.ReadHoldingRegisters(slaveId, startAddress, numRegisters);
                data.Clear();
                for (int i = 0; i < numRegisters; i++)
                {
                    data.Append($"Register {startAddress + i}={registers[i]}" + "\r\n");
                }                
                // hiển thị thông tin truyền nhận
            }
            catch
            {
                // lỗi đường truyền
                Isconnected = false;
            }
        }
             
        private void Xuat_Kho()
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    var fileStream = openFileDialog.OpenFile();
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }


                    string _data = Convert.ToString(fileContent);
                    _data = _data.Replace("\r", "");

                    string[] tach = _data.Split('\n');

                    string[] _Data = new string[tach.Length];


                   
                    for (int i = 1; i < tach.Length; i++)
                    {                       
                        _Data[i] = tach[i].Substring(5, 2);
                    }


                    KhoHangToByte khoHangToByte = new KhoHangToByte();
                    khoHangToByte.MaHoa(_Data);
                    transmit(10, 0, khoHangToByte.a);
                    if (MessageBox.Show("Hoàn tất hiển thị?", "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            khoHangToByte.a[i] &= Convert.ToUInt16(0);
                        }
                        transmit(10, 0, khoHangToByte.a);
                        MessageBox.Show("ok");
                    }
                }
            }
        }

        private void Nhap_Kho()
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    var fileStream = openFileDialog.OpenFile();
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }

                    string data = Convert.ToString(fileContent);
                    data = data.Replace("\r", "");
                    string[] _data = data.Split('\n');

                    for (int i = 0; i < _data.Length; i++)
                    {
                        string Station = _data[i].Substring(0, 5);
                        string Barcode = _data[i].Substring(7);
                        string query1 = "UPDATE dbo.THONGTINKHO set StackName=N'" + Barcode.ToString() + "'where idKho = '" + Station.ToString() + "'";
                        Dataprovider.Instance.ExecuteNonQuery(query1);
                    }
                }
            }
        }



        #endregion



        #region events
        private void btn_Connect_Click(object sender, EventArgs e)
        {
            try
            {
                Opencomport();
                Reconnect = cbx_ID.Text;
                Isconnected = true;

                Check_Connection();
                LoadStorage();
                timer1.Enabled = true;

            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
                Isconnected = false;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Thread k = new Thread(() =>
            {
                this.Invoke(new Action(() =>
                {
                    Check_Connection();
                }));
                
            });
            k.IsBackground = true;
            k.Start();
            LoadStorage();
            k.Abort();

            if (Isconnected == false)
            {
                OpencomportWhenDisconnect();
            }
            
        }
        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            timer1.Stop();            
        }
        private void btn_Transmit_Click(object sender, EventArgs e)
        {
            // hàm này dùng để truyền tay dữ liệu

            //byte a = Convert.ToByte(Txt_SlaveId.Text);
            //ushort addr = Convert.ToUInt16(txtAddress.Text);
            //string ox = Convert.ToString(txtData.Text);
            //ox = ox.Replace(" ", "");
            //string[] mx = ox.Split(';');
            //ushort[] bbb = new ushort[mx.Length];
            //for (int i = 0; i < mx.Length; i++)
            //{
            //    bbb[i] = Convert.ToUInt16(mx[i]);
            //}
            //transmit(a, addr, bbb);
        }
        private void btnXuatkho_Click(object sender, EventArgs e)
        {
            Xuat_Kho();
        }

        private void btnNhapkho_Click(object sender, EventArgs e)
        {
            Nhap_Kho();
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            int StorageID = ((sender as Button).Tag as Storage).ID;
            lsvStorage.Tag = (sender as Button).Tag;
            ShowStorage(StorageID);
        }

        #endregion


    }
}
