


## POS Screen Security Authentication Module (research) | Jan 2019

• Developed a POS screen security authentication model (research)

• Used the POS system module using WPF technology and logic touch pad algorithm that simulate same a digital analog light logic.


 > Password is `1234`


![wpf](https://user-images.githubusercontent.com/75975280/221505122-45a9cc5f-14f4-4602-bbc9-120702bea5fa.png)


 

## Links
 
### Code Blocks (multi-language) & highlighting

#### Update

`Coming soon more animation features`



#### C#　Code Block

```C#
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
```


![numricpad](https://user-images.githubusercontent.com/75975280/221501847-4f072ab5-babd-4464-b027-776d581ff13e.png)


