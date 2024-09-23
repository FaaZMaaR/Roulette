using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Collections;

class BidLabel : Label
{
    public BidLabel(int top, int left, Size size, Color color, string txt, RoulForm master) : base()
    {
        Top = top;
        Left = left;
        Size = size;
        BackColor = color;
        ForeColor = Color.White;
        Text = txt;
        TextAlign = ContentAlignment.MiddleCenter;
        BorderStyle = BorderStyle.Fixed3D;
        master.tablePan.Controls.Add(this);
        Click += (obj, ea) => {
            if ((Int32.Parse(master.bidtb.Text) > 0) & (this.ForeColor != Color.Yellow) & (Int32.Parse(master.bidtb.Text) <= master.playercaps))
            {
                this.ForeColor = Color.Yellow;
                master.bids.Enqueue(new string[] { this.Text, master.bidtb.Text });
                master.playerbid += Int32.Parse(master.bidtb.Text);
                master.playercaps -= Int32.Parse(master.bidtb.Text);
                master.caps.Text = "Фишки: " + master.playercaps;
                master.bid.Text = "Ставка: " + master.playerbid;
            }
        };
    }
}

class RoulForm : Form
{
    private Panel roulPan;
    public Panel tablePan;
    private Panel buttonPan;
    private Panel messagePan;
    private Panel bidPan;

    private PictureBox picbox;
    private Image roulimg;

    private BidLabel bid0;
    private BidLabel bid1;
    private BidLabel bid2;
    private BidLabel bid3;
    private BidLabel bid4;
    private BidLabel bid5;
    private BidLabel bid6;
    private BidLabel bid7;
    private BidLabel bid8;
    private BidLabel bid9;
    private BidLabel bid10;
    private BidLabel bid11;
    private BidLabel bid12;
    private BidLabel bid13;
    private BidLabel bid14;
    private BidLabel bid15;
    private BidLabel bid16;
    private BidLabel bid17;
    private BidLabel bid18;
    private BidLabel bid19;
    private BidLabel bid20;
    private BidLabel bid21;
    private BidLabel bid22;
    private BidLabel bid23;
    private BidLabel bid24;
    private BidLabel bid25;
    private BidLabel bid26;
    private BidLabel bid27;
    private BidLabel bid28;
    private BidLabel bid29;
    private BidLabel bid30;
    private BidLabel bid31;
    private BidLabel bid32;
    private BidLabel bid33;
    private BidLabel bid34;
    private BidLabel bid35;
    private BidLabel bid36;
    private BidLabel bid1_34;
    private BidLabel bid2_35;
    private BidLabel bid3_36;
    private BidLabel bid1st12;
    private BidLabel bid2nd12;
    private BidLabel bid3rd12;
    private BidLabel bid1to18;
    private BidLabel bideven;
    private BidLabel bidred;
    private BidLabel bidblack;
    private BidLabel bidodd;
    private BidLabel bid19to36;
    private int bidsize = 55;

    public Button roll;
    public Button clear;

    public Label caps = new Label();
    public Label bid = new Label();
    public Label result = new Label();
    public Label message;

    private Label bidlbl;
    public TextBox bidtb = new TextBox();
    private Button bidnull;
    private Button bidplus1;
    private Button bidplus10;
    private Button bidplus100;
    private Button bidplus1000;
    private Button bid1_4;
    private Button bid1_3;
    private Button bid1_2;
    private Button bid1_1;
    private int bidsize2 = 75;

    public double roulAngle = 0;
    public Random rnd = new Random();
    public int playercaps = 100;
    public int playerbid = 0;
    public Queue bids = new Queue();
    public bool isSpin = false;

    private bool checkClose = false;

    public RoulForm(string path) : base()
    {
        Size = new Size(1200, 1000);
        FormBorderStyle = FormBorderStyle.Fixed3D;
        StartPosition = FormStartPosition.CenterScreen;
        MaximizeBox = false;
        Text = "Roulette";
        Font = new Font("Arial", 14, FontStyle.Bold);

        roulPan = new Panel();
        roulPan.SetBounds(5, 5, 820, 820);
        roulPan.BorderStyle = BorderStyle.Fixed3D;
        Controls.Add(roulPan);
        picbox = new PictureBox();
        picbox.SetBounds(0, 0, roulPan.Width, roulPan.Height);
        roulPan.Controls.Add(picbox);
        roulimg = Image.FromFile(path);

        tablePan = new Panel();
        tablePan.Top = roulPan.Top;
        tablePan.Left = roulPan.Right;
        tablePan.Width = this.ClientSize.Width - roulPan.Width - 10;
        tablePan.Height = roulPan.Height;
        tablePan.BackColor = Color.Green;
        tablePan.BorderStyle = BorderStyle.Fixed3D;
        Controls.Add(tablePan);
        bid0 = new BidLabel(20, 150, new Size(3 * bidsize, bidsize), Color.Green, "0", this);
        bid1 = new BidLabel(bid0.Bottom, bid0.Left, new Size(bidsize, bidsize), Color.Red, "1", this);
        bid2 = new BidLabel(bid1.Top, bid1.Right, bid1.Size, Color.Black, "2", this);
        bid3 = new BidLabel(bid1.Top, bid2.Right, bid1.Size, Color.Red, "3", this);
        bid4 = new BidLabel(bid1.Bottom, bid1.Left, bid1.Size, Color.Black, "4", this);
        bid5 = new BidLabel(bid4.Top, bid4.Right, bid1.Size, Color.Red, "5", this);
        bid6 = new BidLabel(bid4.Top, bid5.Right, bid1.Size, Color.Black, "6", this);
        bid7 = new BidLabel(bid4.Bottom, bid1.Left, bid1.Size, Color.Red, "7", this);
        bid8 = new BidLabel(bid7.Top, bid7.Right, bid1.Size, Color.Black, "8", this);
        bid9 = new BidLabel(bid7.Top, bid8.Right, bid1.Size, Color.Red, "9", this);
        bid10 = new BidLabel(bid7.Bottom, bid1.Left, bid1.Size, Color.Black, "10", this);
        bid11 = new BidLabel(bid10.Top, bid10.Right, bid1.Size, Color.Black, "11", this);
        bid12 = new BidLabel(bid10.Top, bid11.Right, bid1.Size, Color.Red, "12", this);
        bid13 = new BidLabel(bid10.Bottom, bid1.Left, bid1.Size, Color.Black, "13", this);
        bid14 = new BidLabel(bid13.Top, bid13.Right, bid1.Size, Color.Red, "14", this);
        bid15 = new BidLabel(bid13.Top, bid14.Right, bid1.Size, Color.Black, "15", this);
        bid16 = new BidLabel(bid13.Bottom, bid1.Left, bid1.Size, Color.Red, "16", this);
        bid17 = new BidLabel(bid16.Top, bid16.Right, bid1.Size, Color.Black, "17", this);
        bid18 = new BidLabel(bid16.Top, bid17.Right, bid1.Size, Color.Red, "18", this);
        bid19 = new BidLabel(bid16.Bottom, bid1.Left, bid1.Size, Color.Red, "19", this);
        bid20 = new BidLabel(bid19.Top, bid19.Right, bid1.Size, Color.Black, "20", this);
        bid21 = new BidLabel(bid19.Top, bid20.Right, bid1.Size, Color.Red, "21", this);
        bid22 = new BidLabel(bid19.Bottom, bid1.Left, bid1.Size, Color.Black, "22", this);
        bid23 = new BidLabel(bid22.Top, bid22.Right, bid1.Size, Color.Red, "23", this);
        bid24 = new BidLabel(bid22.Top, bid23.Right, bid1.Size, Color.Black, "24", this);
        bid25 = new BidLabel(bid22.Bottom, bid1.Left, bid1.Size, Color.Red, "25", this);
        bid26 = new BidLabel(bid25.Top, bid25.Right, bid1.Size, Color.Black, "26", this);
        bid27 = new BidLabel(bid25.Top, bid26.Right, bid1.Size, Color.Red, "27", this);
        bid28 = new BidLabel(bid25.Bottom, bid1.Left, bid1.Size, Color.Black, "28", this);
        bid29 = new BidLabel(bid28.Top, bid28.Right, bid1.Size, Color.Black, "29", this);
        bid30 = new BidLabel(bid28.Top, bid29.Right, bid1.Size, Color.Red, "30", this);
        bid31 = new BidLabel(bid28.Bottom, bid1.Left, bid1.Size, Color.Black, "31", this);
        bid32 = new BidLabel(bid31.Top, bid31.Right, bid1.Size, Color.Red, "32", this);
        bid33 = new BidLabel(bid31.Top, bid32.Right, bid1.Size, Color.Black, "33", this);
        bid34 = new BidLabel(bid31.Bottom, bid1.Left, bid1.Size, Color.Red, "34", this);
        bid35 = new BidLabel(bid34.Top, bid34.Right, bid1.Size, Color.Black, "35", this);
        bid36 = new BidLabel(bid34.Top, bid35.Right, bid1.Size, Color.Red, "36", this);
        bid1_34 = new BidLabel(bid34.Bottom, bid1.Left, bid1.Size, Color.Green, "2TO1", this);
        bid1_34.Font = new Font("Arial", 12, FontStyle.Bold);
        bid2_35 = new BidLabel(bid1_34.Top, bid1_34.Right, bid1.Size, Color.Green, "2ТO1", this);
        bid2_35.Font = new Font("Arial", 12, FontStyle.Bold);
        bid3_36 = new BidLabel(bid1_34.Top, bid2_35.Right, bid1.Size, Color.Green, "2TО1", this);
        bid3_36.Font = new Font("Arial", 12, FontStyle.Bold);
        bid1st12 = new BidLabel(bid1.Top, bid1.Left - bidsize, new Size(bidsize, 4 * bidsize), Color.Green, "1\nST\n12", this);
        bid2nd12 = new BidLabel(bid1st12.Bottom, bid1st12.Left, bid1st12.Size, Color.Green, "2\nND\n12", this);
        bid3rd12 = new BidLabel(bid2nd12.Bottom, bid1st12.Left, bid1st12.Size, Color.Green, "3\nRD\n12", this);
        bid1to18 = new BidLabel(bid1.Top, bid1st12.Left - bidsize, new Size(bidsize, 2 * bidsize), Color.Green, "1\nTO\n18", this);
        bideven = new BidLabel(bid1to18.Bottom, bid1to18.Left, bid1to18.Size, Color.Green, "EVEN", this);
        bideven.Font = new Font("Arial", 12, FontStyle.Bold);
        bidred = new BidLabel(bideven.Bottom, bid1to18.Left, bid1to18.Size, Color.Red, "R", this);
        bidblack = new BidLabel(bidred.Bottom, bid1to18.Left, bid1to18.Size, Color.Black, "B", this);
        bidodd = new BidLabel(bidblack.Bottom, bid1to18.Left, bid1to18.Size, Color.Green, "ODD", this);
        bidodd.Font = new Font("Arial", 12, FontStyle.Bold);
        bid19to36 = new BidLabel(bidodd.Bottom, bid1to18.Left, bid1to18.Size, Color.Green, "19\nTO\n36", this);

        buttonPan = new Panel();
        buttonPan.Top = roulPan.Bottom;
        buttonPan.Left = roulPan.Left;
        buttonPan.Width = 250;
        buttonPan.Height = this.ClientSize.Height - roulPan.Height - 10;
        buttonPan.BorderStyle = BorderStyle.Fixed3D;
        Controls.Add(buttonPan);
        roll = new Button();
        roll.Top = 10;
        roll.Left = 50;
        roll.Size = new Size(buttonPan.Width - 100, (buttonPan.Height - 30) / 2);
        roll.Text = "Крутить";
        roll.Font = new Font("Arial", 12, FontStyle.Bold);
        buttonPan.Controls.Add(roll);
        clear = new Button();
        clear.Top = roll.Bottom + 10;
        clear.Left = roll.Left;
        clear.Size = roll.Size;
        clear.Text = "Сбросить ставку";
        clear.Font = new Font("Arial", 12, FontStyle.Bold);
        buttonPan.Controls.Add(clear);

        messagePan = new Panel();
        messagePan.Top = buttonPan.Top;
        messagePan.Left = buttonPan.Right;
        messagePan.Width = roulPan.Width - buttonPan.Width;
        messagePan.Height = buttonPan.Height;
        messagePan.BorderStyle = BorderStyle.Fixed3D;
        Controls.Add(messagePan);
        caps.Left = 5;
        caps.Top = 5;
        caps.Size = new Size((messagePan.Width - 15) / 2, (messagePan.Height - 15) / 2);
        caps.BackColor = Color.Green;
        caps.ForeColor = Color.White;
        caps.Text = "Фишки: " + playercaps;
        caps.TextAlign = ContentAlignment.MiddleLeft;
        messagePan.Controls.Add(caps);
        bid.Top = caps.Top;
        bid.Left = caps.Right + 5;
        bid.Size = caps.Size;
        bid.BackColor = Color.Green;
        bid.ForeColor = Color.White;
        bid.Text = "Ставка: " + playerbid;
        bid.TextAlign = ContentAlignment.MiddleLeft;
        messagePan.Controls.Add(bid);
        result.Top = caps.Bottom + 5;
        result.Left = caps.Left;
        result.Size = new Size(caps.Height, caps.Height);
        result.BackColor = Color.Green;
        result.ForeColor = Color.White;
        result.Text = "0";
        result.TextAlign = ContentAlignment.MiddleCenter;
        messagePan.Controls.Add(result);
        message = new Label();
        message.Left = result.Right + 5;
        message.Top = result.Top;
        message.Size = new Size((messagePan.Width - 15 - result.Height), result.Height);
        message.BackColor = Color.Green;
        message.ForeColor = Color.White;
        message.Text = "Сделайте ставку...";
        message.TextAlign = ContentAlignment.MiddleCenter;
        messagePan.Controls.Add(message);

        bidPan = new Panel();
        bidPan.Top = buttonPan.Top;
        bidPan.Left = messagePan.Right;
        bidPan.Width = tablePan.Width;
        bidPan.Height = buttonPan.Height;
        bidPan.BorderStyle = BorderStyle.Fixed3D;
        Controls.Add(bidPan);
        bidlbl = new Label();
        bidlbl.Top = 5;
        bidlbl.Left = 5;
        bidlbl.Size = new Size((bidPan.Width - 10), (bidPan.Height - 25) / 4);
        bidlbl.Text = "Ставка";
        bidlbl.TextAlign = ContentAlignment.MiddleCenter;
        bidPan.Controls.Add(bidlbl);
        bidtb.Top = bidlbl.Bottom + 5;
        bidtb.Left = bidlbl.Left;
        bidtb.Size = new Size((bidPan.Width - 15 - bidsize2), bidlbl.Height);
        bidtb.Text = "0";
        bidPan.Controls.Add(bidtb);
        bidnull = new Button();
        bidnull.SetBounds(bidtb.Right + 5, bidtb.Top, bidsize2, bidlbl.Height);
        bidnull.Text = "0";
        bidPan.Controls.Add(bidnull);
        bidplus1 = new Button();
        bidplus1.Top = bidtb.Bottom + 5;
        bidplus1.Left = bidtb.Left;
        bidplus1.Size = bidnull.Size;
        bidplus1.Text = "+1";
        bidPan.Controls.Add(bidplus1);
        bidplus10 = new Button();
        bidplus10.Top = bidplus1.Top;
        bidplus10.Left = bidplus1.Right + 5;
        bidplus10.Size = bidnull.Size;
        bidplus10.Text = "+10";
        bidPan.Controls.Add(bidplus10);
        bidplus100 = new Button();
        bidplus100.Top = bidplus1.Bottom + 5;
        bidplus100.Left = bidtb.Left;
        bidplus100.Size = bidnull.Size;
        bidplus100.Text = "+100";
        bidPan.Controls.Add(bidplus100);
        bidplus1000 = new Button();
        bidplus1000.Top = bidplus100.Top;
        bidplus1000.Left = bidplus100.Right + 5;
        bidplus1000.Size = bidnull.Size;
        bidplus1000.Text = "+1000";
        bidPan.Controls.Add(bidplus1000);
        bid1_3 = new Button();
        bid1_3.Left = bidnull.Left;
        bid1_3.Top = bidplus1.Top;
        bid1_3.Size = bidnull.Size;
        bid1_3.Text = "1/3";
        bidPan.Controls.Add(bid1_3);
        bid1_4 = new Button();
        bid1_4.Left = bid1_3.Left - bidsize2 - 5;
        bid1_4.Top = bid1_3.Top;
        bid1_4.Size = bidnull.Size;
        bid1_4.Text = "1/4";
        bidPan.Controls.Add(bid1_4);
        bid1_2 = new Button();
        bid1_2.Left = bid1_4.Left;
        bid1_2.Top = bid1_4.Bottom + 5;
        bid1_2.Size = bidnull.Size;
        bid1_2.Text = "1/2";
        bidPan.Controls.Add(bid1_2);
        bid1_1 = new Button();
        bid1_1.Left = bid1_3.Left;
        bid1_1.Top = bid1_2.Top;
        bid1_1.Size = bidnull.Size;
        bid1_1.Text = "1/1";
        bidPan.Controls.Add(bid1_1);

        this.Load += (obj, ea) => {
            (new Thread(() => {
                while (true)
                {
                    picbox.Invalidate();
                    Thread.Sleep(20);
                }
            })).Start();
        };
        this.FormClosed += (obj, ea) => {
            checkClose = true;
        };

        picbox.Paint += (obj, ea) => {
            DrawRoulette(ea.Graphics);
        };

        roll.Click += (obj, ea) => {
            isSpin = true;
        };
        clear.Click += (obj, ea) => {
            playercaps += playerbid;
            playerbid = 0;
            bids.Clear();
            caps.Text = "Фишки: " + playercaps;
            bid.Text = "Ставка: " + playerbid;
            ClearBids();
        };

        bidnull.Click += (obj, ea) => { bidtb.Text = "0"; };
        bidplus1.Click += (obj, ea) => {
            int num = Int32.Parse(bidtb.Text);
            bidtb.Text = (num + 1) + "";
        };
        bidplus10.Click += (obj, ea) => {
            int num = Int32.Parse(bidtb.Text);
            bidtb.Text = (num + 10) + "";
        };
        bidplus100.Click += (obj, ea) => {
            int num = Int32.Parse(bidtb.Text);
            bidtb.Text = (num + 100) + "";
        };
        bidplus1000.Click += (obj, ea) => {
            int num = Int32.Parse(bidtb.Text);
            bidtb.Text = (num + 1000) + "";
        };
        bid1_4.Click += (obj, ea) => {
            int num = playercaps;
            bidtb.Text = playercaps / 4 + "";
        };
        bid1_3.Click += (obj, ea) => {
            int num = playercaps;
            bidtb.Text = playercaps / 3 + "";
        };
        bid1_2.Click += (obj, ea) => {
            int num = playercaps;
            bidtb.Text = playercaps / 2 + "";
        };
        bid1_1.Click += (obj, ea) => {
            int num = playercaps;
            bidtb.Text = playercaps + "";
        };
    }

    public void SwitchButtons()
    {
        roll.Invoke(new Action(() => roll.Enabled = (roll.Enabled) ? false : true));
        clear.Invoke(new Action(() => clear.Enabled = (clear.Enabled) ? false : true));
    }

    public void DrawRoulette(Graphics g)
    {
        g.Clear(Color.Green);
        g.TranslateTransform(picbox.Width / 2, picbox.Height / 2);
        g.RotateTransform((float)(roulAngle));
        g.TranslateTransform(-picbox.Width / 2, -picbox.Height / 2);
        g.DrawImage(roulimg, 0, 0);
        g.TranslateTransform(picbox.Width / 2, picbox.Height / 2);
        g.RotateTransform(-(float)(roulAngle));
        g.TranslateTransform(-picbox.Width / 2, -picbox.Height / 2);
        g.FillPolygon(new SolidBrush(Color.Blue), new Point[] { new Point(picbox.Width / 2 - 8, picbox.Height / 2), new Point(picbox.Width / 2 + 8, picbox.Height / 2), new Point(picbox.Width / 2, 600) });
        if (checkClose)
        {
            g.Dispose();
            roulimg.Dispose();
            Application.Exit();
        }
    }

    public int CalcCaps(string[] bid)
    {
        int s = 0;
        switch (bid[0])
        {
            case "1\nTO\n18":
            case "19\nTO\n36":
            case "EVEN":
            case "ODD":
            case "R":
            case "B":
                s = Int32.Parse(bid[1]) * 2;
                break;
            case "1\nST\n12":
            case "2\nND\n12":
            case "3\nRD\n12":
            case "2TO1":
            case "2ТO1":
            case "2TО1":
                s = Int32.Parse(bid[1]) * 3;
                break;
            default:
                s = Int32.Parse(bid[1]) * 37;
                break;
        }
        return s;
    }

    public void ClearBids()
    {
        bid0.ForeColor = Color.White;
        bid1.ForeColor = Color.White;
        bid2.ForeColor = Color.White;
        bid3.ForeColor = Color.White;
        bid4.ForeColor = Color.White;
        bid5.ForeColor = Color.White;
        bid6.ForeColor = Color.White;
        bid7.ForeColor = Color.White;
        bid8.ForeColor = Color.White;
        bid9.ForeColor = Color.White;
        bid10.ForeColor = Color.White;
        bid11.ForeColor = Color.White;
        bid12.ForeColor = Color.White;
        bid13.ForeColor = Color.White;
        bid14.ForeColor = Color.White;
        bid15.ForeColor = Color.White;
        bid16.ForeColor = Color.White;
        bid17.ForeColor = Color.White;
        bid18.ForeColor = Color.White;
        bid19.ForeColor = Color.White;
        bid20.ForeColor = Color.White;
        bid21.ForeColor = Color.White;
        bid22.ForeColor = Color.White;
        bid23.ForeColor = Color.White;
        bid24.ForeColor = Color.White;
        bid25.ForeColor = Color.White;
        bid26.ForeColor = Color.White;
        bid27.ForeColor = Color.White;
        bid28.ForeColor = Color.White;
        bid29.ForeColor = Color.White;
        bid30.ForeColor = Color.White;
        bid31.ForeColor = Color.White;
        bid32.ForeColor = Color.White;
        bid33.ForeColor = Color.White;
        bid34.ForeColor = Color.White;
        bid35.ForeColor = Color.White;
        bid36.ForeColor = Color.White;
        bid1_34.ForeColor = Color.White;
        bid2_35.ForeColor = Color.White;
        bid3_36.ForeColor = Color.White;
        bid1st12.ForeColor = Color.White;
        bid2nd12.ForeColor = Color.White;
        bid3rd12.ForeColor = Color.White;
        bid1to18.ForeColor = Color.White;
        bid19to36.ForeColor = Color.White;
        bideven.ForeColor = Color.White;
        bidodd.ForeColor = Color.White;
        bidred.ForeColor = Color.White;
        bidblack.ForeColor = Color.White;
    }
}