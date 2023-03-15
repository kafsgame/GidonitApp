using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;


namespace GidonitApp
{
    /// <summary>
    /// Логика взаимодействия для Logger.xaml
    /// </summary>
    public partial class Logger : Window
    {
        Thread th;
        public Logger()
        {
            InitializeComponent();
            Show();
            Activate();
        }
        public void End()
        {
            this.Close();
        }
        public void addText(string text)
        {
            this.Dispatcher.Invoke(() => {log.AppendText(text); });
        }
        public void initMinter(Dictionary<object, object> payload,
        List<int> keyEncoder,
        string mintType,
        decimal mintPrice,
        int gasUnitPrice,
        int gasLimit,
        string moduleAddress,
        string[] mintTime,
        string collectionName,
        string node,
        List<Account> CheckedAccounts)
        {
            
            Thread th = new Thread(() => start(payload, keyEncoder, mintType, mintPrice, gasUnitPrice, gasLimit, moduleAddress, mintTime, collectionName, node, CheckedAccounts));
            th.Start();

        }
        private void start(Dictionary<object, object> payload,
        List<int> keyEncoder,
        string mintType,
        decimal mintPrice,
        int gasUnitPrice,
        int gasLimit,
        string moduleAddress,
        string[] mintTime,
        string collectionName,
        string node,
        List<Account> CheckedAccounts
        )
        {
            bool alive = true;
            double wc = 0;
            string hello;
            string suc = "";


            addText("Waiting...\n");

            while((DateTime.Now - DateTime.Today.AddHours(Convert.ToInt32(mintTime[0])).AddMinutes(Convert.ToInt32(mintTime[1])).AddSeconds(Convert.ToInt32(mintTime[2]))).TotalSeconds < 0)
            {
                Thread.Sleep(1000);
            }
            for (int i = 0; i < 5000; i++)
            {
                if (!alive)
                {
                    break;
                }
                foreach (Account acc in CheckedAccounts)
                {

                    if (!IsVisible)
                    {
                        alive = false;
                        break;
                    }
                    UInt64 seq = MainWindow.getSequenceNumber(acc.address, node);


                    UInt64 expirationTimestampSecs = (UInt64)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds + 300;


                    Dictionary<Object, Object> rawTransaction = new Dictionary<object, object>
            {
                { "sender" , MainWindow.StringToByteArray(acc.address.Replace("0x","")) },
                { "sequence_number" , seq },
                { "payload" , payload },
                { "max_gas_amount" , (UInt64)gasLimit },
                { "gas_unit_price" , (UInt64)gasUnitPrice },
                { "expiration_timestamp_secs" , expirationTimestampSecs },



            };
                    int chain_id = MainWindow.getChainId(node);
                    if (MainWindow.minter(acc.privateKey, keyEncoder, rawTransaction, chain_id, node))
                        suc = "";
                    else
                        suc = "not";

                    Console.WriteLine(123123);
                    hello = acc.address + "-" + suc + " sent\n";

                    addText(hello);

                }
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(th != null)
            {
                th.Abort();
            }
        }
    }
}
