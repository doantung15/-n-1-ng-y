
namespace Modbus
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblError = new System.Windows.Forms.Label();
            this.txt_Receive = new System.Windows.Forms.TextBox();
            this.txt_Kiemtra = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtData = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Transmit = new System.Windows.Forms.Button();
            this.Txt_SlaveId = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Slave = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btn_Connect = new System.Windows.Forms.Button();
            this.cbx_ID = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnRefresh = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnHamThu = new System.Windows.Forms.Button();
            this.txtbtn1 = new System.Windows.Forms.TextBox();
            this.txtbtn2 = new System.Windows.Forms.TextBox();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblError);
            this.groupBox3.Controls.Add(this.txt_Receive);
            this.groupBox3.Location = new System.Drawing.Point(394, 189);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(287, 302);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Receive";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.Location = new System.Drawing.Point(18, 227);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 20);
            this.lblError.TabIndex = 1;
            // 
            // txt_Receive
            // 
            this.txt_Receive.Location = new System.Drawing.Point(6, 27);
            this.txt_Receive.Multiline = true;
            this.txt_Receive.Name = "txt_Receive";
            this.txt_Receive.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_Receive.Size = new System.Drawing.Size(275, 220);
            this.txt_Receive.TabIndex = 0;
            // 
            // txt_Kiemtra
            // 
            this.txt_Kiemtra.AllowDrop = true;
            this.txt_Kiemtra.Location = new System.Drawing.Point(394, 475);
            this.txt_Kiemtra.Multiline = true;
            this.txt_Kiemtra.Name = "txt_Kiemtra";
            this.txt_Kiemtra.ReadOnly = true;
            this.txt_Kiemtra.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_Kiemtra.Size = new System.Drawing.Size(275, 129);
            this.txt_Kiemtra.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtData);
            this.groupBox2.Controls.Add(this.txtAddress);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btn_Transmit);
            this.groupBox2.Controls.Add(this.Txt_SlaveId);
            this.groupBox2.Location = new System.Drawing.Point(99, 188);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(276, 304);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Transmit";
            // 
            // txtData
            // 
            this.txtData.AllowDrop = true;
            this.txtData.Location = new System.Drawing.Point(145, 125);
            this.txtData.Multiline = true;
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(86, 22);
            this.txtData.TabIndex = 6;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(145, 86);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(86, 22);
            this.txtAddress.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Dữ liệu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Số thanh ghi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Địa chỉ";
            // 
            // btn_Transmit
            // 
            this.btn_Transmit.Location = new System.Drawing.Point(26, 230);
            this.btn_Transmit.Name = "btn_Transmit";
            this.btn_Transmit.Size = new System.Drawing.Size(86, 38);
            this.btn_Transmit.TabIndex = 1;
            this.btn_Transmit.Text = "OK";
            this.btn_Transmit.UseVisualStyleBackColor = true;
            this.btn_Transmit.Click += new System.EventHandler(this.btn_Transmit_Click);
            // 
            // Txt_SlaveId
            // 
            this.Txt_SlaveId.Location = new System.Drawing.Point(145, 39);
            this.Txt_SlaveId.Multiline = true;
            this.Txt_SlaveId.Name = "Txt_SlaveId";
            this.Txt_SlaveId.Size = new System.Drawing.Size(86, 22);
            this.Txt_SlaveId.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Slave);
            this.groupBox1.Controls.Add(this.btnDisconnect);
            this.groupBox1.Controls.Add(this.btn_Connect);
            this.groupBox1.Controls.Add(this.cbx_ID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(99, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(738, 123);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Coneect";
            // 
            // btn_Slave
            // 
            this.btn_Slave.Location = new System.Drawing.Point(559, 20);
            this.btn_Slave.Name = "btn_Slave";
            this.btn_Slave.Size = new System.Drawing.Size(141, 33);
            this.btn_Slave.TabIndex = 6;
            this.btn_Slave.Text = "COn as slave";
            this.btn_Slave.UseVisualStyleBackColor = true;
            this.btn_Slave.Click += new System.EventHandler(this.btn_Slave_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(390, 72);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(134, 36);
            this.btnDisconnect.TabIndex = 5;
            this.btnDisconnect.Text = "Dis";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btn_Connect
            // 
            this.btn_Connect.Location = new System.Drawing.Point(390, 19);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(134, 35);
            this.btn_Connect.TabIndex = 4;
            this.btn_Connect.Text = "Con";
            this.btn_Connect.UseVisualStyleBackColor = true;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // cbx_ID
            // 
            this.cbx_ID.FormattingEnabled = true;
            this.cbx_ID.Location = new System.Drawing.Point(112, 30);
            this.cbx_ID.Name = "cbx_ID";
            this.cbx_ID.Size = new System.Drawing.Size(165, 21);
            this.cbx_ID.TabIndex = 0;
            this.cbx_ID.SelectedIndexChanged += new System.EventHandler(this.cbx_ID_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID";
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(880, 21);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(230, 110);
            this.btnRefresh.TabIndex = 10;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnHamThu
            // 
            this.btnHamThu.Location = new System.Drawing.Point(1065, 161);
            this.btnHamThu.Name = "btnHamThu";
            this.btnHamThu.Size = new System.Drawing.Size(138, 51);
            this.btnHamThu.TabIndex = 11;
            this.btnHamThu.Text = "Hamthu";
            this.btnHamThu.UseVisualStyleBackColor = true;
            this.btnHamThu.Click += new System.EventHandler(this.btnHamThu_Click);
            // 
            // txtbtn1
            // 
            this.txtbtn1.Location = new System.Drawing.Point(707, 161);
            this.txtbtn1.Multiline = true;
            this.txtbtn1.Name = "txtbtn1";
            this.txtbtn1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtbtn1.Size = new System.Drawing.Size(316, 275);
            this.txtbtn1.TabIndex = 12;
            // 
            // txtbtn2
            // 
            this.txtbtn2.Location = new System.Drawing.Point(709, 448);
            this.txtbtn2.Multiline = true;
            this.txtbtn2.Name = "txtbtn2";
            this.txtbtn2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtbtn2.Size = new System.Drawing.Size(313, 205);
            this.txtbtn2.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1230, 659);
            this.Controls.Add(this.txtbtn2);
            this.Controls.Add(this.txtbtn1);
            this.Controls.Add(this.btnHamThu);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.txt_Kiemtra);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txt_Kiemtra;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.TextBox txt_Receive;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Transmit;
        private System.Windows.Forms.TextBox Txt_SlaveId;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btn_Connect;
        private System.Windows.Forms.ComboBox cbx_ID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btn_Slave;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnHamThu;
        private System.Windows.Forms.TextBox txtbtn1;
        private System.Windows.Forms.TextBox txtbtn2;
    }
}

