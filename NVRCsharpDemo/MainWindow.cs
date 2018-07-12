using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using jiangxi2Inter;

namespace NVRCsharpDemo
{
    //gb add
    public partial class MainWindow : Form
    {
        private bool m_bInitSDK = false;
        private uint iLastErr = 0;
        private Int32 m_lUserID = -1;
        private Int32 m_lFindHandle = -1;
        private Int32 m_lPlayHandle = -1;
        private Int32 m_lDownHandle = -1;
        private string str;
        private string str1;
        private string str2;
        private string str3;
        private string sPlayBackFileName = null;
        private Int32 i = 0;
        private Int32 m_lTree=0;

        private bool m_bPause = false;
        private bool m_bReverse = false;
        private bool m_bSound = false;

        private long iSelIndex = 0;
        private uint dwAChanTotalNum = 0;
        private uint dwDChanTotalNum = 0;
        public CHCNetSDK.NET_DVR_DEVICEINFO_V30 DeviceInfo;
        public CHCNetSDK.NET_DVR_IPPARACFG_V40 m_struIpParaCfgV40;
        public CHCNetSDK.NET_DVR_GET_STREAM_UNION m_unionGetStream;
        public CHCNetSDK.NET_DVR_IPCHANINFO m_struChanInfo;

        public static jiangxi2Inter.JX2Interface jx2interface = null;

        //ConfigFile config;
        string NET_authCode, NET_testlineNo;
        SqlControl sql;
        public int[,] testLineChanel=new int[8,2];
        public bool isUploading = false;

        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 96, ArraySubType = UnmanagedType.U4)]
        private int[] iChannelNum;
        private string ftpdir = "D://VIDEOFTP//";
        Thread uploadThread = null;
        public MainWindow()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            m_bInitSDK = CHCNetSDK.NET_DVR_Init();
            if (m_bInitSDK == false)
            {
                MessageBox.Show("NET_DVR_Init error!");
                return;
            }
            else
            {
                //保存SDK日志
                CHCNetSDK.NET_DVR_SetLogToFile(3,"C:\\SdkLog\\", true);
                iChannelNum = new int[96];
            }
        }
        private void readNVRsetting(out string ip,out Int16 port,out string name,out string password)
        {
            port = 9999;
            var config = ConfigFile.LoadOrCreateFile("config.test");
            ip = config.GetConfigValue("NVRIP");
            int porttemp;
            if (config.TryParseConfigValue("NVRPORT", out porttemp))
                port = (Int16)porttemp;
            name = config.GetConfigValue("NVRNAME");
            password = config.GetConfigValue("NVRPASSWORD");
        }
        private void readNETsetting(out string testlineNo, out string authCode)
        {
            var config = ConfigFile.LoadOrCreateFile("config.test");
            testlineNo = config.GetConfigValue("testlineNo");
            authCode = config.GetConfigValue("authCode");
        }
        private void readCHANNELsetting()
        {
            var config = ConfigFile.LoadOrCreateFile("config.test");
            for (int i=1;i<=8;i++)
            {
                int porttemp;
                if (config.TryParseConfigValue("CHANELFRONT"+i.ToString(), out porttemp))
                    testLineChanel[i-1,0] = (Int16)porttemp;
                if (config.TryParseConfigValue("CHANELBACK" + i.ToString(), out porttemp))
                    testLineChanel[i - 1, 1] = (Int16)porttemp;
            }
            comboBoxChF1.Text = testLineChanel[0, 0].ToString();
            comboBoxChB1.Text = testLineChanel[0, 1].ToString();
            comboBoxChF2.Text = testLineChanel[1, 0].ToString();
            comboBoxChB2.Text = testLineChanel[1, 1].ToString();
            comboBoxChF3.Text = testLineChanel[2, 0].ToString();
            comboBoxChB3.Text = testLineChanel[2, 1].ToString();
            comboBoxChF4.Text = testLineChanel[3, 0].ToString();
            comboBoxChB4.Text = testLineChanel[3, 1].ToString();
            comboBoxChF5.Text = testLineChanel[4, 0].ToString();
            comboBoxChB5.Text = testLineChanel[4, 1].ToString();
            comboBoxChF6.Text = testLineChanel[5, 0].ToString();
            comboBoxChB6.Text = testLineChanel[5, 1].ToString();
            comboBoxChF7.Text = testLineChanel[6, 0].ToString();
            comboBoxChB7.Text = testLineChanel[6, 1].ToString();
            comboBoxChF8.Text = testLineChanel[7, 0].ToString();
            comboBoxChB8.Text = testLineChanel[7, 1].ToString();
        }
        private void saveChanelsetting()
        {
            var config = ConfigFile.LoadOrCreateFile("config.test");
            try
            {
                testLineChanel[0, 0] = int.Parse(comboBoxChF1.Text);
                testLineChanel[0, 1] = int.Parse(comboBoxChB1.Text);
                testLineChanel[1, 0] = int.Parse(comboBoxChF2.Text);
                testLineChanel[1, 1] = int.Parse(comboBoxChB2.Text);
                testLineChanel[2, 0] = int.Parse(comboBoxChF3.Text);
                testLineChanel[2, 1] = int.Parse(comboBoxChB3.Text);
                testLineChanel[3, 0] = int.Parse(comboBoxChF4.Text);
                testLineChanel[3, 1] = int.Parse(comboBoxChB4.Text);
                testLineChanel[4, 0] = int.Parse(comboBoxChF5.Text);
                testLineChanel[4, 1] = int.Parse(comboBoxChB5.Text);
                testLineChanel[5, 0] = int.Parse(comboBoxChF6.Text);
                testLineChanel[5, 1] = int.Parse(comboBoxChB6.Text);
                testLineChanel[6, 0] = int.Parse(comboBoxChF7.Text);
                testLineChanel[6, 1] = int.Parse(comboBoxChB7.Text);
                testLineChanel[7, 0] = int.Parse(comboBoxChF8.Text);
                testLineChanel[7, 1] = int.Parse(comboBoxChB8.Text);
                for (int i = 1; i <= 8; i++)
                {
                    config["CHANELFRONT" + i.ToString()] = testLineChanel[i - 1, 0].ToString();
                    config["CHANELBACK" + i.ToString()] = testLineChanel[i - 1, 1].ToString();
                }
            }
            catch
            {
                MessageBox.Show("输入格式有误");
            }
        }
        private void saveNVRsetting(string ip,Int16 port,string name,string password)
        {
            var config = ConfigFile.LoadOrCreateFile("config.test");
            config["NVRIP"] = ip;
            config["NVRPORT"] = port.ToString();
            config["NVRNAME"] = name;
            config["NVRPASSWORD"] = password;
            //config.AddOrSetKeyValue("NVR", "IP", ip);
            //config.AddOrSetKeyValue("NVR", "PORT", port.ToString());
            //config.AddOrSetKeyValue("NVR", "NAME", name);
            //config.AddOrSetKeyValue("NVR", "PASSWORD", password);
        }
        private void saveNETsetting(string testlineNo,  string authCode)
        {
            var config = ConfigFile.LoadOrCreateFile("config.test");
            config["testlineNo"] = testlineNo;
            config["authCode"] = authCode;
        }
        private bool initNetInter()
        {
            try
            {
                LogMessage("初始化联网接口");
                jx2interface = new jiangxi2Inter.JX2Interface(NET_testlineNo, "01", NET_authCode);
                string servertime = "", errmsg = "";
                if (jx2interface.getSystemTime(out servertime, out errmsg))
                {
                    DateTime syntime = DateTime.Parse(servertime);
                    SetSystemDateTime.SetLocalTimeByStr(syntime.ToString("yyyy-MM-dd HH:mm:ss"));
                    logControl.saveLogInf("同步服务器联网时间成功:" + syntime.ToString("yyyy-MM-dd HH:mm:ss"));
                    LogMessage("同步服务器联网时间成功:" + syntime.ToString("yyyy-MM-dd HH:mm:ss"));
                    return true;

                }
                else
                {
                    logControl.saveLogInf("同步服务器联网时间失败:" + errmsg);
                    LogMessage("同步服务器联网时间失败:" + errmsg);
                    return false;
                }

            }
            catch (Exception er)
            {
                logControl.saveLogInf("同步服务器联网时间异常:" + er.Message);
                LogMessage("同步服务器联网时间异常:" + er.Message);
                return false;
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (textBoxIP.Text == "" || textBoxPort.Text == "" ||
                textBoxUserName.Text == "" || textBoxPassword.Text == "")
            {
                MessageBox.Show("Please input IP, Port, User name and Password!");
                return;
            }
            if (m_lUserID < 0)
            {
                string DVRIPAddress = textBoxIP.Text; //设备IP地址或者域名
                Int16 DVRPortNumber = Int16.Parse(textBoxPort.Text);//设备服务端口号
                string DVRUserName = textBoxUserName.Text;//设备登录用户名
                string DVRPassword = textBoxPassword.Text;//设备登录密码
                saveNVRsetting(DVRIPAddress, DVRPortNumber, DVRUserName, DVRPassword);
                //    DeviceInfo = new CHCNetSDK.NET_DVR_DEVICEINFO_V30();

                //登录设备 Login the device
                m_lUserID = CHCNetSDK.NET_DVR_Login_V30(DVRIPAddress, DVRPortNumber, DVRUserName, DVRPassword, ref DeviceInfo);
                if (m_lUserID < 0)
                {
                    iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    str1 = "NET_DVR_Login_V30 failed, error code= " + iLastErr; //登录失败，输出错误号
                    MessageBox.Show(str1);
                    return;
                }
                else
                {
                    //登录成功
                    MessageBox.Show("Login Success!");
                    btnLogin.Text = "Logout";
                    buttonSyncTime.Enabled = true;
                    dwAChanTotalNum = (uint)DeviceInfo.byChanNum;
                    dwDChanTotalNum = (uint)DeviceInfo.byIPChanNum + 256 * (uint)DeviceInfo.byHighDChanNum;

                    if (dwDChanTotalNum > 0)
                    {
                        InfoIPChannel();
                    }
                    else
                    {
                        for (i = 0; i < dwAChanTotalNum; i++)
                        {
                            ListAnalogChannel(i+1, 1);
                            iChannelNum[i] = i + (int)DeviceInfo.byStartChan;
                        }
                       // MessageBox.Show("This device has no IP channel!");
                    }
                }

            }
            else
            {                
                if (m_lPlayHandle >= 0) 
                {
                    MessageBox.Show("Please stop playback firstly"); //登出前先停止预览
                    return;
                }

                //注销登录 Logout the device
                if (!CHCNetSDK.NET_DVR_Logout(m_lUserID))
                {
                    iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    str1 = "NET_DVR_Logout failed, error code= " + iLastErr;
                    MessageBox.Show(str1);
                    return;
                }
                listViewIPChannel.Items.Clear();//清空通道列表
                m_lUserID = -1;
                btnLogin.Text = "Login";
            }
            return;
        }

        public void InfoIPChannel()
        {
            uint dwSize = (uint)Marshal.SizeOf(m_struIpParaCfgV40);

            IntPtr ptrIpParaCfgV40 = Marshal.AllocHGlobal((Int32)dwSize);
            Marshal.StructureToPtr(m_struIpParaCfgV40, ptrIpParaCfgV40, false);

            uint dwReturn = 0;
            int iGroupNo = 0; //该Demo仅获取第一组64个通道，如果设备IP通道大于64路，需要按组号0~i多次调用NET_DVR_GET_IPPARACFG_V40获取
            if (!CHCNetSDK.NET_DVR_GetDVRConfig(m_lUserID, CHCNetSDK.NET_DVR_GET_IPPARACFG_V40, iGroupNo, ptrIpParaCfgV40, dwSize, ref dwReturn))
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                str1 = "NET_DVR_GET_IPPARACFG_V40 failed, error code= " + iLastErr; //获取IP资源配置信息失败，输出错误号
                MessageBox.Show(str1);
            }
            else
            {
                // succ
                m_struIpParaCfgV40 = (CHCNetSDK.NET_DVR_IPPARACFG_V40)Marshal.PtrToStructure(ptrIpParaCfgV40, typeof(CHCNetSDK.NET_DVR_IPPARACFG_V40));
               
                for (i = 0; i < dwAChanTotalNum; i++)
                {
                    ListAnalogChannel(i+1, m_struIpParaCfgV40.byAnalogChanEnable[i]);
                    iChannelNum[i] = i + (int)DeviceInfo.byStartChan;                     
                }
                
                byte byStreamType;
                uint iDChanNum = 64;

                if (dwDChanTotalNum < 64)
                {
                    iDChanNum = dwDChanTotalNum; //如果设备IP通道小于64路，按实际路数获取
                }

                for (i = 0; i < iDChanNum; i++)
                {
                    iChannelNum[i + dwAChanTotalNum] = i + (int)m_struIpParaCfgV40.dwStartDChan;

                    byStreamType = m_struIpParaCfgV40.struStreamMode[i].byGetStreamType;
                    m_unionGetStream = m_struIpParaCfgV40.struStreamMode[i].uGetStream;

                    switch (byStreamType)
                    {
                        //目前NVR仅支持0- 直接从设备取流一种方式
                        case 0:
                            dwSize = (uint)Marshal.SizeOf(m_unionGetStream);
                            IntPtr ptrChanInfo = Marshal.AllocHGlobal((Int32)dwSize);
                            Marshal.StructureToPtr(m_unionGetStream, ptrChanInfo, false);
                            m_struChanInfo = (CHCNetSDK.NET_DVR_IPCHANINFO)Marshal.PtrToStructure(ptrChanInfo, typeof(CHCNetSDK.NET_DVR_IPCHANINFO));

                            //列出IP通道
                            ListIPChannel(i + 1, m_struChanInfo.byEnable, m_struChanInfo.byIPID);
                            Marshal.FreeHGlobal(ptrChanInfo);
                            break;

                        default:
                            break;
                    }
                }
            }
            Marshal.FreeHGlobal(ptrIpParaCfgV40);
        }
        public void ListIPChannel(Int32 iChanNo, byte byOnline, byte byIPID)
        {
            str1 = String.Format("IPCamera {0}", iChanNo);
            m_lTree++;

            if (byIPID == 0)
            {
                str2 = "X"; //通道空闲，没有添加前端设备                 
            }
            else
            { 
                if(byOnline==0)
                {
                    str2 = "offline"; //通道不在线
                }
                else
                    str2 = "online"; //通道在线
            }
            
            listViewIPChannel.Items.Add(new ListViewItem(new string[] {str1, str2}));//将通道添加到列表中
        }
        public void ListAnalogChannel(Int32 iChanNo, byte byEnable)
        {
            str1 = String.Format("Camera {0}", iChanNo);
            m_lTree++;

            if (byEnable == 0)
            {
                str2 = "Disabled"; //通道已被禁用 This channel has been disabled               
            }
            else
            {
                str2 = "Enabled"; //通道处于启用状态
            }

            listViewIPChannel.Items.Add(new ListViewItem(new string[] {str1, str2 }));//将通道添加到列表中
        }

        private void listViewIPChannel_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listViewIPChannel.SelectedItems.Count > 0) 
            {
                iSelIndex = listViewIPChannel.SelectedItems[0].Index;  //当前选中的行
            }
        }

        private void btnBMP_Click(object sender, EventArgs e)
        {
            if (m_lPlayHandle < 0)
            {
                MessageBox.Show("Please start playback firstly!"); //BMP抓图需要先打开预览
                return;
            }

            string sBmpPicFileName;
            //图片保存路径和文件名 the path and file name to save
            sBmpPicFileName = "test.bmp";

            //BMP抓图 Capture a BMP picture
            if (!CHCNetSDK.NET_DVR_PlayBackCaptureFile(m_lPlayHandle, sBmpPicFileName))
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                str = "NET_DVR_PlayBackCaptureFile failed, error code= " + iLastErr;
                MessageBox.Show(str);
                return;
            }
            else
            {
                str = "Successful to capture the BMP file and the saved file is " + sBmpPicFileName;
                MessageBox.Show(str);
            }
            return;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            listViewFile.Items.Clear();//清空文件列表 

            CHCNetSDK.NET_DVR_FILECOND_V40 struFileCond_V40 = new CHCNetSDK.NET_DVR_FILECOND_V40();

            struFileCond_V40.lChannel = iChannelNum[(int)iSelIndex]; //通道号 Channel number
            struFileCond_V40.dwFileType = 0xff; //0xff-全部，0-定时录像，1-移动侦测，2-报警触发，...
            struFileCond_V40.dwIsLocked = 0xff; //0-未锁定文件，1-锁定文件，0xff表示所有文件（包括锁定和未锁定）

            //设置录像查找的开始时间 Set the starting time to search video files
            struFileCond_V40.struStartTime.dwYear   = (uint)dateTimeStart.Value.Year;
            struFileCond_V40.struStartTime.dwMonth  = (uint)dateTimeStart.Value.Month;
            struFileCond_V40.struStartTime.dwDay    = (uint)dateTimeStart.Value.Day;
            struFileCond_V40.struStartTime.dwHour   = (uint)dateTimeStart.Value.Hour;
            struFileCond_V40.struStartTime.dwMinute = (uint)dateTimeStart.Value.Minute;
            struFileCond_V40.struStartTime.dwSecond = (uint)dateTimeStart.Value.Second;

            //设置录像查找的结束时间 Set the stopping time to search video files
            struFileCond_V40.struStopTime.dwYear   = (uint)dateTimeEnd.Value.Year;
            struFileCond_V40.struStopTime.dwMonth  = (uint)dateTimeEnd.Value.Month;
            struFileCond_V40.struStopTime.dwDay    = (uint)dateTimeEnd.Value.Day;
            struFileCond_V40.struStopTime.dwHour   = (uint)dateTimeEnd.Value.Hour;
            struFileCond_V40.struStopTime.dwMinute = (uint)dateTimeEnd.Value.Minute;
            struFileCond_V40.struStopTime.dwSecond = (uint)dateTimeEnd.Value.Second;

            //开始录像文件查找 Start to search video files 
            m_lFindHandle = CHCNetSDK.NET_DVR_FindFile_V40(m_lUserID, ref struFileCond_V40);

            if (m_lFindHandle < 0)
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                str = "NET_DVR_FindFile_V40 failed, error code= " + iLastErr; //预览失败，输出错误号
                MessageBox.Show(str);
                return;
            }
            else
            {
                CHCNetSDK.NET_DVR_FINDDATA_V30 struFileData = new CHCNetSDK.NET_DVR_FINDDATA_V30(); ;
                while(true)
                {
                    //逐个获取查找到的文件信息 Get file information one by one.
                    int result = CHCNetSDK.NET_DVR_FindNextFile_V30(m_lFindHandle, ref struFileData);

                    if (result == CHCNetSDK.NET_DVR_ISFINDING)  //正在查找请等待 Searching, please wait
                    {
                        continue;
                    }
                    else if (result == CHCNetSDK.NET_DVR_FILE_SUCCESS) //获取文件信息成功 Get the file information successfully
                    {
                        str1 = struFileData.sFileName;

                        str2= Convert.ToString(struFileData.struStartTime.dwYear) + "-" +
                            Convert.ToString(struFileData.struStartTime.dwMonth) + "-" +
                            Convert.ToString(struFileData.struStartTime.dwDay) + " " +
                            Convert.ToString(struFileData.struStartTime.dwHour) + ":" +
                            Convert.ToString(struFileData.struStartTime.dwMinute) + ":" +
                            Convert.ToString(struFileData.struStartTime.dwSecond);

                        str3 = Convert.ToString(struFileData.struStopTime.dwYear) + "-" +
                            Convert.ToString(struFileData.struStopTime.dwMonth) + "-" +
                            Convert.ToString(struFileData.struStopTime.dwDay) + " " +
                            Convert.ToString(struFileData.struStopTime.dwHour) + ":" +
                            Convert.ToString(struFileData.struStopTime.dwMinute) + ":" +
                            Convert.ToString(struFileData.struStopTime.dwSecond);

                        listViewFile.Items.Add(new ListViewItem(new string[] { str1, str2, str3}));//将查找的录像文件添加到列表中

                    }
                    else if (result == CHCNetSDK.NET_DVR_FILE_NOFIND || result == CHCNetSDK.NET_DVR_NOMOREFILE) 
                    {
                        break; //未查找到文件或者查找结束，退出   No file found or no more file found, search is finished 
                    }
                    else
                    {                      
                        break;
                    }
                }               
               
            }

        }

        private void listViewFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewFile.SelectedItems.Count > 0)
            {
                sPlayBackFileName = listViewFile.FocusedItem.SubItems[0].Text;
            }
        }

        private void btnPlaybackName_Click(object sender, EventArgs e)
        {
            if (sPlayBackFileName==null)
            {
                MessageBox.Show("Please select one file firstly!");//先选择回放的文件
                return;
            }

            if (m_lPlayHandle >= 0)
            {
                //如果已经正在回放，先停止回放
                if (!CHCNetSDK.NET_DVR_StopPlayBack(m_lPlayHandle))
                {
                    iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    str = "NET_DVR_StopPlayBack failed, error code= " + iLastErr; //停止回放失败，输出错误号
                    MessageBox.Show(str);
                    return;
                }

                m_bReverse = false;
                btnReverse.Text = "Reverse";
                labelReverse.Text = "切换为倒放";

                m_bPause = false;
                btnPause.Text = "||";
                labelPause.Text = "暂停";

                m_lPlayHandle = -1;
                PlaybackprogressBar.Value = 0;
            }

            //按文件名回放
            m_lPlayHandle = CHCNetSDK.NET_DVR_PlayBackByName(m_lUserID, sPlayBackFileName, VideoPlayWnd.Handle);
            if (m_lPlayHandle<0)
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                str = "NET_DVR_PlayBackByName failed, error code= " + iLastErr;
                MessageBox.Show(str);
                return;            
            }
           
            uint iOutValue=0;
            if (!CHCNetSDK.NET_DVR_PlayBackControl_V40(m_lPlayHandle, CHCNetSDK.NET_DVR_PLAYSTART, IntPtr.Zero, 0, IntPtr.Zero, ref iOutValue))
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                str = "NET_DVR_PLAYSTART failed, error code= " + iLastErr; //回放控制失败，输出错误号
                MessageBox.Show(str);
                return;
            }
            timerPlayback.Interval = 1000;
            timerPlayback.Enabled = true;
            btnStopPlayback.Enabled = true;
        }

        private void btnPlaybackTime_Click(object sender, EventArgs e)
        {
            if (m_lPlayHandle >= 0)
            {
                //如果已经正在回放，先停止回放
                if (!CHCNetSDK.NET_DVR_StopPlayBack(m_lPlayHandle))
                {
                    iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    str = "NET_DVR_StopPlayBack failed, error code= " + iLastErr; 
                    MessageBox.Show(str);
                    return;
                }

                m_bReverse = false;
                btnReverse.Text = "Reverse";
                labelReverse.Text = "切换为倒放";

                m_bPause = false;
                btnPause.Text = "||";
                labelPause.Text = "暂停"; 

                m_lPlayHandle = -1;

                PlaybackprogressBar.Value = 0;
            }

            CHCNetSDK.NET_DVR_VOD_PARA struVodPara = new CHCNetSDK.NET_DVR_VOD_PARA();
            struVodPara.dwSize = (uint)Marshal.SizeOf(struVodPara);
            struVodPara.struIDInfo.dwChannel = (uint)iChannelNum[(int)iSelIndex]; //通道号 Channel number  
            struVodPara.hWnd = VideoPlayWnd.Handle;//回放窗口句柄

            //设置回放的开始时间 Set the starting time to search video files
            struVodPara.struBeginTime.dwYear = (uint)dateTimeStart.Value.Year;
            struVodPara.struBeginTime.dwMonth = (uint)dateTimeStart.Value.Month;
            struVodPara.struBeginTime.dwDay = (uint)dateTimeStart.Value.Day;
            struVodPara.struBeginTime.dwHour = (uint)dateTimeStart.Value.Hour;
            struVodPara.struBeginTime.dwMinute = (uint)dateTimeStart.Value.Minute;
            struVodPara.struBeginTime.dwSecond = (uint)dateTimeStart.Value.Second;

            //设置回放的结束时间 Set the stopping time to search video files
            struVodPara.struEndTime.dwYear = (uint)dateTimeEnd.Value.Year;
            struVodPara.struEndTime.dwMonth = (uint)dateTimeEnd.Value.Month;
            struVodPara.struEndTime.dwDay = (uint)dateTimeEnd.Value.Day;
            struVodPara.struEndTime.dwHour = (uint)dateTimeEnd.Value.Hour;
            struVodPara.struEndTime.dwMinute = (uint)dateTimeEnd.Value.Minute;
            struVodPara.struEndTime.dwSecond = (uint)dateTimeEnd.Value.Second;

            //按时间回放 Playback by time
            m_lPlayHandle = CHCNetSDK.NET_DVR_PlayBackByTime_V40(m_lUserID, ref struVodPara);
            if (m_lPlayHandle < 0)
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                str = "NET_DVR_PlayBackByTime_V40 failed, error code= " + iLastErr;
                MessageBox.Show(str);
                return;
            }

            uint iOutValue = 0;
            if (!CHCNetSDK.NET_DVR_PlayBackControl_V40(m_lPlayHandle, CHCNetSDK.NET_DVR_PLAYSTART, IntPtr.Zero, 0, IntPtr.Zero, ref iOutValue))
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                str = "NET_DVR_PLAYSTART failed, error code= " + iLastErr; //回放控制失败，输出错误号
                MessageBox.Show(str);
                return;
            }
            timerPlayback.Interval = 1000;
            timerPlayback.Enabled = true;
            btnStopPlayback.Enabled = true;
        }

        private void btnStopPlayback_Click(object sender, EventArgs e)
        {
            if (m_lPlayHandle < 0)
            {
                return;
            }

            //停止回放
            if (!CHCNetSDK.NET_DVR_StopPlayBack(m_lPlayHandle))
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                str = "NET_DVR_StopPlayBack failed, error code= " + iLastErr;
                MessageBox.Show(str);
                return;
            }

            PlaybackprogressBar.Value = 0;
            timerPlayback.Stop();
            
            m_bReverse = false;
            btnReverse.Text = "Reverse";
            labelReverse.Text = "切换为倒放";
            
            m_bPause = false;
            btnPause.Text = "||";
            labelPause.Text = "暂停";
            
            m_lPlayHandle = -1;
            VideoPlayWnd.Invalidate();//刷新窗口    
            btnStopPlayback.Enabled = false;
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            uint iOutValue = 0;

            if (!m_bPause)
            {
                if (!CHCNetSDK.NET_DVR_PlayBackControl_V40(m_lPlayHandle, CHCNetSDK.NET_DVR_PLAYPAUSE, IntPtr.Zero, 0, IntPtr.Zero, ref iOutValue))
                {
                    iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    str = "NET_DVR_PLAYPAUSE failed, error code= " + iLastErr; //回放控制失败，输出错误号
                    MessageBox.Show(str);
                    return;
                }
                m_bPause = true;
                btnPause.Text = ">";
                labelPause.Text = "播放";
            }
            else
            {
                if (!CHCNetSDK.NET_DVR_PlayBackControl_V40(m_lPlayHandle, CHCNetSDK.NET_DVR_PLAYRESTART, IntPtr.Zero, 0, IntPtr.Zero, ref iOutValue))
                {
                    iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    str = "NET_DVR_PLAYRESTART failed, error code= " + iLastErr; //回放控制失败，输出错误号
                    MessageBox.Show(str);
                    return;
                }
                m_bPause = false;
                btnPause.Text = "||";
                labelPause.Text = "暂停";
            }
            return;
        }

        private void btnSlow_Click(object sender, EventArgs e)
        {
            uint iOutValue = 0;

            if (!CHCNetSDK.NET_DVR_PlayBackControl_V40(m_lPlayHandle, CHCNetSDK.NET_DVR_PLAYSLOW, IntPtr.Zero, 0, IntPtr.Zero, ref iOutValue))
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                str = "NET_DVR_PLAYSLOW failed, error code= " + iLastErr; //回放控制失败，输出错误号
                MessageBox.Show(str);
                return;
            }
        }

        private void btnFast_Click(object sender, EventArgs e)
        {
            uint iOutValue = 0;

            if (!CHCNetSDK.NET_DVR_PlayBackControl_V40(m_lPlayHandle, CHCNetSDK.NET_DVR_PLAYFAST, IntPtr.Zero, 0, IntPtr.Zero, ref iOutValue))
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                str = "NET_DVR_PLAYFAST failed, error code= " + iLastErr; //回放控制失败，输出错误号
                MessageBox.Show(str);
                return;
            }
        }

        private void btnFrame_Click(object sender, EventArgs e)
        {
            uint iOutValue = 0;

            if (!CHCNetSDK.NET_DVR_PlayBackControl_V40(m_lPlayHandle, CHCNetSDK.NET_DVR_PLAYFRAME, IntPtr.Zero, 0, IntPtr.Zero, ref iOutValue))
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                str = "NET_DVR_PLAYFRAME failed, error code= " + iLastErr; //回放控制失败，输出错误号
                MessageBox.Show(str);
                return;
            }
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            uint iOutValue = 0;

            if (!CHCNetSDK.NET_DVR_PlayBackControl_V40(m_lPlayHandle, CHCNetSDK.NET_DVR_PLAYNORMAL, IntPtr.Zero, 0, IntPtr.Zero, ref iOutValue))
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                str = "NET_DVR_PLAYNORMAL failed, error code= " + iLastErr; //回放控制失败，输出错误号
                MessageBox.Show(str);
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            uint iOutValue = 0;
            if (!m_bReverse)
            {
                if (!CHCNetSDK.NET_DVR_PlayBackControl_V40(m_lPlayHandle, CHCNetSDK.NET_DVR_PLAY_REVERSE, IntPtr.Zero, 0, IntPtr.Zero, ref iOutValue))
                {
                    iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    str = "NET_DVR_PLAY_REVERSE failed, error code= " + iLastErr; //回放控制失败，输出错误号
                    MessageBox.Show(str);
                    return;
                }
                m_bReverse = true;
                btnReverse.Text = "Forward";
                labelReverse.Text = "切换为正放";
            }
            else
            {
                if (!CHCNetSDK.NET_DVR_PlayBackControl_V40(m_lPlayHandle, CHCNetSDK.NET_DVR_PLAY_FORWARD, IntPtr.Zero, 0, IntPtr.Zero, ref iOutValue))
                {
                    iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    str = "NET_DVR_PLAY_FORWARD failed, error code= " + iLastErr; //回放控制失败，输出错误号
                    MessageBox.Show(str);
                    return;
                }
                m_bReverse = false;
                btnReverse.Text = "Reverse";
                labelReverse.Text = "切换为倒放";       
            }

        }

        private void btnDownloadTime_Click(object sender, EventArgs e)
        {
            if (m_lDownHandle >= 0)
            {
                MessageBox.Show("Downloading, please stop firstly!");//正在下载，请先停止下载
                return;
            }

            CHCNetSDK.NET_DVR_PLAYCOND struDownPara = new CHCNetSDK.NET_DVR_PLAYCOND();
            struDownPara.dwChannel = (uint)iChannelNum[(int)iSelIndex]; //通道号 Channel number  

            //设置下载的开始时间 Set the starting time
            struDownPara.struStartTime.dwYear = (uint)dateTimeStart.Value.Year;
            struDownPara.struStartTime.dwMonth = (uint)dateTimeStart.Value.Month;
            struDownPara.struStartTime.dwDay = (uint)dateTimeStart.Value.Day;
            struDownPara.struStartTime.dwHour = (uint)dateTimeStart.Value.Hour;
            struDownPara.struStartTime.dwMinute = (uint)dateTimeStart.Value.Minute;
            struDownPara.struStartTime.dwSecond = (uint)dateTimeStart.Value.Second;

            //设置下载的结束时间 Set the stopping time
            struDownPara.struStopTime.dwYear = (uint)dateTimeEnd.Value.Year;
            struDownPara.struStopTime.dwMonth = (uint)dateTimeEnd.Value.Month;
            struDownPara.struStopTime.dwDay = (uint)dateTimeEnd.Value.Day;
            struDownPara.struStopTime.dwHour = (uint)dateTimeEnd.Value.Hour;
            struDownPara.struStopTime.dwMinute = (uint)dateTimeEnd.Value.Minute;
            struDownPara.struStopTime.dwSecond = (uint)dateTimeEnd.Value.Second;

            string sVideoFileName;  //录像文件保存路径和文件名 the path and file name to save      
            sVideoFileName = "D:\\Downtest_Channel"+struDownPara.dwChannel+".mp4";

            //按时间下载 Download by time
            m_lDownHandle = CHCNetSDK.NET_DVR_GetFileByTime_V40(m_lUserID, sVideoFileName, ref struDownPara);
            if (m_lDownHandle < 0)
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                str = "NET_DVR_GetFileByTime_V40 failed, error code= " + iLastErr;
                MessageBox.Show(str);
                return;
            }

            uint iOutValue = 0;
            if (!CHCNetSDK.NET_DVR_PlayBackControl_V40(m_lDownHandle, CHCNetSDK.NET_DVR_PLAYSTART, IntPtr.Zero, 0, IntPtr.Zero, ref iOutValue))
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                str = "NET_DVR_PLAYSTART failed, error code= " + iLastErr; //下载控制失败，输出错误号
                MessageBox.Show(str);
                return;
            }

            timerDownload.Interval = 1000;
            timerDownload.Enabled = true;
            btnStopDownload.Enabled = true;
        }

        private void btnDownloadName_Click(object sender, EventArgs e)
        {
            if (m_lDownHandle >= 0)
            {
                MessageBox.Show("Downloading, please stop firstly!");//正在下载，请先停止下载
                return;
            }

            string sVideoFileName;  //录像文件保存路径和文件名 the path and file name to save      
            sVideoFileName = "Downtest_"+sPlayBackFileName+".mp4";

            //按文件名下载 Download by file name
            m_lDownHandle = CHCNetSDK.NET_DVR_GetFileByName(m_lUserID, sPlayBackFileName, sVideoFileName);
            if (m_lDownHandle < 0)
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                str = "NET_DVR_GetFileByName failed, error code= " + iLastErr;
                MessageBox.Show(str);
                return;
            }

            uint iOutValue = 0;

            //设置转封装格式
            //UInt32 iInValue = 5;
            //IntPtr lpInValue = Marshal.AllocHGlobal(4);
            //Marshal.StructureToPtr(iInValue, lpInValue, false);

            //if (!CHCNetSDK.NET_DVR_PlayBackControl_V40(m_lDownHandle, CHCNetSDK.NET_DVR_SET_TRANS_TYPE, lpInValue, 4, IntPtr.Zero, ref iOutValue))
            //{
            //    iLastErr = CHCNetSDK.NET_DVR_GetLastError();
            //    str = "NET_DVR_PLAYSTART failed, error code= " + iLastErr; //下载控制失败，输出错误号
            //    MessageBox.Show(str);
            //    return;
            //}

            if (!CHCNetSDK.NET_DVR_PlayBackControl_V40(m_lDownHandle, CHCNetSDK.NET_DVR_PLAYSTART, IntPtr.Zero, 0, IntPtr.Zero, ref iOutValue))
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                str = "NET_DVR_PLAYSTART failed, error code= " + iLastErr; //下载控制失败，输出错误号
                MessageBox.Show(str);
                return;
            }
            timerDownload.Interval = 1000;
            timerDownload.Enabled = true;
            btnStopDownload.Enabled = true;
        }

        private void btnStopDownload_Click(object sender, EventArgs e)
        {
            if(m_lDownHandle<0)
            {
                return;            
            }

            if (!CHCNetSDK.NET_DVR_StopGetFile(m_lDownHandle))
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                str = "NET_DVR_StopGetFile failed, error code= " + iLastErr; //下载控制失败，输出错误号
                MessageBox.Show(str);
                return;
            }

            timerDownload.Stop(); 

            MessageBox.Show("The downloading has been stopped succesfully!");
            m_lDownHandle = -1;
            DownloadProgressBar.Value = 0;
            btnStopDownload.Enabled = true;
        }

        private void timerProgress_Tick(object sender, EventArgs e)
        {
            DownloadProgressBar.Maximum = 100;
            DownloadProgressBar.Minimum = 0;

            int iPos = 0;

            //获取下载进度
            iPos = CHCNetSDK.NET_DVR_GetDownloadPos(m_lDownHandle);

            if ((iPos > DownloadProgressBar.Minimum) && (iPos < DownloadProgressBar.Maximum))
            {
                DownloadProgressBar.Value = iPos;            
            }

            if (iPos == 100)  //下载完成
            {
                DownloadProgressBar.Value = iPos;
                if (!CHCNetSDK.NET_DVR_StopGetFile(m_lDownHandle))
                {
                    iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    str = "NET_DVR_StopGetFile failed, error code= " + iLastErr; //下载控制失败，输出错误号
                    MessageBox.Show(str);
                    return;
                }
                m_lDownHandle = -1;
                timerDownload.Stop(); 
            }

            if (iPos == 200) //网络异常，下载失败
            {
                MessageBox.Show("The downloading is abnormal for the abnormal network!");
                timerDownload.Stop();
            }
        }

        private void timerPlayback_Tick(object sender, EventArgs e)
        {
            PlaybackprogressBar.Maximum = 100;
            PlaybackprogressBar.Minimum = 0;

            uint iOutValue = 0;
            int iPos = 0;

            IntPtr lpOutBuffer = Marshal.AllocHGlobal(4);

            //获取回放进度
            CHCNetSDK.NET_DVR_PlayBackControl_V40(m_lPlayHandle, CHCNetSDK.NET_DVR_PLAYGETPOS, IntPtr.Zero, 0, lpOutBuffer, ref iOutValue);

            iPos = (int)Marshal.PtrToStructure(lpOutBuffer, typeof(int));

            if ((iPos > PlaybackprogressBar.Minimum) && (iPos < PlaybackprogressBar.Maximum))
            {
                PlaybackprogressBar.Value = iPos;
            }

            if (iPos == 100)  //回放结束
            {
                PlaybackprogressBar.Value = iPos;
                if (!CHCNetSDK.NET_DVR_StopPlayBack(m_lPlayHandle))
                {
                    iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    str = "NET_DVR_StopPlayBack failed, error code= " + iLastErr; //回放控制失败，输出错误号
                    MessageBox.Show(str);
                    return;
                }
                m_lPlayHandle = -1;
                timerPlayback.Stop();
            }

            if (iPos == 200) //网络异常，回放失败
            {
                MessageBox.Show("The playback is abnormal for the abnormal network!");
                timerPlayback.Stop();
            }
            Marshal.FreeHGlobal(lpOutBuffer);
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            //初始化时间
            string NVR_IP, NVR_name, NVR_password;
            Int16 NVR_port;
            readNVRsetting(out NVR_IP, out NVR_port, out NVR_name, out NVR_password);
            readNETsetting(out NET_testlineNo, out NET_authCode);
            readCHANNELsetting();
            textBoxIP.Text = NVR_IP;
            textBoxPort.Text = NVR_port.ToString();
            textBoxUserName.Text = NVR_name;
            textBoxPassword.Text = NVR_password;
            textBoxTestLineNo.Text = NET_testlineNo;
            textBoxAuthCode.Text = NET_authCode;
            dateTimeStart.Text = DateTime.Now.ToShortDateString();
            dateTimeEnd.Text = DateTime.Now.ToString();
            dateTimePickerJcKssj.Text = DateTime.Now.ToString("yyyy-MM-dd")+" 00:00:00";
            dateTimePickerJcJssj.Text= DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59";
            sql = new SqlControl();
            if (initNetInter())
            {
                //buttonFlash.Enabled = true;
            }
            else
            {
                //buttonFlash.Enabled = false;
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            //停止回放 Stop playback
            if (m_lPlayHandle >= 0)
            {
                CHCNetSDK.NET_DVR_StopPlayBack(m_lPlayHandle);
                m_lPlayHandle = -1;
            }

            //停止下载 Stop download
            if (m_lDownHandle >= 0)
            {
                CHCNetSDK.NET_DVR_StopGetFile(m_lDownHandle);
                m_lDownHandle = -1;            
            }

            //注销登录 Logout the device
            if (m_lUserID >= 0)
            {
                CHCNetSDK.NET_DVR_Logout(m_lUserID);
                m_lUserID = -1;
            }
            try
            {
                if (uploadThread != null)
                {
                    if (uploadThread.IsAlive)
                    {
                        uploadThread.Abort();
                    }
                }
            }
            catch
            { }
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            NET_testlineNo = textBoxTestLineNo.Text;
            NET_authCode = textBoxAuthCode.Text;
            saveNETsetting(NET_testlineNo, NET_authCode);
        }

        private void buttonFlash_Click(object sender, EventArgs e)
        {
            if (!isUploading)
            {
                buttonFlash.Enabled = false;
                buttonStopRefresh.Enabled = true;
                isUploading = true;
                try
                {
                    if (uploadThread != null)
                    {
                        if (uploadThread.IsAlive)
                        {
                            uploadThread.Abort();
                        }
                    }
                }
                catch
                { }
                uploadThread = new Thread(upload_Progress);
                uploadThread.Start();
            }
            else
            {
                MessageBox.Show("正在上传数据，不能刷新列表");
            }
        }
        private void upload_Progress()
        {
            try
            {
                while (true)
                {
                    DataTable dt = sql.getCarList(dateTimePickerJcKssj.Value, dateTimePickerJcJssj.Value);
                    listViewCar.Items.Clear();
                    if (dt != null)
                        if (dt.Rows.Count > 0)
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                DataRow dr = dt.Rows[i];
                                if (dr["HasUpload"].ToString() == "Y")
                                {
                                    listViewFinish.Items.Add(new ListViewItem(new string[] { dr["CLID"].ToString(), dr["VideoFrontUrl"].ToString(), dr["VideoBackUrl"].ToString() }));
                                }
                                else
                                {
                                    listViewCar.Items.Add(new ListViewItem(new string[] { dr["CLID"].ToString(), dr["JCSJ"].ToString(), "待处理", dr["JCKSSJ"].ToString(), dr["JCJSSJ"].ToString(), dr["LINEID"].ToString() }));
                                }
                            }
                        }
                    if (listViewCar.Items.Count > 0)
                    {
                        for (int i = 0; i < listViewCar.Items.Count; i++)
                        {
                            listViewCar.Items[i].SubItems[2].Text = "准备下载";
                            string clid = listViewCar.Items[i].SubItems[0].Text;
                            string jcsj = DateTime.Parse(listViewCar.Items[i].SubItems[1].Text).ToString("yyyyMMdd");
                            int lineindex = int.Parse(listViewCar.Items[i].SubItems[5].Text);
                            DateTime jckssj = DateTime.Now, jcjssj = DateTime.Now;
                            LogMessage("准备下载视频，车辆ID=" + clid);
                            string frontvideourl = jcsj+"//"+ clid  + "front.mp4";
                            string backvideourl = jcsj + "//"+clid  + "back.mp4";
                            bool isfrontvideoexist = false, isbackvideoexist = false;
                            if (File.Exists(frontvideourl))
                            {
                                LogMessage("前视频已存在");
                                isfrontvideoexist = true;
                            }
                            if (File.Exists(backvideourl))
                            {
                                LogMessage("后视频已存在");
                                isbackvideoexist = true;
                            }
                            if (!isfrontvideoexist || !isbackvideoexist)
                            {
                                if (!DateTime.TryParse(listViewCar.Items[i].SubItems[3].Text, out jckssj))
                                {
                                    LogError("检测开始时间格式异常:" + listViewCar.Items[i].SubItems[3].Text);
                                    continue;
                                }
                                if (!DateTime.TryParse(listViewCar.Items[i].SubItems[4].Text, out jcjssj))
                                {
                                    LogError("检测结束时间格式异常:" + listViewCar.Items[i].SubItems[4].Text);
                                    continue;
                                }
                                TimeSpan ts = jcjssj - jckssj;
                                if (ts.TotalMinutes > 15)//如果检测过程长于15分钟，只取最后15分钟的视频
                                {
                                    LogWarning("检测时长大于15分钟，视频将下载最后15分钟");
                                    jckssj = jcjssj.AddMinutes(-15);
                                }
                                if (!isfrontvideoexist)
                                {
                                    listViewCar.Items[i].SubItems[2].Text = "开始下载前视频";
                                    string message;
                                    if (DownloadTime(jckssj, jcjssj, frontvideourl, (uint)(testLineChanel[lineindex - 1, 0]), out message))
                                    {
                                        listViewCar.Items[i].SubItems[2].Text = "前视频下载中...";
                                        while(m_lDownHandle>=0)
                                        {
                                            Thread.Sleep(2000);
                                        }
                                        listViewCar.Items[i].SubItems[2].Text = "前视频下载完成";
                                    }
                                    else
                                    {
                                        buttonFlash.Enabled = true;
                                        buttonStopRefresh.Enabled = false;
                                        LogError(message);
                                        isUploading = false;
                                        return;
                                    }
                                    listViewCar.Items[i].SubItems[2].Text = "开始下载后视频";
                                    if (DownloadTime(jckssj, jcjssj, backvideourl, (uint)(testLineChanel[lineindex - 1, 1]), out message))
                                    {
                                        listViewCar.Items[i].SubItems[2].Text = "后视频下载中...";
                                        while (m_lDownHandle >= 0)
                                        {
                                            Thread.Sleep(2000);
                                        }
                                        listViewCar.Items[i].SubItems[2].Text = "后视频下载完成";
                                    }
                                    else
                                    {
                                        buttonFlash.Enabled = true;
                                        buttonStopRefresh.Enabled = false;
                                        LogError(message);
                                        isUploading = false;
                                        return;
                                    }
                                    listViewCar.Items[i].SubItems[2].Text = "上传视频路径至平台";
                                    string result, info;
                                    Pictrue_Video model = new Pictrue_Video();
                                    model.serialNo = clid;
                                    model.fileModelType = "2";
                                    model.fileType = "2";
                                    model.fileName = clid + "front.mp4";
                                    model.remoteUrl = frontvideourl;
                                    model.imgType = "1";
                                    model.fileContent = "";
                                    jx2interface.writePictureVideo(model,out result,out info);
                                    if(result!="true")
                                    {
                                        buttonFlash.Enabled = true;
                                        buttonStopRefresh.Enabled = false;
                                        LogError("上传前视频信息失败:"+ info);
                                        isUploading = false;
                                        return;
                                    }
                                    else
                                    {
                                        LogMessage("上传前视频信息成功");
                                    }
                                    model.fileName = clid + "back.mp4";
                                    model.remoteUrl = backvideourl;
                                    model.imgType = "2";
                                    model.fileContent = "";
                                    jx2interface.writePictureVideo(model, out result, out info);
                                    if (result != "true")
                                    {
                                        buttonFlash.Enabled = true;
                                        buttonStopRefresh.Enabled = false;
                                        LogError("上传后视频信息失败:" + info);
                                        isUploading = false;
                                        return;
                                    }
                                    else
                                    {
                                        LogMessage("上传后视频信息成功");
                                    }
                                    listViewCar.Items[i].SubItems[2].Text = "上传完成";
                                    sql.updataCarInf(clid, "Y", frontvideourl, backvideourl);
                                    LogMessage("更新数据库完毕");
                                }
                            }
                        }
                    }
                    if (!checkBoxAutoRefresh.Checked)
                    {
                        buttonFlash.Enabled = true;
                        buttonStopRefresh.Enabled = false;
                        isUploading = false;
                        return;
                    }
                    Thread.Sleep(2000);
                }
            }
            catch(Exception er)
            {
                buttonFlash.Enabled = true;
                buttonStopRefresh.Enabled = false;
                logControl.saveLogInf("上传过程中发生异常:" + er.Message);
                LogError("上传过程中发生异常:" + er.Message);
                isUploading = true;
            }
        }
        private bool DownloadTime(DateTime jckssj,DateTime jcjssj,string url,uint ch_index,out string message)
        {
            message = "";
            if (m_lDownHandle >= 0)
            {
                message="有下载任务正在进行中!";//正在下载，请先停止下载
                return false;
            }

            CHCNetSDK.NET_DVR_PLAYCOND struDownPara = new CHCNetSDK.NET_DVR_PLAYCOND();
            struDownPara.dwChannel = ch_index; //通道号 Channel number  

            //设置下载的开始时间 Set the starting time
            struDownPara.struStartTime.dwYear = (uint)jckssj.Year;
            struDownPara.struStartTime.dwMonth = (uint)jckssj.Month;
            struDownPara.struStartTime.dwDay = (uint)jckssj.Day;
            struDownPara.struStartTime.dwHour = (uint)jckssj.Hour;
            struDownPara.struStartTime.dwMinute = (uint)jckssj.Minute;
            struDownPara.struStartTime.dwSecond = (uint)jckssj.Second;

            //设置下载的结束时间 Set the stopping time
            struDownPara.struStopTime.dwYear = (uint)jcjssj.Year;
            struDownPara.struStopTime.dwMonth = (uint)jcjssj.Month;
            struDownPara.struStopTime.dwDay = (uint)jcjssj.Day;
            struDownPara.struStopTime.dwHour = (uint)jcjssj.Hour;
            struDownPara.struStopTime.dwMinute = (uint)jcjssj.Minute;
            struDownPara.struStopTime.dwSecond = (uint)jcjssj.Second;

            string sVideoFileName=ftpdir+ url;  //录像文件保存路径和文件名 the path and file name to save  

            //按时间下载 Download by time
            m_lDownHandle = CHCNetSDK.NET_DVR_GetFileByTime_V40(m_lUserID, sVideoFileName, ref struDownPara);
            if (m_lDownHandle < 0)
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                str = "NET_DVR_GetFileByTime_V40 failed, error code= " + iLastErr;
                message="开启下载出现错误:"+str;
                return false;
            }

            uint iOutValue = 0;
            if (!CHCNetSDK.NET_DVR_PlayBackControl_V40(m_lDownHandle, CHCNetSDK.NET_DVR_PLAYSTART, IntPtr.Zero, 0, IntPtr.Zero, ref iOutValue))
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                str = "NET_DVR_PLAYSTART failed, error code= " + iLastErr; //下载控制失败，输出错误号
                message = "开启下载出现错误:" + str;
                return false;
            }

            timerDownload2.Interval = 1000;
            timerDownload2.Enabled = true;
            buttonStopRefresh.Enabled = true;
            return true;
        }
        private void checkBoxAutoRefresh_CheckedChanged(object sender, EventArgs e)
        {
            var config = ConfigFile.LoadOrCreateFile("config.test");
            config["AUTOREFRESH"] = checkBoxAutoRefresh.Checked?"Y":"N";
        }

        private void btnSound_Click(object sender, EventArgs e)
        {
            uint iOutValue = 0;
            if (!m_bSound)
            {
                if (!CHCNetSDK.NET_DVR_PlayBackControl_V40(m_lPlayHandle, CHCNetSDK.NET_DVR_PLAYSTARTAUDIO, IntPtr.Zero, 0, IntPtr.Zero, ref iOutValue))
                {
                    iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    str = "NET_DVR_PLAYSTARTAUDIO failed, error code= " + iLastErr; //回放控制失败，输出错误号
                    MessageBox.Show(str);
                    return;
                }
                m_bSound = true;
                btnSound.Text = "Stop";
                labelSound.Text = "关闭声音";
            }
            else
            {
                if (!CHCNetSDK.NET_DVR_PlayBackControl_V40(m_lPlayHandle, CHCNetSDK.NET_DVR_PLAYSTOPAUDIO, IntPtr.Zero, 0, IntPtr.Zero, ref iOutValue))
                {
                    iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    str = "NET_DVR_PLAYSTOPAUDIO failed, error code= " + iLastErr; //回放控制失败，输出错误号
                    MessageBox.Show(str);
                    return;
                }
                m_bSound = false;
                btnSound.Text = "Sound";
                labelSound.Text = "打开声音";
            }
        }

        #region 日志记录、支持其他线程访问 
        public delegate void LogAppendDelegate(Color color, string text);
        /// <summary> 
        /// 追加显示文本 
        /// </summary> 
        /// <param name="color">文本颜色</param> 
        /// <param name="text">显示文本</param> 
        public void LogAppend(Color color, string text)
        {
            richTextBox1.AppendText("\n");
            richTextBox1.SelectionColor = color;
            richTextBox1.AppendText(text);
        }
        /// <summary> 
        /// 显示错误日志 
        /// </summary> 
        /// <param name="text"></param> 
        public void LogError(string text)
        {
            LogAppendDelegate la = new LogAppendDelegate(LogAppend);
            richTextBox1.Invoke(la, Color.Red, DateTime.Now.ToString("HH:mm:ss ") + text);
        }
        /// <summary> 
        /// 显示警告信息 
        /// </summary> 
        /// <param name="text"></param> 
        public void LogWarning(string text)
        {
            LogAppendDelegate la = new LogAppendDelegate(LogAppend);
            richTextBox1.Invoke(la, Color.Violet, DateTime.Now.ToString("HH:mm:ss ") + text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveChanelsetting();
        }

        private void timerDownload2_Tick(object sender, EventArgs e)
        {
            DownloadProgressBar2.Maximum = 100;
            DownloadProgressBar2.Minimum = 0;

            int iPos = 0;

            //获取下载进度
            iPos = CHCNetSDK.NET_DVR_GetDownloadPos(m_lDownHandle);

            if ((iPos > DownloadProgressBar2.Minimum) && (iPos < DownloadProgressBar.Maximum))
            {
                DownloadProgressBar2.Value = iPos;
            }

            if (iPos == 100)  //下载完成
            {
                DownloadProgressBar2.Value = iPos;
                if (!CHCNetSDK.NET_DVR_StopGetFile(m_lDownHandle))
                {
                    iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    str = "NET_DVR_StopGetFile failed, error code= " + iLastErr; //下载控制失败，输出错误号
                    MessageBox.Show(str);
                    return;
                }
                m_lDownHandle = -1;
                timerDownload2.Stop();
            }

            if (iPos == 200) //网络异常，下载失败
            {
                MessageBox.Show("The downloading is abnormal for the abnormal network!");
                timerDownload2.Stop();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (uploadThread != null)
                {
                    if (uploadThread.IsAlive)
                        uploadThread.Abort();
                }
            }
            catch
            { }
            buttonFlash.Enabled = true;
            buttonStopRefresh.Enabled = false;
            isUploading = false;
            LogMessage("上传过程终止成功!");
            if (m_lDownHandle < 0)
            {
                LogMessage("当前没有下载任务!");
                return;
            }

            if (!CHCNetSDK.NET_DVR_StopGetFile(m_lDownHandle))
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                str = "NET_DVR_StopGetFile failed, error code= " + iLastErr; //下载控制失败，输出错误号
                LogWarning("下载过程终止失败:"+str);
                //MessageBox.Show(str);
                return;
            }
            timerDownload2.Stop();
            LogMessage("下载过程终止成功!");
            m_lDownHandle = -1;
            DownloadProgressBar2.Value = 0;
        }

        private void buttonSyncTime_Click(object sender, EventArgs e)
        {
            CHCNetSDK.NET_DVR_TIME dvr_time = new CHCNetSDK.NET_DVR_TIME();
            dvr_time.dwYear = (uint)DateTime.Now.Year;
            dvr_time.dwMonth = (uint)DateTime.Now.Month;
            dvr_time.dwDay = (uint)DateTime.Now.Day;
            dvr_time.dwHour = (uint)DateTime.Now.Hour;
            dvr_time.dwMinute = (uint)DateTime.Now.Minute;
            dvr_time.dwSecond = (uint)DateTime.Now.Second;
            Int32 nSize = Marshal.SizeOf(dvr_time);
            IntPtr ptrShowStrCfg = Marshal.AllocHGlobal(nSize);
            Marshal.StructureToPtr(dvr_time, ptrShowStrCfg, false);
            if (!CHCNetSDK.NET_DVR_SetDVRConfig(m_lPlayHandle, CHCNetSDK.NET_DVR_SET_TIMECFG, -1, ptrShowStrCfg, (UInt32)nSize))
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                str = "同步时间失败, error code= " + iLastErr;
                MessageBox.Show(str);
                return;
            }
            else
            {
                str = "同步时间成功" ;
                MessageBox.Show(str);
            }
        }

        /// <summary> 
        /// 显示信息 
        /// </summary> 
        /// <param name="text"></param> 
        public void LogMessage(string text)
        {
            LogAppendDelegate la = new LogAppendDelegate(LogAppend);
            richTextBox1.Invoke(la, Color.Black, DateTime.Now.ToString("HH:mm:ss ") + text);
        }
        #endregion
    }
}
