


## POS Screen Security Authentication Module (research) | Jan 2019

• Developed a POS screen security authentication model (research)
• Used the POS system module using WPF technology and logic touch pad algorithm that simulate same a digital analog light logic.

`Password : 1234`
 




![](https://stephenhaunts.files.wordpress.com/2013/11/wpf-logo1.jpg)

![](https://img.shields.io/github/stars/pandao/editor.md.svg) ![](https://img.shields.io/github/forks/pandao/editor.md.svg) ![](https://img.shields.io/github/tag/pandao/editor.md.svg) ![](https://img.shields.io/github/release/pandao/editor.md.svg) ![](https://img.shields.io/github/issues/pandao/editor.md.svg) ![](https://img.shields.io/bower/v/editor.md.svg)




                    
> "Blockquotes Blockquotes", [Link](http://localhost/)。

## Links


`<link>` : <https://github.com>

[Reference link][id/name] 



###Code Blocks (multi-language) & highlighting

####Update

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



### FlowChart
 
```flow
st=>start: Login
op=>operation: Login operation
cond=>condition: Successful Yes or No?
e=>end: To admin

st->op->cond
cond(yes)->e
cond(no)->op
```


![image](https://user-images.githubusercontent.com/75975280/153934362-0ee4b1ef-5435-4bd5-abb6-4898bfc3a324.png)
![numricpad](https://user-images.githubusercontent.com/75975280/221501847-4f072ab5-babd-4464-b027-776d581ff13e.png)

###End
