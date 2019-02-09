using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net; // Importing two extra namespaces these are required for online multiplayer
using System.Net.Sockets;
namespace Connect_Four
{
    public partial class Connect_Four : Form
    {// Declaring required variables        
        int totalCountersRed;
        int totalCountersYellow;
        bool red = true;
        bool host = false;
        bool singlePlayer = false;
        bool cubedVersion = false;
        char[] gameValues = new char[51]; // 0 - 48 is used to store the value all possible counter locations, 49 and 50 are used to hold game settings
        string winner = "";
        Button[] btn = new Button[49];        
        Random rnd = new Random(8);
        Socket sck;                 
        EndPoint epLocal, epRemote;
        public Connect_Four()
        {   // setting options for socket variable
            InitializeComponent();     
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp); 
            sck.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);            
        }        
        private void incomingData(IAsyncResult aResult)
        {        // incoming Data will run in the backgroud once connected to opponent and
            try  // will recieve any bytes sent by opponent and process them as required

            {
                int size = sck.EndReceiveFrom(aResult, ref epRemote);
                if (size > 0)
                {
                    byte[] recievedData = new byte[1500];
                    recievedData = (byte[])aResult.AsyncState;
                    ASCIIEncoding eEncoding = new ASCIIEncoding();
                    string recievedMessage = eEncoding.GetString(recievedData);
                    if (recievedMessage.Contains("btn["))
                    {
                        int i = recievedMessage[4];
                        i = i - 48;
                        
                        if (red == false)
                        {
                            counterBellowEmptyRed(i);
                        }
                        else // Yellow
                        {
                            counterBellowEmptyYellow(i);
                        }                       
                    }
                    if (red == false && !recievedMessage.Contains("btn["))
                    {
                        listMessage.Items.Add("Red: " + recievedMessage);

                    }
                    if (red == true && !recievedMessage.Contains("btn["))
                    {
                        listMessage.Items.Add("Yellow: " + recievedMessage);
                    }                    
                }
                byte[] buffer = new byte[1500];
                sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(incomingData), buffer);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
        }
        private void startConnectionBtn_Click(object sender, EventArgs e)
        {
            try
            {
                epLocal = new IPEndPoint(IPAddress.Parse(textLocalIP.Text), Convert.ToInt32(textLocalPort.Text));
                sck.Bind(epLocal); // Starts by binding the local and client ip address and port numbers to the Endpoints epLocal and epRemote
                epRemote = new IPEndPoint(IPAddress.Parse(client2IP.Text), Convert.ToInt32(client2Port.Text));
                sck.Connect(epRemote);                   
                byte[] buffer = new byte[1500]; // Creating a byte array and attempts to connect to the epRemote
                sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(incomingData), buffer);
                startConnectionBtn.Text = "Connected!";
                if (host == false)
                {// if sucessfull some propperties will change and incomingData will run in the background  
                    red = false;
                    onlineTurnLbl.Text = "Opponents Turn";
                }
                else
                {
                    onlineTurnLbl.Text = "Your Turn";
                    if (gameValues[49] == 'T')
                    {
                        sendMsgTBox.Text = "btn[49]"; 
                        sentMessageBtn.PerformClick();
                    }
                }               
                hostCBox.Enabled = false;
                startConnectionBtn.Enabled = false;
                singlePlayerCBox.Enabled = false;
                sentMessageBtn.Enabled = true;
                sendMsgTBox.Focus();
                startGame();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void sentMessageBtn_Click(object sender, EventArgs e)
        {
            try
            {
                System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
                byte[] msg = new byte[1500];
                msg = enc.GetBytes(sendMsgTBox.Text);
                sck.Send(msg);
                if (!sendMsgTBox.Text.Contains("btn["))
                {
                    listMessage.Items.Add("You: " + sendMsgTBox.Text);
                }                        
                sendMsgTBox.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }     
        private void PlayOfflineBtn_Click(object sender, EventArgs e)
        {
            startGame();
        }
        private void startGame()
        { // Sets up game 
            cubedVersionCBox.Visible = false;
            singlePlayerCBox.Visible = false;
            pictureBox1.Visible = false;
            PlayOfflineBtn.Visible = false;
            for (int i = 0; i < btn.Length; i++)
            {
                int index = i;
                this.btn[i] = new Button();
                this.btn[i].Visible = false;
                int x = 50 + (i % 7) * 50;
                int y = 90 + (i / 7) * 50;
                this.btn[i].Location = new System.Drawing.Point(x, y);
                this.btn[i].Name = "btn" + index;
                this.btn[i].Size = new System.Drawing.Size(50, 50);
                this.btn[i].TabIndex = i;
                this.btn[i].Text = "";
                this.btn[i].UseVisualStyleBackColor = true;
                this.btn[i].BackColor = Color.Black;
                this.btn[i].Visible = true;
                btn[i].Click += (sender1, ex) => this.btnHasBeenPressed(index);
                this.Controls.Add(btn[i]);
                gameValues[i] = 'E';
                
                if (red == false) // this stops none host playing first counter in online multiplayer 
                {                 // this does not affect offline as red always starts 
                    btn[i].Enabled = false;
                }
            }
        }
        private void counterBellowEmptyRed(int i)
        {// checks if counts bellow is empty and sets values for red
            totalCountersRed++;
            this.btn[i].BackColor = Color.Red;
            this.btn[i].Text = "R";
            for (int q = 0; q < 6; q++)
            {
                this.btn[i].BackColor = Color.Red;
                this.btn[i].Text = "";
                if (gameValues[i + 7] == 'E' && i < 49)
                {
                    this.btn[i].BackColor = Color.Black;
                    gameValues[i] = 'E';
                    this.btn[i + 7].BackColor = Color.Red;
                    this.btn[i + 7].Text = "";
                    gameValues[i + 7] = 'R';
                    if (i + 7 < 49)
                    {
                        i = i + 7;
                    }
                }
                else
                {
                    q = 6;
                }                
            }
            if (startConnectionBtn.Text == "Connected!")
            {
                for (int p = 0; p < 49; p++)
                {
                    btn[p].Enabled = true;
                }
                onlineTurnLbl.Text = "Your Turn";
            }
            hasPlayerWon();
        }
        private void counterBellowEmptyYellow(int i)
        {// checks if counts bellow is empty and sets values for red
            totalCountersYellow++;
            this.btn[i].BackColor = Color.Yellow;
            this.btn[i].Text = "";
            for (int q = 0; q < 6; q++)
            {
                this.btn[i].BackColor = Color.Yellow;
                this.btn[i].Text = "";
                if (gameValues[i + 7] == 'E' && i < 49)
                {
                    this.btn[i].BackColor = Color.Black;
                    gameValues[i] = 'E';
                    this.btn[i + 7].BackColor = Color.Yellow;
                    this.btn[i + 7].Text = "";
                    gameValues[i + 7] = 'Y';
                    if (i + 7 < 49)
                    {
                        i = i + 7;
                    }
                }
                else
                {
                    q = 6;
                }                
            }
            if (startConnectionBtn.Text == "Connected!")
            {
                for (int p = 0; p < 49; p++)
                {
                    btn[p].Enabled = true;
                }
                onlineTurnLbl.Text = "Your Turn";
            }            
            hasPlayerWon();
        }
        private void btnHasBeenPressed(int i)
        {
            Console.WriteLine("TEST: Button Number " + i + " has been pressed");
            if (i <= 6 && btn[i].BackColor == Color.Black)
            {                
                if (startConnectionBtn.Text != "Connected!")
                {// IF OFFLINE
                    if (red == true) // red
                    {
                        counterBellowEmptyRed(i);
                    }
                    else // Yellow
                    {
                        counterBellowEmptyYellow(i);
                    }
                    
                    if (singlePlayer == false)
                    {
                        red = !red;
                    }
                    else
                    {
                        if (i == 0 )
                        {
                            i = i + 1;
                        }
                        if (i == 6)
                        {
                            i = i - 1;
                        }
                        if (gameValues[i] == 'E' && gameValues[i-1] == 'E' && gameValues[i+1] == 'E')
                        {
                            i = rnd.Next(i - 1, i + 1);
                        }
                        
                        Console.WriteLine("TEST: Random number for single player Yellow is " + i);
                        counterBellowEmptyYellow(i);                    
                    }
                }                
                if (startConnectionBtn.Text == "Connected!")
                {// If ONline sends a message containting the number of the button pressed, this is hidden from the players
                    sendMsgTBox.Text = "btn[" + i + "]"; // in the chat list, this is done in the incomingData method and sendMessagebtn
                    sentMessageBtn.PerformClick();
                    if (host == true)
                    {
                        counterBellowEmptyRed(i);                        
                    }
                    else // Yellow
                    {
                        counterBellowEmptyYellow(i);
                    }                    
                    for (int p = 0; p < 49; p++)
                    {
                        btn[p].Enabled = false;
                    }
                    onlineTurnLbl.Text = "Opponents Turn";
                    hasPlayerWon();
                }                
            }
            else
            {
                MessageBox.Show("ERROR: Must inset counter on top row!");
            }
        }


        private void fourInALine(int a, int b, int c, int d, int e, int f, int g)
        { // checks if four buttons are the same value in a line using a character array
            if (gameValues[a] == gameValues[b] && gameValues[a] == gameValues[c] && gameValues[a] == gameValues[d] && gameValues[a] != 'E' && gameValues[a] == 'R' ||
                gameValues[b] == gameValues[c] && gameValues[b] == gameValues[d] && gameValues[b] == gameValues[e] && gameValues[b] != 'E' && gameValues[b] == 'R' ||
                gameValues[c] == gameValues[d] && gameValues[c] == gameValues[e] && gameValues[c] == gameValues[f] && gameValues[c] != 'E' && gameValues[c] == 'R' ||
                gameValues[d] == gameValues[e] && gameValues[d] == gameValues[f] && gameValues[e] == gameValues[g] && gameValues[d] != 'E' && gameValues[d] == 'R')
            {
                winner = "Red";
            }
            if (gameValues[a] == gameValues[b] && gameValues[a] == gameValues[c] && gameValues[a] == gameValues[d] && gameValues[a] != 'E' && gameValues[a] == 'Y' ||
                gameValues[b] == gameValues[c] && gameValues[b] == gameValues[d] && gameValues[b] == gameValues[e] && gameValues[b] != 'E' && gameValues[b] == 'Y' ||
                gameValues[c] == gameValues[d] && gameValues[c] == gameValues[e] && gameValues[c] == gameValues[f] && gameValues[c] != 'E' && gameValues[c] == 'Y' ||
                gameValues[d] == gameValues[e] && gameValues[d] == gameValues[f] && gameValues[e] == gameValues[g] && gameValues[d] != 'E' && gameValues[d] == 'Y')
            {
                winner = "Yellow";
            }
        }
        private void fourInACube(int a, int b, int c, int d, int e, int f, int g,
                                 int h, int i, int j, int k, int l, int m, int n)
        {// checks if four buttons are the same value in a cube using the character array
            if (gameValues[a] == gameValues[b] && gameValues[a] == gameValues[h] && gameValues[a] == gameValues[i] && gameValues[a] != 'E' && gameValues[a] == 'R' ||
                gameValues[b] == gameValues[c] && gameValues[b] == gameValues[i] && gameValues[c] == gameValues[j] && gameValues[b] != 'E' && gameValues[b] == 'R' ||
                gameValues[c] == gameValues[d] && gameValues[c] == gameValues[j] && gameValues[e] == gameValues[k] && gameValues[c] != 'E' && gameValues[c] == 'R' ||
                gameValues[d] == gameValues[e] && gameValues[d] == gameValues[k] && gameValues[d] == gameValues[l] && gameValues[d] != 'E' && gameValues[d] == 'R' ||
                gameValues[e] == gameValues[f] && gameValues[e] == gameValues[l] && gameValues[e] == gameValues[m] && gameValues[e] != 'E' && gameValues[e] == 'R' ||
                gameValues[f] == gameValues[g] && gameValues[f] == gameValues[m] && gameValues[f] == gameValues[n] && gameValues[f] != 'E' && gameValues[f] == 'R')
            {
                winner = "Red";
            }
            if (gameValues[a] == gameValues[b] && gameValues[a] == gameValues[h] && gameValues[a] == gameValues[i] && gameValues[a] != 'E' && gameValues[a] == 'Y' ||
                gameValues[b] == gameValues[c] && gameValues[b] == gameValues[i] && gameValues[c] == gameValues[j] && gameValues[b] != 'E' && gameValues[b] == 'Y' ||
                gameValues[c] == gameValues[d] && gameValues[c] == gameValues[j] && gameValues[e] == gameValues[k] && gameValues[c] != 'E' && gameValues[c] == 'Y' ||
                gameValues[d] == gameValues[e] && gameValues[d] == gameValues[k] && gameValues[d] == gameValues[l] && gameValues[d] != 'E' && gameValues[d] == 'Y' ||
                gameValues[e] == gameValues[f] && gameValues[e] == gameValues[l] && gameValues[e] == gameValues[m] && gameValues[e] != 'E' && gameValues[e] == 'Y' ||
                gameValues[f] == gameValues[g] && gameValues[f] == gameValues[m] && gameValues[f] == gameValues[n] && gameValues[f] != 'E' && gameValues[f] == 'Y')
            {
                winner = "Yellow";
            } 
        }
        
        private void singlePlayerCBox_CheckedChanged(object sender, EventArgs e)
        { // sets game propertey and dissables online menu items 
            singlePlayer = !singlePlayer;
            startConnectionBtn.Enabled = !startConnectionBtn.Enabled;
            sentMessageBtn.Enabled = !sentMessageBtn.Enabled;
            client1GBox.Enabled = !client1GBox.Enabled;
            client2GBox.Enabled = !client2GBox.Enabled;
            hostCBox.Enabled = !hostCBox.Enabled;
            if (singlePlayer == true)
            {
                gameValues[50] = 'T';
            }
            else
            {
                gameValues[50] = 'F';
            }
        }
        private void cubedVersionCBox_CheckedChanged(object sender, EventArgs e)
        {
            cubedVersion = !cubedVersion;
            if (cubedVersion == true)
            {
                gameValues[49] = 'T';
            }
            else
            {
                gameValues[49] = 'F';
            }
        }
        private void hostCBox_CheckedChanged(object sender, EventArgs e)
        {
            host = !host;
            textLocalPort.Text = "80";
            client2Port.Text = "81";
        }

        private void Connect_Four_Load(object sender, EventArgs e)
        {

        }
        private void hasPlayerWon()
        { // Calls to the 4InA Line & Cube methods the required times             
            fourInALine(0, 1, 2, 3, 4, 5, 6);        // four in rows
            fourInALine(7, 8, 9, 10, 11, 12, 13);
            fourInALine(14, 15, 16, 17, 18, 19, 20);
            fourInALine(21, 22, 23, 24, 25, 26, 27);
            fourInALine(28, 29, 30, 31, 32, 33, 34);
            fourInALine(35, 36, 37, 38, 39, 40, 41);
            fourInALine(42, 43, 44, 45, 46, 47, 48);
            fourInALine(0, 7, 14, 21, 28, 35, 42);   // four in columns
            fourInALine(1, 8, 15, 22, 29, 36, 43);
            fourInALine(2, 9, 16, 23, 30, 37, 44);
            fourInALine(3, 10, 17, 24, 31, 38, 45);
            fourInALine(4, 11, 18, 25, 32, 39, 46);
            fourInALine(5, 12, 19, 26, 33, 40, 47);
            fourInALine(6, 13, 20, 27, 34, 41, 48);
            fourInALine(21, 29, 37, 45, 0, 0, 0);    // four in diagonal lines 
            fourInALine(14, 22, 30, 38, 46, 0, 0); 
            fourInALine(7, 14, 23, 31, 39, 47, 0); 
            fourInALine(0, 8, 16, 24, 32, 40, 48);
            fourInALine(1, 9, 17, 25, 33, 41, 0); 
            fourInALine(2, 10, 18, 26, 34, 0, 0); 
            fourInALine(3, 11, 19, 27, 0, 0, 0); 
            fourInALine(3, 9, 15, 21, 0, 0, 0);
            fourInALine(4, 10, 16, 22, 28, 0, 0);
            fourInALine(5, 11, 17, 23, 29, 35, 0);
            fourInALine(6, 12, 18, 24, 30, 36, 42);
            fourInALine(20, 26, 32, 38, 44, 0, 0);
            fourInALine(27, 33, 39, 45, 0, 0, 0);
            fourInALine(27, 19, 11, 3, 0, 0, 0);
            fourInALine(34, 26, 18, 10, 2, 0, 0);
            fourInALine(41, 33, 25, 17, 9, 1, 0);
            fourInALine(48, 40, 32, 24, 16, 8, 0);
            fourInALine(47, 39, 31, 23, 15, 7, 0);
            fourInALine(46, 38, 30, 22, 14, 0, 0);
            fourInALine(45, 39, 33, 27, 0, 0, 0);
            fourInALine(45, 37, 29, 21, 0, 0, 0);
            fourInALine(44, 38, 32, 26, 20, 0, 0);
            fourInALine(43, 37, 31, 25, 19, 13, 0);
            fourInALine(42, 36, 30, 24, 18, 12, 0);
            fourInALine(35, 29, 23, 17, 11, 5, 0);
            fourInALine(21, 15, 9, 3, 0, 0, 0);
            if (cubedVersion == true)
            {
                fourInACube(35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48); // 1 
                fourInACube(28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41); // 2
                fourInACube(21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34); // 3
                fourInACube(14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27); // 4
                fourInACube(7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20); // 5
                fourInACube(0, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14); // 6
            }

            if (winner != "")
            {
                string title = "Play Again?";
                string message = "The Winner is " + winner + "!";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    for (int i = 0; i < 49; i++)
                    {
                        gameValues[i] = 'E';
                        this.btn[i].BackColor = Color.Black;
                    }
                    if (startConnectionBtn.Text != "Connected!")
                    {
                        red = true;
                    }                    
                    winner = "";
                    totalCountersRed = 0;
                    totalCountersYellow = 0;                    
                }
                if (result == DialogResult.No)
                {
                    this.Close();
                }
            }
        }        
    }
}
