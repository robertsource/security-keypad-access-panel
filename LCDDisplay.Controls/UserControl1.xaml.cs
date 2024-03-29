﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
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

namespace LCDDisplay.Controls
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {

        #region Fields

        private readonly Storyboard _storyboard1;
        private readonly Storyboard _storyboard2;
        private readonly Storyboard _storyboard3;
        private readonly Storyboard _storyboard4;
        private readonly Storyboard _storyboard5;
        private readonly Storyboard _storyboard6;
        private readonly Storyboard _storyboard7;
        private readonly Storyboard _storyboard8;
        private readonly Storyboard _storyboard9;
        private readonly Storyboard _storyboard0;
        private readonly Storyboard _storyboard10;
        private readonly Storyboard _storyboard11;
        private readonly Storyboard _storyboard12;
        private readonly Storyboard _storyboard13;
        private readonly Storyboard _storyboard14;
        private readonly Storyboard _storyboard15;
        private readonly Storyboard _storyboard16;
        private readonly Storyboard _storyboardColon;

        private const double MinimumOpacity = 0.01;

        private bool _colonComplete = true;

        #endregion

        #region Properties

        private SolidColorBrush _numberColor;
        /// <summary>
        /// Color Of Seven Segment Number
        /// </summary>
        public SolidColorBrush NumberColor
        {
            get
            {
                return _numberColor;
            }
            set
            {
                _numberColor = value;
                OnPropertyChanged("NumberColor");
            }
        }

        private SolidColorBrush _colonColor;

        /// <summary>
        /// Color Of . char
        /// </summary>
        public SolidColorBrush ColonColor
        {
            get
            {
                return _colonColor;
            }
            set
            {
                _colonColor = value;
                OnPropertyChanged("ColonColor");
            }
        }

        private Visibility _dotVisibility;
        /// <summary>
        /// Is . Visible or not
        /// </summary>
        public Visibility DotVisibility
        {
            get
            {
                return _dotVisibility;
            }
            set
            {
                _dotVisibility = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("DotVisibility");
            }
        }

        private Visibility _colonVisibility;
        /// <summary>
        /// Is : Visible or not
        /// </summary>
        public Visibility ColonVisibility
        {
            get
            {
                return _colonVisibility;
            }
            set
            {
                _colonVisibility = value;
                OnPropertyChanged("ColonVisibility");
            }
        }

        /// <summary>
        /// Delay of animation
        /// </summary>
        public KeyTime KeyTime { get; set; }
        public KeyTime ColonKeyTime { get; set; }

        private bool _colonAnimation;
        /// <summary>
        /// Peresents colon characters `:` with animation
        /// </summary>
        public bool ColonAnimation
        {
            get
            {
                return _colonAnimation;
            }
            set
            {
                _colonAnimation = value;
                OnPropertyChanged("ColonAnimation");
            }
        }

        private int _blurRadius;
        /// <summary>
        /// Radius of Blur on SevenSegment 
        /// </summary>
        public int BlurRadius
        {
            get
            {
                return _blurRadius;
            }
            set
            {
                _blurRadius = value;
                OnPropertyChanged("BlurRadius");
            }
        }

        private bool _playAnimation;
        /// <summary>
        /// Peresents SevenSegment with animation
        /// </summary>
        public bool PlayAnimation
        {
            get
            {
                return _playAnimation;
            }
            set
            {
                _playAnimation = value;
                OnPropertyChanged("PlayAnimation");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name)
        {

            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion


        #region Methods

        public UserControl1()
        {
            InitializeComponent();

            this.Background = Brushes.Transparent;
            //////////////////////////

            
            foreach (Path path in FindVisualChildren<Path>(this))
            {
                path.Fill = Brushes.White;
            }


            NumberColor = Brushes.White;
            //NumberColor = new SolidColorBrush(Color.FromRgb(251, 23, 23));
            ColonColor = new SolidColorBrush(Color.FromRgb(251, 23, 23));
            BlurRadius = 15;
            DotVisibility = Visibility.Hidden;
            ColonVisibility = Visibility.Hidden;
            PlayAnimation = true;
            ColonAnimation = true;
            KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 0, 0, 0));


            middleTop.Opacity = 0.01;
            middleBottom.Opacity = 0.01;
            middleTopBlur.Opacity = 0.01;
            middleBottomBlur.Opacity = 0.01;
            //ColonKeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 0, 0, 500));

            //////////////////////////
            _storyboard1 = (Storyboard)FindResource("Storyboard1");
            _storyboard2 = (Storyboard)FindResource("Storyboard2");
            _storyboard3 = (Storyboard)FindResource("Storyboard3");
            _storyboard4 = (Storyboard)FindResource("Storyboard4");
            _storyboard5 = (Storyboard)FindResource("Storyboard5");
            _storyboard6 = (Storyboard)FindResource("Storyboard6");
            _storyboard7 = (Storyboard)FindResource("Storyboard7");
            _storyboard8 = (Storyboard)FindResource("Storyboard8");
            _storyboard9 = (Storyboard)FindResource("Storyboard9");
            _storyboard0 = (Storyboard)FindResource("Storyboard0");
            _storyboard10 = (Storyboard)FindResource("Storyboard10");
            _storyboard11 = (Storyboard)FindResource("Storyboard11");
            _storyboard12 = (Storyboard)FindResource("Storyboard12");
            _storyboard13 = (Storyboard)FindResource("Storyboard13");
            _storyboard14 = (Storyboard)FindResource("Storyboard14");
            _storyboard15= (Storyboard)FindResource("Storyboard15");
            _storyboard16 = (Storyboard)FindResource("Storyboard16");
            // _storyboardColon = (Storyboard)FindResource("StoryboardColon");

            //////////////////////////
            //_storyboardColon.Completed += StoryboardColonCompleted;
        }

        void StoryboardColonCompleted(object sender, EventArgs e)
        {
            _colonComplete = true;
        }

        public static T FindVisualChildByName<T>(DependencyObject parent, string name) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                string controlName = child.GetValue(Control.NameProperty) as string;

                if (controlName == name)
                {
                    return child as T;
                }
                else
                {
                    T result = FindVisualChildByName<T>(child, name);
                    if (result != null)
                        return result;
                }
            }
            return null;
        }
  
        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                foreach (object child in LogicalTreeHelper.GetChildren(depObj))
                {

                    //if (o is T) { } 
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child as DependencyObject))
                    {
                        yield return childOfChild;
                    }


                }

              
            }
        }

        /// <summary>
        /// Sets number of seven segment number
        /// </summary>
        public void SetNumber(int number)
        {
            #region Set KeyTimes

            //foreach (var keyFrames in _storyboardColon.Children.Select(child => ((DoubleAnimationUsingKeyFrames)child).KeyFrames[0]))
            //    keyFrames.KeyTime = ColonKeyTime;
            foreach (var keyFrames in _storyboard0.Children.Select(child => ((DoubleAnimationUsingKeyFrames)child).KeyFrames[0]))
                keyFrames.KeyTime = KeyTime;
            foreach (var keyFrames in _storyboard1.Children.Select(child => ((DoubleAnimationUsingKeyFrames)child).KeyFrames[0]))
                keyFrames.KeyTime = KeyTime;
            foreach (var keyFrames in _storyboard2.Children.Select(child => ((DoubleAnimationUsingKeyFrames)child).KeyFrames[0]))
                keyFrames.KeyTime = KeyTime;
            foreach (var keyFrames in _storyboard3.Children.Select(child => ((DoubleAnimationUsingKeyFrames)child).KeyFrames[0]))
                keyFrames.KeyTime = KeyTime;
            foreach (var keyFrames in _storyboard4.Children.Select(child => ((DoubleAnimationUsingKeyFrames)child).KeyFrames[0]))
                keyFrames.KeyTime = KeyTime;
            foreach (var keyFrames in _storyboard5.Children.Select(child => ((DoubleAnimationUsingKeyFrames)child).KeyFrames[0]))
                keyFrames.KeyTime = KeyTime;
            foreach (var keyFrames in _storyboard6.Children.Select(child => ((DoubleAnimationUsingKeyFrames)child).KeyFrames[0]))
                keyFrames.KeyTime = KeyTime;
            foreach (var keyFrames in _storyboard7.Children.Select(child => ((DoubleAnimationUsingKeyFrames)child).KeyFrames[0]))
                keyFrames.KeyTime = KeyTime;
            foreach (var keyFrames in _storyboard8.Children.Select(child => ((DoubleAnimationUsingKeyFrames)child).KeyFrames[0]))
                keyFrames.KeyTime = KeyTime;
            foreach (var keyFrames in _storyboard9.Children.Select(child => ((DoubleAnimationUsingKeyFrames)child).KeyFrames[0]))
                keyFrames.KeyTime = KeyTime;
            foreach (var keyFrames in _storyboard10.Children.Select(child => ((DoubleAnimationUsingKeyFrames)child).KeyFrames[0]))
                keyFrames.KeyTime = KeyTime;
            foreach (var keyFrames in _storyboard11.Children.Select(child => ((DoubleAnimationUsingKeyFrames)child).KeyFrames[0]))
                keyFrames.KeyTime = KeyTime;
            foreach (var keyFrames in _storyboard12.Children.Select(child => ((DoubleAnimationUsingKeyFrames)child).KeyFrames[0]))
                keyFrames.KeyTime = KeyTime;
            foreach (var keyFrames in _storyboard13.Children.Select(child => ((DoubleAnimationUsingKeyFrames)child).KeyFrames[0]))
                keyFrames.KeyTime = KeyTime;
            foreach (var keyFrames in _storyboard14.Children.Select(child => ((DoubleAnimationUsingKeyFrames)child).KeyFrames[0]))
                keyFrames.KeyTime = KeyTime;
            foreach (var keyFrames in _storyboard15.Children.Select(child => ((DoubleAnimationUsingKeyFrames)child).KeyFrames[0]))
                keyFrames.KeyTime = KeyTime;
            foreach (var keyFrames in _storyboard16.Children.Select(child => ((DoubleAnimationUsingKeyFrames)child).KeyFrames[0]))
                keyFrames.KeyTime = KeyTime;


            #endregion

            //if (number > 9)
            //{
            //    string numberStr = number.ToString(CultureInfo.InvariantCulture);
            //    number = int.Parse(numberStr[0].ToString(CultureInfo.InvariantCulture));
            //}

            if (ColonAnimation && _colonComplete)
            {
                _colonComplete = false;
                //_storyboardColon.Begin();
            }

            #region Switch

            switch (number)
            {
                case 0:
                    if (!PlayAnimation)
                        Show0();
                    else
                        _storyboard0.Begin();
                    break;

                case 1:
                    if (!PlayAnimation)
                        Show1();
                    else
                        _storyboard1.Begin();
                    break;

                case 2:
                    if (!PlayAnimation)
                        Show2();
                    else
                        _storyboard2.Begin();
                    break;

                case 3:
                    if (!PlayAnimation)
                        Show3();
                    else
                        _storyboard3.Begin();
                    break;

                case 4:
                    if (!PlayAnimation)
                        Show4();
                    else
                        _storyboard4.Begin();
                    break;

                case 5:
                    if (!PlayAnimation)
                        Show5();
                    else
                        _storyboard5.Begin();
                    break;

                case 6:
                    if (!PlayAnimation)
                        Show6();
                    else
                        _storyboard6.Begin();
                    break;

                case 7:
                    if (!PlayAnimation)
                        Show7();
                    else
                        _storyboard7.Begin();
                    break;

                case 8:
                    if (!PlayAnimation)
                        Show8();
                    else
                        _storyboard8.Begin();
                    break;

                case 9:
                    if (!PlayAnimation)
                        Show9();
                    else
                        _storyboard9.Begin();
                    break;

                case 10:
                    if (!PlayAnimation)
                        Show10();
                    else
                        _storyboard10.Begin();
                    break;

                case 11:
                    if (!PlayAnimation)
                        Show11();
                    else
                        _storyboard11.Begin();
                    break;

                case 12:
                    if (!PlayAnimation)
                        Show12();
                    else
                        _storyboard12.Begin();
                    break;

                case 13:
                    if (!PlayAnimation)
                        Show13();
                    else
                        _storyboard13.Begin();
                    break;
                case 14:
                    if (!PlayAnimation)
                        Show14();
                    else
                        _storyboard14.Begin();
                    break;
                case 15:
                    if (!PlayAnimation)
                        Show15();
                    else
                        _storyboard15.Begin();
                    break;
                case 16:
                    if (!PlayAnimation)
                        Show16();
                    else
                        _storyboard16.Begin();
                    break;
            }

            #endregion
        }

        #region Show Numbers

        private void Show0()
        {
            top.Opacity = 1;
            topBlur.Opacity = 1;

            topLeft.Opacity = 1;
            topLeftBlur.Opacity = 1;

            topRight.Opacity = 1;
            topRightBlur.Opacity = 1;

            middle.Opacity = MinimumOpacity;
            middleBlur.Opacity = MinimumOpacity;

            bottomLeft.Opacity = 1;
            bottomLeftBlur.Opacity = 1;

            bottomRight.Opacity = 1;
            bottomRightBlur.Opacity = 1;

            bottom.Opacity = 1;
            bottomBlur.Opacity = 1;

            middleTop.Opacity = MinimumOpacity;
            middleTopBlur.Opacity = MinimumOpacity;

            middleBottom.Opacity = MinimumOpacity;
            middleBottomBlur.Opacity = MinimumOpacity;
        }

        private void Show1()
        {
            top.Opacity = MinimumOpacity;
            topBlur.Opacity = MinimumOpacity;

            topLeft.Opacity = MinimumOpacity;
            topLeftBlur.Opacity = MinimumOpacity;

            topRight.Opacity = 1;
            topRightBlur.Opacity = 1;

            middle.Opacity = MinimumOpacity;
            middleBlur.Opacity = MinimumOpacity;

            bottomLeft.Opacity = MinimumOpacity;
            bottomLeftBlur.Opacity = MinimumOpacity;

            bottomRight.Opacity = 1;
            bottomRightBlur.Opacity = 1;

            bottom.Opacity = MinimumOpacity;
            bottomBlur.Opacity = MinimumOpacity;

            middleTop.Opacity = MinimumOpacity;
            middleTopBlur.Opacity = MinimumOpacity;

            middleBottom.Opacity = MinimumOpacity;
            middleBottomBlur.Opacity = MinimumOpacity;
        }

        private void Show2()
        {
            top.Opacity = 1;
            topBlur.Opacity = 1;

            topLeft.Opacity = MinimumOpacity;
            topLeftBlur.Opacity = MinimumOpacity;

            topRight.Opacity = 1;
            topRightBlur.Opacity = 1;

            middle.Opacity = 1;
            middleBlur.Opacity = 1;

            bottomLeft.Opacity = 1;
            bottomLeftBlur.Opacity = 1;

            bottomRight.Opacity = MinimumOpacity;
            bottomRightBlur.Opacity = MinimumOpacity;

            bottom.Opacity = 1;
            bottomBlur.Opacity = 1;

            middleTop.Opacity = MinimumOpacity;
            middleTopBlur.Opacity = MinimumOpacity;

            middleBottom.Opacity = MinimumOpacity;
            middleBottomBlur.Opacity = MinimumOpacity;
        }

        private void Show3()
        {
            top.Opacity = 1;
            topBlur.Opacity = 1;

            topLeft.Opacity = MinimumOpacity;
            topLeftBlur.Opacity = MinimumOpacity;

            topRight.Opacity = 1;
            topRightBlur.Opacity = 1;

            middle.Opacity = 1;
            middleBlur.Opacity = 1;

            bottomLeft.Opacity = MinimumOpacity;
            bottomLeftBlur.Opacity = MinimumOpacity;

            bottomRight.Opacity = 1;
            bottomRightBlur.Opacity = 1;

            bottom.Opacity = 1;
            bottomBlur.Opacity = 1;

            middleTop.Opacity = MinimumOpacity;
            middleTopBlur.Opacity = MinimumOpacity;

            middleBottom.Opacity = MinimumOpacity;
            middleBottomBlur.Opacity = MinimumOpacity;
        }

        private void Show4()
        {
            top.Opacity = MinimumOpacity;
            topBlur.Opacity = MinimumOpacity;

            topLeft.Opacity = 1;
            topLeftBlur.Opacity = 1;

            topRight.Opacity = 1;
            topRightBlur.Opacity = 1;

            middle.Opacity = 1;
            middleBlur.Opacity = 1;

            bottomLeft.Opacity = MinimumOpacity;
            bottomLeftBlur.Opacity = MinimumOpacity;

            bottomRight.Opacity = 1;
            bottomRightBlur.Opacity = 1;

            bottom.Opacity = MinimumOpacity;
            bottomBlur.Opacity = MinimumOpacity;

            middleTop.Opacity = MinimumOpacity;
            middleTopBlur.Opacity = MinimumOpacity;

            middleBottom.Opacity = MinimumOpacity;
            middleBottomBlur.Opacity = MinimumOpacity;
        }

        private void Show5()
        {
            top.Opacity = 1;
            topBlur.Opacity = 1;

            topLeft.Opacity = 1;
            topLeftBlur.Opacity = 1;

            topRight.Opacity = MinimumOpacity;
            topRightBlur.Opacity = MinimumOpacity;

            middle.Opacity = 1;
            middleBlur.Opacity = 1;

            bottomLeft.Opacity = MinimumOpacity;
            bottomLeftBlur.Opacity = MinimumOpacity;

            bottomRight.Opacity = 1;
            bottomRightBlur.Opacity = 1;

            bottom.Opacity = 1;
            bottomBlur.Opacity = 1;

            middleTop.Opacity = MinimumOpacity;
            middleTopBlur.Opacity = MinimumOpacity;

            middleBottom.Opacity = MinimumOpacity;
            middleBottomBlur.Opacity = MinimumOpacity;
        }

        private void Show6()
        {
            top.Opacity = 1;
            topBlur.Opacity = 1;

            topLeft.Opacity = 1;
            topLeftBlur.Opacity = 1;

            topRight.Opacity = MinimumOpacity;
            topRightBlur.Opacity = MinimumOpacity;

            middle.Opacity = 1;
            middleBlur.Opacity = 1;

            bottomLeft.Opacity = 1;
            bottomLeftBlur.Opacity = 1;

            bottomRight.Opacity = 1;
            bottomRightBlur.Opacity = 1;

            bottom.Opacity = 1;
            bottomBlur.Opacity = 1;

            middleTop.Opacity = MinimumOpacity;
            middleTopBlur.Opacity = MinimumOpacity;

            middleBottom.Opacity = MinimumOpacity;
            middleBottomBlur.Opacity = MinimumOpacity;
        }

        private void Show7()
        {
            top.Opacity = 1;
            topBlur.Opacity = 1;

            topLeft.Opacity = MinimumOpacity;
            topLeftBlur.Opacity = MinimumOpacity;

            topRight.Opacity = 1;
            topRightBlur.Opacity = 1;

            middle.Opacity = MinimumOpacity;
            middleBlur.Opacity = MinimumOpacity;

            bottomLeft.Opacity = MinimumOpacity;
            bottomLeftBlur.Opacity = MinimumOpacity;

            bottomRight.Opacity = 1;
            bottomRightBlur.Opacity = 1;

            bottom.Opacity = MinimumOpacity;
            bottomBlur.Opacity = MinimumOpacity;

            middleTop.Opacity = MinimumOpacity;
            middleTopBlur.Opacity = MinimumOpacity;

            middleBottom.Opacity = MinimumOpacity;
            middleBottomBlur.Opacity = MinimumOpacity;
        }

        private void Show8()
        {
            top.Opacity = 1;
            topBlur.Opacity = 1;

            topLeft.Opacity = 1;
            topLeftBlur.Opacity = 1;

            topRight.Opacity = 1;
            topRightBlur.Opacity = 1;

            middle.Opacity = 1;
            middleBlur.Opacity = 1;

            bottomLeft.Opacity = 1;
            bottomLeftBlur.Opacity = 1;

            bottomRight.Opacity = 1;
            bottomRightBlur.Opacity = 1;

            bottom.Opacity = 1;
            bottomBlur.Opacity = 1;

            middleTop.Opacity = MinimumOpacity;
            middleTopBlur.Opacity = MinimumOpacity;

            middleBottom.Opacity = MinimumOpacity;
            middleBottomBlur.Opacity = MinimumOpacity;
        }

        private void Show9()
        {
            top.Opacity = 1;
            topBlur.Opacity = 1;

            topLeft.Opacity = 1;
            topLeftBlur.Opacity = 1;

            topRight.Opacity = 1;
            topRightBlur.Opacity = 1;

            middle.Opacity = 1;
            middleBlur.Opacity = 1;

            bottomLeft.Opacity = MinimumOpacity;
            bottomLeftBlur.Opacity = MinimumOpacity;

            bottomRight.Opacity = 1;
            bottomRightBlur.Opacity = 1;

            bottom.Opacity = 1;
            bottomBlur.Opacity = 1;

            middleTop.Opacity = MinimumOpacity;
            middleTopBlur.Opacity = MinimumOpacity;

            middleBottom.Opacity = MinimumOpacity;
            middleBottomBlur.Opacity = MinimumOpacity;
        }
        //show C alphabet
        private void Show10()
        {
            top.Opacity = 1;
            topBlur.Opacity = 1;

            topLeft.Opacity = 1;
            topLeftBlur.Opacity = 1;

            topRight.Opacity = MinimumOpacity;
            topRightBlur.Opacity = MinimumOpacity;

            middle.Opacity = MinimumOpacity;
            middleBlur.Opacity = MinimumOpacity;

            bottomLeft.Opacity = 1;
            bottomLeftBlur.Opacity = 1;

            bottomRight.Opacity = MinimumOpacity;
            bottomRightBlur.Opacity = MinimumOpacity;

            bottom.Opacity = 1;
            bottomBlur.Opacity = 1;

            middleTop.Opacity = MinimumOpacity;
            middleTopBlur.Opacity = MinimumOpacity;

            middleBottom.Opacity = MinimumOpacity;
            middleBottomBlur.Opacity = MinimumOpacity;
        }
        //show L alphabet
        private void Show11()
        {
            top.Opacity = MinimumOpacity;
            topBlur.Opacity = MinimumOpacity;

            topLeft.Opacity = 1;
            topLeftBlur.Opacity = 1;

            topRight.Opacity = MinimumOpacity;
            topRightBlur.Opacity = MinimumOpacity;

            middle.Opacity = MinimumOpacity;
            middleBlur.Opacity = MinimumOpacity;

            bottomLeft.Opacity = 1;
            bottomLeftBlur.Opacity = 1;

            bottomRight.Opacity = MinimumOpacity;
            bottomRightBlur.Opacity = MinimumOpacity;

            bottom.Opacity = 1;
            bottomBlur.Opacity = 1;

            middleTop.Opacity = MinimumOpacity;
            middleTopBlur.Opacity = MinimumOpacity;

            middleBottom.Opacity = MinimumOpacity;
            middleBottomBlur.Opacity = MinimumOpacity;
        }

        //show K alphabet
        private void Show12()
        {
            top.Opacity = MinimumOpacity;
            topBlur.Opacity = MinimumOpacity;

            topLeft.Opacity = 1;
            topLeftBlur.Opacity = 1;

            topRight.Opacity = MinimumOpacity;
            topRightBlur.Opacity = MinimumOpacity;

            middle.Opacity = MinimumOpacity;
            middleBlur.Opacity = MinimumOpacity;

            bottomLeft.Opacity = 1;
            bottomLeftBlur.Opacity = 1;

            bottomRight.Opacity = MinimumOpacity;
            bottomRightBlur.Opacity = MinimumOpacity;

            bottom.Opacity = MinimumOpacity;
            bottomBlur.Opacity = MinimumOpacity;

            middleTop.Opacity = 1;
            middleTopBlur.Opacity = 1;

            middleBottom.Opacity = 1;
            middleBottomBlur.Opacity = 1;
              
        }

        //show N alphabet
        private void Show13()
        {
            top.Opacity = MinimumOpacity;
            topBlur.Opacity = MinimumOpacity;

            topLeft.Opacity = 1;
            topLeftBlur.Opacity = 1;

            topRight.Opacity = 1;
            topRightBlur.Opacity = 1;

            middle.Opacity = MinimumOpacity;
            middleBlur.Opacity = MinimumOpacity;

            bottomLeft.Opacity = 1;
            bottomLeftBlur.Opacity = 1;

            bottomRight.Opacity = 1;
            bottomRightBlur.Opacity = 1;

            bottom.Opacity = MinimumOpacity;
            bottomBlur.Opacity = MinimumOpacity;

            middleTop.Opacity = MinimumOpacity;
            middleTopBlur.Opacity = MinimumOpacity;

            middleBottom.Opacity = 1;
            middleBottomBlur.Opacity = 1;

        }

        //show top 
        private void Show14()
        {
            top.Opacity = 1;
            topBlur.Opacity = 1;

            topLeft.Opacity = 1;
            topLeftBlur.Opacity = 1;

            topRight.Opacity = 1;
            topRightBlur.Opacity = 1;

            middle.Opacity = 1;
            middleBlur.Opacity = 1;

            bottomLeft.Opacity = MinimumOpacity;
            bottomLeftBlur.Opacity = MinimumOpacity;

            bottomRight.Opacity = MinimumOpacity;
            bottomRightBlur.Opacity = MinimumOpacity;

            bottom.Opacity = MinimumOpacity;
            bottomBlur.Opacity = MinimumOpacity;

            middleTop.Opacity = MinimumOpacity;
            middleTopBlur.Opacity = MinimumOpacity;

            middleBottom.Opacity = MinimumOpacity;
            middleBottomBlur.Opacity = MinimumOpacity;

        }
        //show bottom 
        private void Show15()
        {
            top.Opacity = MinimumOpacity;
            topBlur.Opacity = MinimumOpacity;

            topLeft.Opacity = MinimumOpacity;
            topLeftBlur.Opacity = MinimumOpacity;

            topRight.Opacity = MinimumOpacity;
            topRightBlur.Opacity = MinimumOpacity;

            middle.Opacity = 1;
            middleBlur.Opacity = 1;

            bottomLeft.Opacity = 1;
            bottomLeftBlur.Opacity = 1;

            bottomRight.Opacity = 1;
            bottomRightBlur.Opacity = 1;

            bottom.Opacity = 1;
            bottomBlur.Opacity = 1;

            middleTop.Opacity = MinimumOpacity;
            middleTopBlur.Opacity = MinimumOpacity;

            middleBottom.Opacity = MinimumOpacity;
            middleBottomBlur.Opacity = MinimumOpacity;

        }

        //show bottom 
        private void Show16()
        {
            top.Opacity = MinimumOpacity;
            topBlur.Opacity = MinimumOpacity;

            topLeft.Opacity = MinimumOpacity;
            topLeftBlur.Opacity = MinimumOpacity;

            topRight.Opacity = MinimumOpacity;
            topRightBlur.Opacity = MinimumOpacity;

            middle.Opacity = 1;
            middleBlur.Opacity = 1;

            bottomLeft.Opacity = MinimumOpacity;
            bottomLeftBlur.Opacity = MinimumOpacity;

            bottomRight.Opacity = MinimumOpacity;
            bottomRightBlur.Opacity = MinimumOpacity;

            bottom.Opacity = MinimumOpacity;
            bottomBlur.Opacity = MinimumOpacity;

            middleTop.Opacity = MinimumOpacity;
            middleTopBlur.Opacity = MinimumOpacity;

            middleBottom.Opacity = MinimumOpacity;
            middleBottomBlur.Opacity = MinimumOpacity;

        }

        #endregion

        #endregion



    }
}
