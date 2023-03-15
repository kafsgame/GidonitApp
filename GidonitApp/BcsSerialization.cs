using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GidonitApp
{
    internal class BcsSerialization
    {
        IEnumerable<byte> o = new byte[0];



        public byte[] oput()
        {
            return o.ToArray<byte>();
        }

        public void serBool(bool val)
        {
            o = o.Append<byte>(BitConverter.GetBytes(val)[0]);
        }

        public void serBytes(byte[] bytes)
        {
            uleb128((UInt32)bytes.Length);
            foreach (var item in bytes)
            {
                o = o.Append<byte>(item);
            }

        }

        public bool isFirstBigger(byte[] f, byte[] s)
        {
            if (f.Length > s.Length)
                return true;
            else
            {
                if (f.Length < s.Length)
                    return false;
                else
                {
                    for (int i = 0; i < f.Length; i++)
                    {
                        if (f[i] > s[i])
                            return true;
                    }
                }
            }
            return false;
        }

        public void sequence(List<object> values, List<int> valueEncoder)
        {
            uleb128((uint)values.Count());

            int c = 0;

            foreach (var value in values)
            {
                serBytes(Encoder.encode(value, valueEncoder[c]));
                c++;
            }
        }

        public Dictionary<byte[], byte[]> sort(byte[][] keys, byte[][] values)
        {
            Dictionary<byte[], byte[]> res = new Dictionary<byte[], byte[]>();
            byte[] temp;
            int len = keys.Count();


            for (int i = 1; i < len; i++)
            {
                for (int j = 0; j < len - i; j++)
                {

                    if (isFirstBigger(keys[j], keys[j + 1]))
                    {
                        temp = keys[j];
                        keys[j] = keys[j + 1];
                        keys[j + 1] = temp;
                        temp = values[j];
                        values[j] = values[j + 1];
                        values[j + 1] = temp;
                    }
                }
            }

            for (int i = 0; i < len; i++)
            {
                res.Add(keys[i], values[i]);
            }
            return res;

        }


        public void fixedBytes(byte[] bytes)
        {
            foreach (var item in bytes)
            {
                o = o.Append<byte>(item);
            }
        }

        public void serStr(string str)
        {
            serBytes(Encoding.ASCII.GetBytes(str));
        }

        public void map(Dictionary<object, object> values, List<object> key_encoder, List<object> value_encoder)
        {
            IEnumerable<byte[]> encodedKeys = new List<byte[]>();
            IEnumerable<byte[]> encodedValues = new List<byte[]>();
            int num = 0;
            foreach (var item in values)
            {
                byte[] ekey = Encoder.encode(item.Key, key_encoder[num]);
                byte[] evalue = Encoder.encode(item.Value, value_encoder[num]);
                encodedKeys = encodedKeys.Append<byte[]>(ekey);
                encodedValues = encodedValues.Append<byte[]>(evalue);
                num++;
            }

            Dictionary<byte[], byte[]> sorted = sort(encodedKeys.ToArray(), encodedValues.ToArray());

            uleb128((uint)encodedKeys.Count());
            foreach (var key in sorted)
            {
                fixedBytes(key.Key);
                fixedBytes(key.Value);
            }
        }



        public void u8(byte val)
        {
            o = o.Append<byte>(val);
        }
        public void u16(UInt16 val)
        {
            byte[] b = BitConverter.GetBytes(val);
            foreach (var item in b)
            {
                o = o.Append<byte>(item);
            }
        }

        public void u32(UInt32 val)
        {
            byte[] b = BitConverter.GetBytes(val);
            foreach (var item in b)
            {
                o = o.Append<byte>(item);
            }
        }

        public void u64(UInt64 val)
        {
            byte[] b = BitConverter.GetBytes(val);
            foreach (var item in b)
            {
                o = o.Append<byte>(item);
            }
        }




        public void uleb128(UInt32 val)
        {

            byte b = 0;
            while (val >= 0x80)
            {
                b = (byte)(val & 0x7F);

                u8((byte)(b | 0x80));
                val >>= 7;
            }

            u8((byte)(val & 0x7F));
        }






    }
    public struct Encoder
    {
        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }
        public static byte[] encode(object value, object encoder)
        {

            BcsSerialization ser = new BcsSerialization();
            if (encoder.GetType() == 64.GetType())
            {
                switch (encoder)
                {
                    case 0:
                        ser.serBool((bool)value);
                        break;
                    case 8:
                        ser.u8((byte)value);
                        break;
                    case 16:
                        ser.u16((UInt16)value);
                        break;
                    case 32:
                        ser.u32((UInt32)value);

                        break;
                    case 64:
                        ser.u64((UInt64)value);
                        break;
                    case 1:
                        ser.serBytes((byte[])value);
                        break;
                    case 2:
                        ser.fixedBytes((byte[])value);
                        break;
                    case 4:
                        ser.serStr((string)value);
                        break;
                    case 5:
                        ser.fixedBytes(StringToByteArray(((string)value).Replace("0x", "")));
                        break;
                    default:
                        throw new Exception("WTF BROOOOOOOOO");
                }
            }
            else
            {
                ser.map((Dictionary<object, object>)value, (List<object>)((List<object>)encoder)[0], (List<object>)((List<object>)encoder)[1]);
            }
            return ser.oput();
        }
    }
}

