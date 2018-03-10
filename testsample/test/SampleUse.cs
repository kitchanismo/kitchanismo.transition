﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Collections;
using System.Reflection;
using System.Runtime.InteropServices;
//import
using kitchanismo_transition;

namespace test
{
    public partial class SampleUse : Form
    {
        //instantiate transition
        Kitchanismo kitchan = new Kitchanismo();

        Color silver = Color.Silver;
        Color gray = Color.Gray;
        Color dgray = Color.DimGray;
        Color egray = Color.FromArgb(90, 90, 90);
        Point p;
        Assembly assembly = Assembly.GetExecutingAssembly();
        // 1000 = 1 sec
        int speed = 900;

        // see CustomizeTransitions form to user other easing
     
        
        public SampleUse()
        {
            
            InitializeComponent();

            //initialize location and speed
            TProperties.initLocation(getGUID());
            TProperties.speed = speed;
           
        }

        #region drag

        //menu
        private void pnmain_MouseDown(object sender, MouseEventArgs e)
        {
            kitchan.Grab(pnmain);
        }

        private void pnmain_MouseUp(object sender, MouseEventArgs e)
        {
            kitchan.Release();
        }

        private void pnmain_MouseMove(object sender, MouseEventArgs e)
        {
            kitchan.MoveObject(pnmain);
        }
     
        #endregion

        #region tabs

        private void btntab1_Click(object sender, EventArgs e)
        {
            move_accent(btntab1, panel1.BackColor);
            customize_transition(panel1);
            kitchan.changeforecolor_control(btntab2, silver);
            kitchan.changeforecolor_control(btntab3, gray);
        }

        private void btntab2_Click(object sender, EventArgs e)
        {
            move_accent(btntab2, panel2.BackColor);
            customize_transition(panel2);
            kitchan.changeforecolor_control(btntab1, silver);
            kitchan.changeforecolor_control(btntab3, silver);
     
        }


        private void btntab3_Click(object sender, EventArgs e)
        {
            move_accent(btntab3, panel3.BackColor);
            customize_transition(panel3);
            kitchan.changeforecolor_control(btntab1, gray);
            kitchan.changeforecolor_control(btntab2, silver);
        }

        #endregion

        #region methods

        void move_accent(Button btn, Color col)
        {
            p.Y = pnnav.Location.Y;
            p.X = btn.Location.X;
            kitchan.move_animation(pnnav, p, 30);
            kitchan.changebackcolor_control(pnnav, col);
            kitchan.changeforecolor_control(btn, Color.White);
            kitchan.changeforecolor_control(lblversion, col);
        }

        void initType(Control target)
        {
           
            //target move
            TProperties.nav = target;

            //max of 5 panels, min of 2
            TProperties.nav1 = panel1;
            TProperties.nav2 = panel2;
            TProperties.nav3 = panel3;
            TProperties.nav4 = new Panel();
            TProperties.nav5 = new Panel();
 
            //assign location, speed, ease to TProperty
            TProperties.loc = 0;
            TProperties.speed = speed;
            TProperties.ease = IEasing.bounceout;
        }

  
        public void customize_transition(Control target)
        {
           //call methos
           initType(target);

           //see CustomizeTransition form to see more custom transitions
           //kitchan.x_swap(true);//swap , x , left
           //kitchan.x_swap(false);//swap , x , right

           kitchan.y_swap(true);//swap , y , down
           //kitchan.y_swap(false);//swap , y , up   
        }

  

        #endregion

        private void SampleUse_Load(object sender, EventArgs e)
        {
           
           
        }

        string getGUID() {
            var attribute = (GuidAttribute)assembly.GetCustomAttributes(typeof(GuidAttribute), true)[0];
            return attribute.Value;
        }

    }
}