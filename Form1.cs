using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.DateTimePicker;
using System.Data.SqlClient;
using System.Runtime.Remoting.Contexts;
using System.Windows.Forms.VisualStyles;

namespace FProject
{
    public partial class Form1 : Form
    {
        public DateTime SetDate { get; set; }
        CompanyModel Ent = new CompanyModel();
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            foreach (Warehouse W in Ent.Warehouses)
            {
                comboBox1.Items.Add(W.W_Id);
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(comboBox1.Text);
            Warehouse WH = Ent.Warehouses.Find(id);
            textBox1.Text = WH.W_Id.ToString();
            textBox2.Text = WH.W_Name;
            textBox3.Text = WH.W_Address;
            textBox4.Text = WH.Resp_Id.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Warehouse W = new Warehouse();
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                Warehouse WH = Ent.Warehouses.Find(int.Parse(textBox1.Text));
                if (WH == null)
                {
                    W.W_Id = int.Parse(textBox1.Text);
                    W.W_Name = textBox2.Text;
                    W.W_Address = textBox3.Text;
                    W.Resp_Id = int.Parse(textBox4.Text);
                    Ent.Warehouses.Add(W);
                    Ent.SaveChanges();
                    comboBox1.Items.Add(textBox1.Text);
                    textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
                }
                else
                {
                    MessageBox.Show("Used ID");
                }
            }
            else
            {
                MessageBox.Show("Must Fill All Data");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                Warehouse W = Ent.Warehouses.Find(int.Parse(textBox1.Text));
                if (W != null)
                {
                    if (textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
                    {
                        W.W_Name = textBox2.Text;
                        W.W_Address = textBox3.Text;
                        W.Resp_Id = int.Parse(textBox4.Text);
                        Ent.SaveChanges();
                        textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Check all data is inserted");
                    }
                }
                else
                {
                    MessageBox.Show("Used ID");
                }
            }
            else
            {
                MessageBox.Show("Enter ID");
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                Warehouse W = Ent.Warehouses.Find(int.Parse(textBox1.Text));
                if (W != null)
                {
                    Ent.Warehouses.Remove(W);
                    Ent.SaveChanges();
                    comboBox1.Items.Remove(textBox1.Text);
                    textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
                }
                else
                {
                    MessageBox.Show("Unavailable Warehouse");
                }
            }
            else
            {
                MessageBox.Show("Enter ID");
            }
        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            foreach (Good G in Ent.Goods)
            {
                comboBox2.Items.Add(G.G_Code);
            }
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(comboBox2.Text);
            Good G = Ent.Goods.Find(id);
            textBox5.Text = G.G_Code.ToString();
            textBox6.Text = G.G_Name;
            textBox40.Text = G.Supp_Id.ToString();
            textBox41.Text = G.Quantity.ToString();
            textBox7.Text = G.G_Unit;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Good G = new Good();
            if (textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox40.Text != "")
            {
                Good GO = Ent.Goods.Find(int.Parse(textBox5.Text));
                if (GO == null)
                {
                    G.G_Code = int.Parse(textBox5.Text);
                    G.G_Name = textBox6.Text;
                    G.Supp_Id = int.Parse(textBox40.Text);
                    G.Quantity= int.Parse(textBox41.Text);
                    G.G_Unit = textBox7.Text;
                    Ent.Goods.Add(G);
                    Ent.SaveChanges();
                    comboBox2.Items.Add(textBox5.Text);
                    textBox5.Text = textBox6.Text = textBox7.Text = textBox40.Text = textBox41.Text = "";
                }
                else
                {
                    MessageBox.Show("Used Code");
                }
            }
            else
            {
                MessageBox.Show("Must Fill All Data");
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox5.Text != "")
            {
                Good G = Ent.Goods.Find(int.Parse(textBox5.Text));
                if (G != null)
                {
                    if (textBox6.Text != null && textBox7.Text != null && textBox40.Text != null)
                    {
                        G.G_Name = textBox6.Text;
                        G.Supp_Id = int.Parse(textBox40.Text);
                        G.Quantity = int.Parse(textBox41.Text);
                        G.G_Unit = textBox7.Text;
                        Ent.SaveChanges();
                        textBox5.Text = textBox6.Text = textBox7.Text = textBox40.Text = textBox41.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Check all data is inserted");
                    }
                }
                else
                {
                    MessageBox.Show("Used Code");
                }
            }
            else
            {
                MessageBox.Show("Enter Goods Code");
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox5.Text != "")
            {
                Good G = Ent.Goods.Find(int.Parse(textBox5.Text));
                if (G != null)
                {
                    Ent.Goods.Remove(G);
                    Ent.SaveChanges();
                    comboBox2.Items.Remove(textBox5.Text);
                    textBox5.Text = textBox6.Text = textBox7.Text = textBox40.Text = textBox41.Text = "";
                }
                else
                {
                    MessageBox.Show("Unavailable Goods");
                }
            }
            else
            {
                MessageBox.Show("Enter Goods Code");
            }
        }
        private void groupBox3_Enter(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            foreach (Supplier S in Ent.Suppliers)
            {
                comboBox3.Items.Add(S.Supp_Id);
            }
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(comboBox3.Text);
            Supplier S = Ent.Suppliers.Find(id);
            textBox9.Text = S.Supp_Id.ToString();
            textBox10.Text = S.Supp_Name;
            textBox11.Text = S.Phone.ToString();
            textBox12.Text = S.Supp_Phone.ToString();
            textBox13.Text = S.Fax.ToString();
            textBox14.Text = S.E_mail;
            textBox15.Text = S.Website;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            Supplier S = new Supplier();
            if (textBox9.Text != "" && textBox10.Text != "" && textBox11.Text != "" && textBox12.Text != "" && textBox13.Text != "" && textBox14.Text != "" && textBox15.Text != "")
            {
                Supplier Supp = Ent.Suppliers.Find(int.Parse(textBox9.Text));
                if (Supp == null)
                {
                    S.Supp_Id = int.Parse(textBox9.Text);
                    S.Supp_Name = textBox10.Text;
                    S.Phone = textBox11.Text;
                    S.Supp_Phone = textBox12.Text;
                    S.Fax = textBox13.Text;
                    S.E_mail = textBox14.Text;
                    S.Website = textBox15.Text;
                    Ent.Suppliers.Add(S);
                    Ent.SaveChanges();
                    comboBox3.Items.Add(textBox9.Text);
                    textBox9.Text = textBox10.Text = textBox11.Text = textBox12.Text = textBox13.Text = textBox14.Text = textBox15.Text = "";
                }
                else
                {
                    MessageBox.Show("Used ID");
                }
            }
            else
            {
                MessageBox.Show("Must Fill All Data");
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox9.Text != "")
            {
                Supplier S = Ent.Suppliers.Find(int.Parse(textBox9.Text));
                if (S != null)
                {
                    if (textBox10.Text != "" && textBox11.Text != "" && textBox12.Text != "" && textBox13.Text != "" && textBox14.Text != "" && textBox15.Text != "")
                    {
                        S.Supp_Name = textBox10.Text;
                        S.Phone = textBox11.Text;
                        S.Supp_Phone = textBox12.Text;
                        S.Fax = textBox13.Text;
                        S.E_mail = textBox14.Text;
                        S.Website = textBox15.Text;
                        Ent.SaveChanges();
                        textBox9.Text = textBox10.Text = textBox11.Text = textBox12.Text = textBox13.Text = textBox14.Text = textBox15.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Check all data is inserted");
                    }
                }
                else
                {
                    MessageBox.Show("Used ID");
                }
            }
            else
            {
                MessageBox.Show("Enter ID");
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox9.Text != "")
            {
                Supplier S = Ent.Suppliers.Find(int.Parse(textBox9.Text));
                if (S != null)
                {
                    Ent.Suppliers.Remove(S);
                    Ent.SaveChanges();
                    comboBox3.Items.Remove(textBox9.Text);
                    textBox9.Text = textBox10.Text = textBox11.Text = textBox12.Text = textBox13.Text = textBox14.Text = textBox15.Text = "";
                }
                else
                {
                    MessageBox.Show("Unavailable Supplier");
                }
            }
            else
            {
                MessageBox.Show("Enter ID");
            }
        }
        private void groupBox4_Enter(object sender, EventArgs e)
        {
            comboBox4.Items.Clear();
            foreach (Client C in Ent.Clients)
            {
                comboBox4.Items.Add(C.Client_Id);
            }
        }
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(comboBox4.Text);
            Client C = Ent.Clients.Find(id);
            textBox16.Text = C.Client_Id.ToString();
            textBox17.Text = C.Client_Name;
            textBox18.Text = C.Phone.ToString();
            textBox19.Text = C.Client_Phone.ToString();
            textBox20.Text = C.Fax.ToString();
            textBox21.Text = C.E_mail;
            textBox22.Text = C.Website;
        }
        private void button10_Click(object sender, EventArgs e)
        {
            Client C = new Client();
            if (textBox16.Text != "" && textBox17.Text != "" && textBox18.Text != "" && textBox19.Text != "" && textBox20.Text != "" && textBox21.Text != "" && textBox22.Text != "")
            {
                Client client = Ent.Clients.Find(int.Parse(textBox16.Text));
                if (client == null)
                {
                    C.Client_Id = int.Parse(textBox16.Text);
                    C.Client_Name = textBox17.Text;
                    C.Phone = textBox18.Text;
                    C.Client_Phone = textBox19.Text;
                    C.Fax = textBox20.Text;
                    C.E_mail = textBox21.Text;
                    C.Website = textBox22.Text;
                    Ent.Clients.Add(C);
                    Ent.SaveChanges();
                    comboBox4.Items.Add(textBox16.Text);
                    textBox16.Text = textBox17.Text = textBox18.Text = textBox19.Text = textBox20.Text = textBox21.Text = textBox22.Text = "";
                }
                else
                {
                    MessageBox.Show("Used ID");
                }
            }
            else
            {
                MessageBox.Show("Must Fill All Data");
            }
        }
        private void button11_Click(object sender, EventArgs e)
        {
            if (textBox16.Text != "")
            {
                Client C = Ent.Clients.Find(int.Parse(textBox16.Text));
                if (C != null)
                {
                    if (textBox16.Text != "" && textBox17.Text != "" && textBox18.Text != "" && textBox19.Text != "" && textBox20.Text != "" && textBox21.Text != "" && textBox22.Text != "")
                    {
                        C.Client_Name = textBox17.Text;
                        C.Phone = textBox18.Text;
                        C.Client_Phone = textBox19.Text;
                        C.Fax = textBox20.Text;
                        C.E_mail = textBox21.Text;
                        C.Website = textBox22.Text;
                        Ent.SaveChanges();
                        textBox16.Text = textBox17.Text = textBox18.Text = textBox19.Text = textBox20.Text = textBox21.Text = textBox22.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Check all data is inserted");
                    }
                }
                else
                {
                    MessageBox.Show("Used ID");
                }
            }
            else
            {
                MessageBox.Show("Enter ID");
            }
        }
        private void button12_Click(object sender, EventArgs e)
        {
            if (textBox16.Text != "")
            {
                Client C = Ent.Clients.Find(int.Parse(textBox16.Text));
                if (C != null)
                {
                    Ent.Clients.Remove(C);
                    Ent.SaveChanges();
                    comboBox4.Items.Remove(textBox16.Text);
                    textBox16.Text = textBox17.Text = textBox18.Text = textBox19.Text = textBox20.Text = textBox21.Text = textBox22.Text = "";
                }
                else
                {
                    MessageBox.Show("Unavailable Client");
                }
            }
            else
            {
                MessageBox.Show("Enter ID");
            }
        }
        private void groupBox5_Enter(object sender, EventArgs e)
        {
            comboBox5.Items.Clear();
            foreach (Import_Permission I in Ent.Import_Permission)
            {
                comboBox5.Items.Add(I.Perm_no);
            }
        }
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(comboBox5.Text);
            Import_Permission I = Ent.Import_Permission.Find(id);
            textBox23.Text = I.Perm_no.ToString();
            textBox24.Text = I.Perm_Date.ToString();
            textBox25.Text = I.W_Id.ToString();
            textBox26.Text = I.Goods_Id.ToString();
            textBox27.Text = I.Q_G.ToString();
            textBox28.Text = I.Supp_Id.ToString();
            textBox29.Text = I.Produc_Date.ToString();
            textBox30.Text = I.Expire_Date.ToString();
        }
        private void button13_Click(object sender, EventArgs e)
        {
            Import_Permission I = new Import_Permission();
            try
            {
                if (textBox23.Text != "" && textBox24.Text != "" && textBox25.Text != "" && textBox26.Text != "" && textBox27.Text != "" && textBox28.Text != "" && textBox29.Text != "" && textBox30.Text != "")
                {
                    Import_Permission import = Ent.Import_Permission.Find(int.Parse(textBox23.Text));
                    if (import == null)
                    {
                        var z = textBox24.Text;
                        var f = textBox29.Text;
                        var n = textBox30.Text;
                        I.Perm_no = int.Parse(textBox23.Text);
                        I.Perm_Date = DateTime.Parse(z);
                        //I.Perm_Date = DateTime.Parse(textBox24.Text);
                        I.W_Id = int.Parse(textBox25.Text);
                        I.Goods_Id = int.Parse(textBox26.Text);
                        I.Q_G = int.Parse(textBox27.Text);
                        I.Supp_Id = int.Parse(textBox28.Text);
                        I.Produc_Date = DateTime.Parse(f);
                        I.Expire_Date = DateTime.Parse(n);
                        //I.Produc_Date = DateTime.Parse(textBox29.Text);
                        //I.Expire_Date= DateTime.Parse(textBox30.Text);
                        Ent.Import_Permission.Add(I);
                        Ent.SaveChanges();
                        comboBox5.Items.Add(textBox23.Text);
                        textBox23.Text = textBox24.Text = textBox25.Text = textBox26.Text = textBox27.Text = textBox28.Text = textBox29.Text = textBox30.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Used Code");
                    }
                }
                else
                {
                    MessageBox.Show("Must Fill All Data");
                }
            }
            catch
            {
                MessageBox.Show("Invalid Date");
            }
        }
        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox23.Text != "")
                {
                    Import_Permission I = Ent.Import_Permission.Find(int.Parse(textBox23.Text));
                    if (I != null)
                    {
                        if (textBox23.Text != "" && textBox24.Text != "" && textBox25.Text != "" && textBox26.Text != "" && textBox27.Text != "" && textBox28.Text != "" && textBox29.Text != "" && textBox30.Text != "")
                        {
                            var z = textBox24.Text;
                            var f = textBox29.Text;
                            var n = textBox30.Text;
                            I.Perm_Date = DateTime.Parse(z);
                            //I.Perm_Date = DateTime.Parse(textBox24.Text);
                            I.W_Id = int.Parse(textBox25.Text);
                            I.Goods_Id = int.Parse(textBox26.Text);
                            I.Q_G = int.Parse(textBox27.Text);
                            I.Supp_Id = int.Parse(textBox28.Text);
                            I.Produc_Date = DateTime.Parse(f);
                            I.Expire_Date = DateTime.Parse(n);
                            //I.Produc_Date = DateTime.Parse(textBox29.Text);
                            //I.Expire_Date = DateTime.Parse(textBox30.Text);
                            Ent.SaveChanges();
                            textBox23.Text = textBox24.Text = textBox25.Text = textBox26.Text = textBox27.Text = textBox28.Text = textBox29.Text = textBox30.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Check all data is inserted");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Enter ID");
                }
            }
            catch
            {
                MessageBox.Show("Invalid Date");
            }
        }
        private void groupBox6_Enter(object sender, EventArgs e)
        {
            comboBox6.Items.Clear();
            foreach (Export_Permission E in Ent.Export_Permission)
            {
                comboBox6.Items.Add(E.Perm_no);
            }
        }
        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(comboBox6.Text);
            Export_Permission E = Ent.Export_Permission.Find(id);
            textBox31.Text = E.Perm_no.ToString();
            textBox32.Text = E.Perm_Date.ToString();
            textBox33.Text = E.W_Id.ToString();
            textBox34.Text = E.Goods_Id.ToString();
            textBox35.Text = E.Q_G.ToString();
            textBox36.Text = E.SuppE_Id.ToString();
            textBox37.Text = E.Client_Id.ToString();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                Export_Permission E = new Export_Permission();
                if (textBox31.Text != "" && textBox32.Text != "" && textBox33.Text != "" && textBox34.Text != "" && textBox35.Text != "" && textBox36.Text != "" && textBox37.Text != "")
                {
                    Export_Permission export = Ent.Export_Permission.Find(int.Parse(textBox31.Text));
                    if (export == null)
                    {
                        E.Perm_no = int.Parse(textBox31.Text);

                        E.Perm_Date = DateTime.Parse(textBox32.Text);
                        E.W_Id = int.Parse(textBox33.Text);
                        E.Goods_Id = int.Parse(textBox34.Text);
                        E.Q_G = int.Parse(textBox35.Text);
                        E.SuppE_Id = int.Parse(textBox36.Text);
                        E.Client_Id = int.Parse(textBox37.Text);
                        Ent.Export_Permission.Add(E);
                        Ent.SaveChanges();
                        comboBox6.Items.Add(textBox31.Text);
                        textBox31.Text = textBox32.Text = textBox33.Text = textBox34.Text = textBox35.Text = textBox36.Text = textBox37.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Used Code");
                    }
                }
                else
                {
                    MessageBox.Show("Must Fill All Data");
                }
            }
            catch
            {
                MessageBox.Show("Invalid Date");
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox31.Text != "")
                {
                    Export_Permission E = Ent.Export_Permission.Find(int.Parse(textBox31.Text));
                    if (E != null)
                    {
                        if (textBox31.Text != "" && textBox32.Text != "" && textBox33.Text != "" && textBox34.Text != "" && textBox35.Text != "" && textBox36.Text != "" && textBox37.Text != "")
                        {
                            E.Perm_Date = DateTime.Parse(textBox32.Text);
                            E.W_Id = int.Parse(textBox33.Text);
                            E.Goods_Id = int.Parse(textBox34.Text);
                            E.Q_G = int.Parse(textBox35.Text);
                            E.SuppE_Id = int.Parse(textBox36.Text);
                            E.Client_Id = int.Parse(textBox37.Text);
                            Ent.SaveChanges();
                            textBox31.Text = textBox32.Text = textBox33.Text = textBox34.Text = textBox35.Text = textBox36.Text = textBox37.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Check all data is inserted");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Used Code");
                    }
                }
                else
                {
                    MessageBox.Show("Enter ID");
                }
            }
            catch
            {
                MessageBox.Show("Invalid Date");
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (Import_Permission i in Ent.Import_Permission)
            {
                listBox1.Items.Add(i.W_Id + "\t" + i.Goods_Id + "\t" + i.Q_G + "\t" + i.Supp_Id + "\t" + i.Produc_Date + "\t" + i.Expire_Date);
            }
        }
        private void button18_Click(object sender, EventArgs e)
        {
            if (textBox38.Text != "" && textBox39.Text != "")
            {
                int id = int.Parse(textBox38.Text);
                int id1 = int.Parse(textBox39.Text);
                Warehouse w = Ent.Warehouses.Find(id);
                Warehouse w1 = Ent.Warehouses.Find(id1);
                Import_Permission imp = new Import_Permission();
                if (textBox44.Text != null)
                {
                    if (w != null)
                    {
                        if (w1 != null)
                        {
                            var query = from im in Ent.Import_Permission where im.W_Id == w.W_Id select im;
                            var query1 = from im in Ent.Import_Permission where im.W_Id == w1.W_Id select im;
                            listBox1.Items.Clear();
                            foreach (var item in query)
                            {
                                item.Q_G -= int.Parse(textBox44.Text);
                            }
                            foreach (var item1 in query1)
                            {
                                item1.Q_G += int.Parse(textBox44.Text);
                            }
                            foreach (var item in query)
                            {
                                foreach (var item1 in query1)
                                {
                                    listBox1.Items.Add(w.W_Id + "\t" + w1.W_Id + "\t" + item.Goods_Id + "\t" + item1.Goods_Id + "\t" + item.Q_G + "\t" + item1.Q_G);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("The To ID is not available");
                        }
                    }
                    else
                    {
                        MessageBox.Show("The From ID is not available");
                    }
                }
                else
                {
                    MessageBox.Show("please Enter The quantity");
                }
            }
            else
            {
                MessageBox.Show("please Enter The IDs");
            }
            Ent.SaveChanges();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (textBox45.Text != "")
            {
                int id = int.Parse(textBox45.Text);
                Warehouse WH = Ent.Warehouses.Find(id);
                listBox2.Items.Clear();
                    if (WH != null)
                    {
                        var query = from im in Ent.Import_Permission where im.W_Id == WH.W_Id select im;
                        foreach (var item in query)
                        {
                            listBox2.Items.Add(WH.W_Id + "\t" + WH.W_Name + "\t" + WH.W_Address + "\t" + WH.Resp_Id + "\t" + item.Goods_Id + "\t" + item.Q_G);
                        }
                    }
                    else
                    {
                        listBox2.Items.Add("This ID is not available");
                    }
            }
            else
            {
                MessageBox.Show("please Enter ID");
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if(textBox46.Text != "") { 
            int id = int.Parse(textBox46.Text);
            Good g = Ent.Goods.Find(id);
            listBox3.Items.Clear();
                    if (g != null)
                    {
                        var query = from exp in Ent.Export_Permission where exp.Goods_Id == g.G_Code select exp;
                        var query2 = from imp in Ent.Import_Permission where imp.Goods_Id == g.G_Code select imp;
                    foreach (var item in query)
                    {
                        foreach (var item2 in query2)
                        {
                            listBox3.Items.Add((g.G_Code + "\t" + g.G_Name + "\t" + g.Quantity + "\t" + g.G_Unit) + "\n" +
                                (item.Perm_no + "\t" + item.Perm_Date + "\t" + item.W_Id + "\t" + item.Q_G + "\t" + item.SuppE_Id + "\t" + item.Client_Id) + "\t" +
                                (item2.Perm_no + "\t" + item2.Perm_Date + "\t" + item2.Supp_Id + "\t" + item2.Produc_Date + "\t" + item2.Expire_Date));
                        }
                    }
                    }
                    else
                    {
                        listBox3.Items.Add("This Code is not available");
                    }
                }
                else
                {
                    MessageBox.Show("please Enter Code");
                }
        }
        private void button21_Click(object sender, EventArgs e)
        {
            listBox4.Items.Clear();
            if (textBox8.Text != "")
            {
                foreach (var item in Ent.Import_Permission)
                {
                    var date8 = System.Convert.ToDateTime(item.Perm_Date);
                    DateTime date = DateTime.Now;
                    System.TimeSpan diff1 = date.Subtract(date8);
                    var date6 = diff1.Days / 360;
                    if (date6 >= int.Parse(textBox8.Text))
                    {
                        listBox4.Items.Add(item.Perm_no + "\t" + item.Goods_Id + "\t" + item.Q_G + "\t" + item.W_Id + "\t" + item.Supp_Id + "\t" + item.Expire_Date);
                    }
                }
            }
            else
            {
                listBox4.Items.Add("Enter no. of years"); 
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            try
            {
                listBox5.Items.Clear();
                if (textBox42.Text != "" && textBox43.Text != "")
                {
                    foreach (var item in Ent.Import_Permission)
                    {
                        var date = item.Produc_Date - item.Expire_Date;
                        DateTime date2 = new DateTime();
                        var date1 = item.Expire_Date - date2;
                        if (item.Produc_Date >= System.Convert.ToDateTime(textBox42.Text) && item.Produc_Date <= System.Convert.ToDateTime(textBox43.Text))
                        {
                            if (date1 > date)
                            {
                                listBox5.Items.Add(item.Produc_Date);
                            }
                        }
                    }
                }
                else
                {
                    listBox5.Items.Add("Enter Range of Data");
                }
            }
            catch
            {
                MessageBox.Show("Invalid Date");
            }
        }
    }
}
