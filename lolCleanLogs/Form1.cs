using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lolCleanLogs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        static readonly string ProgramData = @"C:\ProgramData\Riot Games";
        private static readonly string Local = @"C:\Users\faruk\AppData\Local\RiotGames";
        string temp = Environment.GetEnvironmentVariable("TEMP");
        private string dirName;
        private string dirPath;
        private bool truePath;

        private void button1_Click_1(object sender, EventArgs e)
        {

            FolderBrowserDialog x = new FolderBrowserDialog();
            x.ShowDialog();
            dirPath = x.SelectedPath;

            if (x.SelectedPath.Contains("Riot Games\\League of Legends") ||
                x.SelectedPath.Contains("Riot Games\\lol") || x.SelectedPath.Contains("League of Legends") ||
                x.SelectedPath.Contains("lol"))
            {
                MessageBox.Show("True directory", "Success");
                truePath = true;
            }

            else
            {
                MessageBox.Show("Wrong directory!", "Error");
                truePath = false;
            }
        }

        private void cleanBtn_Click_1(object sender, EventArgs e)
        {
            // if league of legends path true
            if (truePath == true)
            {
                //close lol game
                string lolGame = "League of Legends";
                Process[] processX = Process.GetProcessesByName(lolGame);

                foreach (Process prs in processX)
                {
                    if (prs.ProcessName == lolGame)
                    {
                        prs.Kill();
                        break;
                    }
                }

                //close lol client
                string lol = "LeagueClient";
                Process[] process = Process.GetProcessesByName(lol);

                foreach (Process prs in process)
                {
                    if (prs.ProcessName == lol)
                    {
                        prs.Kill();
                        break;
                    }
                }

                // close lol login screen
                string riotClient = "RiotClientServices";
                Process[] riot = Process.GetProcessesByName(riotClient);

                foreach (Process prs in riot)
                {
                    if (prs.ProcessName == riotClient)
                    {
                        prs.Kill();
                        break;
                    }
                }

                try
                {
                    if (Directory.Exists(temp))
                    {
                        Directory.Delete(temp, true);
                        MessageBox.Show("Temp logs deleted!", "Success");
                        progressBar.Value = 50;
                    }
                    else if (!Directory.Exists(Local))
                    {
                        MessageBox.Show("Temp not found!", "Error");
                        progressBar.Value = 50;
                    }
                }
                catch (Exception exception)
                {


                }

                try
                {
                    string machine = "machine.cfg";
                    if (File.Exists(Path.Combine(ProgramData, machine)))
                    {
                        // If file found, delete it    
                        File.Delete(Path.Combine(ProgramData, machine));
                        MessageBox.Show("Machine.cfg deleted!");
                        progressBar.Value = 25;
                    }

                    else if (!File.Exists(Path.Combine(ProgramData, machine)))
                    {
                        MessageBox.Show("Machine.cfg not found!", "Success");
                        progressBar.Value = 25;
                    }
                }
                catch (Exception exception)
                {

                }

                try
                {
                    if (Directory.Exists(Local))
                    {
                        Directory.Delete(Local);
                        MessageBox.Show("Appdata logs deleted!", "Success");
                        progressBar.Value = 50;
                    }
                    else if (!Directory.Exists(Local))
                    {
                        MessageBox.Show("Appdata/RiotGames not found!", "Success");
                        progressBar.Value = 50;
                    }
                }
                catch (Exception exception)
                {

                }


                try
                {
                    string config = "Config";
                    string configdir = Path.Combine(dirPath, config);
                    if (Directory.Exists(configdir))
                    {
                        Directory.Delete(configdir, true);
                        MessageBox.Show("Configs deleted!", "Success");
                        progressBar.Value = 75;
                    }
                    else if (!Directory.Exists(configdir))
                    {
                        MessageBox.Show("Configs not found!", "Success");
                        progressBar.Value = 75;
                    }

                }
                catch (Exception exception)
                {
                    MessageBox.Show("For delete Config u need to close LoLClient.exe");

                }


                try
                {
                    string logs = "Logs";
                    string logsdir = Path.Combine(dirPath, logs);
                    if (Directory.Exists(logsdir))
                    {
                        Directory.Delete(logsdir, true);
                        MessageBox.Show("Logs deleted!", "Success");
                        progressBar.Value = 100;
                    }
                    else if (!Directory.Exists(logsdir))
                    {
                        MessageBox.Show("Logs not found!", "Success");
                        progressBar.Value = 100;
                    }

                }
                catch (Exception exception)
                {
                    MessageBox.Show("For delete logs u need to close LoLClient.exe");
                    Application.Exit();
                }

                MessageBox.Show("All logs successfuly deleted!");

            }

            if (truePath == false)
            {
                MessageBox.Show("Select a League of Legends directory!", "Error");
            }


        }

    }
}
