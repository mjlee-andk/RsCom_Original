using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.IO.Ports;
using mySetting = RsComCs.Properties.Settings;

namespace RsComCs
{
    public partial class Main : Form
    {
        public delegate void msgCallback(string str);   // 대리자 선언 (dispMessage에서 사용)

        public string CrLf = "\r\n";
        public string Cr = "\r";

        string pureStr = string.Empty;      // 전송 받은 데이터
        string terminator = string.Empty;   // 터미네이터

        uint dataNum = 0;                   // 시퀀스 변수  
        int sectimer = 0;                   // 커맨드 반복주기 입력 박스
        bool iconShow;                       // 타이머 2

        string txtToPrint = string.Empty;   // 프린트 관련 변수

        Int32 allowedLine = 1000;         // 모든 옵션 체크 상태에서 약 9,000~10,000라인
        
        public Main()
        {
            InitializeComponent();
            this.ComPort.DataReceived += new SerialDataReceivedEventHandler(this.RS_DataReceived);      // 이벤트 핸들러
            //this.ComPort.ErrorReceived += new SerialErrorReceivedEventHandler(this.RS_ErrorReceived);
            this.Resize += new System.EventHandler(this.Main_Resize);                                   // 이벤트 핸들러
//            txtBox.MaxLength = 0;
        }

        // 메인폼 로드 (이전 설정값을 읽어온다)
        private void Main_Load(object sender, EventArgs e)
        {
            // 사용 가능한 포트를 읽어온다
            foreach (string str in SerialPort.GetPortNames())
            {
                ((ComboBox)boxPort).Items.Add(str);
            }
            // 설정값 읽어옴
            boxPort.Text = mySetting.Default.PortDefault;
            boxBaudrate.Text = mySetting.Default.BpsDefault;
            boxLength.Text = mySetting.Default.LengthDefault;
            boxParity.Text = mySetting.Default.ParityDefault;
            boxStopbits.Text = mySetting.Default.StopDefault;
            boxTerminator.Text = mySetting.Default.TerminatorDefault;
            formTime.Checked = mySetting.Default.formTime;
            formDate.Checked = mySetting.Default.formDate;
            formSeq.Checked = mySetting.Default.formSeq;
            formCommand.Checked = mySetting.Default.formCommand;
            formPU.Checked = mySetting.Default.formPU;
            formRepeat.Checked = mySetting.Default.formRepeat;
            txtRepeat.Text = mySetting.Default.txtRepeat;
            txtCommand.Text = mySetting.Default.txtCommand;
            txtBox.MaxLength = 0;
        }

        // rs 수신 이벤트
        private void RS_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Thread msgThread = new Thread(new ParameterizedThreadStart(callThread));    // 스레드 생성 및 초기화
            string stringdata = string.Empty;   // 표시창에 출력되는 문자열 데이터
            try
            {
                pureStr = ComPort.ReadTo(terminator);
                stringdata = pureStr;
            }
            catch (TimeoutException)
            {
                pureStr = ComPort.ReadExisting();
                stringdata = pureStr;
            }
            //catch
            //{
            //    stringdata = string.Empty;
            //    return;
            //}
            msgThread.Start(stringdata);    // 스레드 시작            
        }

        // 데이터를 만들고 메시지 함수 호출
        private void callThread(object obj)
        {
            string str;
            str = Convert.ToString(obj);
            str = makeFormat(str);
            dispMessage(str);
        }

        // 데이터 포맷 형성
        private string makeFormat(string _data)
        {
            // 시간, 날짜, 시퀀스 변수
            string dataTime = string.Empty;
            string dataDate = string.Empty;
            string dataSeq = string.Empty;

            string StrData = string.Empty;
            bool Flag = false;

            // PU 함수
            if (formPU.Checked)
            {
                for (int i = 0; i < _data.Length; i++)
                {
                    switch (_data.Substring(i, 1))
                    {
                        case "0":
                        case "1":
                        case "2":
                        case "3":
                        case "4":
                        case "5":
                        case "6":
                        case "7":
                        case "8":
                        case "9":
                        case ".":
                            Flag = true;
                            StrData =  StrData + _data.Substring(i, 1);
                            break;
                        default:
                            if (Flag)
                            {
                                StrData = StrData + ",";
                            }
                            Flag = false;
                            StrData = StrData + _data.Substring(i, 1);
                            break;
                    }
                }
                _data = StrData;
            }

            if (formTime.Checked)
                dataTime = "," + DateTime.Now.ToString("hh:mm:ss");
            else
                dataTime = string.Empty;

            if (formDate.Checked)
                dataDate = "," + DateTime.Now.ToString("yyyy/mm/dd");
            else
                dataDate = string.Empty;

            if (formSeq.Checked)
            {
                dataNum = dataNum + 1;
                dataSeq = "," + dataNum.ToString();
            }
            else
            {
                dataNum = 0;
                dataSeq = string.Empty;
            }

            _data = _data + dataTime + dataDate + dataSeq;

            return _data;
        }

        // 텍스트 박스에 메시지 표시
        private void dispMessage(string str)
        {
            if (this.txtBox.InvokeRequired)
            {
                msgCallback d = new msgCallback(dispMessage);
                this.Invoke(d, new object[] { str });
            }
            else
            {
                //if (txtBox.Text.Length > allowedLine)
                //{
                //    Int32 endmarker = txtBox.Text.IndexOf('\n', allowedLine / 4) + 1;
                //    if (endmarker < allowedLine / 4)
                //        endmarker = allowedLine / 4;
                //    txtBox.Select(0, endmarker);
                //    txtBox.Cut();
                //}

                //txtBox.SelectionStart = txtBox.Text.Length;
                //txtBox.SelectionLength = 0;

                this.txtReceivedata.Clear();
                this.txtBox.AppendText(str + terminator);
                this.txtReceivedata.AppendText(pureStr);    // 오리지널 수신 데이터(전역변수)
                this.txtBox.ScrollToCaret();
            }
        }

        // 타이머
        private void timer1_Tick(object sender, EventArgs e)
        {
            int ret = Convert.ToInt16(mySetting.Default.txtRepeat) * 10;
            Thread commandThread = new Thread(new ParameterizedThreadStart(callThread));
            sectimer = sectimer + 1;
            ComPort.NewLine = terminator;
            if (formRepeat.Checked)
            {
                if (ret == 0)
                {
                    if (formCommand.Checked)
                    {
                        commandThread.Start(txtCommand.Text);
                    }
                    ComPort.WriteLine(txtCommand.Text);
                }
                else if (ret == sectimer)
                {
                    sectimer = 0;
                    if (formCommand.Checked)
                    {
                        commandThread.Start(txtCommand.Text);
                    }
                    ComPort.WriteLine(txtCommand.Text);
                }
            }
        }
        
        // 아이콘 타이머
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (ComPort.IsOpen)
            {
                if (iconShow)
                {
                    this.Icon = RsComCs.Properties.Resources.MISC13;
                    iconShow = false;
                }
                else
                {
                    this.Icon = RsComCs.Properties.Resources.MISC15;
                    iconShow = true;
                }        
            }
        }

        // 표시 박스 리사이징
        private void Main_Resize(Object sender, EventArgs e)
        {
            txtBox.Width = this.Width - 40;
            txtBox.Height = this.Height - 350;
        }

        #region 버튼 관련 함수

        // 화면 지움
        private void btnClear_Click(object sender, EventArgs e)
        {
            DialogResult ret;
            if (txtBox.Text != string.Empty)
            {
                ret = MessageBox.Show("Will you clear this data", "RsCom C#", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                if (ret == DialogResult.Yes)
                    this.txtBox.Clear();
            }
        }

        // 저장
        private void btnSave_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        // 저장 OK or Calcel 선택  (saveFileDialog1 의 OK 이벤트)
        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            txtBox.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
        }

        // 프린트
        private void btnPrint_Click(object sender, EventArgs e)
        {
            txtToPrint = txtBox.Text;
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        // printDocument1 인스턴스 더블클릭으로 생성
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int linesPerPage = 0;
            int charOnPage = 0;

            e.Graphics.MeasureString(txtToPrint, Font, e.MarginBounds.Size, StringFormat.GenericTypographic, out charOnPage, out linesPerPage);
            e.Graphics.DrawString(txtToPrint, Font, Brushes.Black, e.MarginBounds, StringFormat.GenericTypographic);
            txtToPrint = txtToPrint.Substring(charOnPage);
            e.HasMorePages = (txtToPrint.Length > 0);
        }

        // 포트 오픈
        private void btnOpen_Click(object sender, EventArgs e)
        {
            Thread commandKeyThread = new Thread(new ParameterizedThreadStart(callThread));
            ComPort.NewLine = terminator;
            if (ComPort.IsOpen)
            {
                // 커맨드 메시지 표시
                if (formCommand.Checked)
                {
                    commandKeyThread.Start(txtCommand.Text);
                }
                ComPort.WriteLine(txtCommand.Text);
            }
            else
            {
                try
                {
                    ComPort.Open();
                    timer1.Start();
                    timer2.Start();
                    // 콤보박스 비활성화
                    boxPort.Enabled = false;
                    boxBaudrate.Enabled = false;
                    boxLength.Enabled = false;
                    boxParity.Enabled = false;
                    boxStopbits.Enabled = false;
                    boxTerminator.Enabled = false;
                    // 커맨드, 스탑버튼으로 변경
                    btnOpen.Text = "Command";
                    btnClose.Text = "Stop";
                    if (formRepeat.Checked)
                    {
                        btnSave.Enabled = false;
                        btnPrint.Enabled = false;
                        btnOpen.Enabled = false;
                        txtCommand.Enabled = false;
                    }
                }
                catch
                {
                    // 포트 사용중일 때
                    MessageBox.Show("Can not Open !" + CrLf + "Please Check Setting of Com Port !", "RsCom", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // 포트 닫기
        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult ret = 0;
            timer1.Stop();
            timer2.Stop();
            btnSave.Enabled = true;
            btnPrint.Enabled = true;
            btnOpen.Enabled = true;
            txtCommand.Enabled = true;
            dataNum = 0;    // 시퀀스 넘버 리셋
            sectimer = 0;   // 타이머 리셋
            this.Icon = RsComCs.Properties.Resources.AND_Blue;  //아이콘 변경
            iconShow = true;    // 아이콘 관련
            if (ComPort.IsOpen)
            {
                ComPort.Close();
                // 콤보박스 활성화
                boxPort.Enabled = true;
                boxBaudrate.Enabled = true;
                boxLength.Enabled = true;
                boxParity.Enabled = true;
                boxStopbits.Enabled = true;
                boxTerminator.Enabled = true;
            }
            else
            {
                if (txtBox.Text != string.Empty)
                {
                    ret = MessageBox.Show("Will you save this data", "RsCom C#", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                    if (ret == DialogResult.Yes)
                    {
                        this.Close();
                    }
                    else if (ret == DialogResult.No)
                    {
                        this.Close();
                    }
                }
                else
                {
                    this.Close();                    
                }
            }
            btnOpen.Text = "Start";
            btnClose.Text = "End";
        }

        #endregion

        #region 좌측 콤보박스

        // 포트 선택
        private void boxPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            mySetting.Default.PortDefault = boxPort.Text;
            ComPort.PortName = mySetting.Default.PortDefault;
        }

        // 보레이트 선택
        private void boxBaudrate_SelectedIndexChanged(object sender, EventArgs e)
        {
            mySetting.Default.BpsDefault = boxBaudrate.Text;
            ComPort.BaudRate = Convert.ToInt32(mySetting.Default.BpsDefault);
        }

        // 데이터 길이 선택
        private void boxLength_SelectedIndexChanged(object sender, EventArgs e)
        {
            mySetting.Default.LengthDefault = boxLength.Text;
            ComPort.DataBits = Convert.ToInt32(mySetting.Default.LengthDefault);
        }

        // 패리티
        private void boxParity_SelectedIndexChanged(object sender, EventArgs e)
        {
            mySetting.Default.ParityDefault = boxParity.Text;
            if (mySetting.Default.ParityDefault == "Even")
            {
                ComPort.Parity = Parity.Even;
            }
            else if (mySetting.Default.ParityDefault == "Odd")
            {
                ComPort.Parity = Parity.Odd;
            }
            else if (mySetting.Default.ParityDefault == "None")
            {
                ComPort.Parity = Parity.None;
            }
        }

        // 스탑비트
        private void boxStopbits_SelectedIndexChanged(object sender, EventArgs e)
        {
            mySetting.Default.StopDefault = boxStopbits.Text;
            if (mySetting.Default.StopDefault == "1")
            {
                ComPort.StopBits = StopBits.One;
            }
            else if (mySetting.Default.StopDefault == "1.5")
            {
                ComPort.StopBits = StopBits.OnePointFive;
            }
            else if (mySetting.Default.StopDefault == "2")
            {
                ComPort.StopBits = StopBits.Two;
            }
        }

        // 종료문자
        private void boxTerminator_SelectedIndexChanged(object sender, EventArgs e)
        {
            mySetting.Default.TerminatorDefault = boxTerminator.Text;
            if (mySetting.Default.TerminatorDefault == "CR/LF")
            {
                terminator = CrLf;
            }
            else if (mySetting.Default.TerminatorDefault == "CR")
            {
                terminator = Cr;
            }
        }

        #endregion

        #region 우측 체크 박스

        // 커맨드 주기 체크
        private void formRepeat_CheckedChanged(object sender, EventArgs e)
        {
            if (formRepeat.Checked)
            {
                mySetting.Default.formRepeat = true;
                if (ComPort.IsOpen)
                {
                    btnSave.Enabled = false;
                    btnPrint.Enabled = false;
                    btnOpen.Enabled = false;
                    txtCommand.Enabled = false;
                }
                else
                {
                    btnSave.Enabled = true;
                    btnPrint.Enabled = true;
                    btnOpen.Enabled = true;
                    txtCommand.Enabled = true;
                }
            }
            else
            {
                mySetting.Default.formRepeat = false;
                btnSave.Enabled = true;
                btnPrint.Enabled = true;
                btnOpen.Enabled = true;
                txtCommand.Enabled = true;
            }
            sectimer = 0;
        }

        // 커맨드 주기 설정
        private void txtRepeat_TextChanged(object sender, EventArgs e)
        {
            if (txtRepeat.Text == string.Empty)
            {
                txtRepeat.Text = "0";
            }
            else
            {
                mySetting.Default.txtRepeat = txtRepeat.Text;
            }
            sectimer = 0;
        }

        // 시간 표시
        private void formTime_CheckedChanged(object sender, EventArgs e)
        {
            if (formTime.Checked)
            {
                mySetting.Default.formTime = true;
            }
            else
            {
                mySetting.Default.formTime = false;
            }
        }

        // 날짜 표시
        private void formDate_CheckedChanged(object sender, EventArgs e)
        {
            if (formDate.Checked)
            {
                mySetting.Default.formDate = true;
            }
            else
            {
                mySetting.Default.formDate = false;
            }
        }

        // 시퀀스 넘버 표시
        private void formSeq_CheckedChanged(object sender, EventArgs e)
        {
            if (formSeq.Checked)
            {
                mySetting.Default.formSeq = true;
            }
            else
            {
                mySetting.Default.formSeq = false;
            }
        }

        // 화면에 커맨드 표시
        private void formCommand_CheckedChanged(object sender, EventArgs e)
        {
            if (formCommand.Checked)
            {
                mySetting.Default.formCommand = true;
            }
            else
            {
                mySetting.Default.formCommand = false;
            }
        }

        // 숫자 데이터와 단위 구분 문자 , 삽입
        private void formPU_CheckedChanged(object sender, EventArgs e)
        {
            if (formPU.Checked)
            {
                mySetting.Default.formPU = true;
            }
            else
            {
                mySetting.Default.formPU = false;
            }
        }

        // 커맨드 명령어
        private void txtCommand_SelectedIndexChanged(object sender, EventArgs e)
        {
            mySetting.Default.txtCommand = txtCommand.Text;
        }

        #endregion
    }
}
