using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace IDEA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private static int function(int length)
        {

            while (length % 8 != 0) { length++; }
            return length;
        }
        
        private  void init_enc()
        {
            string key = txt_Key.Text,
                   str = txt_Text.Text,
                   str1 = "";
            int h1 = function(str.Length);
            str = str.PadRight(h1, ' ');            
            int[] d = { 0, 0, 0, 0, 0, 0, 0, 0 };                       
                for (int i = 0; i < str.Length; i += 8)
                {
                    string_to_int(str.Substring(i, 8)).CopyTo(d, 0);
                    str1 += (Encrypt(d, KeyGen(key)));
                }
                txt_EncDecText.Text = "";
                txt_EncDecText.Text = str1;                    
        }

        private void init_dec()
        {
            string key = txt_Key.Text,
                   str = txt_Text.Text,
                   str2 = "";
            var regex = new Regex("^[a-zA-Z0-9\u0020]");
            string error = "";
            int h1 = function(str.Length);
            str = str.PadRight(h1, ' ');
            int[] d = { 0, 0, 0, 0, 0, 0, 0, 0 };
            for (int i = 0; i < str.Length; i += 8)
            {
                string_to_int(str.Substring(i, 8)).CopyTo(d, 0);
                str2 += (Encrypt(d, Inverse_KeyGen(KeyGen(key))));
                if (regex.Match(str2).Length == 0)   error = "Invalid key";     
            }

            txt_EncDecText.Text = "";
            txt_EncDecText.Text = error.Length > 0 ? error : str2.Trim();
        }


        private static int[] Inverse_KeyGen(int[] key)
        {
            int[] invKey = new int[key.Length];
            int p = 0;
            int i = 8 * 6;
            invKey[i + 0] = multiplicative_inverse(key[p++]);
            invKey[i + 1] = additive_inverse(key[p++]);
            invKey[i + 2] = additive_inverse(key[p++]);
            invKey[i + 3] = multiplicative_inverse(key[p++]);
            for (int r = 8 - 1; r >= 0; r--)
            {
                i = r * 6;
                int m = r > 0 ? 2 : 1;
                int n = r > 0 ? 1 : 2;
                invKey[i + 4] = key[p++];
                invKey[i + 5] = key[p++];
                invKey[i + 0] = multiplicative_inverse(key[p++]);
                invKey[i + m] = additive_inverse(key[p++]);
                invKey[i + n] = additive_inverse(key[p++]);
                invKey[i + 3] = multiplicative_inverse(key[p++]);
            }
            return invKey;
        }

        private static int[] string_to_int(string data_string)
        {
            char[] text_array = data_string.ToCharArray();
            int[] text = new int[data_string.Length];
            for (int i = 0; i < data_string.Length; i++)
            {
                text[i] = (int)text_array[i];
            }
            return text;
        }


        private static int[] KeyGen(string data)
        {
            int index, index1 = 0;
            int[] KEY = new int[52];
            int[] oldkey = string_to_int(data);
            for (index = 0; index < 5; index++)
            {
                oldkey.CopyTo(KEY, index1);
                index1 += 8;
                oldkey = shift_left(oldkey);
            }
            oldkey = shift_left(oldkey);
            KEY[48] = oldkey[0];
            KEY[49] = oldkey[1];
            KEY[50] = oldkey[2];
            KEY[51] = oldkey[3];
            return KEY;
        }


        private static int[] shift_left(int[] data)
        {
            StringBuilder st = new StringBuilder();
            int[] newkey = new int[16];
                foreach (int num in data) st.Append(Convert.ToString(num, 2).PadLeft(8, '0'));
                string a = "";
                a = st.ToString().Substring(25, 103) + st.ToString().Substring(0, 25);
                for (int i = 0; i < 128; i += 8) newkey[i / 8] = Convert.ToByte(a.Substring(i, 8), 2);        
            return newkey;
        }


        private static int additive_inverse(int data)
        {
            int m = 0;
            for (int i = 1; i < 65536; i++)
            {
                if ((data + i) % 65536 == 0) m = i;
            }
            return m;
        }

        private static int multiplicative_inverse(int data)
        {
            int m = 0;
            for (int i = 1; i < 65537; i++)
            {
                if ((data * i) % 65537 == 1) m = i;
            }
            return m;
        }

        private static string Encrypt(int[] data, int[] key)
        {
            int x0 = data[0] << 8 ^ data[1];
            int x1 = data[2] << 8 ^ data[3];
            int x2 = data[4] << 8 ^ data[5];
            int x3 = data[6] << 8 ^ data[7];
            int p = 0;
            StringBuilder str = new StringBuilder();
            for (int round = 0; round < 8; round++)
            {
                int y0 = mul(x0, key[p++]);
                int y1 = add(x1, key[p++]);
                int y2 = add(x2, key[p++]);
                int y3 = mul(x3, key[p++]);
                
                int t0 = mul(y0 ^ y2, key[p++]);
                int t1 = add(y1 ^ y3, t0);
                int t2 = mul(t1, key[p++]);
                int t3 = add(t0, t2);
                
                x0 = y0 ^ t2;
                x1 = y2 ^ t2;
                x2 = y1 ^ t3;
                x3 = y3 ^ t3;
            }
            
            int r0 = mul(x0, key[p++]);
            int r1 = add(x2, key[p++]);
            int r2 = add(x1, key[p++]);
            int r3 = mul(x3, key[p++]);
            
            data[0] = (byte)(r0 >> 8);
            data[1] = (byte)r0;
            data[2] = (byte)(r1 >> 8);
            data[3] = (byte)r1;
            data[4] = (byte)(r2 >> 8);
            data[5] = (byte)r2;
            data[6] = (byte)(r3 >> 8);
            data[7] = (byte)r3;

            for (int i = 0; i < 8; i++) str.Append((char)data[i]);
            return str.ToString();
        }

        private static int add(int a, int b)
        {
            return (a + b) & 0xFFFF;
        }

        private static int mul(int a, int b)
        {
            long r = (long)a * b;
            if (r != 0)
            {
                return (int)(r % 65537);
            }
            else
            {
                return (1 - a - b);
            }
        }

        private static int xor(int a, int b)
        {
            return a ^ b;
        }

        private void btn_Encrypt_Click(object sender, EventArgs e)
        {
            if(txt_Key.Text.Length < 16) MessageBox.Show("The key length must be 16 symbols", "Warning", MessageBoxButtons.OK);
                else
            if(txt_Text.Text=="") MessageBox.Show("Please, input text", "Warning", MessageBoxButtons.OK);
            else
            init_enc();
        }

        private void btn_Decrypt_Click(object sender, EventArgs e)
        {
            if (txt_Key.Text.Length < 16) MessageBox.Show("The key length must be 16 symbols", "Warning", MessageBoxButtons.OK);
            else
            if (txt_Text.Text == "") MessageBox.Show("Please, input text", "Warning", MessageBoxButtons.OK);
            else
            init_dec();
        }
    }
}

