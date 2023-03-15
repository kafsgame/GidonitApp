using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using System.Text.Json;
using Waher.Security;
using Waher.Security.SHA3;
using Waher.Security.EllipticCurves;
using System.Drawing;
using System.Globalization;
using System.Windows.Markup;
using System.Runtime.InteropServices.ComTypes;
using static System.Net.Mime.MediaTypeNames;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Diagnostics;


namespace GidonitApp
{
    
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Logger logger;
        private string launchpad = "";
        private string selectedWallet = "";
        public static bool done = false;
        private List<Account> Accounts = new List<Account>();
        private List<Account> CheckedAccounts = new List<Account>();
        private static string kKey = "0x896ef54640104e27400e9a6f18441288669311be04ad04bec365de16a2407326";
        private string node = "";
        private  List<string> addrList = new  List<string>
        {
            "0x2163e5e0c30ba59ac86ffccddb8f4a7bdb555bcfa5a001e71afbe9f49353f297"
        };
        private bool Holder = false;
        


        
        public MainWindow()
        {

            InitializeComponent();

           

            
            Dictionary<string, string> data;
            using (FileStream fs = File.OpenRead("userdata.dat"))
            {
                byte[] buffer = new byte[fs.Length];

                fs.Read(buffer, 0, buffer.Length);

                data = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, string>>(Encoding.Default.GetString(buffer));


            }
            node = data["node"];
            Holder = isHolder(data["token"]);
            if (Holder)
            {
                HolderNotVerified.Visibility = Visibility.Hidden;
            }
            NodeInput.Text = node;
            AuthWallet.Text = data["token"];
            addWalletsFromDataToWalletList();
            WalletsList.ItemsSource = Accounts;
            ActiveWallets.ItemsSource = CheckedAccounts;
        }

        private void Minter_bot_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void AddWalletToWalletList(string name, string PrivateKey)
        {

            //Grid.SetRow(l, WalletsList.RowDefinitions.Count);
            //Grid.SetColumn(l, 0);
            //WalletsList.Children.Add(l);

        }

        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

    

        private void Distributton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {


        }
        private void closeWindow(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
        private void hideWindow(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void MoveWindow(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            foreach (Account item in WalletsList.Items)
            {

                item.CB = (bool)((CheckBox)sender).IsChecked;
            }
            WalletsList.Items.Refresh();
            
        }

        private void Send(object sender, MouseButtonEventArgs e)
        {
            DataGridCell cell = new DataGridCell();
            for (var vis = sender as Visual; vis != null; vis = VisualTreeHelper.GetParent(vis) as Visual)
                if (vis is DataGridCellsPanel)
                {

                    cell = (DataGridCell)VisualTreeHelper.GetChild(vis, 2);
                    break;
                }
            ((TextBox)VisualTreeHelper.GetChild((ContentPresenter)cell.Content, 0)).Focus();
            selectedWallet = ((TextBox)VisualTreeHelper.GetChild((ContentPresenter)cell.Content, 0)).Text;
            Dark.Visibility = Visibility.Visible;
            WalletsList.Visibility = Visibility.Hidden;
            Wallet_Manager_Buttons.Visibility = Visibility.Hidden;
            Menu_Buttons.Visibility = Visibility.Hidden;

            Dark.Source = BitmapToImageSource(getbmp());

            sendingMenu.Visibility = Visibility.Visible;


        }
        private void Del(object sender, MouseButtonEventArgs e)
        {
            DataGridCell cell = new DataGridCell();
            for (var vis = sender as Visual; vis != null; vis = VisualTreeHelper.GetParent(vis) as Visual)
                if (vis is DataGridCellsPanel)
                {

                    cell = (DataGridCell)VisualTreeHelper.GetChild(vis, 2);
                    break;
                }
             ((TextBox)VisualTreeHelper.GetChild((ContentPresenter)cell.Content, 0)).Focus();
            string p = ((TextBox)VisualTreeHelper.GetChild((ContentPresenter)cell.Content, 0)).Text;
            for(int i = 0; i < Accounts.Count; i++)
            {
                if (Accounts[i].privateKey == p)
                {
                    Accounts.Remove(Accounts[i]);
                    removeWalletFromUserData(p);
                    WalletsList.ItemsSource = Accounts;
                    WalletsList.Items.Refresh();
                    break;
                }
            }

        }
        private void Edit(object sender, MouseButtonEventArgs e)
        {
            DataGridCell cell = new DataGridCell();
            for (var vis = sender as Visual; vis != null; vis = VisualTreeHelper.GetParent(vis) as Visual)
                if (vis is DataGridCellsPanel)
                {

                    cell = (DataGridCell)VisualTreeHelper.GetChild(vis, 2);
                    break;
                }
            ((TextBox)VisualTreeHelper.GetChild((ContentPresenter)cell.Content, 0)).Focus();
            selectedWallet = ((TextBox)VisualTreeHelper.GetChild((ContentPresenter)cell.Content, 0)).Text;
            Dark.Visibility = Visibility.Visible;
            WalletsList.Visibility = Visibility.Hidden;
            Wallet_Manager_Buttons.Visibility = Visibility.Hidden;
            Menu_Buttons.Visibility = Visibility.Hidden;

            Dark.Source = BitmapToImageSource(getbmp());

            editingWallet.Visibility = Visibility.Visible;


        }



        private void submitEdit_Click(object sender, MouseButtonEventArgs e)
        {
            string key = selectedWallet;


            for (int i = 0; i < Accounts.Count; i++)
            {
                if (Accounts[i].privateKey == key)
                {
                    Accounts[i].name = newName.Text;
                    addWalletToUserData(key, newName.Text);
                    WalletsList.ItemsSource = Accounts;
                    WalletsList.Items.Refresh();
                    break;
                }
            }




            Menu_Buttons.Visibility = Visibility.Visible;
            WalletsList.Visibility = Visibility.Visible;
            Wallet_Manager_Buttons.Visibility = Visibility.Visible;
            newName.Text = "";


            Dark.Visibility = Visibility.Hidden;
            editingWallet.Visibility = Visibility.Hidden;



        }

        private void cancelEdit_Click(object sender, MouseButtonEventArgs e)
        {
            Menu_Buttons.Visibility = Visibility.Visible;
            WalletsList.Visibility = Visibility.Visible;
            Wallet_Manager_Buttons.Visibility = Visibility.Visible;
            newName.Text = "";


            Dark.Visibility = Visibility.Hidden;
            editingWallet.Visibility = Visibility.Hidden;
        }


        public void addWalletsFromDataToWalletList()
        {
            Dictionary<string, string> data;
            using (FileStream fs = File.OpenRead("userdata.dat"))
            {
                byte[] buffer = new byte[fs.Length];

                fs.Read(buffer, 0, buffer.Length);
                data = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, string>>(Encoding.Default.GetString(buffer));

            }

            foreach (var item in data)
            {
                if (item.Key != "node" && item.Key != "token")
                {
                    Add_wallet(item.Key, item.Value);
                }
            }
        }
        public static int getChainId(string node)
        {
            WebRequest r = WebRequest.Create(node);
            WebResponse resp = r.GetResponse();
            Stream stream = resp.GetResponseStream();
            StreamReader sr = new StreamReader(stream);
            string sresp = sr.ReadToEnd();
            int seq = Convert.ToInt32(System.Text.Json.JsonSerializer.Deserialize<LedgerInfo>(sresp).chain_id);
            resp.Dispose();
            return seq;
        }
        private void removeWalletFromUserData(string PrivateKey)
        {

            Dictionary<string, string> data;
            using (FileStream fs = File.OpenRead("userdata.dat"))
            {
                byte[] buffer = new byte[fs.Length];

                fs.Read(buffer, 0, buffer.Length);

                data = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, string>>(Encoding.Default.GetString(buffer));


            }
            data.Remove(PrivateKey);


            string dataSer = System.Text.Json.JsonSerializer.Serialize(data);


            using (FileStream fs = new FileStream("userdata.dat", FileMode.Create))
            {
                byte[] buffer = Encoding.Default.GetBytes(dataSer);
                fs.Write(buffer, 0, buffer.Length);

            }
        }
        private void addWalletToUserData(string PrivateKey, string Name)
        {
            Dictionary<string, string> data;
            using (FileStream fs = File.OpenRead("userdata.dat"))
            {
                byte[] buffer = new byte[fs.Length];

                fs.Read(buffer, 0, buffer.Length);

                data = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, string>>(Encoding.Default.GetString(buffer));


            }
            if (data.ContainsKey(PrivateKey))
                data[PrivateKey] = Name;
            else
                data.Add(PrivateKey, Name);


            string dataSer = System.Text.Json.JsonSerializer.Serialize(data);


            using (FileStream fs = new FileStream("userdata.dat", FileMode.Create))
            {
                byte[] buffer = Encoding.Default.GetBytes(dataSer);
                fs.Write(buffer, 0, buffer.Length);

            }
        }
        
        
        private void createNewData()
        {
            Dictionary<string, string> data = new Dictionary<string, string>
            {
                {"node", node},
                {"token", "" }
            };

            string dataSer = System.Text.Json.JsonSerializer.Serialize(data);


            using (FileStream fs = new FileStream("userdata.dat", FileMode.Create))
            {
                byte[] buffer = Encoding.Default.GetBytes(dataSer);
                fs.Write(buffer, 0, buffer.Length);

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Dictionary<Object, Object> payload = new Dictionary<Object, Object> {
                {"function", "0x09b9812f618c67f447aeaa93605074433f2f11489e23d7e775f2d705d2f40f86::minting::mint" },
                {"type_arguments", new List<Object>{ } },
                {"arguments", new List<Object>
                {
                    "0xa46e7dbb9a97488a6da529ee784f5d1b2d9056e01d422571d9a8708bdd8db927",
                    (UInt64)5000000,
                    (UInt64)1,
                    Encoding.UTF8.GetBytes("")
                }
                },
                {"type", "entry_function_payload" }
            };

            List<int> keyEncoder = new List<int>()
            {
                5,
                64,
                64,
                1
            };
            UInt64 seq = getSequenceNumber("0x4891879d21a57a9ea6f9e649d6a37ed9ebf256ab5498ca622ac2a04e4d0ee142", node);

            UInt64 maxGasAmount = 100000;
            UInt64 gasUnitPrice = 100;
            UInt64 expirationTimestampSecs = (UInt64)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds + 300;


            Dictionary<Object, Object> rawTransaction = new Dictionary<object, object>
            {
                { "sender" , StringToByteArray("4891879d21a57a9ea6f9e649d6a37ed9ebf256ab5498ca622ac2a04e4d0ee142") },
                { "sequence_number" , seq },
                { "payload" , payload },
                { "max_gas_amount" , maxGasAmount },
                { "gas_unit_price" , gasUnitPrice },
                { "expiration_timestamp_secs" , expirationTimestampSecs },



            };
            int chain_id = getChainId(node);
            minter(kKey, keyEncoder, rawTransaction, chain_id, node);

        }
        private Bitmap getbmp()
        {
            Bitmap bmp = new Bitmap(1366, 768);
            using (Graphics G = Graphics.FromImage(bmp))
            {
                G.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
                G.CopyFromScreen(PointConverter.ConvertBack(this.PointToScreen(new System.Windows.Point(0, 25))), new System.Drawing.Point(0, 0), new System.Drawing.Size(1366, 768));
                double percent = 0.60;
                System.Drawing.Color darken = System.Drawing.Color.FromArgb((int)(255 * percent), System.Drawing.Color.Black);
                using (System.Drawing.Brush brsh = new SolidBrush(darken))
                {
                    G.FillRectangle(brsh, new RectangleF(0,0,1366,768));
                }
            }
            return bmp;
        }
        BitmapImage BitmapToImageSource(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();

                return bitmapimage;
            }
        }
        private void Add_wallets_Click(object sender, EventArgs e)
        {
            
            Dark.Visibility = Visibility.Visible;
            WalletsList.Visibility = Visibility.Hidden;
            Wallet_Manager_Buttons.Visibility = Visibility.Hidden;
            Menu_Buttons.Visibility = Visibility.Hidden;

            Dark.Source = BitmapToImageSource(getbmp());

            AddingMenu.Visibility = Visibility.Visible;
 
            

            //int count = WalletList.Controls.Count / 5;
            //Add_wallet("0x896ef54640104e27400e9a6f18441288669311be04ad04bec365de16a2407326" + Convert.ToString(count), "0x4891879d21a57a9ea6f9e649d6a37ed9ebf256ab5498ca622ac2a04e4d0ee142" + Convert.ToString(count), 0.12345, "Кошель"+ Convert.ToString(count));

        }
        private void Gen_wallets_Click(object sender, EventArgs e)
        {

            Dark.Visibility = Visibility.Visible;
            WalletsList.Visibility = Visibility.Hidden;
            Wallet_Manager_Buttons.Visibility = Visibility.Hidden;
            Menu_Buttons.Visibility = Visibility.Hidden;

            Dark.Source = BitmapToImageSource(getbmp());

            generatingWallets.Visibility = Visibility.Visible;
            
        }
        private void Add_wallet(string private_key, string name)
        {



            Edwards25519 ed25519 = new Edwards25519();
            ed25519.SetPrivateKey(StringToByteArray(private_key.Replace("0x", "")));

            byte[] publicKey = ed25519.PublicKey.Append<byte>(0).ToArray();

            SHA3_256 sha = new SHA3_256();

            string addr = "0x" + BitConverter.ToString(sha.ComputeVariable(publicKey)).Replace("-", "").ToLower();

            decimal bal = getBalance(addr);
         

            Accounts = Accounts.Append(new Account(false, name, private_key, addr, Convert.ToString(bal), Convert.ToString(getItems(addr)))).ToList();
            WalletsList.ItemsSource = Accounts;
            WalletsList.Items.Refresh();


        }
        
        private int getItems(string addr)
        {
            int items = 0;
            string rawItems = "";
            string data = "{\"operationName\":\"AccountTokensCount\",\"variables\":{\"owner_address\":\"" + addr + "\"},\"query\":\"query AccountTokensCount($owner_address: String) {\\n  current_token_ownerships_aggregate(\\n    where: {owner_address: {_eq: $owner_address}, amount: {_gt: \\\"0\\\"}}\\n  ) {\\n    aggregate {\\n      count\\n      __typename\\n    }\\n    __typename\\n  }\\n}\"}";
            byte[] sentData = Encoding.ASCII.GetBytes(data);
            WebRequest r = WebRequest.Create("https://indexer.mainnet.aptoslabs.com/v1/graphql");
            r.Method = "POST";
            r.Timeout = 120000;
            r.ContentType = "application/json";

            r.ContentLength = sentData.Length;
            Stream sendStream = r.GetRequestStream();
            sendStream.Write(sentData, 0, sentData.Length);
            sendStream.Close();
            try
            {
                
                WebResponse resp = r.GetResponse();
                Stream stream = resp.GetResponseStream();
                StreamReader sr = new StreamReader(stream);
                string sresp = sr.ReadToEnd().Remove(0, 72);
                for (int i = 0; sresp[i]!=','; i++){
                    rawItems += sresp[i];
                }
                items = Convert.ToInt32(rawItems);


                resp.Dispose();
            }
            catch
            {
                return 0;
            }
            return items;
        }
        private decimal getBalance(string addr)
        {
            decimal bal = 0;

           
            try
            {
                Console.WriteLine(node + "accounts/" + addr + "/resource/0x1::coin::CoinStore<0x1::aptos_coin::AptosCoin>");
                WebRequest r = WebRequest.Create(node + "accounts/" + addr + "/resource/0x1::coin::CoinStore<0x1::aptos_coin::AptosCoin>");
                WebResponse resp = r.GetResponse();
                Stream stream = resp.GetResponseStream();
                StreamReader sr = new StreamReader(stream);
                string sresp = sr.ReadToEnd();



                ResponseBalance newfoo = System.Text.Json.JsonSerializer.Deserialize<ResponseBalance>(sresp);

                bal = Convert.ToDecimal(newfoo.data.coin["value"]) / (decimal)100000000;
                resp.Dispose();
            }
            catch
            {
                bal = 0;

            }
            return bal;

        }
        public static bool minter(string Key, List<int> keyEncoder, Dictionary<Object, Object> rawTransaction, int chaid_id, string node)
        {
            Edwards25519 ed25519 = new Edwards25519();
            ed25519.SetPrivateKey(StringToByteArray(Key.Replace("0x", "")));



            List<int> argTy_encoder = new List<int>()
            {

            };

            byte[] serRaw = serializeRawTxn(rawTransaction, keyEncoder, argTy_encoder, chaid_id);
            byte[] prefix = StringToByteArray("b5e97db07fa0bd0e5598aa3643a9bc6f6693bddc1a9fec9e674a461eaa00b193");
            int length = prefix.Length + serRaw.Length;
            byte[] signing_message = new byte[length];
            prefix.CopyTo(signing_message, 0);
            serRaw.CopyTo(signing_message, prefix.Length);

            //string aa = "0xb5e97db07fa0bd0e5598aa3643a9bc6f6693bddc1a9fec9e674a461eaa00b1934891879d21a57a9ea6f9e649d6a37ed9ebf256ab5498ca622ac2a04e4d0ee14202000000000000000200000000000000000000000000000000000000000000000000000000000000010d6170746f735f6163636f756e74087472616e73666572000220e474ba7755a3f7ecdef27e34e91465dac4b7e355f545c0096e31ec65cf4183cc0820a1070000000000f803000000000000640000000000000048e67c630000000026";
            byte[] signature = signMessage(signing_message, ed25519);


            Dictionary<object, byte[]> authenticator = new Dictionary<object, byte[]>
            {
                { "public_key", ed25519.PublicKey },
                { "signature", signature},
            };


            byte[] txn = serializeSignedTxn(serRaw, authenticator);



            bool suc = send_txn(txn, node);

            return suc;
            //string s = sr.ReadToEnd();
            //label1.Text = s;



        }

        public static bool send_txn(byte[] sentData, string node)
        {
            WebRequest r = WebRequest.Create(node + "transactions");
            r.Method = "POST";
            r.Timeout = 120000;
            r.ContentType = "application/x.aptos.signed_transaction+bcs";

            r.ContentLength = sentData.Length;
            Stream sendStream = r.GetRequestStream();
            sendStream.Write(sentData, 0, sentData.Length);
            sendStream.Close();
            try
            {
                WebResponse resp = r.GetResponse();
                resp.Dispose();
                return true;
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(new StreamReader(ex.Response
                    .GetResponseStream()).ReadToEnd());
               
                return false;
            }


        }
        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        private static byte[] serializeSignedTxn(byte[] serRaw, Dictionary<object, byte[]> authenticator)
        {
            BcsSerialization ser = new BcsSerialization();
            ser.fixedBytes(serRaw);
            ser.uleb128((uint)0);
            ser.serBytes(authenticator["public_key"]);
            ser.serBytes(authenticator["signature"]);

            return ser.oput();

        }
        private static byte[] serializeRawTxn(Dictionary<Object, Object> rawTransaction, List<int> arg_encoder, List<int> argTy_encoder, int chain_id)
        {
            BcsSerialization ser = new BcsSerialization();

            ser.fixedBytes((byte[])rawTransaction["sender"]);
            ser.u64((UInt64)rawTransaction["sequence_number"]);
            ser.uleb128((uint)2);
            string[] ModuleData = ((string)((Dictionary<Object, Object>)rawTransaction["payload"])["function"]).Split(new char[] { ':', ':' });
            ser.fixedBytes(StringToByteArray(ModuleData[0].Remove(0, 2)));
            ser.serStr(ModuleData[2]);

            ser.serStr(ModuleData[4]);
            ser.sequence((List<object>)(((Dictionary<Object, Object>)rawTransaction["payload"])["type_arguments"]), argTy_encoder);
            ser.sequence((List<object>)(((Dictionary<Object, Object>)rawTransaction["payload"])["arguments"]), arg_encoder);

            ser.u64((UInt64)rawTransaction["max_gas_amount"]);
            ser.u64((UInt64)rawTransaction["gas_unit_price"]);
            ser.u64((UInt64)rawTransaction["expiration_timestamp_secs"]);
            ser.u8((byte)chain_id);




            return ser.oput();

        }

        public static UInt64 getSequenceNumber(string addr, string node)
        {
            try
            {
                WebRequest r = WebRequest.Create(node + "accounts/" + addr);
                WebResponse resp = r.GetResponse();
                Stream stream = resp.GetResponseStream();
                StreamReader sr = new StreamReader(stream);
                string sresp = sr.ReadToEnd();
                UInt64 seq = Convert.ToUInt64(System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, string>>(sresp)["sequence_number"]);
                resp.Dispose();
                return seq;
            }
            catch
            {
                return 0;
            }
        }

        private static byte[] signMessage(byte[] message, Edwards25519 ed25519)
        {
            byte[] signature = ed25519.Sign(message);
            return signature;
        }




        private void AddingText_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyboardDevice.IsKeyDown(Key.LeftCtrl) || e.KeyboardDevice.IsKeyDown(Key.RightCtrl))
            {
                switch (e.Key)
                {
                    case Key.Enter:
                        TextBox t = sender as TextBox;
                        t.Text += Environment.NewLine;
                        t.CaretIndex = t.Text.Length - 1;
                        break;
                }
            }
            else
            {
                if (e.Key == Key.Enter)
                {
                    SubmitPrivateKey_Click(this, null);
                    e.Handled = true;
                }
            }
        }

        private void CancelAddingWallet_Click(object sender, EventArgs e)
        {
            Menu_Buttons.Visibility = Visibility.Visible;
            WalletsList.Visibility = Visibility.Visible;
            Wallet_Manager_Buttons.Visibility = Visibility.Visible;
            PrivateKeyInput.Text = "";


            Dark.Visibility = Visibility.Hidden;
            AddingMenu.Visibility = Visibility.Hidden;

        }
        private void SubmitPrivateKey_Click(object sender, EventArgs e)
        {
            string data = PrivateKeyInput.Text;
            string name = "";
            bool exist = false;
            string[] pairs = data.Split('\n');
            foreach (string rawpair in pairs)
            {
                string[] pair = rawpair.Split(';');
                
                string key = pair[0];
                try
                {
                    name = pair[1];
                }
                catch
                {
                    name = "";
                }

                key = key.Replace(" ", "");
                key = key.Replace("0x", "");
                key = key.Replace("\n", "");
                key = key.Replace("\r", "");
                int len = key.Length;
                Console.WriteLine(len);
                if (len > 64)
                {
                    
                    continue;
                }
                for (int i = 0; i < 64 - len; i++)
                {
                    key = "0" + key;
                }
                key = "0x" + key;
                try
                {
                    exist = false;
                    StringToByteArray(key.Replace("0x", ""));
                    foreach(Account account in Accounts)
                    {
                        if (account.privateKey == key)
                        {
                            exist = true;
                            break;
                        }
                    }
                    if (exist)
                        continue;
                    addWalletToUserData(key, name);
                    Add_wallet(key, name);
                    
                    

                }
                catch
                {

                }
            }
            Menu_Buttons.Visibility = Visibility.Visible;
            WalletsList.Visibility = Visibility.Visible;
            Wallet_Manager_Buttons.Visibility = Visibility.Visible;

            PrivateKeyInput.Text = "";


                    Dark.Visibility = Visibility.Hidden;
                    AddingMenu.Visibility = Visibility.Hidden;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Console.WriteLine(Accounts.Count);
            if ((bool)checkBox1.IsChecked)
            {
                for (int i = 0; i < WalletsList.Items.Count; i++)
                    ((Account)WalletsList.Items[i]).CB = true;
                WalletsList.Items.Refresh();
            }
            else
            {
                for (int i = 0; i < WalletsList.Items.Count; i++)
                    ((Account)WalletsList.Items[i]).CB = false;
                WalletsList.Items.Refresh();
            }
        }

        

        private void cancelGen_Click(object sender, EventArgs e)
        {
            Menu_Buttons.Visibility = Visibility.Visible;
            WalletsList.Visibility = Visibility.Visible;
            Wallet_Manager_Buttons.Visibility = Visibility.Visible;
            countOfWallets.Text = "";


            Dark.Visibility = Visibility.Hidden;
            generatingWallets.Visibility = Visibility.Hidden;
        }

       

        private void submitGen_Click(object sender, EventArgs e)
        {
            byte[] wal = new byte[32];
            Random rnd = new Random();
            try
            {
                for (int i = 0; i < Convert.ToInt32(countOfWallets.Text); i++)
                {
                    for (int j = 0; j < 32; j++)
                    {
                        wal[j] = Convert.ToByte(rnd.Next(0, 256));
                    }
                    Add_wallet("0x" + BitConverter.ToString(wal).ToLower().Replace("-", ""), "");
                    addWalletToUserData("0x" + BitConverter.ToString(wal).ToLower().Replace("-", ""), "");
                }
                Menu_Buttons.Visibility = Visibility.Visible;
                WalletsList.Visibility = Visibility.Visible;
                Wallet_Manager_Buttons.Visibility = Visibility.Visible;
                countOfWallets.Text = "";


                Dark.Visibility = Visibility.Hidden;
                generatingWallets.Visibility = Visibility.Hidden;
            }
            catch
            {
                return;
            }
        }

        private void Distr_wallets_Click(object sender, EventArgs e)
        {
            Dark.Visibility = Visibility.Visible;
            WalletsList.Visibility = Visibility.Hidden;
            Wallet_Manager_Buttons.Visibility = Visibility.Hidden;
            Menu_Buttons.Visibility = Visibility.Hidden;

            Dark.Source = BitmapToImageSource(getbmp());

            distribMenu.Visibility = Visibility.Visible;

            
        }

        

        private void cancelDistrib_click(object sender, EventArgs e)
        {
            WalletsList.Visibility = Visibility.Visible;
            Wallet_Manager_Buttons.Visibility = Visibility.Visible;
            Menu_Buttons.Visibility = Visibility.Visible;

            amountDistrib.Text = "";
            privateKeyForDistrib.Text = "";

            Dark.Visibility = Visibility.Hidden;
            distribMenu.Visibility = Visibility.Hidden;
        }

        private void confirmDistrib_Click(object sender, EventArgs e)
        {
            decimal amount;

            try
            {
                amount = Convert.ToDecimal(amountDistrib.Text.Replace(".", ","));
            }
            catch
            {
                invalidAmount.Visibility = Visibility.Visible;
                return;
            }
            int count = 0;
            for (int i = 1; i < WalletsList.Items.Count; i++)
            {
                if ((bool)((Account)WalletsList.Items[i]).CB)
                    count++;
            }

            string key = privateKeyForDistrib.Text;

            key = key.Replace(" ", "");
            key = key.Replace("0x", "");
            int len = key.Length;
            if (len > 64)
            {
                PrivateKeyErrorDistr.Visibility = Visibility.Visible;
                return;
            }
            for (int i = 0; i < (64 - len); i++)
            {
                key = "0" + key;
            }
            try
            {
                StringToByteArray(key);
            }
            catch
            {
                PrivateKeyErrorDistr.Visibility = Visibility.Visible;
                return;
            }

            key = "0x" + key;
            Edwards25519 ed = new Edwards25519(StringToByteArray(key.Replace("0x", "")));
            SHA3_256 sha = new SHA3_256();
            byte[] publicKey = ed.PublicKey.Append<byte>(0).ToArray();
            string addr = "0x" + BitConverter.ToString(sha.ComputeVariable(publicKey)).Replace("-", "").ToLower();
            
            decimal bal = getBalance(addr);
            int chain_id = getChainId(node);
            Console.WriteLine(bal);
            Console.WriteLine((amount + (decimal)0.005) * count);
            if (bal < ((amount + (decimal)0.005) * count))
            {
                insufficientFunds.Visibility = Visibility.Visible;
                return;
            }

            string addrrec;
            ulong seq = getSequenceNumber(addr, node);

            for (int i = 0; i < WalletsList.Items.Count; i++)
            {


                if (((Account)WalletsList.Items[i]).CB)
                {
                    ((Account)WalletsList.Items[i]).CB = false;
                    addrrec = ((Account)WalletsList.Items[i]).address;
                    Dictionary<Object, Object> payload = new Dictionary<Object, Object> {
                                    {"function", "0x0000000000000000000000000000000000000000000000000000000000000001::aptos_account::transfer" },
                                    {"type_arguments", new List<Object>{ } },
                                    {"arguments", new List<Object>
                                    {
                                        addrrec,
                                        (UInt64)(amount*100000000)
                                    }
                                    },
                                    {"type", "entry_function_payload" }
                                };

                    List<int> keyEncoder = new List<int>()
                                {
                                    5,
                                    64
                                };


                    UInt64 maxGasAmount = 50000;
                    UInt64 gasUnitPrice = 100;
                    UInt64 expirationTimestampSecs = (UInt64)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds + 300;


                    Dictionary<Object, Object> rawTransaction = new Dictionary<object, object>
                                        {
                                    { "sender" , StringToByteArray(addr.Replace("0x","")) },
                                    { "sequence_number" , seq },
                                    { "payload" , payload },
                                    { "max_gas_amount" , maxGasAmount },
                                    { "gas_unit_price" , gasUnitPrice },
                                    { "expiration_timestamp_secs" , expirationTimestampSecs },



                                        };
                    minter(key, keyEncoder, rawTransaction, chain_id, node);
                    seq++;

                }


            }

            Menu_Buttons.Visibility = Visibility.Visible;
            WalletsList.Visibility = Visibility.Visible;
            Wallet_Manager_Buttons.Visibility = Visibility.Visible;
            amountDistrib.Text = "";
            privateKeyForDistrib.Text = "";
            
            System.Threading.Thread.Sleep(5000);
            refreshFunds();
            WalletsList.Items.Refresh();
            Dark.Visibility = Visibility.Hidden;
            distribMenu.Visibility = Visibility.Hidden;
            

        }
        private void refreshFunds()
        {
            
            for (int i = 0; i < WalletsList.Items.Count; i++)
            {
                ((Account)WalletsList.Items[i]).balance = Convert.ToString(getBalance(((Account)WalletsList.Items[i]).address));
                ((Account)WalletsList.Items[i]).NFT = Convert.ToString(getItems(((Account)WalletsList.Items[i]).address));
            }
            WalletsList.Items.Refresh();
        }

       

        private void refreshBalance_Click(object sender, EventArgs e)
        {
            refreshFunds();
        }

        private void Collect_wallets_Click(object sender, EventArgs e)
        {
            Dark.Visibility = Visibility.Visible;
            WalletsList.Visibility = Visibility.Hidden;
            Wallet_Manager_Buttons.Visibility = Visibility.Hidden;
            Menu_Buttons.Visibility = Visibility.Hidden;

            Dark.Source = BitmapToImageSource(getbmp());

            collectMenu.Visibility = Visibility.Visible;

        }

        private void cancelCollect_click(object sender, EventArgs e)
        {
            Menu_Buttons.Visibility = Visibility.Visible;
            WalletsList.Visibility = Visibility.Visible;
            Wallet_Manager_Buttons.Visibility = Visibility.Visible;

            collectAddress.Text = "";


            Dark.Visibility = Visibility.Hidden;
            collectMenu.Visibility = Visibility.Hidden;
        }

        private void confirmCollect_Click(object sender, EventArgs e)
        {
            string addressRec = collectAddress.Text;
            addressRec = addressRec.Replace(" ", "").Replace("0x", "");
            int len = addressRec.Length;
            if (len > 64)
            {
                invalidAddressCollect.Visibility = Visibility.Visible;
                return;
            }
            for (int i = 0; i < (64 - len); i++)
            {
                addressRec = "0" + addressRec;
            }
            try
            {
                StringToByteArray(addressRec);

            }
            catch
            {
                invalidAddressCollect.Visibility = Visibility.Visible;
                return;
            }
            addressRec = "0x" + addressRec;

            string keySender;
            string addrsend;
            ulong bal;
            ulong seq;
            int chain_id = getChainId(node);
            for (int i = 0; i < WalletsList.Items.Count; i++)
            {


                if (((Account)WalletsList.Items[i]).CB)
                {

                    ((Account)WalletsList.Items[i]).CB = false;
                    keySender = ((Account)WalletsList.Items[i]).privateKey;
                    addrsend = ((Account)WalletsList.Items[i]).address;
                    bal =  (ulong)(getBalance(addrsend) * 100000000);

                    if(bal == 0)
                    {
                        continue;
                    }
                    
                    Dictionary<Object, Object> payload = new Dictionary<Object, Object> {
                                    {"function", "0x0000000000000000000000000000000000000000000000000000000000000001::aptos_account::transfer" },
                                    {"type_arguments", new List<Object>{ } },
                                    {"arguments", new List<Object>
                                    {
                                        addressRec,
                                        (UInt64)(bal-541000)
                                    }
                                    },
                                    {"type", "entry_function_payload" }
                                };

                    List<int> keyEncoder = new List<int>()
                                {
                                    5,
                                    64
                                };


                    UInt64 maxGasAmount = 5410;
                    UInt64 gasUnitPrice = 100;
                    UInt64 expirationTimestampSecs = (UInt64)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds + 300;
                    seq = getSequenceNumber(addrsend, node);

                    Dictionary<Object, Object> rawTransaction = new Dictionary<object, object>
                                        {
                                    { "sender" , StringToByteArray(addrsend.Replace("0x","")) },
                                    { "sequence_number" , seq },
                                    { "payload" , payload },
                                    { "max_gas_amount" , maxGasAmount },
                                    { "gas_unit_price" , gasUnitPrice },
                                    { "expiration_timestamp_secs" , expirationTimestampSecs },



                                        };
                    minter(keySender, keyEncoder, rawTransaction, chain_id, node);


                }


            }

            Menu_Buttons.Visibility = Visibility.Visible;
            WalletsList.Visibility = Visibility.Visible;
            Wallet_Manager_Buttons.Visibility = Visibility.Visible;

            collectAddress.Text = "";
            System.Threading.Thread.Sleep(5000);

            refreshFunds();
            Dark.Visibility = Visibility.Hidden;
            collectMenu.Visibility = Visibility.Hidden;

        }

        private void CancelExportWallet_Click(object sender, RoutedEventArgs e)
        {
            
            WalletsList.Visibility = Visibility.Visible;
            Wallet_Manager_Buttons.Visibility = Visibility.Visible;
            Menu_Buttons.Visibility = Visibility.Visible;


            PrivateKeyExport.Text = "";
            ExportMenu.Visibility = Visibility.Hidden;
            Dark.Visibility = Visibility.Hidden;
        }

        private void exportWallets(object sender, RoutedEventArgs e)
        {
            string text = "";

            foreach(Account account in Accounts)
            {
                if (account.CB)
                    text += (account.privateKey + "\n");
            }

            Dark.Visibility = Visibility.Visible;
            WalletsList.Visibility = Visibility.Hidden;
            Wallet_Manager_Buttons.Visibility = Visibility.Hidden;
            Menu_Buttons.Visibility = Visibility.Hidden;

            Dark.Source = BitmapToImageSource(getbmp());
            PrivateKeyExport.Text = text;
            ExportMenu.Visibility = Visibility.Visible;


        }

        private void importWallets(object sender, RoutedEventArgs e)
        {
            string text = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                text = File.ReadAllText(openFileDialog.FileName);

            string[] wallets = text.Split('\n');

            foreach(string wallet in wallets)
            {
                try
                {
                    addWalletToUserData(wallet, "");
                    Add_wallet(wallet, "");
                }
                catch
                {
                    continue;
                }
            }

            

        }
        private void cancelSend_click(object sender, RoutedEventArgs e)
        {
            Menu_Buttons.Visibility = Visibility.Visible;
            WalletsList.Visibility = Visibility.Visible;
            Wallet_Manager_Buttons.Visibility = Visibility.Visible;
            addressForSend.Text = "";
            amountSend.Text = "";

            Dark.Visibility = Visibility.Hidden;
            sendingMenu.Visibility = Visibility.Hidden;
            invalidAmountSend.Visibility = Visibility.Hidden;
            AddressErrorSend.Visibility = Visibility.Hidden;
            insufficientFundsSend.Visibility = Visibility.Hidden;
        }
        private void confirmSend_click(object sender, RoutedEventArgs e)
        {
            string key = selectedWallet;

            decimal amount;

            try
            {
                amount = Convert.ToDecimal(amountSend.Text.Replace(".", ","));
            }
            catch
            {
                invalidAmountSend.Visibility = Visibility.Visible;
                return;
            }



            key = key.Replace(" ", "");
            key = key.Replace("0x", "");
            int len = key.Length;
            if (len > 64)
            {
                AddressErrorSend.Visibility = Visibility.Visible;
                return;
            }
            for (int i = 0; i < (64 - len); i++)
            {
                key = "0" + key;
            }


            key = "0x" + key;
            Edwards25519 ed = new Edwards25519(StringToByteArray(key.Replace("0x", "")));
            SHA3_256 sha = new SHA3_256();
            byte[] publicKey = ed.PublicKey.Append<byte>(0).ToArray();
            string addr = "0x" + BitConverter.ToString(sha.ComputeVariable(publicKey)).Replace("-", "").ToLower();

            decimal bal = getBalance(addr);
            int chain_id = getChainId(node);
            if (bal < (amount + (decimal)0.005))
            {
                insufficientFundsSend.Visibility = Visibility.Visible;
                return;
            }

            string addrrec = addressForSend.Text;
            ulong seq = getSequenceNumber(addr, node);





            Dictionary<Object, Object> payload = new Dictionary<Object, Object> {
                                    {"function", "0x0000000000000000000000000000000000000000000000000000000000000001::aptos_account::transfer" },
                                    {"type_arguments", new List<Object>{ } },
                                    {"arguments", new List<Object>
                                    {
                                        addrrec,
                                        (UInt64)(amount*100000000)
                                    }
                                    },
                                    {"type", "entry_function_payload" }
                                };

            List<int> keyEncoder = new List<int>()
                                {
                                    5,
                                    64
                                };


            UInt64 maxGasAmount = 50000;
            UInt64 gasUnitPrice = 100;
            UInt64 expirationTimestampSecs = (UInt64)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds + 300;


            Dictionary<Object, Object> rawTransaction = new Dictionary<object, object>
                                        {
                                    { "sender" , StringToByteArray(addr.Replace("0x","")) },
                                    { "sequence_number" , seq },
                                    { "payload" , payload },
                                    { "max_gas_amount" , maxGasAmount },
                                    { "gas_unit_price" , gasUnitPrice },
                                    { "expiration_timestamp_secs" , expirationTimestampSecs },



                                        };
            minter(key, keyEncoder, rawTransaction, chain_id, node);







            Menu_Buttons.Visibility = Visibility.Visible;
            WalletsList.Visibility = Visibility.Visible;
            Wallet_Manager_Buttons.Visibility = Visibility.Visible;
            addressForSend.Text = "";
            amountSend.Text = "";

            System.Threading.Thread.Sleep(5000);
            refreshFunds();
            WalletsList.Items.Refresh();
            Dark.Visibility = Visibility.Hidden;
            sendingMenu.Visibility = Visibility.Hidden;
            invalidAmountSend.Visibility = Visibility.Hidden;
            AddressErrorSend.Visibility = Visibility.Hidden;
            insufficientFundsSend.Visibility = Visibility.Hidden;



        }

        private void newName_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                submitEdit_Click(this, null);
                e.Handled = true;
            }
        }

        private void countOfWallets_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                submitGen_Click(this, null);
                e.Handled = true;
            }
        }

        private void privateKeyForDistrib_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                confirmDistrib_Click(this, null);
                e.Handled = true;
            }
        }

        private void addressForSend_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                confirmSend_click(this, null);
                e.Handled = true;
            }
        }

        private void collectAddress_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                confirmCollect_Click(this, null);
                e.Handled = true;
            }
        }

        private void setAccess(string token)
        {

            Dictionary<string, string> data;
            using (FileStream fs = File.OpenRead("userdata.dat"))
            {
                byte[] buffer = new byte[fs.Length];

                fs.Read(buffer, 0, buffer.Length);

                data = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, string>>(Encoding.Default.GetString(buffer));


            }
            data["token"] = token;

            string dataSer = System.Text.Json.JsonSerializer.Serialize(data);


            using (FileStream fs = new FileStream("userdata.dat", FileMode.Create))
            {
                byte[] buffer = Encoding.Default.GetBytes(dataSer);
                fs.Write(buffer, 0, buffer.Length);

            }
        }
        private void SetNewPrivateKey_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Holder = isHolder(AuthWallet.Text);
       
            setAccess(AuthWallet.Text);
        }
        private bool isHolder(string privateKey)
        {
            string addr;
            try
            {
                Edwards25519 ed25519 = new Edwards25519();
                ed25519.SetPrivateKey(StringToByteArray(privateKey.Replace("0x", "")));

                byte[] publicKey = ed25519.PublicKey.Append<byte>(0).ToArray();

                SHA3_256 sha = new SHA3_256();

                addr = "0x" + BitConverter.ToString(sha.ComputeVariable(publicKey)).Replace("-", "").ToLower();
            }
            catch
            {
                return false;
            }
            string data = "{\"query\":\"query getAccountCurrentTokens($address: String!, $offset: Int, $limit: Int) {\\n  current_token_ownerships(\\n    where: {owner_address: {_eq: $address}, amount: {_gt: 0}}\\n    order_by: [{last_transaction_version: desc}, {creator_address: desc}, {collection_name: desc}, {name: desc}]\\n    offset: $offset\\n    limit: $limit\\n  ) {\\n    amount\\n    current_token_data {\\n      ...TokenDataFields\\n    }\\n    current_collection_data {\\n      ...CollectionDataFields\\n    }\\n    last_transaction_version\\n    property_version\\n    token_properties\\n  }\\n}\\n\\nfragment TokenDataFields on current_token_datas {\\n  creator_address\\n  collection_name\\n  description\\n  metadata_uri\\n  name\\n  token_data_id_hash\\n  collection_data_id_hash\\n}\\n\\nfragment CollectionDataFields on current_collection_datas {\\n  metadata_uri\\n  supply\\n  description\\n  collection_name\\n  collection_data_id_hash\\n  table_handle\\n  creator_address\\n}\",\"variables\":{\"address\":\"" + addr + "\",\"limit\":9999,\"offset\":0},\"operationName\":\"getAccountCurrentTokens\"}";
            byte[] sentData = Encoding.ASCII.GetBytes(data);
            string sresp = "";
            WebRequest r = WebRequest.Create("https://indexer.mainnet.aptoslabs.com/v1/graphql");
            r.Method = "POST";
            r.Timeout = 120000;
            r.ContentType = "application/json";

            r.ContentLength = sentData.Length;
            Stream sendStream = r.GetRequestStream();
            sendStream.Write(sentData, 0, sentData.Length);
            sendStream.Close();
            try
            {

                WebResponse resp = r.GetResponse();
                Stream stream = resp.GetResponseStream();
                StreamReader sr = new StreamReader(stream);
                sresp = sr.ReadToEnd();
                


                resp.Dispose();
                
            }
            catch
            {
                return false;
            }
            Dictionary<string, Dictionary<string, List<Dictionary<string, object>>>> jsondata = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, List<Dictionary<string, object>>>>>(sresp);
            string addrCheck;
            foreach (Dictionary<string, object> token in jsondata["data"]["current_token_ownerships"])
            {
                addrCheck = JsonConvert.DeserializeObject<Dictionary<string, string>>(JsonConvert.SerializeObject(token["current_collection_data"]))["creator_address"];
                if (addrList.Contains(addrCheck))
                    return true;
            
            }
            return false;
            }

        private void Settings_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            SettingsMenu.Visibility = Visibility.Visible;
            MinterMenu.Visibility = Visibility.Hidden;
            SniperMenu.Visibility = Visibility.Hidden;
            Wallets_Menu.Visibility = Visibility.Hidden;
            HolderNotVerified.Visibility = Visibility.Hidden;
        }

        private void Wallets_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            SettingsMenu.Visibility = Visibility.Hidden;
            MinterMenu.Visibility = Visibility.Hidden;
            SniperMenu.Visibility = Visibility.Hidden;
            if (Holder)
            {
                Wallets_Menu.Visibility = Visibility.Visible;
                HolderNotVerified.Visibility = Visibility.Hidden;
            }
            else
            {
                Wallets_Menu.Visibility = Visibility.Hidden;
                HolderNotVerified.Visibility = Visibility.Visible;
            }
        }

        private void Sniper_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            SettingsMenu.Visibility = Visibility.Hidden;
            MinterMenu.Visibility = Visibility.Hidden;
            Wallets_Menu.Visibility = Visibility.Hidden;
            if (Holder)
            {
                SniperMenu.Visibility = Visibility.Visible;
                
                HolderNotVerified.Visibility = Visibility.Hidden;
            }
            else
            {
                SniperMenu.Visibility = Visibility.Hidden;
               
                HolderNotVerified.Visibility = Visibility.Visible;
            }
        }

        private void Minter_bot_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            CheckedAccounts = new List<Account>();
            foreach(Account acc in Accounts)
            {
                if(acc.CB)
                    CheckedAccounts.Add(acc);
            }
            ActiveWallets.ItemsSource = CheckedAccounts;
            ActiveWallets.Items.Refresh();
            SettingsMenu.Visibility = Visibility.Hidden;
            SniperMenu.Visibility = Visibility.Hidden;
            Wallets_Menu.Visibility = Visibility.Hidden;
            if (Holder)
            {
                MintModuleSettings.Visibility = Visibility.Hidden;
                MinterSelection.Visibility = Visibility.Visible;
                MinterMenu.Visibility = Visibility.Visible;
                HolderNotVerified.Visibility = Visibility.Hidden;
            }
            else
            {
             
                MinterMenu.Visibility = Visibility.Hidden;
                HolderNotVerified.Visibility = Visibility.Visible;
            }
        }

        private void SetNode_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            node = NodeInput.Text;
            if (node[node.Length - 1] != '\\' && node[node.Length - 1] != '/')
                node = node + "/";
            Dictionary<string, string> data;
            using (FileStream fs = File.OpenRead("userdata.dat"))
            {
                byte[] buffer = new byte[fs.Length];

                fs.Read(buffer, 0, buffer.Length);

                data = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, string>>(Encoding.Default.GetString(buffer));


            }
            data["node"] = node;

            string dataSer = System.Text.Json.JsonSerializer.Serialize(data);


            using (FileStream fs = new FileStream("userdata.dat", FileMode.Create))
            {
                byte[] buffer = Encoding.Default.GetBytes(dataSer);
                fs.Write(buffer, 0, buffer.Length);

            }
        }
        private void MinterSelectorButton_click(object sender, RoutedEventArgs e)
        {
            launchpad = ((System.Windows.Controls.Image)sender).Name;
            
            MintModuleSettings.Visibility = Visibility.Visible;
            MinterSelection.Visibility = Visibility.Hidden;
        }

        private void CancelMint_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MintModuleSettings.Visibility = Visibility.Hidden;
            MinterSelection.Visibility = Visibility.Visible;
        }

        private void ConfimrmMint_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Dictionary<object, object> payload = new Dictionary<object, object>();
            List<int> keyEncoder = new List<int>();
            string mintType;

            decimal mintPrice ;
            int gasUnitPrice;
            int gasLimit;
            string moduleAddress;
            string[] mintTime;
            string collectionName;
            try
            {
                
                mintType = ((ComboBoxItem)MintType.SelectedItem).Content.ToString();
    
                mintPrice = Convert.ToDecimal(MintPrice.Text.Replace(".", ","));
                gasUnitPrice = Convert.ToInt32(GasUP.Text);
                gasLimit = Convert.ToInt32(GasMax.Text);
                moduleAddress = ModAddr.Text;
                mintTime = MintTime.Text.Split('-');
                collectionName = CollectionName.Text;
            }
            catch
            {
                return;
            }
            switch (launchpad)
            {
                case "Topaz":

                    payload = new Dictionary<Object, Object> {
                        {"function", moduleAddress+"::launchpad_nft::mint" },
                        {"type_arguments", new List<Object>{ } },
                        {"arguments", new List<Object>
                        {
                            (UInt64)1
                        }
                        },
                        {"type", "entry_function_payload" }
                   };
                    keyEncoder = new List<int>
                   {
                       64
                   };
                    break;
                case "Souffl3":
                    switch (mintType)
                    {
                        case "Public":
                            payload = new Dictionary<Object, Object>
                            {
                                {"function", "0xa663d27aefe025179518b9f563273b31669940d63929dbdd11ea3e31bf864711::DropArm::public_sale_mint" },
                                {"type_arguments", new List<Object>{ } },
                                {"arguments", new List<Object>
                                {
                                    moduleAddress,
                                    collectionName,
                                    (UInt64)1
                                }
                                },
                                {"type", "entry_function_payload" }
                            };
                            keyEncoder = new List<int>
                           {
                               5,
                               4,
                               64
                           };
                            break;

                    }
                    break;
                case "Lmnft":

                    payload = new Dictionary<Object, Object>
                            {
                                {"function", "0x09b9812f618c67f447aeaa93605074433f2f11489e23d7e775f2d705d2f40f86::minting::mint" },
                                {"type_arguments", new List<Object>{ } },
                                {"arguments", new List<Object>
                                {
                                    moduleAddress,
                                    Convert.ToInt64(mintPrice*100000000),
                                    (UInt64)1,
                                    Encoding.UTF8.GetBytes("")
                                }
                                },
                                {"type", "entry_function_payload" }
                            };
                    keyEncoder = new List<int>
                           {
                               5,
                               64,
                               64,
                               1
                           };

                    break;
                case "BlueMove":
                    switch (mintType)
                    {
                        case "Public":
                            payload = new Dictionary<Object, Object>
                            {
                                {"function", moduleAddress+"::factory::mint_with_quantity" },
                                {"type_arguments", new List<Object>{ } },
                                {"arguments", new List<Object>
                                {
                                    (UInt64)1
                                }
                                },
                                {"type", "entry_function_payload" }
                            };
                            keyEncoder = new List<int>
                           {
                               64
                           };
                            break;
                        case "WL":
                            payload = new Dictionary<Object, Object>
                            {
                                {"function", moduleAddress+"::factory::mint_with_quantity_wl" },
                                {"type_arguments", new List<Object>{ } },
                                {"arguments", new List<Object>
                                {
                                    (UInt64)1
                                }
                                },
                                {"type", "entry_function_payload" }
                            };
                            keyEncoder = new List<int>
                           {
                               64
                           };
                            break;
                        case "OG":
                            payload = new Dictionary<Object, Object>
                            {
                                {"function", moduleAddress+"::factory::mint_with_quantity_og" },
                                {"type_arguments", new List<Object>{ } },
                                {"arguments", new List<Object>
                                {
                                    (UInt64)1
                                }
                                },
                                {"type", "entry_function_payload" }
                            };
                            keyEncoder = new List<int>
                           {
                               64
                           };
                            break;

                    }

                    break;
                case "Candy":


                    payload = new Dictionary<Object, Object>
                            {
                                {"function", "0xc071ef709539f7f9372f16050bf984fe6f11850594b8394f11bc74d22f48836b::candy_machine_v2::mint_tokens" },
                                {"type_arguments", new List<Object>{ } },
                                {"arguments", new List<Object>
                                {
                                    moduleAddress,
                                    collectionName,
                                    (UInt64)1
                                }
                                },
                                {"type", "entry_function_payload" }
                            };
                    keyEncoder = new List<int>
                           {
                                5,
                                4,
                                64
                           };


                    break;
            }
            logger = new Logger();
            logger.initMinter(payload, keyEncoder, mintType, mintPrice, gasUnitPrice, gasLimit, moduleAddress, mintTime, collectionName, node, CheckedAccounts);
            
        
        }

        

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (logger != null)
            {
                logger.End();
            }
        }
    }

    public class Account
    {
        public bool CB { get; set; }
        public string name { get; set; }
        public string privateKey { get; set; }
        public string address { get; set; }
        public string balance { get; set; }
        public string NFT { get; set; }
        public string hiddenPK { get; set; }
        public string hiddenAddr { get; set; }
        
        public Account(bool CB, string name, string privateKey, string address, string balance, string NFT)
        {
            this.CB = CB;
            this.name = name;
            this.privateKey = privateKey;
            this.address = address;
            this.balance = balance;
            this.NFT = NFT;
            string buff = "";
            buff += privateKey.Remove(6, privateKey.Length - 6);
            buff += "***";
            buff += privateKey.Remove(0, privateKey.Length - 4);

            hiddenPK = buff;
            buff = "";
            buff += address.Remove(6, address.Length - 6);
            buff += "***";
            buff += address.Remove(0, address.Length - 4);
            hiddenAddr = buff;



        }

        
        
      
    }

    public class WithdrawEvents
    {
        public string counter { get; set; }
        public Dictionary<string, Dictionary<string, string>> guid { get; set; }


    }
    public class DepositEvents
    {
        public string counter { get; set; }
        public Dictionary<string, Dictionary<string, string>> guid { get; set; }

    }
    public class ResponseBalanceData
    {
        public Dictionary<string, string> coin { get; set; }
        public DepositEvents deposit_events { get; set; }

        public bool frozen { get; set; }

        public WithdrawEvents withdraw_events { get; set; }

    }
    public class ResponseBalance
    {
        public string type { get; set; }
        public ResponseBalanceData data { get; set; }

    }

    public class LedgerInfo
    {
        public int chain_id { get; set; }
        public string epoch { get; set; }
        public string ledger_version { get; set; }
        public string oldest_ledger_version { get; set; }
        public string ledger_timestamp { get; set; }
        public string node_role { get; set; }
        public string oldest_block_height { get; set; }
        public string block_height { get; set; }
        public string git_hash { get; set; }
    }
    public class PointConverter
    {
        public static System.Windows.Point Convert(System.Drawing.Point value)
        {
            System.Drawing.Point dp = value;
            return new System.Windows.Point(dp.X, dp.Y);
        }

        public static System.Drawing.Point ConvertBack(System.Windows.Point value)
        {
            System.Windows.Point wp = value;
            return new System.Drawing.Point((int)wp.X, (int)wp.Y);
        }
    }
    [SuppressUnmanagedCodeSecurity]
    public static class ConsoleManager
    {
        private const string Kernel32_DllName = "kernel32.dll";

        [DllImport(Kernel32_DllName)]
        private static extern bool AllocConsole();

        [DllImport(Kernel32_DllName)]
        private static extern bool FreeConsole();

        [DllImport(Kernel32_DllName)]
        private static extern IntPtr GetConsoleWindow();

        [DllImport(Kernel32_DllName)]
        private static extern int GetConsoleOutputCP();

        public static bool HasConsole
        {
            get { return GetConsoleWindow() != IntPtr.Zero; }
        }

        /// <summary>
        /// Creates a new console instance if the process is not attached to a console already.
        /// </summary>
        public static void Show()
        {
            //#if DEBUG
            if (!HasConsole)
            {
                AllocConsole();
                InvalidateOutAndError();
            }
            //#endif
        }

        /// <summary>
        /// If the process has a console attached to it, it will be detached and no longer visible. Writing to the System.Console is still possible, but no output will be shown.
        /// </summary>
        public static void Hide()
        {
            //#if DEBUG
            if (HasConsole)
            {
                SetOutAndErrorNull();
                FreeConsole();
            }
            //#endif
        }

        public static void Toggle()
        {
            if (HasConsole)
            {
                Hide();
            }
            else
            {
                Show();
            }
        }

        static void InvalidateOutAndError()
        {
            Type type = typeof(System.Console);

            System.Reflection.FieldInfo _out = type.GetField("_out",
                System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);

            System.Reflection.FieldInfo _error = type.GetField("_error",
                System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);

            System.Reflection.MethodInfo _InitializeStdOutError = type.GetMethod("InitializeStdOutError",
                System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);

            Debug.Assert(_out != null);
            Debug.Assert(_error != null);

            Debug.Assert(_InitializeStdOutError != null);

            _out.SetValue(null, null);
            _error.SetValue(null, null);

            _InitializeStdOutError.Invoke(null, new object[] { true });
        }

        static void SetOutAndErrorNull()
        {
            Console.SetOut(TextWriter.Null);
            Console.SetError(TextWriter.Null);
        }
    }
}