using System;
using System.Windows;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Diagnostics;

namespace ScreenSaver
{
    public partial class Form1 : Form
    {
        private Thread ReaderThread;
        List<string> PhotoList=null; 
        static bool Paused=false;
        bool Idle=false;
        //MouseHook mh;
        public Form1()
        {
            InitializeComponent();
            //mh = new MouseHook();
            //mh.SetHook();
            //mh.MouseMoveEvent  += OnMouseMove;
            //mh.MouseClickEvent += OnMouseEvent;
        	GetFileList();
            StartDisplay();
            SetFullScreen();
            //Hide();
            //Visible=false;
            this.WindowState = FormWindowState.Minimized;
        }

        private void GoLeftButton(object sender, EventArgs e){
            PauseCheckbox.Checked=true;
            PauseCheckboxClicked(null,null);
            if(ImageIndex-1>0)
              ImageIndex--;
        }
        private void GoRightButton(object sender, EventArgs e){
            PauseCheckbox.Checked=true;
            PauseCheckboxClicked(null,null);
            if(ImageIndex+1<PhotoList.Count)
              ImageIndex++;
        }

        private void ExitScreenSaver(object sender, EventArgs e){
            System.Windows.Forms.Application.Exit();
        }

        public void StartDisplay() {
            if (ReaderThread == null)
            {
                ReaderThread = new Thread(ReadImages);
                ReaderThread.Priority = ThreadPriority.Normal;
                ReaderThread.IsBackground = true;
                ReaderThread.Name = "Reader";
                ReaderThread.Start();
            }
        }

        private void SetFullScreen() {
            this.TopMost = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            float ImageWidth =Screen.PrimaryScreen.Bounds.Width;
            float ImageHeight=Screen.PrimaryScreen.Bounds.Height;
            this.PictureFrame.Width  = (int)ImageWidth;
            this.PictureFrame.Height = (int)ImageHeight;

            //this.HeatmapPBox.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            this.PictureFrame.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
            //this.PictureFrame.SizeMode=PictureBoxSizeMode.StretchImage;
            this.PictureFrame.SizeMode=PictureBoxSizeMode.Normal;
            //this.PictureFrame.SizeMode=PictureBoxSizeMode.AutoSize;
            //this.PictureFrame.SizeMode=PictureBoxSizeMode.Zoom;
            this.Opacity=1.0;
        }

        private delegate void UnHideDelegate();
        private void UnHide(){
            if (this.InvokeRequired){
              object[] args = new object[] { };
              this.BeginInvoke(new UnHideDelegate(UnHide),args);
              return;
            }
            this.Show();
            this.Visible=true;
            this.WindowState = FormWindowState.Maximized;
        }

        private delegate void DisplayImageDelegate(string ImageName);
        private void DisplayImage(string ImageName){
            if (this.InvokeRequired){
              object[] args = new object[] { ImageName };
              this.BeginInvoke(new DisplayImageDelegate(DisplayImage), args);
              return;
            }

            //InterpolationMode IMode = InterpolationMode.HighQualityBilinear;
            Image bmp = Image.FromFile(ImageName);

            if(bmp.Width<bmp.Height) {
               bmp.RotateFlip(RotateFlipType.Rotate270FlipNone);
            }

            float ImageWidth     = bmp.Width;
            float ImageHeight    = bmp.Height;
            //System.Diagnostics.Debug.WriteLine("Aspect Ratio={0}",(double)bmp.Width/bmp.Height);

            if(Screen.PrimaryScreen.Bounds.Width<bmp.Width && Screen.PrimaryScreen.Bounds.Height<bmp.Height) {
                float Ratio1= (float)Screen.PrimaryScreen.Bounds.Width/bmp.Width;
                float Ratio2= (float)Screen.PrimaryScreen.Bounds.Height/bmp.Height;
                float Ratio = Math.Min(Ratio1,Ratio2);
                ImageWidth *= Ratio;
                ImageHeight*= Ratio;
                //System.Diagnostics.Debug.WriteLine("New Aspect Ratio={0}",(double)ImageWidth/ImageHeight);
            } else if(Screen.PrimaryScreen.Bounds.Width<bmp.Width) {
                float Ratio = (float)Screen.PrimaryScreen.Bounds.Width/bmp.Width;
                ImageWidth  = Screen.PrimaryScreen.Bounds.Width;
                ImageHeight*= Ratio;
            } else if(Screen.PrimaryScreen.Bounds.Height<bmp.Height){
                float Ratio = (float)Screen.PrimaryScreen.Bounds.Height/bmp.Height;
                ImageWidth *= Ratio;
                ImageHeight = Screen.PrimaryScreen.Bounds.Height;
            }

            float AnchorX        = (float)(Screen.PrimaryScreen.Bounds.Width/2.0f) - (ImageWidth/2.0f);
            float AnchorY        = (float)(Screen.PrimaryScreen.Bounds.Height*0.05);

            PictureFrame.Location= new Point((int)AnchorX,(int)AnchorY);

            PictureFrame.Width   = (int)ImageWidth;
            PictureFrame.Height  = (int)ImageHeight;
            PictureFrame.BorderStyle = BorderStyle.Fixed3D;
            Rectangle ImageRect  = new Rectangle(0,0,(int)ImageWidth,(int)ImageHeight);
            Bitmap scaledCanvas  = new Bitmap((int)ImageWidth,(int)ImageHeight,PixelFormat.Format24bppRgb);
            Graphics g=Graphics.FromImage(scaledCanvas);
            //g.InterpolationMode = IMode;
            g.DrawImage(bmp,ImageRect);
            bmp.Dispose();

            PictureFrame.Image=scaledCanvas;
            FileNameTextBox.Text=ImageName;

            if(DeleteFile.Length>0 && DeleteFile!=ImageName) {
              Thread.Sleep(10);
              File.Delete(DeleteFile);
              DeleteFile="";
            }
        }

        private void ReadImages() {
            while(true) {
               DisplayPhotos(PhotoList);
            }
        }

        private void PauseCheckboxClicked(object sender, EventArgs e) {
            if(PauseCheckbox.Checked)
              Paused=true;
            else
              Paused=false;
        }

        string DeleteFile="";
        private void DeletePhoto(object sender, EventArgs e){
            DeleteFile=PhotoList[ImageIndex];
            //System.Diagnostics.Debug.WriteLine("Delete "+FName);
            //File.Delete(FName);
            //FileIO.FileSystem.DeleteDirectory(rootdir+FName, FileIO.UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
        }
        private void DeletePhoto(string FName) {
            //FileIO.FileSystem.DeleteDirectory(rootdir+FName, FileIO.UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
        }

        Point MouseXY;
        private void OnMouseMove(object sender, System.Windows.Forms.MouseEventArgs e) {
          if (!MouseXY.IsEmpty) {
            //if (MouseXY != new Point(e.X, e.Y))
            //   Close();
          }
          MouseXY = new Point(e.X, e.Y);
        }
        private void OnMouseEvent(object sender, System.Windows.Forms.MouseEventArgs e) {
          if (!MouseXY.IsEmpty) {
            //if (MouseXY != new Point(e.X, e.Y))
            //  Close();
            //if (e.Clicks > 0)
            //  Close();
          }
          MouseXY = new Point(e.X, e.Y);
        }

        private string rootdir = "";
        private static Random rand = new Random();
	    private void GetFileList() {
   	      string path = "./";
          //var files = new DirectoryInfo(path).GetFiles(path).OrderByDescending(f => f.LastWriteTime).First();
          //string rootdir = "/mnt/c/Users/steve.c/Pictures";
          string User=System.Security.Principal.WindowsIdentity.GetCurrent().Name;
          int I=User.IndexOf("\\");
          User=User.Substring(I+1);
          System.Diagnostics.Debug.WriteLine("user={0}",User);
          rootdir = @"c:\Users\"+User+"\\Pictures";
          string Photos="*.jpg";
 
          string[] PhotoArray;
          if (!Directory.Exists(rootdir)) {
            GetTargetFolder(ref rootdir);
          }

          PhotoArray=Directory.GetFileSystemEntries(rootdir, Photos, SearchOption.AllDirectories);
          while(PhotoArray.Length==0) {
            MessageBox.Show("No photos found, Please select a different folder");
            GetTargetFolder(ref rootdir);
            PhotoArray=Directory.GetFileSystemEntries(rootdir, Photos, SearchOption.AllDirectories);
          }
          
          PhotoList =PhotoArray.ToList<string>();
          PhotoList = PhotoList.OrderBy(a => rand.Next()).ToList();
          //System.Diagnostics.Debug.WriteLine(String.Join(Environment.NewLine, PhotoList));
        }

        private void GetTargetFolder(ref string path){
            //UnHide();
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                //
                // The user selected a folder and pressed the OK button.
                // We print the number of files found.
                //
                //string[] files = Directory.GetFiles(folderBrowserDialog1.SelectedPath);
                //MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                rootdir=folderBrowserDialog1.SelectedPath;
            }
#if false
          using(var fbd = new FolderBrowserDialog()) {
              DialogResult result = fbd.ShowDialog();
          
              if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
              {
                  string[] files = Directory.GetFiles(fbd.SelectedPath);

                  System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
              }
          }
#endif
#if false
            string cmd = "explorer.exe";
            string arg = "/select, " + path;
            Process.Start(cmd, arg);
            path="";
#endif
        }

        int ImageIndex=0;
        private void DisplayPhotos(List<string> PhotoList) {
          int TmpIndex=0;
          for(ImageIndex=0;ImageIndex<PhotoList.Count;ImageIndex++) {
              string file=PhotoList[ImageIndex];

              //if(!Idle && GetIdleTime() < 30000) {
              if(!Idle && GetIdleTime() < 300) {
                Thread.Sleep(1500);
                continue;
              }
              Idle=true;
              UnHide();

              //System.Diagnostics.Debug.WriteLine("Idle Time={0}",GetIdleTime());
              while(Paused) {
                TmpIndex=ImageIndex;
                Thread.Sleep(100);
                if(TmpIndex!=ImageIndex){
                  file=PhotoList[ImageIndex];
                  if(File.Exists(file))
                    DisplayImage(file);
                }
              }
                
              //System.Diagnostics.Debug.WriteLine(file);
              if(File.Exists(file))
                DisplayImage(file);
              if(ImageSpeed.Value==0)
                Thread.Sleep(1000);
              else 
                Thread.Sleep(700*ImageSpeed.Value);
   	      }
       }

       private struct LASTINPUTINFO {
            public uint cbSize;
            public uint dwTime;
       }
       [DllImport("User32.dll")] private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);	
       public static uint GetIdleTime() {
          LASTINPUTINFO lastInPut = new LASTINPUTINFO();
          lastInPut.cbSize = (uint)System.Runtime.InteropServices.Marshal.SizeOf(lastInPut);
          GetLastInputInfo(ref lastInPut);

          return ( (uint)Environment.TickCount - lastInPut.dwTime);
       }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

}
