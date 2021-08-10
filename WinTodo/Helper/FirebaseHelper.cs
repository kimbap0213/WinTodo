using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinTodo.Model;
using System.IO;

namespace WinTodo.Helper
{
    class FirebaseHelper
    {
        public int locx()
        {
            string[] a = File.ReadAllLines(System.Windows.Forms.Application.StartupPath + "\\location.txt");
            return Convert.ToInt32(a[0]);
        }
        public int locy()
        {
            string[] a = File.ReadAllLines(System.Windows.Forms.Application.StartupPath + "\\location.txt");
            return Convert.ToInt32(a[1]);
        }
        public void loc(int x, int y)
        {
            string[] a = { x.ToString(), y.ToString() };
            using (StreamWriter outputFile = new StreamWriter(System.Windows.Forms.Application.StartupPath + "\\location.txt"))
            {
                foreach (string line in a)
                {
                    outputFile.WriteLine(line);
                }
            }
        }
        public List<RowInfo> Geta(string k)
        {
            string[] a = File.ReadAllLines(System.Windows.Forms.Application.StartupPath + "\\" + k + ".txt");
            List<RowInfo> b = new List<RowInfo>();
            b.Clear();
            RowInfo c;
            for(int i = 0; i < a.Length; i++)
            {
                c = new RowInfo { Text = a[i] };
                b.Add(c);
            }
            return b.ToList();
        }
        public List<RowInfo> Dela(string c, List<RowInfo> k)
        {
            string[] lines = new string[k.Count];
            for(int i = 0; i < k.Count; i++)
            {
                lines[i] = k[i].Text;
            }
            using (StreamWriter outputFile = new StreamWriter(System.Windows.Forms.Application.StartupPath + "\\" + c + ".txt"))
            {
                foreach (string line in lines)
                {
                    outputFile.WriteLine(line);
                }
            }
            string[] x = File.ReadAllLines(System.Windows.Forms.Application.StartupPath + "\\" + c + ".txt");
            List<RowInfo> z = new List<RowInfo>();
            z.Clear();
            RowInfo y;
            for (int i = 0; i < x.Length; i++)
            {
                y = new RowInfo { Text = x[i] };
                z.Add(y);
            }
            return z.ToList();
            //for (int i = a + 1; i < b - 2; i++)
            //{
            //    await firebase
            //        .Child(c)
            //        .Child(Convert.ToString(i))
            //        .PutAsync(new RowInfo() { Text = k[i - 1].Text });
            //}
            //await firebase
            //    .Child(c)
            //    .Child(Convert.ToString(b - 2))
            //    .DeleteAsync();
            //return (await firebase
            //    .Child(c)
            //    .OnceAsync<RowInfo>()).Select(item => new RowInfo
            //    {
            //        Text = item.Object.Text
            //    }).ToList();
        }
        public List<RowInfo> Newa(string b, string k)
        {
            using (StreamWriter outputFile = new StreamWriter(System.Windows.Forms.Application.StartupPath + "\\" + b + ".txt", true))
            {
                outputFile.WriteLine(k);
            }
            string[] x = File.ReadAllLines(System.Windows.Forms.Application.StartupPath + "\\" + b + ".txt");
            List<RowInfo> z = new List<RowInfo>();
            z.Clear();
            RowInfo y;
            for (int i = 0; i < x.Length; i++)
            {
                y = new RowInfo { Text = x[i] };
                z.Add(y);
            }
            return z.ToList();
            //await firebase
            //    .Child(b)
            //    .Child(Convert.ToString(a - 2))
            //    .PutAsync(new RowInfo() { Text = k });

            //return (await firebase
            //    .Child(b)
            //    .OnceAsync<RowInfo>()).Select(item => new RowInfo
            //    {
            //        Text = item.Object.Text
            //    }).ToList();
        }
    }
}
