using FloSDK.Exceptions;
using FloSDK.Methods;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FLO_web
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public static string DataAddress = "oRZcv1xaTiDra8sCGgJn3xEecn21L3uWmv";
        public string url = "https://testnet.flocha.in/tx/";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            string username = ConfigurationManager.AppSettings.Get("rpcusername");
            string password = ConfigurationManager.AppSettings.Get("rpcpassword");
            string wallet_url = ConfigurationManager.AppSettings.Get("wallet_url");
            string wallet_port = ConfigurationManager.AppSettings.Get("wallet_port");

            string DataAddress = "oRZcv1xaTiDra8sCGgJn3xEecn21L3uWmv";

            RpcMethods obj = new RpcMethods(username, password, wallet_url, wallet_port);

            try
            {

                string enteredText = enterbox.Text;

                string IDentifier = enteredIDentifier.Text;

                string flodatatosave = IDentifier + enteredText;


                // saving data to ledger

                JObject jobj = JObject.Parse(obj.SendToAddress(DataAddress, 0.1M, "stored data", "stored data", false, false, 1, "UNSET", flodatatosave));

                if (string.IsNullOrEmpty(jobj["error"].ToString()))
                {
                    url += jobj["result"];
                    lblMessage.Text = "Data Saved successfully to FLO";
                    lblMessage.ForeColor = Color.Blue;
                    lblMessage.Visible = true;
                    //linkLabel1.Visible = true;
                }
                else
                {
                    lblMessage.Text = "Error saving data to FLO";
                    lblMessage.ForeColor = Color.Red;
                    lblMessage.Visible = true;
                    //inkLabel1.Visible = false;
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
                //linkLabel1.Visible = false;
            }

            catch (Exception ex1)
            {
                Console.WriteLine("Exception :" + ex1.ToString());
                lblMessage.Text = "Error saving data to FLO";
                lblMessage.ForeColor = Color.Red;
                lblMessage.Visible = true;
                //linkLabel1.Visible = false;
            }
        }

        private void linkLabel1_LinkClicked(object sender)
        {
            System.Diagnostics.Process.Start(url);
        }

        protected void search_Click(object sender, EventArgs e)
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

                //string searchpattern = "MYDATA#7575";
                lblMessage2.Visible = false;
                Label2.Visible = false;
                fd.Visible = false;

                string searchpattern = identifier.Text;
                int  len= searchpattern.Length;
                
                int startBlock = 2104345;

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

                                            display += floData.Remove(0, len) + newLine;
                                        }
                                    }
                                }
                                if (string.IsNullOrEmpty(display))  
                                {
                                    lblMessage2.Text = "Data Does Not Exist";
                                    lblMessage2.ForeColor = Color.Red;
                                    lblMessage2.Visible = true;
                                }
                                else
                                {
                                    fd.Text = display;
                                    Label2.ForeColor = Color.DarkGreen;
                                    Label2.Visible=true;
                                    fd.Visible = true;
                                    lblMessage2.Visible = false;
                                }
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

        protected void identifier_TextChanged(object sender, EventArgs e)
        {

        }
    }
}