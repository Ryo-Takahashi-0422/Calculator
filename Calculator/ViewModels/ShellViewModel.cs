﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.ViewModels
{
    public class ShellViewModel : Caliburn.Micro.Screen
    {
		private decimal _num = 0;
        private bool IsDotButtonPushed = false;
        private bool dotButtonActive = true;
        private bool plusFlag = false, minusFlag = false, multiFlag = false, divideFlag = false, isSecondInput = false, isAfterPushMathSymbol = false;
   
        private decimal firstInputNum, secondInputNum;
        private decimal maxNum = 100000000000000000000M;
        private decimal mem = 0;

		public decimal Num
		{
			get 
			{
				return _num; 
			}
			set 
			{
                _num = value;
				NotifyOfPropertyChange(() => Num);
			}
		}

        /// <summary>
        /// [0]ボタンが入力された時の処理
        /// </summary>
        public void PushButtonZero()
        {
            // 現在のテキストボックス値が0且つdotボタン非押下状態なら何もしないで早期リターン
            if(CheckCurrentNumIsZero() && !IsDotButtonPushed && dotButtonActive)
            {
                return;
            }

            string tempNum = Num.ToString();

            if (!isSecondInput)
            {
                if (CheckInputNumLenght(tempNum.Length))
                {
                    if (IsDotButtonPushed)
                    {
                        firstInputNum = decimal.Parse(tempNum + ".0");
                        Num = firstInputNum;
                        IsDotButtonPushed = false;
                    }
                    else
                    {
                        firstInputNum = decimal.Parse(tempNum + "0");
                        Num = firstInputNum;
                    }
                }
            }
            else
            {
                if (CheckInputNumLenght(tempNum.Length))
                {
                    if (IsDotButtonPushed)
                    {
                        secondInputNum = decimal.Parse(tempNum + ".0");
                        Num = secondInputNum;
                        IsDotButtonPushed = false;
                    }
                    else
                    {
                        // 数学記号を押した直後は入力をそのまま表示する
                        if (isAfterPushMathSymbol)
                        {
                            secondInputNum = decimal.Parse("0");
                            Num = secondInputNum;
                            isAfterPushMathSymbol = false;
                        }
                        // 数学記号を押した直後でなければ入力を現在の表記に付け加える
                        else
                        {
                            secondInputNum = decimal.Parse(tempNum + "0");
                            Num = secondInputNum;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// [00]ボタンが入力された時の処理
        /// </summary>
        public void PushButtonDoubleZero()
        {
            // 現在のテキストボックス値が0且つdotボタン非押下状態なら何もしないで早期リターン
            if (CheckCurrentNumIsZero() && !IsDotButtonPushed && dotButtonActive)
            {
                return;
            }

            string tempNum = Num.ToString();

            if (!isSecondInput)
            {
                if (IsDotButtonPushed)
                {
                    // 現在のテキストボックス値桁数が19桁なら0を追加する。
                    if (CheckCurrentNumOfDigitIs_19(tempNum.Length))
                    {
                        firstInputNum = decimal.Parse(tempNum + ".0");
                        Num = firstInputNum;
                        IsDotButtonPushed = false;
                    }
                    // 現在のテキストボックス値桁数に1を足した結果が20桁未満なら00を追加する。
                    else if (CheckInputNumLenght(tempNum.Length + 1))
                    {
                        firstInputNum = decimal.Parse(tempNum + ".00");
                        Num = firstInputNum;
                        IsDotButtonPushed = false;
                    }
                }
                else
                {
                    // 現在のテキストボックス値桁数が19桁なら0を追加する。
                    if (CheckCurrentNumOfDigitIs_19(tempNum.Length))
                    {
                        firstInputNum = decimal.Parse(tempNum + "0");
                        Num = firstInputNum;
                    }
                    // 現在のテキストボックス値桁数に1を足した結果が20桁未満なら00を追加する。
                    else if (CheckInputNumLenght(tempNum.Length + 1))
                    {
                        firstInputNum = decimal.Parse(tempNum + "00");
                        Num = firstInputNum;
                    }
                }
            }
            else
            {
                if (IsDotButtonPushed)
                {
                    // 現在のテキストボックス値桁数が19桁なら0を追加する。
                    if (CheckCurrentNumOfDigitIs_19(tempNum.Length))
                    {
                        secondInputNum = decimal.Parse(tempNum + ".0");
                        Num = secondInputNum;
                        IsDotButtonPushed = false;
                    }
                    // 現在のテキストボックス値桁数に1を足した結果が20桁未満なら00を追加する。
                    else if (CheckInputNumLenght(tempNum.Length + 1))
                    {
                        secondInputNum = decimal.Parse(tempNum + ".00");
                        Num = secondInputNum;
                        IsDotButtonPushed = false;
                    }
                }
                else
                {
                    // 現在のテキストボックス値桁数が19桁なら0を追加する。
                    if (CheckCurrentNumOfDigitIs_19(tempNum.Length))
                    {
                        secondInputNum = decimal.Parse(tempNum + "0");
                        Num = secondInputNum;
                    }
                    // 現在のテキストボックス値桁数に1を足した結果が20桁未満なら00を追加する。
                    else if (CheckInputNumLenght(tempNum.Length + 1))
                    {
                        // 数学記号を押した直後は入力をそのまま表示する
                        if (isAfterPushMathSymbol)
                        {
                            secondInputNum = decimal.Parse("0");
                            Num = secondInputNum;
                            isAfterPushMathSymbol = false;
                        }
                        // 数学記号を押した直後でなければ入力を現在の表記に付け加える
                        else
                        {
                            secondInputNum = decimal.Parse(tempNum + "00");
                            Num = secondInputNum;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// [1]ボタンが入力された時の処理
        /// </summary>
        public void PushButtonOne()
		{
			string tempNum = Num.ToString();

            if (!isSecondInput)
            {
                if (CheckInputNumLenght(tempNum.Length))
                {
                    if (IsDotButtonPushed)
                    {
                        firstInputNum = decimal.Parse(tempNum + ".1");
                        Num = firstInputNum;
                        IsDotButtonPushed = false;
                    }
                    else
                    {
                        firstInputNum = decimal.Parse(tempNum + "1");
                        Num = firstInputNum;
                    }
                }
            }
            else
            {
                if (CheckInputNumLenght(tempNum.Length))
                {
                    if (IsDotButtonPushed)
                    {
                        secondInputNum = decimal.Parse(tempNum + ".1");
                        Num = secondInputNum;
                        IsDotButtonPushed = false;
                    }
                    else
                    {
                        // 数学記号を押した直後は入力をそのまま表示する
                        if (isAfterPushMathSymbol)
                        {
                            secondInputNum = decimal.Parse("1");
                            Num = secondInputNum;
                            isAfterPushMathSymbol = false;
                        }
                        // 数学記号を押した直後でなければ入力を現在の表記に付け加える
                        else
                        {
                            secondInputNum = decimal.Parse(tempNum + "1");
                            Num = secondInputNum;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// [2]ボタンが入力された時の処理
        /// </summary>
        public void PushButtonTwo()
        {
            string tempNum = Num.ToString();

            if (!isSecondInput)
            {
                if (CheckInputNumLenght(tempNum.Length))
                {
                    if (IsDotButtonPushed)
                    {
                        firstInputNum = decimal.Parse(tempNum + ".2");
                        Num = firstInputNum;
                        IsDotButtonPushed = false;
                    }
                    else
                    {
                        firstInputNum = decimal.Parse(tempNum + "2");
                        Num = firstInputNum;
                    }
                }
            }
            else
            {
                if (CheckInputNumLenght(tempNum.Length))
                {
                    if (IsDotButtonPushed)
                    {
                        secondInputNum = decimal.Parse(tempNum + ".2");
                        Num = secondInputNum;
                        IsDotButtonPushed = false;
                    }
                    else
                    {
                        // 数学記号を押した直後は入力をそのまま表示する
                        if (isAfterPushMathSymbol)
                        {
                            secondInputNum = decimal.Parse("2");
                            Num = secondInputNum;
                            isAfterPushMathSymbol = false;
                        }
                        // 数学記号を押した直後でなければ入力を現在の表記に付け加える
                        else
                        {
                            secondInputNum = decimal.Parse(tempNum + "2");
                            Num = secondInputNum;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// [3]ボタンが入力された時の処理
        /// </summary>
        public void PushButtonThree()
        {
            string tempNum = Num.ToString();

            if (!isSecondInput)
            {
                if (CheckInputNumLenght(tempNum.Length))
                {
                    if (IsDotButtonPushed)
                    {
                        firstInputNum = decimal.Parse(tempNum + ".3");
                        Num = firstInputNum;
                        IsDotButtonPushed = false;
                    }
                    else
                    {
                        firstInputNum = decimal.Parse(tempNum + "3");
                        Num = firstInputNum;
                    }
                }
            }
            else
            {
                if (CheckInputNumLenght(tempNum.Length))
                {
                    if (IsDotButtonPushed)
                    {
                        secondInputNum = decimal.Parse(tempNum + ".3");
                        Num = secondInputNum;
                        IsDotButtonPushed = false;
                    }
                    else
                    {
                        // 数学記号を押した直後は入力をそのまま表示する
                        if (isAfterPushMathSymbol)
                        {
                            secondInputNum = decimal.Parse("3");
                            Num = secondInputNum;
                            isAfterPushMathSymbol = false;
                        }
                        // 数学記号を押した直後でなければ入力を現在の表記に付け加える
                        else
                        {
                            secondInputNum = decimal.Parse(tempNum + "3");
                            Num = secondInputNum;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// [4]ボタンが入力された時の処理
        /// </summary>
        public void PushButtonFour()
        {
            string tempNum = Num.ToString();

            if (!isSecondInput)
            {
                if (CheckInputNumLenght(tempNum.Length))
                {
                    if (IsDotButtonPushed)
                    {
                        firstInputNum = decimal.Parse(tempNum + ".4");
                        Num = firstInputNum;
                        IsDotButtonPushed = false;
                    }
                    else
                    {
                        firstInputNum = decimal.Parse(tempNum + "4");
                        Num = firstInputNum;
                    }
                }
            }
            else
            {
                if (CheckInputNumLenght(tempNum.Length))
                {
                    if (IsDotButtonPushed)
                    {
                        secondInputNum = decimal.Parse(tempNum + ".4");
                        Num = secondInputNum;
                        IsDotButtonPushed = false;
                    }
                    else
                    {
                        // 数学記号を押した直後は入力をそのまま表示する
                        if (isAfterPushMathSymbol)
                        {
                            secondInputNum = decimal.Parse("4");
                            Num = secondInputNum;
                            isAfterPushMathSymbol = false;
                        }
                        // 数学記号を押した直後でなければ入力を現在の表記に付け加える
                        else
                        {
                            secondInputNum = decimal.Parse(tempNum + "4");
                            Num = secondInputNum;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// [5]ボタンが入力された時の処理
        /// </summary>
        public void PushButtonFive()
        {
            string tempNum = Num.ToString();

            if (!isSecondInput)
            {
                if (CheckInputNumLenght(tempNum.Length))
                {
                    if (IsDotButtonPushed)
                    {
                        firstInputNum = decimal.Parse(tempNum + ".5");
                        Num = firstInputNum;
                        IsDotButtonPushed = false;
                    }
                    else
                    {
                        firstInputNum = decimal.Parse(tempNum + "5");
                        Num = firstInputNum;
                    }
                }
            }
            else
            {
                if (CheckInputNumLenght(tempNum.Length))
                {
                    if (IsDotButtonPushed)
                    {
                        secondInputNum = decimal.Parse(tempNum + ".5");
                        Num = secondInputNum;
                        IsDotButtonPushed = false;
                    }
                    else
                    {
                        // 数学記号を押した直後は入力をそのまま表示する
                        if (isAfterPushMathSymbol)
                        {
                            secondInputNum = decimal.Parse("5");
                            Num = secondInputNum;
                            isAfterPushMathSymbol = false;
                        }
                        // 数学記号を押した直後でなければ入力を現在の表記に付け加える
                        else
                        {
                            secondInputNum = decimal.Parse(tempNum + "5");
                            Num = secondInputNum;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// [6]ボタンが入力された時の処理
        /// </summary>
        public void PushButtonSix()
        {
            string tempNum = Num.ToString();

            if (!isSecondInput)
            {
                if (CheckInputNumLenght(tempNum.Length))
                {
                    if (IsDotButtonPushed)
                    {
                        firstInputNum = decimal.Parse(tempNum + ".6");
                        Num = firstInputNum;
                        IsDotButtonPushed = false;
                    }
                    else
                    {
                        firstInputNum = decimal.Parse(tempNum + "6");
                        Num = firstInputNum;
                    }
                }
            }
            else
            {
                if (CheckInputNumLenght(tempNum.Length))
                {
                    if (IsDotButtonPushed)
                    {
                        secondInputNum = decimal.Parse(tempNum + ".6");
                        Num = secondInputNum;
                        IsDotButtonPushed = false;
                    }
                    else
                    {
                        // 数学記号を押した直後は入力をそのまま表示する
                        if (isAfterPushMathSymbol)
                        {
                            secondInputNum = decimal.Parse("6");
                            Num = secondInputNum;
                            isAfterPushMathSymbol = false;
                        }
                        // 数学記号を押した直後でなければ入力を現在の表記に付け加える
                        else
                        {
                            secondInputNum = decimal.Parse(tempNum + "6");
                            Num = secondInputNum;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// [7]ボタンが入力された時の処理
        /// </summary>
        public void PushButtonSeven()
        {
            string tempNum = Num.ToString();

            if (!isSecondInput)
            {
                if (CheckInputNumLenght(tempNum.Length))
                {
                    if (IsDotButtonPushed)
                    {
                        firstInputNum = decimal.Parse(tempNum + ".7");
                        Num = firstInputNum;
                        IsDotButtonPushed = false;
                    }
                    else
                    {
                        firstInputNum = decimal.Parse(tempNum + "7");
                        Num = firstInputNum;
                    }
                }
            }
            else
            {
                if (CheckInputNumLenght(tempNum.Length))
                {
                    if (IsDotButtonPushed)
                    {
                        secondInputNum = decimal.Parse(tempNum + ".7");
                        Num = secondInputNum;
                        IsDotButtonPushed = false;
                    }
                    else
                    {
                        // 数学記号を押した直後は入力をそのまま表示する
                        if(isAfterPushMathSymbol)
                        {
                            secondInputNum = decimal.Parse("7");
                            Num = secondInputNum;
                            isAfterPushMathSymbol = false;
                        }
                        // 数学記号を押した直後でなければ入力を現在の表記に付け加える
                        else
                        {
                            secondInputNum = decimal.Parse(tempNum + "7");
                            Num = secondInputNum;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// [8]ボタンが入力された時の処理
        /// </summary>
        public void PushButtonEight()
        {
            string tempNum = Num.ToString();

            if (!isSecondInput)
            {
                if (CheckInputNumLenght(tempNum.Length))
                {
                    if (IsDotButtonPushed)
                    {
                        firstInputNum = decimal.Parse(tempNum + ".8");
                        Num = firstInputNum;
                        IsDotButtonPushed = false;
                    }
                    else
                    {
                        firstInputNum = decimal.Parse(tempNum + "8");
                        Num = firstInputNum;
                    }
                }
            }
            else
            {
                if (CheckInputNumLenght(tempNum.Length))
                {
                    if (IsDotButtonPushed)
                    {
                        secondInputNum = decimal.Parse(tempNum + ".8");
                        Num = secondInputNum;
                        IsDotButtonPushed = false;
                    }
                    else
                    {
                        // 数学記号を押した直後は入力をそのまま表示する
                        if (isAfterPushMathSymbol)
                        {
                            secondInputNum = decimal.Parse("8");
                            Num = secondInputNum;
                            isAfterPushMathSymbol = false;
                        }
                        // 数学記号を押した直後でなければ入力を現在の表記に付け加える
                        else
                        {
                            secondInputNum = decimal.Parse(tempNum + "8");
                            Num = secondInputNum;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// [9]ボタンが入力された時の処理
        /// </summary>
        public void PushButtonNine()
        {
            string tempNum = Num.ToString();

            if (!isSecondInput)
            {
                if (CheckInputNumLenght(tempNum.Length))
                {
                    if (IsDotButtonPushed)
                    {
                        firstInputNum = decimal.Parse(tempNum + ".9");
                        Num = firstInputNum;
                        IsDotButtonPushed = false;
                    }
                    else
                    {
                        firstInputNum = decimal.Parse(tempNum + "9");
                        Num = firstInputNum;
                    }
                }
            }
            else
            {
                if (CheckInputNumLenght(tempNum.Length))
                {
                    if (IsDotButtonPushed)
                    {
                        secondInputNum = decimal.Parse(tempNum + ".9");
                        Num = secondInputNum;
                        IsDotButtonPushed = false;
                    }
                    else
                    {
                        // 数学記号を押した直後は入力をそのまま表示する
                        if (isAfterPushMathSymbol)
                        {
                            secondInputNum = decimal.Parse("9");
                            Num = secondInputNum;
                            isAfterPushMathSymbol = false;
                        }
                        // 数学記号を押した直後でなければ入力を現在の表記に付け加える
                        else
                        {
                            secondInputNum = decimal.Parse(tempNum + "9");
                            Num = secondInputNum;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// [AC]ボタンが入力された時の処理
        /// </summary>
        public void PushButtonAC()
        {
            Num = 0;
            mem = 0;
        }

        /// <summary>
        /// [C]ボタンが入力された時の処理
        /// </summary>
        public void PushButtonC()
        {
            string temp;
            int count;

            if (!isSecondInput)
            {
                temp = Num.ToString();
                count = temp.Length;
                temp = temp.Substring(0, count - 1);
                firstInputNum = decimal.Parse(temp);
                Num = firstInputNum;
            }
            else
            {
                temp = Num.ToString();
                count = temp.Length;
                temp = temp.Substring(0, count - 1);
                secondInputNum = decimal.Parse(temp);
                Num = secondInputNum;
            }
        }

        /// <summary>
        /// [M+]ボタンが入力された時の処理
        /// </summary>
        public void PushButtonMPlus()
        {
            string tempNum;

            if (isSecondInput)
            {
                if (plusFlag)
                {
                    mem += firstInputNum + secondInputNum;
                    tempNum = mem.ToString();
                    AdjustResult();

                    firstInputNum = 0;
                    secondInputNum = 0;
                    isAfterPushMathSymbol = true;
                    plusFlag = false;
                }
                else if (minusFlag)
                {
                    mem += firstInputNum - secondInputNum;
                    tempNum = mem.ToString();
                    AdjustResult();

                    firstInputNum = 0;
                    secondInputNum = 0;
                    isAfterPushMathSymbol = true;
                    minusFlag = false;
                }
                else if (multiFlag)
                {
                    mem += firstInputNum * secondInputNum;
                    tempNum = mem.ToString();
                    AdjustResult();

                    firstInputNum = 0;
                    secondInputNum = 0;
                    isAfterPushMathSymbol = true;
                    multiFlag = false;
                }
                else if (divideFlag)
                {
                    mem += firstInputNum / secondInputNum;
                    tempNum = mem.ToString();
                    AdjustResult();

                    firstInputNum = 0;
                    secondInputNum = 0;
                    isAfterPushMathSymbol = true;
                    divideFlag = false;
                }
            }

            void AdjustResult()
            {
                // 計算結果が最大値より大きい場合、最大値を表示する
                if (mem >= maxNum)
                {
                    mem = maxNum - 1;
                }

                int numLength = tempNum.Length;
                // 小数の場合の処理
                if (mem > 0 && mem - Math.Floor(mem) != 0M)
                {
                    if (numLength < 20)
                    {
                        tempNum = tempNum.Substring(0, numLength);
                    }
                    else 
                    {
                        tempNum = tempNum.Substring(0, 20);
                    }
                    
                    mem = decimal.Parse(tempNum);
                }
                else if (mem < 0 && mem - Math.Ceiling(mem) != 0M)
                {
                    if (numLength < 20)
                    {
                        tempNum = tempNum.Substring(0, numLength);
                    }
                    else
                    {
                        tempNum = tempNum.Substring(0, 20);
                    }
                    mem = decimal.Parse(tempNum);
                }
            }
        }

        /// <summary>
        /// [M-]ボタンが入力された時の処理
        /// </summary>
        public void PushButtonMMinus()
        {
            string tempNum;

            if (isSecondInput)
            {
                if (plusFlag)
                {
                    mem -= firstInputNum + secondInputNum;
                    tempNum = mem.ToString();
                    AdjustResult();

                    firstInputNum = 0;
                    secondInputNum = 0;
                    isAfterPushMathSymbol = true;
                    plusFlag = false;
                }
                else if (minusFlag)
                {
                    mem -= firstInputNum - secondInputNum;
                    tempNum = mem.ToString();
                    AdjustResult();

                    firstInputNum = 0;
                    secondInputNum = 0;
                    isAfterPushMathSymbol = true;
                    minusFlag = false;
                }
                else if (multiFlag)
                {
                    mem -= firstInputNum * secondInputNum;
                    tempNum = mem.ToString();
                    AdjustResult();

                    firstInputNum = 0;
                    secondInputNum = 0;
                    isAfterPushMathSymbol = true;
                    multiFlag = false;
                }
                else if (divideFlag)
                {
                    mem -= firstInputNum / secondInputNum;
                    tempNum = mem.ToString();
                    AdjustResult();

                    firstInputNum = 0;
                    secondInputNum = 0;
                    isAfterPushMathSymbol = true;
                    divideFlag = false;
                }
            }

            void AdjustResult()
            {
                // 計算結果が最大値より大きい場合、最大値を表示する
                if (mem >= maxNum)
                {
                    mem = maxNum - 1;
                }

                int numLength = tempNum.Length;
                // 小数の場合の処理
                if (mem > 0 && mem - Math.Floor(mem) != 0M)
                {
                    if (numLength < 20)
                    {
                        tempNum = tempNum.Substring(0, numLength);
                    }
                    else
                    {
                        tempNum = tempNum.Substring(0, 20);
                    }

                    mem = decimal.Parse(tempNum);
                }
                else if (mem < 0 && mem - Math.Ceiling(mem) != 0M)
                {
                    if (numLength < 20)
                    {
                        tempNum = tempNum.Substring(0, numLength);
                    }
                    else
                    {
                        tempNum = tempNum.Substring(0, 20);
                    }
                    mem = decimal.Parse(tempNum);
                }
            }
        }

        // TODO : memが桁あふれしている場合、桁数チェックにより入力出来ない問題(1/3 →M+ → 1+1など→M+→0.6666666666... 入力時の桁数チェックにより1の入力が受け付けられていないことが原因)

        /// <summary>
        /// [MRC]ボタンが入力された時の処理
        /// </summary>
        public void PushButtonMRC()
        {
            Num = mem;
            firstInputNum = 0;
            secondInputNum = 0;
        }

        /// <summary>
        /// [.]ボタンが入力された時の処理
        /// </summary>
        public void PushButtonDot()
        {
            if(dotButtonActive)
            {
                IsDotButtonPushed = true;
                dotButtonActive = false; // +とか計算ボタン押下時にアクティベートする
            }       
        }

        /// <summary>
        /// [+]ボタンが入力された時の処理
        /// </summary>
        public void PushButtonPlus()
        {
            firstInputNum = Num;

            plusFlag = true;
            minusFlag = false;
            multiFlag = false;
            divideFlag = false;
            isSecondInput = true;

            dotButtonActive = true;
            isAfterPushMathSymbol = true;
        }

        /// <summary>
        /// [-]ボタンが入力された時の処理
        /// </summary>
        public void PushButtonMinus()
        {
            firstInputNum = Num;

            plusFlag = false;
            minusFlag = true;
            multiFlag = false;
            divideFlag = false;
            isSecondInput = true;

            dotButtonActive = true;
            isAfterPushMathSymbol = true;
        }

        /// <summary>
        /// [x]ボタンが入力された時の処理
        /// </summary>
        public void PushButtonMulti()
        {
            firstInputNum = Num;

            plusFlag = false;
            minusFlag = false;
            multiFlag = true;
            divideFlag = false;
            isSecondInput = true;

            dotButtonActive = true;
            isAfterPushMathSymbol = true;
        }

        /// <summary>
        /// [÷]ボタンが入力された時の処理
        /// </summary>
        public void PushButtonDivide()
        {
            firstInputNum = Num;

            plusFlag = false;
            minusFlag = false;
            multiFlag = false;
            divideFlag = true;
            isSecondInput = true;

            dotButtonActive = true;
            isAfterPushMathSymbol = true;
        }

        /// <summary>
        /// [=]ボタンが入力された時の処理
        /// </summary>
        public void PushButtonEqual()
        {
            string tempNum;

            if (plusFlag)
            {
                firstInputNum += secondInputNum;
                tempNum = firstInputNum.ToString();
                ProcessResult();
            }
            else if (minusFlag) 
            {
                firstInputNum -= secondInputNum;
                tempNum = firstInputNum.ToString();
                ProcessResult();
            }
            else if (multiFlag)
            {
                firstInputNum *= secondInputNum;
                tempNum = firstInputNum.ToString();
                ProcessResult();
            }
            else if (divideFlag)
            {
                firstInputNum /= secondInputNum;
                tempNum = firstInputNum.ToString();
                ProcessResult();
            }

            isSecondInput = false;
            dotButtonActive = true;

            void ProcessResult()
            {
                // 計算結果の桁数が20以下なら表示する。
                if (CheckCurrentNumLenght(tempNum.Length))
                {
                    Num = firstInputNum;
                }
                // 計算結果が最大値より大きい場合、最大値を表示する
                else if (firstInputNum >= maxNum)
                {
                    Num = maxNum - 1;
                    firstInputNum = maxNum; // TODO : 1e + ...といった表記にする
                }
                else if (firstInputNum > 0 && firstInputNum - Math.Floor(firstInputNum) != 0M)
                {
                    tempNum = tempNum.Substring(0, 20);
                    firstInputNum = decimal.Parse(tempNum);
                    Num = firstInputNum;
                }
                else if (firstInputNum < 0 && firstInputNum - Math.Ceiling(firstInputNum) != 0M)
                {
                    tempNum = tempNum.Substring(0, 20);
                    firstInputNum = decimal.Parse(tempNum);
                    Num = firstInputNum;
                }
            }
        }

        /// <summary>
        /// 現在の入力値が20桁未満かチェックする。未満ならtrue、以上ならfalseを返す。
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        private bool CheckInputNumLenght(int length)
		{
			if (length < 20)
			{
				return true;
			}

			return false;
		}

        /// <summary>
        /// 現在の入力値が19桁かチェックする。19桁ならtrue、以上ならfalseを返す。
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        private bool CheckCurrentNumOfDigitIs_19(int length)
        {
            if (length == 19)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 計算結果が20桁以下かチェックする。未満ならtrue、以上ならfalseを返す。
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        private bool CheckCurrentNumLenght(int length)
        {
            if (length <= 20)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 現在のテキストボックス入力値が0かどうか判定する。0ならtrue、でなければfalseを返す。
        /// </summary>
        /// <returns></returns>
        private bool CheckCurrentNumIsZero()
        {
            if(Num == 0)
            {
                return true;
            }

            return false;
        }
	}
}
