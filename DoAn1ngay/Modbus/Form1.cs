using NModbus;
using NModbus.Serial;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modbus
{
    public partial class Form1 : Form
    {
        
        IModbusMaster master;
        IModbusRtuTransport RTUtransport;
        IModbusSerialMaster serialMaster;

        StringBuilder data = new StringBuilder();
        StringBuilder check = new StringBuilder();
        StringBuilder _check = new StringBuilder();
        Thread thread;
        string Reconnect;
        SerialPort serialPort1 = new SerialPort();
        private bool Isconnected = false;

       

        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            cbx_ID.Items.AddRange(SerialPort.GetPortNames());
            checkopen();
        }

        void checkopen()
        {
            if (cbx_ID.Text=="") 
            {
                txt_Kiemtra.Enabled = false;
                txt_Receive.Enabled = false;
                Txt_SlaveId.Enabled = false;
                txtData.Enabled = false;
                txtAddress.Enabled = false;
                btnDisconnect.Enabled = false;
                btnRefresh.Enabled = false;
                btn_Connect.Enabled = false;
                //btn_Slave.Enabled = false;
                btn_Transmit.Enabled = false;

            }
            else
            {
                btn_Connect.Enabled = true;
                if (Isconnected == true) 
                {
                    txt_Kiemtra.Enabled = true;
                    txt_Receive.Enabled = true;
                    Txt_SlaveId.Enabled = true;
                    txtData.Enabled = true;
                    txtAddress.Enabled = true;
                    btnDisconnect.Enabled = true;
                    btnRefresh.Enabled = true;
                    btn_Connect.Enabled = false;
                    //btn_Slave.Enabled = true;
                    btn_Transmit.Enabled = true;
                }
                else
                {
                    txt_Kiemtra.Enabled = false;
                    txt_Receive.Enabled = false;
                    Txt_SlaveId.Enabled = false;
                    txtData.Enabled = false;
                    txtAddress.Enabled = false;
                    btnDisconnect.Enabled = false;
                    btnRefresh.Enabled = false;
                    btn_Connect.Enabled = true;
                    //btn_Slave.Enabled = false;
                    btn_Transmit.Enabled = false;
                }
            }
        }

        #region old_event
        private void Opencomport()
        {

            serialPort1.PortName = cbx_ID.Text;
            serialPort1.BaudRate = 38400;
            serialPort1.DataBits = 8;
            serialPort1.Parity = Parity.None;
            serialPort1.StopBits = StopBits.One;
            serialPort1.Open();
            serialPort1.ReadTimeout = 50;
            serialPort1.WriteTimeout = 50;

            var factory = new ModbusFactory();
            //RTUtransport = factory.CreateRtuTransport(serialPort1);
            //serialMaster = factory.CreateMaster(RTUtransport);
            master = factory.CreateRtuMaster(serialPort1);
            
        }

        public void new_opencomport(byte i)
        {
            this.Invoke(new Action(() =>
            {
                var watch = new System.Diagnostics.Stopwatch();
                watch.Start();
                try
                {
                    master.WriteSingleCoil(i, 0, true);

                }
                catch (Exception)
                {
                    check.Append(i + "\r\n");
                }

                txt_Kiemtra.Text = check.ToString();
                watch.Stop();

                _check.Append($"Execution Time: " + watch.ElapsedMilliseconds + " ms" + "\r\n");
                txtbtn1.Text = _check.ToString();

            }));
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
                serialPort1.ReadTimeout = 1000;
                serialPort1.WriteTimeout = 1000;

                var factory = new ModbusFactory();
                master = factory.CreateRtuMaster(serialPort1);
            }
            catch
            {
                lblError.Text = "";
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
                txt_Receive.Text = Convert.ToString(data);
            }
            catch
            {
                lblError.Text = "Lỗi rồi, đường truyền có vấn đề";
                Isconnected = false;
            }
        }
        void aa()
        {
            receive(10, 0, 11);
        }
        private void btn_Connect_Click(object sender, EventArgs e)
        {
          
            try
            {
                Opencomport();
                Reconnect = cbx_ID.Text;
                Isconnected = true;
                timer1.Enabled = true;

            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
                Isconnected = false;
            }
            checkopen();
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            Isconnected = false;
            timer1.Stop();
            thread.Abort();

            checkopen();
        }

        private void btn_Transmit_Click(object sender, EventArgs e)
        {
            byte a = Convert.ToByte(Txt_SlaveId.Text);
            ushort addr = Convert.ToUInt16(txtAddress.Text);
            string ox = Convert.ToString(txtData.Text);
            ox = ox.Replace(" ", "");
            string[] mx = ox.Split(';');
            ushort[] bbb = new ushort[mx.Length];
            for (int i = 0; i < mx.Length; i++)
            {
                bbb[i] = Convert.ToUInt16(mx[i]);
            }
            transmit(a, addr, bbb);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            thread = new Thread(aa)
            {
                IsBackground = true
            };
            thread.Start();
            if (Isconnected == false)
            {
                OpencomportWhenDisconnect();

            }
        }
        #endregion

        void checktimeout()
        {            
                Task<ushort[]> t1 = master.ReadHoldingRegistersAsync(Convert.ToByte(Txt_SlaveId.Text), 0, 1);
                //Task<bool[]> t2 = master.ReadCoilsAsync(Convert.ToByte(Txt_SlaveId.Text), 0, 10);
                if (!t1.Wait(5000))
                {
                    txt_Kiemtra.Text= Txt_SlaveId.Text + "Deo ket noi duoc \r\n";
                }
                else
                {
                    txt_Kiemtra.Text= Txt_SlaveId.Text + " ngon \r\n";
                }
            

        }

        void check_task()
        {
            Task t = Task.Run(() =>
            {
                Random rnd = new Random();
                long sum = 0;
                int n = 5000000;
                for (int ctr = 1; ctr <= n; ctr++)
                {
                    int number = rnd.Next(0, 101);
                    sum += number;
                }
                txtbtn1.Text = "Total:  " + sum.ToString() + "\r\n" + "Mean:  " + (sum / n).ToString() + "\r\n" + "N:     " + n.ToString();
            });
            TimeSpan ts = TimeSpan.FromMilliseconds(150);
            if (!t.Wait(ts))
                MessageBox.Show("The timeout interval elapsed.");
        }


        void check_task_Connection_Timeout()
        {

            this.Invoke(new Action(() =>
            {
                Task t = Task.Run(() =>
                {
                    master.ReadHoldingRegisters(Convert.ToByte(Txt_SlaveId.Text), 0, 1);
                });
                TimeSpan ts = TimeSpan.FromMilliseconds(1500);
                if (!t.Wait(ts))
                {
                    txt_Kiemtra.Text = Txt_SlaveId.Text + "Deo ket noi duoc \r\n";                    
                }
                else
                {
                    txt_Kiemtra.Text = Txt_SlaveId.Text + " ngon \r\n";
                }

            }));    
                
                
           
            
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

            checktimeout();

        }


        #region slave
        
        void Opencomport_slave()
        {

            serialPort1.PortName = cbx_ID.Text;
            serialPort1.BaudRate = 9600;
            serialPort1.DataBits = 8;
            serialPort1.Parity = Parity.None;
            serialPort1.StopBits = StopBits.One;
            serialPort1.Open();
            serialPort1.ReadTimeout = 5000;
            serialPort1.WriteTimeout = 5000;

            var factory = new ModbusFactory();
            var slaveNetwork = factory.CreateRtuSlaveNetwork(serialPort1);

            IModbusSlave slave1 = factory.CreateSlave(1);
            IModbusSlave slave2 = factory.CreateSlave(2);
            IModbusSlave slave3 = factory.CreateSlave(3);

            slaveNetwork.AddSlave(slave1);
            slaveNetwork.AddSlave(slave2);
            slaveNetwork.AddSlave(slave3);

            slaveNetwork.ListenAsync().GetAwaiter().GetResult();

            
        }
                

        private void btn_Slave_Click(object sender, EventArgs e)
        {
            
        }
        #endregion

        private void cbx_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkopen();
        }

        private void btnHamThu_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 30; i++)
            {
                int temp = i;
                Thread t = new Thread(() =>
                {
                    new_opencomport(Convert.ToByte(temp));

                });
                t.IsBackground = true;
                t.Start();
            }

            MessageBox.Show("Done");
            //for(int i = 1; i < 30; i++)
            //{
            //    int temp = i;
            //    Thread t = new Thread(() =>
            //    {
            //        DemoThread("Thread" + temp);

            //    });
            //    //t.IsBackground = true;
            //    t.Start();
            //}
        }

        void DemoThread(string threadIndex)
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            for (int i = 0; i < 1; i++)
            {                             
                check.Append( threadIndex + i + "\r\n");
                txtbtn2.Text = check.ToString();
            }
            watch.Stop();
            _check.Append($"Execution Time: " + watch.ElapsedMilliseconds + " ms" + "\r\n");
            txtbtn1.Text = _check.ToString();
        }

       
    }
}
