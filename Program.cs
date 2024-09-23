using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;
using System.Threading;

class Master
{
    public RoulForm rf;
    private int time;
    private string imgpath;
    private ArrayList numsodd = new ArrayList();
    private ArrayList numseven = new ArrayList();
    private ArrayList nums1_18 = new ArrayList();
    private ArrayList nums19_36 = new ArrayList();
    private ArrayList nums1_12 = new ArrayList();
    private ArrayList nums13_24 = new ArrayList();
    private ArrayList nums25_36 = new ArrayList();
    private ArrayList nums1_34 = new ArrayList();
    private ArrayList nums2_35 = new ArrayList();
    private ArrayList nums3_36 = new ArrayList();

    public Master(int t, string path)
    {
        time = t;
        imgpath = path;
        rf = new RoulForm(imgpath);
        for (int i = 1; i <= 18; i++)
        {
            numsodd.Add(2 * i - 1);
            numseven.Add(2 * i);
            nums1_18.Add(i);
            nums19_36.Add(i + 18);
        }
        for (int i = 1; i <= 12; i++)
        {
            nums1_12.Add(i);
            nums13_24.Add(i + 12);
            nums25_36.Add(i + 24);
            nums1_34.Add(3 * i - 2);
            nums2_35.Add(3 * i - 1);
            nums3_36.Add(3 * i);
        }
    }
    public void Update()
    {
        if (!rf.isSpin) return;
        double max = 10 - rf.rnd.NextDouble() * 2;
        double dif = 0.3;
        double mul=1.015;
        int k = 0;
        double piece = 360.0 / 37.0;
        string res = "";
        string[] curbid;
        int bidsamount = rf.bids.Count;
        int pay = 0;

        rf.SwitchButtons();

        rf.message.Invoke(new Action(() => rf.message.Text = "Крутим рулетку..."));
        
        Thread.Sleep(time);
        while (k < 10000/time)
        {            
            if(k==0 && dif < max)
            {
                dif *= mul;                
            }
            else if (k < 5000 / time)
            {
                k++;
            }
            else
            {
                k++;
                dif /= mul;
            }
            rf.roulAngle += dif;
            Thread.Sleep(time);
        }
        rf.roulAngle %= 360;
        if (rf.roulAngle < piece) res = "0 green";
        else if (rf.roulAngle < (double)(piece * 2)) res = "26 black";
        else if (rf.roulAngle < (double)(piece * 3)) res = "3 red";
        else if (rf.roulAngle < (double)(piece * 4)) res = "35 black";
        else if (rf.roulAngle < (double)(piece * 5)) res = "12 red";
        else if (rf.roulAngle < (double)(piece * 6)) res = "28 black";
        else if (rf.roulAngle < (double)(piece * 7)) res = "7 red";
        else if (rf.roulAngle < (double)(piece * 8)) res = "29 black";
        else if (rf.roulAngle < (double)(piece * 9)) res = "18 red";
        else if (rf.roulAngle < (double)(piece * 10)) res = "22 black";
        else if (rf.roulAngle < (double)(piece * 11)) res = "9 red";
        else if (rf.roulAngle < (double)(piece * 12)) res = "31 black";
        else if (rf.roulAngle < (double)(piece * 13)) res = "14 red";
        else if (rf.roulAngle < (double)(piece * 14)) res = "20 black";
        else if (rf.roulAngle < (double)(piece * 15)) res = "1 red";
        else if (rf.roulAngle < (double)(piece * 16)) res = "33 black";
        else if (rf.roulAngle < (double)(piece * 17)) res = "16 red";
        else if (rf.roulAngle < (double)(piece * 18)) res = "24 black";
        else if (rf.roulAngle < (double)(piece * 19)) res = "5 red";
        else if (rf.roulAngle < (double)(piece * 20)) res = "10 black";
        else if (rf.roulAngle < (double)(piece * 21)) res = "23 red";
        else if (rf.roulAngle < (double)(piece * 22)) res = "8 black";
        else if (rf.roulAngle < (double)(piece * 23)) res = "30 red";
        else if (rf.roulAngle < (double)(piece * 24)) res = "11 black";
        else if (rf.roulAngle < (double)(piece * 25)) res = "36 red";
        else if (rf.roulAngle < (double)(piece * 26)) res = "13 black";
        else if (rf.roulAngle < (double)(piece * 27)) res = "27 red";
        else if (rf.roulAngle < (double)(piece * 28)) res = "6 black";
        else if (rf.roulAngle < (double)(piece * 29)) res = "34 red";
        else if (rf.roulAngle < (double)(piece * 30)) res = "17 black";
        else if (rf.roulAngle < (double)(piece * 31)) res = "25 red";
        else if (rf.roulAngle < (double)(piece * 32)) res = "2 black";
        else if (rf.roulAngle < (double)(piece * 33)) res = "21 red";
        else if (rf.roulAngle < (double)(piece * 34)) res = "4 black";
        else if (rf.roulAngle < (double)(piece * 35)) res = "19 red";
        else if (rf.roulAngle < (double)(piece * 36)) res = "15 black";
        else res = "32 red";
        if (res.Split()[1] == "green") rf.result.BackColor = Color.Green;
        else if (res.Split()[1] == "red") rf.result.BackColor = Color.Red;
        else rf.result.BackColor = Color.Black;
        rf.result.Invoke(new Action(() => rf.result.Text = res.Split()[0]));
        
        for (int i = 0; i < bidsamount; i++)
        {
            curbid = (string[])rf.bids.Dequeue();
            if (rf.result.Text == curbid[0]) pay += rf.CalcCaps(curbid);
            else if ((curbid[0] == "R") && (rf.result.BackColor == Color.Red)) pay += rf.CalcCaps(curbid);
            else if ((curbid[0] == "B") && (rf.result.BackColor == Color.Black)) pay += rf.CalcCaps(curbid);
            else if ((curbid[0] == "EVEN") && (numseven.Contains(Int32.Parse(rf.result.Text)))) pay += rf.CalcCaps(curbid);
            else if ((curbid[0] == "ODD") && (numsodd.Contains(Int32.Parse(rf.result.Text)))) pay += rf.CalcCaps(curbid);
            else if ((curbid[0] == "1\nTO\n18") && (nums1_18.Contains(Int32.Parse(rf.result.Text)))) pay += rf.CalcCaps(curbid);
            else if ((curbid[0] == "19\nTO\n36") && (nums19_36.Contains(Int32.Parse(rf.result.Text)))) pay += rf.CalcCaps(curbid);
            else if ((curbid[0] == "1\nST\n12") && (nums1_12.Contains(Int32.Parse(rf.result.Text)))) pay += rf.CalcCaps(curbid);
            else if ((curbid[0] == "2\nND\n12") && (nums13_24.Contains(Int32.Parse(rf.result.Text)))) pay += rf.CalcCaps(curbid);
            else if ((curbid[0] == "3\nRD\n12") && (nums25_36.Contains(Int32.Parse(rf.result.Text)))) pay += rf.CalcCaps(curbid);
            else if ((curbid[0] == "2TO1") && (nums1_34.Contains(Int32.Parse(rf.result.Text)))) pay += rf.CalcCaps(curbid);
            else if ((curbid[0] == "2ТO1") && (nums2_35.Contains(Int32.Parse(rf.result.Text)))) pay += rf.CalcCaps(curbid);
            else if ((curbid[0] == "2TО1") && (nums3_36.Contains(Int32.Parse(rf.result.Text)))) pay += rf.CalcCaps(curbid);
        }
        rf.playercaps += pay;
        rf.caps.Invoke(new Action(() => rf.caps.Text = "Фишки: " + rf.playercaps));
        
        if (pay - rf.playerbid < 0)
        {
            rf.message.ForeColor = Color.Red;
            rf.message.Invoke(new Action(() => rf.message.Text = "Проигрыш: " + (rf.playerbid - pay)));
            
        }
        else
        {
            rf.message.ForeColor = Color.Yellow;
            rf.message.Invoke(new Action(() => rf.message.Text = "Выигрыш: " + (pay - rf.playerbid)));
            
        }
        rf.playerbid = 0;
        rf.bid.Invoke(new Action(() => rf.bid.Text = "Ставка: " + rf.playerbid));
        
        Thread.Sleep(5000);
        rf.ClearBids();
        rf.message.ForeColor = Color.White;
        rf.message.Invoke(new Action(() => rf.message.Text = "Сделайте ставку..."));

        rf.SwitchButtons();
        rf.isSpin = false;
    }
}

class RoulApp
{
    public static void Update(Master m)
    {
        m.Update();
    }
    public static void Main()
    {
        Master master = new Master(20, "../../Images/roul.png");
        Thread uTh = new Thread(() => {
            while (true)
            {
                Update(master);
            }
        });
        uTh.Start();
        Application.Run(master.rf);
    }
}