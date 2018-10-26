using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _R1_Rekenmachine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool opEnabled = false;
        bool ansEnabled = false;
        bool eurEnabled = false;
        char op = ' ';
        double n1 = 0;
        double n2 = 0;
        double mem = 0;
        double res = 0;


        private void btnGetal(object sender, EventArgs e)
        {
            Button g = (Button)sender;

            ansEnabled = true;
            opEnabled = true;

            if (txtDisplayMain.Text == "0")
            {
                txtDisplayMain.Text = "";
                txtDisplayMain.Text += g.Text;

            }
            else
            {
                txtDisplayMain.Text += g.Text;
            }
        }

        private void btnDecimal_Click(object sender, EventArgs e)
        {
             if (txtDisplayMain.Text.Contains('.') == false)
             {
                  txtDisplayMain.Text += ".";
             }
            
        }

        private void btnMemory(object sender, EventArgs e)
        {
            Button m = (Button)sender;

            switch (m.Text)
            {
                case("MC"):
                    mem = 0;
                    break;

                case("MR"):
                    txtDisplayMain.Text = mem.ToString();
                    break;

                case("MS"):
                    mem = Double.Parse(txtDisplayMain.Text);
                    break;

                case("M+"):
                    mem += Double.Parse(txtDisplayMain.Text);
                    break;

                case ("M-"):
                    mem -= Double.Parse(txtDisplayMain.Text);
                    break;
            }

        }


        private void btnOperator(object sender, EventArgs e)
        {
            Button o = (Button)sender;

            
            


            if (opEnabled == true)
            {
                n1 = Double.Parse(txtDisplayMain.Text);
                txtDisplayMain.Text = "";
                switch (o.Name)
                {
                    case "btnPlus":
                        op = '+';
                        txtDisplayCalc.Text = n1.ToString() + " + ";
                        break;

                    case "btnKeer":
                        op = '*';
                        txtDisplayCalc.Text = n1.ToString() + " * ";
                        break;

                    case "btnMin":
                        op = '-';
                        txtDisplayCalc.Text = n1.ToString() + " - ";
                        break;

                    case "btnDelen":
                        op = '/';
                        txtDisplayCalc.Text = n1.ToString() + " / ";
                        break;

                    case "btnProcent":
                        op = '%';
                        txtDisplayCalc.Text = n1.ToString() + " % ";
                        break;

                    case "btnWortel":
                        op = 'w';
                        txtDisplayCalc.Text = "sqrt(" + n1.ToString() + ")";
                        res = Math.Sqrt(n1);
                        txtDisplayMain.Text = res.ToString();
                        break;

                    case "btnInv":
                        op = 'i';
                        txtDisplayCalc.Text = "1 / " + n1.ToString();
                        res = 1 / n1;
                        txtDisplayMain.Text = res.ToString();
                        break;

                    case "btnKwadraat":
                        op = 'k';
                        txtDisplayCalc.Text = n1.ToString() + "^2"; ;
                        res = Math.Pow(n1, 2);
                        txtDisplayMain.Text = res.ToString();
                        break;
                }
            }
                opEnabled = false;
                
        }

        private void btnIs_Click(object sender, EventArgs e)
        {

            

            if (ansEnabled == true)
            {
                n2 = Double.Parse(txtDisplayMain.Text);
                switch (op)
                {
                    case '+':
                        txtDisplayCalc.Text += (n2 + " = ");
                        res = n1 + n2;

                        break;

                    case '-':
                        txtDisplayCalc.Text += (n2 + " = ");
                        res = n1 - n2;
                        txtDisplayMain.Text = res.ToString();
                        break;

                    case '*':
                        txtDisplayCalc.Text += (n2 + " = ");
                        res = n1 * n2;
                        txtDisplayMain.Text = res.ToString();
                        break;

                    case '/':
                        txtDisplayCalc.Text += (n2 + " = ");
                        res = n1 / n2;
                        txtDisplayMain.Text = res.ToString();
                        break;

                    case '%':
                        txtDisplayCalc.Text += (n2 + " = ");
                        res = (n1 / 100) * n2;
                        txtDisplayMain.Text = res.ToString();
                        break;
                }

                if (eurEnabled == true)
                {
                    double roundres = Math.Round(res, 2);
                    txtDisplayMain.Text = roundres.ToString("0.00");
                }

                else
                {
                    txtDisplayMain.Text = res.ToString();
                }
            }

            ansEnabled = false;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (opEnabled == false && txtDisplayMain.Text.Length > 0)
            {
                txtDisplayMain.Text = txtDisplayMain.Text.Remove(txtDisplayMain.Text.Length - 1);
            }
        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            if (opEnabled == false && ansEnabled == false && txtDisplayMain.Text.Length > 0)
            {
                txtDisplayMain.Text = "0";
            }
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            n1 = 0;
            n2 = 0;
            mem = 0;
            txtDisplayMain.Text = "0";
            txtDisplayCalc.Text = "";

        }

        private void btnEuro_Click(object sender, EventArgs e)
        {
            if (eurEnabled == false)
            {
                eurEnabled = true;
                lblEuroSign.Text = "€";
                lblEuroSign2.Text = "€";
            }
            else
            {
                eurEnabled = false;
                lblEuroSign.Text = " ";
                lblEuroSign2.Text = " ";
            }
        }

    }
}
