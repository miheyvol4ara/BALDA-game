using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Балдень
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool lang = true, player = true, inp = true;
        string filename2 = "dicru.txt";
        string str = "", rts = "";
        int cc = 0, q1 = 0, q2 = 0, ii = 0, jj = 0;
        string x = "";
        string[][] A = new string[5][];
        string[][] B = new string[5][];
       
        static void bap(string[][] A, ref string[][] B)
        {
            for (int i = 0; i < A.Length; i++)
                for (int j = 0; j < A[i].Length; j++)
                    B[i][j] = A[i][j];
        }
        static void listadd(ref bool player, ListBox lst1, ListBox lst2, string rts, ref int q1, ref int q2)
        {
            if (player)
            {
                lst1.Items.Add(rts);
                player = false;
                q1 += rts.Length;
            }
            else
            {
                lst2.Items.Add(rts);
                player = true;
                q2 += rts.Length;
            }
        }
        static void pastedm(ref string[][] A, DataGridView dtg)
        {
            for (int i = 0; i < A.Length; i++)
                for (int j = 0; j < A[i].Length; j++)
                    A[i][j] = dtg.Rows[i].Cells[j].Value as string;
        }
        static void cellselectedcheck(DataGridView dtg, string[][] A, ref bool selectij)
        {
            int ich = 0;
            int jch = 0;
            for (int i = 0; i < A.Length; i++)
                for (int j = 0; j < A.Length; j++)
                {
                    if (dtg.Rows[i].Cells[j].Selected == true)
                    {
                        ich = i;
                        jch = j;
                    }
                }
            for (int i = 0; i < A.Length; i++)
                for (int j = 0; j < A.Length; j++)
                {
                    if (dtg.Rows[i].Cells[j].Selected == true)
                        if ((i != ich + 1 && i != ich - 1 && i != ich) || (j != jch + 1 && j != jch - 1 && j != jch))
                        {
                            selectij = false;
                            break;
                        }
                }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> a = new List<string>();
            foreach (string x in ((new StreamReader(filename2)).ReadToEnd()).Split('\n'))
                if (x.Length == 6) a.Add(x);
            string word = (a[(new Random(DateTime.Now.Millisecond)).Next(0, a.Count - 1)]);
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            for (int i = 0; i < 5; i++)
            {
                dataGridView1.Columns.Add(i + "", "");
                dataGridView1.Columns[i].Width = 35;
            }
            for (int i = 0; i < 5; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Height = 35;
                if (i == 2)
                    for (int j = 0; j < 5; j++)
                        dataGridView1[j, i].Value = word[j];
            }
        }﻿