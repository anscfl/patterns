using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    public interface ITarget
    {
        string GetRequest();
    }

    public class BinaryData
    {
        public readonly string data;
        public BinaryData(string data)
        {
            this.data = data;
        }
        public static implicit operator string(BinaryData d) => d.data;
        public int GetLength(BinaryData d)
        {
            string a = d;
            return a.Length;
            
        }
        public string GetSubstring(BinaryData d, int a, int b)
        {
            string s = d;
            return s.Substring(a, b);
        }
    }

    public class Adapter : ITarget
    {
        readonly BinaryData _adaptee;
        public Adapter(BinaryData adaptee)
        {
            this._adaptee = adaptee;
        }

        public Byte[] GetBytesFromBinaryString(BinaryData _adaptee)
        {
            var list = new List<Byte>();

            for (int i = 0; i < _adaptee.GetLength(_adaptee); i += 8)
            {
                String t = _adaptee.GetSubstring(_adaptee, i, 8);

                list.Add(Convert.ToByte(t, 2));
            }

            return list.ToArray();
        }

        public string GetRequest()
        {
            var data = GetBytesFromBinaryString(_adaptee);
            return Encoding.ASCII.GetString(data);
        }
    }
}
