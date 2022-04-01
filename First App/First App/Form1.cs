using FloSDK.Exceptions;
using FloSDK.Methods;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace First_App
{
    public partial class Form1 : Form
    {
        public static string DataAddress = "oRZcv1xaTiDra8sCGgJn3xEecn21L3uWmv";
        public string url = "https://testnet.flocha.in/tx/";

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void submit_Click(object sender, EventArgs e)
        {
            string username = ConfigurationManager.AppSettings.Get("rpcusername");
            string password = ConfigurationManager.AppSettings.Get("rpcpassword");
            string wallet_url = ConfigurationManager.AppSettings.Get("wallet_url");
            string wallet_port = ConfigurationManager.AppSettings.Get("wallet_port");

            RpcMethods obj = new RpcMethods(username, password, wallet_url, wallet_port);

            try
            {

                string enteredText = enterbox.Text;

                string flodatatosave = "MYDATA#7575" + enteredText;


                // saving data to ledger

                JObject jobj = JObject.Parse(obj.SendToAddress(DataAddress, 0.1M, "stored data", "stored data", false, false, 1, "UNSET", flodatatosave));

                if (string.IsNullOrEmpty(jobj["error"].ToString()))
                {
                    url += jobj["result"];
                    lblMessage.Text = "Data Saved successfully to FLO";
                    lblMessage.ForeColor = Color.Blue;
                    lblMessage.Visible = true;
                    linkLabel1.Visible = true;
                }
                else
                {
                    lblMessage.Text = "Error saving data to FLO";
                    lblMessage.ForeColor = Color.Red;
                    lblMessage.Visible = true;
                    linkLabel1.Visible = false;
                }


            }
            catch (RpcInternalServerErrorException ex)
            {
                var errCode = 0;
                var errMessage = string.Empty;

                if (ex.RpcErrorCode.GetHashCode() != 0)
                {
                    errCode = ex.RpcErrorCode.GetHashCode();
                    errMessage = ex.RpcErrorCode.ToString();

                }
                Console.WriteLine("Exception :" + errCode + "-" + errMessage);

                lblMessage.Text = "Error saving data to FLO";
                lblMessage.ForeColor = Color.Red;
                lblMessage.Visible = true;
                linkLabel1.Visible = false;
            }

            catch (Exception ex1)
            {
                Console.WriteLine("Exception :" + ex1.ToString());
                lblMessage.Text = "Error saving data to FLO";
                lblMessage.ForeColor = Color.Red;
                lblMessage.Visible = true;
                linkLabel1.Visible = false;
            }


        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(url);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void TID_TextChanged(object sender, EventArgs e)
        {

        }

        private void enterbox_TextChanged(object sender, EventArgs e)
        {

        }


        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void flodata_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void searchpattern_TextChanged(object sender, EventArgs e)
        {

        }

        private void search_Click(object sender, EventArgs e)
        {
            string username = ConfigurationManager.AppSettings.Get("rpcusername");
            string password = ConfigurationManager.AppSettings.Get("rpcpassword");
            string wallet_url = ConfigurationManager.AppSettings.Get("wallet_url");
            string wallet_port = ConfigurationManager.AppSettings.Get("wallet_port");

            RpcMethods obj = new RpcMethods(username, password, wallet_url, wallet_port);

            int searchcount = 0;
            int blockcount = 0;
            try
            {
                //get block count

                string searchpattern = "MYDATA#7575";

                int startBlock = 1993080;

                string floData = "";

                string display = "";

                JObject obj1 = JObject.Parse(obj.GetBlockCount());

                if (string.IsNullOrEmpty(obj1["error"].ToString()))
                {
                    blockcount = Convert.ToInt32(obj1["result"].ToString());
                }

                //iterate through all blocks

                for (int i = startBlock; i <= blockcount; i++)
                {
                    try
                    {
                        string blockhash = "";

                        obj1 = JObject.Parse(obj.GetBlockHash(i));

                        if (string.IsNullOrEmpty(obj1["error"].ToString()))
                        {
                            blockhash = obj1["result"].ToString();

                            JObject obj2 = JObject.Parse(obj.GetBlock(blockhash));

                            if (string.IsNullOrEmpty(obj2["error"].ToString()))
                            {
                                JArray txs = JArray.Parse(obj2["result"]["tx"].ToString());

                                //Iterate all transactions

                                //object[] display = new object[50];

                                List<object> mylist = new List<object>();

                                int count = 0;

                                foreach (JValue tx in txs)
                                {

                                    JObject obj3 = JObject.Parse(obj.GetRawTransaction(tx.ToString()));

                                    floData = obj3["result"]["floData"].ToString();


                                    if (floData.Contains(searchpattern))
                                    {
                                        searchcount++;
                                        count++;
                                        for (int x = 0; x < count; x++)
                                        {
                                            string newLine = Environment.NewLine;

                                            display += floData.Remove(0, 11) + newLine;
                                        }


                                    }
                                }


                                fd.Text = display;


                            }

                        }

                    }
                    catch (RpcInternalServerErrorException eu)
                    {
                        continue;
                    }
                    catch (Exception eu1)
                    {
                        continue;
                    }

                }

            }
            catch (RpcInternalServerErrorException ex)
            {
                var errCode = 0;
                var errMessage = string.Empty;

                if (ex.RpcErrorCode.GetHashCode() != 0)
                {
                    errCode = ex.RpcErrorCode.GetHashCode();
                    errMessage = ex.RpcErrorCode.ToString();

                }
                Console.WriteLine("Exception :" + errCode + "-" + errMessage);
            }

            catch (Exception ex1)
            {
                Console.WriteLine("Exception :" + ex1.ToString());
            }
        }
    }
}
