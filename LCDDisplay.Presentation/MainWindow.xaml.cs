using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace LCDDisplay.Presentation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        readonly DispatcherTimer _dispatcherTimer = new DispatcherTimer();
        readonly DispatcherTimer _dispatcherTimerWatch = new DispatcherTimer();
        private DateTime _now;


        public MainWindow()
        {
            InitializeComponent();

            _dispatcherTimer.Tick += DispatcherTimerTick;
            _dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 20);
            //_dispatcherTimer.Start();

            _dispatcherTimerWatch.Tick += DispatcherTimerWatchTick;
            _dispatcherTimerWatch.Interval = new TimeSpan(0, 0, 0, 0, 250);

            StartDefaultState();
        }

        readonly string password = "1234";
        string pressedPassword = "";


        Random random = new Random();
        int number1;
        int number2;
        int number3;
        int number4;

        bool isReset = true;
        bool isLock = false;
        bool stop1 = true;
        bool stop2 = true;
        bool stop3 = true;
        bool stop4 = true;

        int i = 0;

        DateTime startTime = DateTime.Now;
        Stopwatch watch = new Stopwatch();
        private void DispatcherTimerTick(object sender, EventArgs e)
        {

            _now = DateTime.Now;

            //DateTime dt2 = DateTime.ParseExact(time2, "HH:mm:ss", new DateTimeFormatInfo());



            //if (ts.Seconds == 3)
            //{
            //    timeDiff.Content = ts.Seconds;
            //    startTime = DateTime.Now;
            //}
            timelabel.Content = _now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            //string secStr2 = _now.Second.ToString("00").Remove(1);
            //string secStr1 = _now.Millisecond.ToString("000").Remove(1);

            //sec1.SetNumber(int.Parse(secStr1));

            number1 = random.Next(10);
            number2 = random.Next(10);
            number3 = random.Next(10);
            number4 = random.Next(10);

            if (stop1)
            {
                numberOne.SetNumber(number1);

                string addr = @"pack://application:,,,/LCDDisplay.Presentation;component/Assets/Sounds/beep.wav";

                Uri uri = new Uri(addr);
                string addres1 = uri.AbsoluteUri;
                string addres2 = uri.AbsolutePath;
                string addres3 = uri.LocalPath;
                //string addres4 = uri.;

                System.Reflection.Assembly a = System.Reflection.Assembly.GetExecutingAssembly();
                System.IO.Stream s = a.GetManifestResourceStream("LCDDisplay.Presentation.Assets.Sounds.beep2.wav");

                var basePath = System.AppDomain.CurrentDomain.BaseDirectory;
                System.Media.SoundPlayer player = new System.Media.SoundPlayer( );
                // player.SoundLocation= addr;
                string combine= System.IO.Path.Combine(basePath, @"\Assets\Sounds\beep.wav"); ;
                player.SoundLocation = basePath+@"Assets\Sounds\beep.wav";


                //player.Load();
              //  player.PlaySync();
            }
            else
                numberOne.SetNumber(11);// indicate L alphabet

            if (stop2)
                numberTwo.SetNumber(number2);
            else
                numberTwo.SetNumber(0);// indicate O alphabet

            if (stop3)
                numberThree.SetNumber(number3);
            else
                numberThree.SetNumber(10);// indicate C alphabet

            if (stop4)
                numberFour.SetNumber(number4);
            else
                numberFour.SetNumber(12);// indicate K alphabet
        }

        private void DispatcherTimerWatchTick(object sender, EventArgs e)
        {
            _dispatcherTimerWatch.Interval = new TimeSpan(0, 0, 0, 0, 200);

            if (i == 0)
            { stop1 = false; }
            if (i == 1)
            { stop2 = false; }
            if (i == 2)
            { stop3 = false; }
            if (i == 3)
            {
                stop4 = false;
                //   _dispatcherTimer.Stop();
                isReset = true;
                resetButton.IsEnabled = true;
                i = 0;
                _dispatcherTimerWatch.Stop();

            }
            i++;

        }



        private void resetButton_Click(object sender, RoutedEventArgs e)
        {
            // watch.Start();

            StartLockAnimation();
            //if (isReset)
            //{

            //    _dispatcherTimerWatch.Interval = new TimeSpan(0, 0, 0, 1, 0);
            //    _dispatcherTimerWatch.Start();
            //    _dispatcherTimer.Start();

            //    isReset = false;
            //    resetButton.IsEnabled = false;

            //    stop1 = true;
            //    stop2 = true;
            //    stop3 = true;
            //    stop4 = true;
            //    i = 0;

            //}
            // AltDoubleAnimationUsingKeyFramesExample();

            //stop1 = false;
            //stop2 = false;
            //stop3 = false;
            //stop4 = false;
            //numberOne.SetNumber(11);//L
            //numberTwo.SetNumber(0);//O
            //numberThree.SetNumber(10);//C
            //numberFour.SetNumber(12);//K
        }

        private void StartLockAnimation()
        {
            if (isReset)
            {

                _dispatcherTimerWatch.Interval = new TimeSpan(0, 0, 0, 1, 0);
                _dispatcherTimerWatch.Start();
                _dispatcherTimer.Start();

                isReset = false;
                isLock = true;
                resetButton.IsEnabled = false;

                stop1 = true;
                stop2 = true;
                stop3 = true;
                stop4 = true;
                i = 0;

            }
        }

        private void StartDefaultState()
        {
            numberOne.SetNumber(16);
            numberTwo.SetNumber(16);
            numberThree.SetNumber(16);
            numberFour.SetNumber(16);

            isLock = false;

            stop1 = true;
            stop2 = true;
            stop3 = true;
            stop4 = true;
            i = 0;

            _dispatcherTimerWatch.Stop();
            _dispatcherTimer.Stop();

            pressedPassword = "";
        }



        public void AltDoubleAnimationUsingKeyFramesExample()
        {
            Title = "DoubleAnimationUsingKeyFrames Example";
            Background = Brushes.White;
            Margin = new Thickness(20);

            // Create a NameScope for this page so that
            // Storyboards can be used.
            NameScope.SetNameScope(this, new NameScope());

            // Create a rectangle.
            Rectangle aRectangle = new Rectangle();
            aRectangle.Width = 100;
            aRectangle.Height = 100;
            aRectangle.Stroke = Brushes.Black;
            aRectangle.StrokeThickness = 5;

            // Create a Canvas to contain and
            // position the rectangle.
            Canvas containerCanvas = new Canvas();
            containerCanvas.Width = 610;
            containerCanvas.Height = 300;
            containerCanvas.Children.Add(aRectangle);
            Canvas.SetTop(aRectangle, 100);
            Canvas.SetLeft(aRectangle, 10);

            // Create a TranslateTransform to 
            // move the rectangle.
            TranslateTransform animatedTranslateTransform =
                new TranslateTransform();
            aRectangle.RenderTransform = animatedTranslateTransform;

            // Assign the TranslateTransform a name so that
            // it can be targeted by a Storyboard.
            this.RegisterName(
                "AnimatedTranslateTransform", animatedTranslateTransform);

            // Create a DoubleAnimationUsingKeyFrames to
            // animate the TranslateTransform.
            DoubleAnimationUsingKeyFrames translationAnimation
                = new DoubleAnimationUsingKeyFrames();
            translationAnimation.Duration = TimeSpan.FromSeconds(6);

            //// Animate from the starting position to 500
            //// over the first second using linear
            //// interpolation.
            //translationAnimation.KeyFrames.Add(
            //    new LinearDoubleKeyFrame(
            //        500, // Target value (KeyValue)
            //        KeyTime.FromTimeSpan(TimeSpan.FromSeconds(4))) // KeyTime
            //    );

            //// Animate from 500 (the value of the previous key frame) 
            //// to 400 at 4 seconds using discrete interpolation.
            //// Because the interpolation is discrete, the rectangle will appear
            //// to "jump" from 500 to 400.
            //translationAnimation.KeyFrames.Add(
            //    new DiscreteDoubleKeyFrame(
            //        400, // Target value (KeyValue)
            //        KeyTime.FromTimeSpan(TimeSpan.FromSeconds(5))) // KeyTime
            //    );

            //// Animate from 400 (the value of the previous key frame) to 0
            //// over two seconds, starting at 4 seconds (the key time of the
            //// last key frame) and ending at 6 seconds.
            //translationAnimation.KeyFrames.Add(
            //    new SplineDoubleKeyFrame(
            //        0, // Target value (KeyValue)
            //        KeyTime.FromTimeSpan(TimeSpan.FromSeconds(6)), // KeyTime
            //        new KeySpline(0.6, 0.0, 0.9, 0.0) // KeySpline
            //        )
            //    );

            // Set the animation to repeat forever. 
            translationAnimation.RepeatBehavior = RepeatBehavior.Forever;

            // Set the animation to target the X property
            // of the object named "AnimatedTranslateTransform."
            Storyboard.SetTargetName(translationAnimation, "AnimatedTranslateTransform");
            Storyboard.SetTargetProperty(
                translationAnimation, new PropertyPath(TranslateTransform.XProperty));

            // Create a storyboard to apply the animation.
            Storyboard translationStoryboard = new Storyboard();
            translationStoryboard.Children.Add(translationAnimation);

            // Start the storyboard after the rectangle loads.
            aRectangle.Loaded += delegate (object sender, RoutedEventArgs e)
            {
                translationStoryboard.Begin(this);
            };

            Content = containerCanvas;
        }



        private void Numric_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            //  MessageBox.Show(btn.Content.ToString());
            string symbol = btn.Content.ToString();
            PressButton(symbol, btn);
        }


        private void PressButton(string symbol, Button btn)
        {
            switch (symbol)
            {
                case "0":
                    {
                        // MessageBox.Show("0"); 
                        StepByStepStopAnimation(symbol, btn);
                        break;
                    }
                case "1":
                    {
                        //  MessageBox.Show("1");
                        StepByStepStopAnimation(symbol, btn);
                        break;
                    }
                case "2":
                    {
                        // MessageBox.Show("0"); 
                        StepByStepStopAnimation(symbol, btn);
                        break;
                    }
                case "3":
                    {
                        // MessageBox.Show("1"); 
                        StepByStepStopAnimation(symbol, btn);
                        break;
                    }
                case "4":
                    {
                        //  MessageBox.Show("0"); 
                        StepByStepStopAnimation(symbol, btn);
                        break;
                    }
                case "5":
                    {
                        // MessageBox.Show("1"); 
                        StepByStepStopAnimation(symbol, btn);
                        break;
                    }
                case "6":
                    {
                        // MessageBox.Show("0"); 
                        StepByStepStopAnimation(symbol, btn);
                        break;
                    }
                case "7":
                    {
                        // MessageBox.Show("1");
                        StepByStepStopAnimation(symbol, btn);
                        break;
                    }
                case "8":
                    {
                        //MessageBox.Show("0"); 
                        StepByStepStopAnimation(symbol, btn);
                        break;
                    }
                case "9":
                    {
                        //   MessageBox.Show("1"); 
                        StepByStepStopAnimation(symbol, btn);
                        break;
                    }
                case "C":
                    {
                        //  MessageBox.Show("0"); 
                        StartDefaultState();
                        break;
                    }
                case "►":
                    {
                        // MessageBox.Show("►");
                        if (isLock == false)
                        {
                            if (pressedPassword == password)
                            {
                                pressedPassword = "";
                                StartLockAnimation();
                            }
                            else
                            {
                                StartDefaultState();
                            }
                        }
                        break;
                    }
            }
        }

        private void StepByStepStopAnimation(string symbol, Button btn)
        {
            if (stop1)
            { //MessageBox.Show("0");
                stop1 = false; numberOne.SetNumber(14); pressedPassword += symbol;
            }
            else if (stop2)
            {// MessageBox.Show("1"); 
                stop2 = false; numberTwo.SetNumber(15); pressedPassword += symbol;
            }
            else if (stop3)
            { //MessageBox.Show("2"); 
                stop3 = false; numberThree.SetNumber(14); pressedPassword += symbol;
            }
            else if (stop4)
            { //MessageBox.Show("3"); 
                stop4 = false; numberFour.SetNumber(15); pressedPassword += symbol;
            }
            else
            {

                isLock = false;

                if (symbol == "►")
                {

                    PressButton(symbol, btn);
                }
            }
        }

    }
}
