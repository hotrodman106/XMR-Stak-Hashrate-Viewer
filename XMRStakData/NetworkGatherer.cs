using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XMR_Stak_Hashrate_Viewer
{
class NetworkGatherer
{
public static bool requiresLogin(Uri urlAddress, MinerObject miner)
{
try
{
HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
request.Timeout = 5000;
HttpWebResponse response = (HttpWebResponse)request.GetResponse();

if (response.StatusCode != HttpStatusCode.OK)
{
    throw new Exception("Request Error");

}
else
{
    return false;
}

}
catch (WebException ex)
{
if (ex.Message.Contains("401"))
{
    if (miner.usernameTemp != null && miner.passwordTemp != null)
    {
        miner.username = miner.usernameTemp;
        miner.password = miner.passwordTemp;
    }
    else
    {
        Program.mainPage.Invoke((MethodInvoker)delegate
        {
            LoginScreen l = new LoginScreen();
            l.Text = "Connect to: " + urlAddress.Authority;
            l.ShowDialog();
            miner.username = l.username;
            miner.password = CryptographyEngine.EncryptString(l.password, miner.uriApi.AbsolutePath);
        });
    }

    return true;
}
else
{
    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    Console.WriteLine(ex.Message);
    miner.connectionsuccess = false;
    return false;
}
}
}
public static List<List<string>> getNetData(Uri urlAddress, bool getHeaderData, MinerObject miner, int retries)
{
while(retries != 0) {
            try
            {
                if (miner.connectionsuccess == true)
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
                    request.Credentials = miner.credentialCache;
                    request.Timeout = 5000;
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    if (response.StatusCode == HttpStatusCode.OK)
                    {

                        Stream receiveStream = response.GetResponseStream();
                        StreamReader readStream = null;

                        if (response.CharacterSet == null)
                        {
                            readStream = new StreamReader(receiveStream);
                        }
                        else
                        {
                            readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                        }

                        if (getHeaderData)
                        {
                            string data = readStream.ReadToEnd();
                            Regex headerrgx = new Regex(@"(<th>([^<th>])*<\/th>)");
                            MatchCollection headerdataIn = headerrgx.Matches(data);
                            List<string> dataOut = new List<string>();
                            List<List<string>> output = new List<List<string>>();

                            int count = 0;

                            foreach (Match q in headerdataIn)
                            {
                                if (!q.Value.Equals("<th></th>") && !q.Value.Contains("10s") && !q.Value.Contains("60s") && !q.Value.Contains("15m"))
                                {
                                    string parsedString = q.Value.Replace("<th>", string.Empty).Replace("</th>", string.Empty).Replace(" ", string.Empty);
                                    dataOut.Add(parsedString.Remove(parsedString.IndexOf(":")));
                                }
                                count++;
                            }

                            output.Add(dataOut);
                            response.Close();
                            readStream.Close();

                            return output;
                        }
                        else
                        {
                            dynamic json = JsonConvert.DeserializeObject(readStream.ReadToEnd());
                            miner.xmrstakversion = json.version;
                            if (miner.xmrstakversion.Contains("xmr-stak"))
                            {
                                List<List<string>> threadhashrates = new List<List<string>>();

                                for (int i = 0; i != 4; i++)
                                {
                                    threadhashrates.Add(new List<string>());
                                }

                                foreach (JProperty hashrates in json.hashrate)
                                {
                                    if (hashrates.Name.Equals("threads"))
                                    {
                                        foreach (JArray values in hashrates.Value)
                                        {
                                            threadhashrates[0].Add(values.First.ToString());
                                        }
                                    }
                                    else if (hashrates.Name.Equals("total"))
                                    {
                                        threadhashrates[1].Add(hashrates.Value.First.ToString());
                                    }
                                    else
                                    {
                                        threadhashrates[1].Add(hashrates.Value.ToString());
                                    }
                                }

                                foreach (JProperty results in json.results)
                                {
                                    if (!results.Name.Equals("best"))
                                    {
                                        threadhashrates[2].Add(results.First.ToString());
                                    }
                                    else
                                    {
                                        break;
                                    }

                                }

                                foreach (JProperty connection in json.connection)
                                {
                                    if (!connection.Name.Equals("error_log"))
                                    {
                                        threadhashrates[3].Add(connection.First.ToString());
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }

                                response.Close();
                                readStream.Close();
                                return threadhashrates;
                            }
                            else
                            {
                                MessageBox.Show("Not a valid XMR-Stak Miner!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Console.WriteLine("Not a valid XMR-Stak Miner!");
                                return null;
                            }
                        }
                    }
                }
            }

            catch (Exception)
            {
                retries--;
                continue;
            }
}
    miner.connectionsuccess = false;
    return null;
}

public static List<double> getMoneroData(double totalHashrates, int retries)
{
while(retries != 0)
{
try
{
    List<double> moneroData = new List<double>();

    if (totalHashrates == 0)
    {
        moneroData.Add(0);
        moneroData.Add(0);

        return moneroData;
    }
    else
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri("https://api.nanopool.org/v1/xmr/approximated_earnings/" + totalHashrates.ToString()));
        request.Timeout = 5000;
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream receiveStream = response.GetResponseStream();
            StreamReader readStream = null;
            readStream = new StreamReader(receiveStream, Encoding.UTF8);

            dynamic json = JsonConvert.DeserializeObject(readStream.ReadToEnd());
            moneroData.Add(double.Parse(json["data"].prices["price_usd"].Value.ToString()));
            moneroData.Add(double.Parse(json["data"].week["dollars"].Value.ToString()));

            response.Close();
            readStream.Close();
            return moneroData;

    }
}
catch (Exception)
{
        retries--;
        continue;
}
}
return null;
}    
}
}
