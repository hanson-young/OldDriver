using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;

namespace XYS.Remp.Screening.Player
{
    public partial class WMPlayerForm : Form
    {
        //唯一实例
        private static WMPlayerForm _uniquePlayer;

        private static string _pathBase = System.AppDomain.CurrentDomain.BaseDirectory;//目录

        private WMPlayerForm()
        {
            InitializeComponent();
        }
        //获取实例
        public static WMPlayerForm GetInstance()
        {
            if (_uniquePlayer == null)
            {
                _uniquePlayer = new WMPlayerForm();
            }
            return _uniquePlayer;
        }
        //播放
        public void Play(string fileName)
        {
            if (_uniquePlayer!=null)
            {
                //_uniquePlayer.axWindowsMediaPlayer1.currentPlaylist.appendItem(_uniquePlayer.axWindowsMediaPlayer1.newMedia(_pathBase + fileName));
                _uniquePlayer.axWindowsMediaPlayer1.URL = _pathBase + fileName;
                _uniquePlayer.axWindowsMediaPlayer1.Ctlcontrols.play();
                _uniquePlayer.axWindowsMediaPlayer1.settings.volume = 100;
            }
        }
        //停止
        public void Stop()
        {
            if (_uniquePlayer!=null)
            {
                _uniquePlayer.axWindowsMediaPlayer1.Ctlcontrols.stop();
            }
        }
        //暂停
        public void Pause()
        {
            if (_uniquePlayer != null)
            {
                _uniquePlayer.axWindowsMediaPlayer1.Ctlcontrols.pause();
            }
        }

        private void WMPlayerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _uniquePlayer = null;
        }
    }
}
