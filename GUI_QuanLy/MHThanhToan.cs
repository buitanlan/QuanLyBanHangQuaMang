﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_QuanLy;
using DTO_QuanLy;

namespace GUI_QuanLy
{
    public partial class MHThanhToan : Form
    {
        private String selectedYear;
        private const int numberOfYears = 20;
        private bool cashOptionSelected = false;
        public int? maHoaDon;
        public int? maKH;
        public int? maNV;
        public double? tongTien;

        public MHThanhToan()
        {
            InitializeComponent();

            //monthCB.Items.AddRange(new String[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" });
            //monthCB.SelectedIndex = 0;
            setYears();
            setMonth();
        }

        private void setYears()
        {
            int currentYearInt = DateTime.Now.Year;
            for (int i = 0; i <= numberOfYears; i++)
            {
                yearCB.Items.Add((currentYearInt + i).ToString());
            }
            yearCB.SelectedIndex = 0;
            selectedYear = yearCB.Items[0].ToString();
        }

        private void setMonth()
        {
            monthCB.Items.Clear();
            int currentMonth = selectedYear == DateTime.Now.Year.ToString() ? DateTime.Now.Month : 1;
            for (int i = currentMonth; i <= 12; i++)
            {
                monthCB.Items.Add(i.ToString());
            }
            monthCB.SelectedIndex = 0;
        }
        
        private void checkOut()
        {
            //if (!maHoaDon.HasValue || !maKH.HasValue || !maNV.HasValue || !tongTien.HasValue)
            //{
            //    MessageBox.Show("Lỗi!");
            //    return;
            //}
            
            //DTO_ThanhToan thanhToan = new DTO_ThanhToan(maHoaDon.Value, maKH.Value, maNV.Value, 0, tongTien.Value, "");
            DTO_ThanhToan thanhToan = new DTO_ThanhToan(0, 0, 0, 0, 0, "");
            if (cashOptionSelected)
            {
                thanhToan.loaiThanhToan = 0;
                //BUS_ThanhToan.Instance.insertThanhToan(thanhToan);
                MessageBox.Show("Thanh toán thành công!");
                return;
            }
            thanhToan.loaiThanhToan = 1;
            string cardNumber = cardNumberTB.Text;
            string cardholder = cardholderTB.Text;
            string cvc = cvcTB.Text;
            if (cardNumber == "" || cardholder == "" || cvc == "")
            {
                MessageBox.Show("Vui lòng điền đủ thông tin thanh toán");
                return;
            }
            if (cvc.Length > 3)
            {
                MessageBox.Show("Số CVC không hợp lệ!");
                return;
            }
            //BUS_ThanhToan.Instance.insertThanhToan(thanhToan);
            MessageBox.Show("Thanh toán thành công!");
            return;
        }

        private void setPaymentDisplay(bool cashPayment)
        {
            cashOptionSelected = cashPayment;
            paymentInfoGroupBox.Enabled = !cashPayment;
        }

        // Event functions
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            setPaymentDisplay(false);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            setPaymentDisplay(false);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            setPaymentDisplay(false);
        }

        // radioButton4 = cash option
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            setPaymentDisplay(true);
        }

        private void continueShoppingButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkOutButton_Click(object sender, EventArgs e)
        {
            checkOut();
        }

        private void yearCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedYear = yearCB.SelectedItem.ToString();
            setMonth();
        }
    }
}
